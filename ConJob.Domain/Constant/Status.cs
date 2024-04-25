using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.DTOs.Apllicant
{
    public static class Status
    {
        public const string INIT = "INIT";
        public const string ACCEPTED = "ACCEPTED";
        public const string PENDING = "PENDING";
        public const string SUCCESS = "SUCCESS";
        public const string CANCEL = "CANCEL";
        public const string REJECTED = "REJECT";
    }
}
