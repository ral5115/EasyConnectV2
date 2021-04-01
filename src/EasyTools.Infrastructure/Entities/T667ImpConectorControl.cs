using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyTools.Infrastructure.Entities
{
    public class T667ImpConectorControl
    {
        public string F667TsProceso { get; set; }

        public short F667IdCia { get; set; }

        public string F667Referencia { get; set; }

        public short F667IndProcesable { get; set; }

        public short F667IndError { get; set; }

        public short F667EstadoProceso { get; set; }

        public List<T668ImpConectorDetalle> T668ImpConectorDetalles { get; set; }
    }
}