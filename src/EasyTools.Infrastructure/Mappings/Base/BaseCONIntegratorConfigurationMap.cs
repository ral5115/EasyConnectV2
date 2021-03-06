using EasyTools.Infrastructure.Entities;
using FluentNHibernate.Mapping;

namespace EasyTools.Infrastructure.Mappings.Base
{
    public class BaseCONIntegratorConfigurationMap : ClassMap<CONIntegratorConfiguration>
    {
        public BaseCONIntegratorConfigurationMap()
        {
            Table("CONIntegratorConfigurations");
            Id(x => x.Id).Column("CONIntegratorConfigurationId").GeneratedBy.Native(builder => builder.AddParam("sequence", "CONIntegratorConfigurationSEQ"));

            //Map(x => x.WebServiceUrl).Column("WebServiceUrl").Nullable().Length(1024);

            Map(x => x.InternalUser).Column("InternalUser").Not.Nullable().Length(50);

            Map(x => x.InternalPassword).Column("InternalPassword").Not.Nullable().Length(255);

            //Map(x => x.InternalConnectionName).Column("InternalConnectionName").Nullable().Length(10);

            Map(x => x.Active).Column("Active").Not.Nullable();

            Map(x => x.UpdatedBy).Column("UpdatedBy").Not.Nullable().Length(50);

            Map(x => x.LastUpdate).Column("LastUpdate").Not.Nullable();

            Map(x => x.ConnectionNumber).Column("ConnectionNumber").Nullable();

            Map(x => x.ProgramPath).Column("ProgramPath").Nullable().Length(1024);

            //Map(x => x.DirectImport).Column("DirectImport").Not.Nullable();

            Map(x => x.IntegratorId).Column("IntegratorId").Not.Nullable();

            Map(x => x.ConnectionId).Column("ConnectionId").Nullable();

            Map(x => x.CompanyId).Column("CompanyId").Not.Nullable();

            Map(x => x.FileName).Column("FileName").Nullable().Length(255);

            Map(x => x.FileExtension).Column("FileExtension").Nullable().Length(4);

            Map(x => x.Type).Column("Type").Nullable().Length(3);

        }
    }
}