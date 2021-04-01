using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTools.Framework.Data
{
    public class MailConfiguration
    {
        public virtual String EmailServer { get; set; }

        public virtual String EmailUser { get; set; }

        public virtual String EmailPassword { get; set; }

        public virtual String EmailPort { get; set; }

        public virtual Boolean EmailEnableSSL { get; set; }
    }
}
