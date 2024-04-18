using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Entities.Config
{
    public class MailSettings
    {
        public string server { get; set; }   
        public int port { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string sender_name {  get; set; }
        public string sender_email {  get; set; }
    }
}
