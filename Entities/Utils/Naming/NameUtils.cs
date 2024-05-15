using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConJob.Entities.Utils.Naming
{
    public static class NameUtils
    {
        public static string convertVietnamese(string data)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = data.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, "").Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
    }
}
