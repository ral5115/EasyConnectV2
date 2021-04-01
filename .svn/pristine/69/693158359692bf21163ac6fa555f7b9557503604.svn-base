using EasyTools.Infrastructure.Entities;
using FluentNHibernate.Mapping;

namespace EasyTools.Infrastructure.Mappings.Base
{
    public class BaseEXTFileOperaDetailMap : ClassMap<EXTFileOperaDetail>
    {
        public BaseEXTFileOperaDetailMap()
        {
            Table("EXTFileOperaDetails");
            Id(x => x.Id).Column("FileOperaDetailId").GeneratedBy.Native(builder => builder.AddParam("sequence", "EXTFileOperaDetailSEQ"));

            Map(x => x.COD_D).Column("COD_D").Not.Nullable().Length(18);

            Map(x => x.HAB).Column("HAB").Not.Nullable().Length(18);

            Map(x => x.RESERVA).Column("RESERVA").Not.Nullable().Length(18);

            Map(x => x.VALOR).Column("VALOR").Not.Nullable().Length(18);

            Map(x => x.FECHA).Column("FECHA").Not.Nullable().Length(18);

            Map(x => x.DIA).Column("DIA").Not.Nullable().Length(18);

            Map(x => x.IVA).Column("IVA").Not.Nullable().Length(18);

            Map(x => x.PAGO).Column("PAGO").Not.Nullable().Length(3);

            Map(x => x.IMP1).Column("IMP1").Not.Nullable().Length(18);

            Map(x => x.NIT).Column("NIT").Not.Nullable().Length(18);

            Map(x => x.TIPO_DOC).Column("TIPO_DOC").Not.Nullable().Length(18);

            Map(x => x.TRX_NO).Column("TRX_NO").Not.Nullable().Length(18);

            Map(x => x.BILL_NO).Column("BILL_NO").Not.Nullable().Length(18);

            Map(x => x.ORIGINAL_ROOM).Column("ORIGINAL_ROOM").Not.Nullable().Length(18);

            Map(x => x.ORIGINAL_RESV).Column("ORIGINAL_RESV").Not.Nullable().Length(18);

            Map(x => x.RESV_ACTUAL).Column("RESV_ACTUAL").Not.Nullable().Length(18);

            Map(x => x.SUC).Column("SUC").Not.Nullable().Length(18);

            Map(x => x.CAJERO).Column("CAJERO").Not.Nullable().Length(18);

            Map(x => x.FVENCIMIENTO).Column("FVENCIMIENTO").Not.Nullable().Length(18);

            Map(x => x.REFERENCIA).Column("REFERENCIA").Not.Nullable().Length(50);

            Map(x => x.VTARJETA).Column("VTARJETA").Not.Nullable().Length(18);

            Map(x => x.TASACAMBIO).Column("TASACAMBIO").Not.Nullable().Length(18);

            Map(x => x.CURRENCY).Column("CURRENCY").Not.Nullable().Length(18);

            Map(x => x.TIPO_FAC).Column("TIPO_FAC").Not.Nullable().Length(18);

            Map(x => x.FACT_ASOC).Column("FACT_ASOC").Nullable().Length(18);

            Map(x => x.UpdatedBy).Column("UpdatedBy").Not.Nullable().Length(50);

            Map(x => x.LastUpdate).Column("LastUpdate").Not.Nullable();

            Map(x => x.FileOperaId).Column("FileOperaId").Not.Nullable();

        }
    }
}