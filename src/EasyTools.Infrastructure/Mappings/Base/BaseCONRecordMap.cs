using EasyTools.Infrastructure.Entities;
using FluentNHibernate.Mapping;

namespace EasyTools.Infrastructure.Mappings.Base
{
    public class BaseCONRecordMap : ClassMap<CONRecord>
    {
        public BaseCONRecordMap()
        {
            Table("CONRecords");
            Id(x => x.Id).Column("RecordId").GeneratedBy.Native(builder => builder.AddParam("sequence", "CONRecordSEQ"));

            Map(x => x.RecordNumber).Column("RecordNumber").Not.Nullable();

            Map(x => x.RecordType).Column("RecordType").Not.Nullable();

            Map(x => x.SubRecordType).Column("SubRecordType").Not.Nullable();

            Map(x => x.Version).Column("Version").Not.Nullable();

            Map(x => x.Company).Column("Company").Not.Nullable().Length(3);

            Map(x => x.IsSend).Column("IsSend").Not.Nullable();

            Map(x => x.LogicalKey).Column("LogicalKey").Not.Nullable().Length(50);

            Map(x => x.DocumentNumber).Column("DocumentNumber").Nullable();

            Map(x => x.XMLData).Column("XMLData").Not.Nullable().Length(2147483647);

            Map(x => x.IsExternal).Column("IsExternal").Not.Nullable();

            Map(x => x.OperationCenter).Column("OperationCenter").Nullable().Length(3);

            Map(x => x.DocumentType).Column("DocumentType").Nullable().Length(3);

            Map(x => x.PlainText).Column("PlainText").Not.Nullable().Length(2147483647);

            Map(x => x.UpdatedBy).Column("UpdatedBy").Not.Nullable().Length(50);

            Map(x => x.LastUpdate).Column("LastUpdate").Not.Nullable();

            Map(x => x.SQLId).Column("SQLId").Nullable();

        }
    }
}