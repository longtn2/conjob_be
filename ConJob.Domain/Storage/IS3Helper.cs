using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConJob.Domain.Storage
{
    public interface IS3Helper
    {
        string getPesignedURL(string file_path);
    }
}
