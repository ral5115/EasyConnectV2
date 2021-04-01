using EasyConnect.Infrastructure.Entities;
using FluentNHibernate.Mapping;

namespace EasyConnect.Infrastructure.Mappings.Base
{
   public class BaseWSCONCESIONESTIENDAMap : ClassMap<WSCONCESIONESTIENDA>
   {
      public BaseWSCONCESIONESTIENDAMap()
      {
         Table("WS_CONCESIONES_TIENDAS");
         Id(x => x.Id).Column("IdConcesionTienda").GeneratedBy.Native(builder => builder.AddParam("sequence", "WS_CONCESIONES_TIENDASSEQ"));

         Map(x => x.IdConcesion).Column("IdConcesion").Not.Nullable();

         Map(x => x.IdTienda).Column("IdTienda").Not.Nullable().Length(10);

         Map(x => x.NickName).Column("NickName").Nullable().Length(40);

         Map(x => x.FechaAlta).Column("FechaAlta").Nullable();

         Map(x => x.CreationDate).Column("CreationDate").Nullable();

      }
   }
}
