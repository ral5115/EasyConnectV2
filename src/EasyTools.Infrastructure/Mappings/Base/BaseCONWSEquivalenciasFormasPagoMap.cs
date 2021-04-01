using EasyConnect.Infrastructure.Entities;
using EasyTools.Infrastructure.Entities;
using FluentNHibernate.Mapping;

namespace EasyTools.Infrastructure.Mappings.Base
{
    public class BaseCONWSEquivalenciasFormasPagoMap : ClassMap<CONWSEquivalenciasFormasPago>
    {
        public BaseCONWSEquivalenciasFormasPagoMap()
        {
            Table("WS_Equivalencias_Formas_Pago");
            Id(x => x.Id).Column("Id").GeneratedBy.Native(builder => builder.AddParam("sequence", "CONWSEquivalenciasFormasPagoSEQ"));

            Map(x => x.FormaPagoZapa).Column("FormaPagoZapa").Nullable().Length(50);

            Map(x => x.FPagoDet_Zapa).Column("FPagoDet_Zapa").Nullable().Length(50);

            Map(x => x.FormaPagoUNOEE).Column("FormaPagoUNOEE").Nullable().Length(50);

            Map(x => x.RefFP).Column("RefFP").Nullable().Length(50);

            Map(x => x.CuentaContable).Column("CuentaContable").Nullable().Length(50);
            
            //Map(x => x.UpdatedBy).Column("UpdatedBy").Not.Nullable().Length(50);

            //Map(x => x.LastUpdate).Column("LastUpdate").Not.Nullable();

        }
    }
}