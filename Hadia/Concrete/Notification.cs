using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Hadia.Core;
using Hadia.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Hadia.Concrete
{
    public class Notification :INotification
    {
        private HadiaContext _db;
        public Notification(HadiaContext db)
        {
            _db = db;
        }


        public async Task Notify(int userid, string title, string body)
        {
            var deviceTokens = await (from div in _db.Sett_DeviceInfoLogs.Where(x=>x.MemberId!= userid)
                                        group div by div.MemberId into dg
                                        let latest = dg.Max(r => r.CDate)
                                        select dg.FirstOrDefault(x=>x.CDate==latest).DeviceKey)
                                        .ToArrayAsync();
            var messageInformation = new Message
                                    {
                                        notification = new Notif
                                        {
                                            title = title,
                                            text = body
                                        },
                                        data = new object(),
                                        registration_ids = deviceTokens
                                    };
            string jsonMessage = JsonConvert.SerializeObject(messageInformation);
            var request = new HttpRequestMessage(HttpMethod.Post, "https://fcm.googleapis.com/fcm/send");
            request.Headers.TryAddWithoutValidation("Authorization", "key=AAAAqc6GLfc:APA91bE83RxDFfxC-RZ2ZwBSeqrY7kFPlb99HrmjKQBbs_8y2lNwb26mPMzsxE98Xn24iUXfQNW2GqEQizHSKxeOmX8NiWWGud0xB5KtwWPNJ7it7YqWL5s-0RNcryTzVPcOKx8iJl6t");
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
    }
}
