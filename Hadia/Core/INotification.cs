using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Core
{
    public interface INotification
    {
        Task Notify(int userid,string title,string body,int groupId =0);
    }
}
