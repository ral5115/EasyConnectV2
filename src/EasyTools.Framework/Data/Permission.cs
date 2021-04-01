using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTools.Framework.Data
{
    public class Permission : FrameworkEntity
    {
        public string Description { get; set; }

        public string EsDescripcion { get; set; }

        public string EnDescription { get; set; }

        public bool Active { get; set; }

    }

}