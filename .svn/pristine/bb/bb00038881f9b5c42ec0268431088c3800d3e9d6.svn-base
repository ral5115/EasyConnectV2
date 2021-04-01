using EasyConnect.Infrastructure.Entities;
using FluentNHibernate.Mapping;

namespace EasyConnect.Infrastructure.Mappings.Base
{
   public class BaseWSCONCESIONEMap : ClassMap<WSCONCESIONE>
   {
      public BaseWSCONCESIONEMap()
      {
         Table("WS_CONCESIONES");
         Id(x => x.Id).Column("IdConcesion").GeneratedBy.Native(builder => builder.AddParam("sequence", "WS_CONCESIONESSEQ"));

         Map(x => x.RazonSocial).Column("RazonSocial").Not.Nullable().Length(100);

         Map(x => x.NomComercial).Column("NomComercial").Nullable().Length(50);

         Map(x => x.Cif).Column("Cif").Nullable().Length(20);

         Map(x => x.FechaAlta).Column("FechaAlta").Nullable();

         Map(x => x.FechaBaja).Column("FechaBaja").Nullable();

         Map(x => x.Tratamiento).Column("Tratamiento").Nullable().Length(15);

         Map(x => x.FechaModificacion).Column("FechaModificacion").Nullable();

      }
   }
}
