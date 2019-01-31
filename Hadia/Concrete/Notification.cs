 using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Hadia.Core;
using Hadia.Data;
 using Hadia.Models.DomainModels;
 using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Hadia.Concrete
{
    public class Notification :INotification
    {
        private readonly HadiaContext _db;
        public Notification(HadiaContext db)
        {
            _db = db;
        }
        public async Task Notify(int userid, string title, string body,int groupId=0)
        {
            var user = await _db.Mem_Masters
                                .Include(x=>x.MembershipInGroups)
                                    .ThenInclude(x=>x.GroupMaster)
                                .SingleOrDefaultAsync(x=>x.Id == userid);
            var memberships = user.MembershipInGroups.Where(x=>x.IsActive && x.GroupMaster.Type ==GroupType.Chapter).Select(x => x.GroupId).ToList();
            //    &&
            //x.Members.Any(m => m.GroupId == user.GroupId &&
            //                   m.MembershipInGroups.Any(g => memberships.Contains(g.GroupId)))
            //|| m.MembershipInGroups.Any(g => memberships.Contains(g.GroupId))))
            List<string> deviceTokens =new List<string>();
            if (groupId != 0)
            {
                var groupType = await _db.Post_GroupMasters.FindAsync(groupId);
                switch (groupType.Type)
                {
                    case GroupType.Batch:
                        deviceTokens = await (from div in _db.Sett_DeviceInfoLogs
                                    .AsNoTracking()
                                    .Where(x => x.MemberId != userid )
                                    .Where(x => x.Members.Any(m => m.GroupId == groupId))
                                group div by div.MemberId into dg
                                let latest = dg.Max(r => r.CDate)
                                select dg.FirstOrDefault(x => x.CDate == latest).DeviceKey)
                            .ToListAsync();
                        title += " @ Batch";
                        break;
                    case GroupType.Chapter:
                        deviceTokens = await (from div in _db.Sett_DeviceInfoLogs.AsNoTracking()
                                    .Where(x => x.MemberId != userid)
                                    .Where(x =>
                                        x.Members.Any(m => m.MembershipInGroups.Any(g => memberships.Contains(groupId))))
                                group div by div.MemberId
                                into dg
                                let latest = dg.Max(r => r.CDate)
                                select dg.FirstOrDefault(x => x.CDate == latest).DeviceKey)
                            .ToListAsync();
                        title += " @ Chapter";
                        break;
                }


            }
            else
            {
                deviceTokens = await (from div in _db.Sett_DeviceInfoLogs.AsNoTracking().Where(x => x.MemberId != userid)
                    group div by div.MemberId into dg
                    let latest = dg.Max(r => r.CDate)
                    select dg.FirstOrDefault(x => x.CDate == latest).DeviceKey).ToListAsync();
            }
            var deviceTokenArray = deviceTokens.ToArray();
            var messageInformation = new Message
                                    {
                                        notification = new Notif
                                        {
                                            title = title,
                                            text = body,
                                            tag = "hadia"
                                        },
                                        data = new object(),
                                        registration_ids = deviceTokenArray
                                    };
            string jsonMessage = JsonConvert.SerializeObject(messageInformation);
            var request = new HttpRequestMessage(HttpMethod.Post, "https://fcm.googleapis.com/fcm/send");
            request.Headers.TryAddWithoutValidation(
                "Authorization"
               ,"key=AAAAqc6GLfc:APA91bE83RxDFfxC-RZ2ZwBSeqrY7kFPlb99HrmjKQBbs_8y2lNwb26mPMzsxE98Xn24iUXfQNW2GqEQizHSKxeOmX8NiWWGud0xB5KtwWPNJ7it7YqWL5s-0RNcryTzVPcOKx8iJl6t");
            request.Content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
               await client.SendAsync(request);
            }
        }


    }
    public class Message
    {
        public string[] registration_ids { get; set; }
        public Notif notification { get; set; }
        public object data { get; set; }
    }
    public class Notif
    {
        public string title { get; set; }
        public string text { get; set; }
        public string tag { get; set; }
    }
}
