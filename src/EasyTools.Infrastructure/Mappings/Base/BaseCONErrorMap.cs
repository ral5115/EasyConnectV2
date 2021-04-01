using EasyTools.Infrastructure.Entities;
using FluentNHibernate.Mapping;

namespace EasyTools.Infrastructure.Mappings.Base
{
    public class BaseCONErrorMap : ClassMap<CONError>
    {
        public BaseCONErrorMap()
        {
            Table("CONErrors");
            Id(x => x.Id).Column("ErrorId").GeneratedBy.Native(builder => builder.AddParam("sequence", "CONErrorSEQ"));

            Map(x => x.ErrorLevel).Column("ErrorLevel").Not.Nullable();

            Map(x => x.ErrorValue).Column("ErrorValue").Nullable().Length(200);

            Map(x => x.ErrorDetail).Column("ErrorDetail").Nullable().Length(255);

            Map(x => x.RecordNumber).Column("RecordNumber").Not.Nullable();

            Map(x => x.RecordType).Column("RecordType").Not.Nullable();

            Map(x => x.SubRecordType).Column("SubRecordType").Not.Nullable();

            Map(x => x.Version).Column("Version").Not.Nullable();
            Map(x => x.UpdatedBy).Column("UpdatedBy").Not.Nullable().Length(50);

            Map(x => x.LastUpdate).Column("LastUpdate").Not.Nullable();

            Map(x => x.RecordId).Column("RecordId").Not.Nullable();

        }
    }
}