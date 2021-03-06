using EasyTools.Infrastructure.Entities;
using FluentNHibernate.Mapping;

namespace EasyTools.Infrastructure.Mappings.Base
{
    public class BaseCONSQLMap : ClassMap<CONSQL>
    {
        public BaseCONSQLMap()
        {
            Table("CONSQLs");
            Id(x => x.Id).Column("SQLId").GeneratedBy.Native(builder => builder.AddParam("sequence", "CONSQLSEQ"));

            Map(x => x.Active).Column("Active").Not.Nullable();

            Map(x => x.Description).Column("Description").Not.Nullable().Length(255);

            Map(x => x.ConnectionId).Column("ConnectionId").Not.Nullable();

            Map(x => x.SQLSentence).Column("SQLSentence").Nullable().Length(2147483647);

            Map(x => x.Automatic).Column("Automatic").Not.Nullable();

            Map(x => x.ExecuteStoreProcedure).Column("ExecuteStoreProcedure").Nullable().Length(200);

            Map(x => x.StoreProcedureConnectionId).Column("StoreProcedureConnectionId").Nullable();

            //Map(x => x.DestinyConnectionId).Column("DestinyConnectionId").Nullable();

            Map(x => x.GenerateFile).Column("GenerateFile").Not.Nullable();

            //Map(x => x.FileName).Column("FileName").Nullable().Length(255);

            Map(x => x.Tag).Column("Tag").Nullable().Length(50);

            //Map(x => x.FileExtension).Column("FileExtension").Nullable().Length(4);

            Map(x => x.UpdatedBy).Column("UpdatedBy").Not.Nullable().Length(50);

            Map(x => x.LastUpdate).Column("LastUpdate").Not.Nullable();

            Map(x => x.CompanyId).Column("CompanyId").Not.Nullable();

            Map(x => x.MainSQLId).Column("MainSQLId").Nullable();

            Map(x => x.StructureId).Column("StructureId").Not.Nullable();

        }
    }
}