using EasyTools.Infrastructure.Entities;
using FluentNHibernate.Mapping;

namespace EasyTools.Infrastructure.Mappings.Base
{
    public class BaseCONIntegratorMap : ClassMap<CONIntegrator>
    {
        public BaseCONIntegratorMap()
        {
            Table("CONIntegrators");
            Id(x => x.Id).Column("IntegratorId").GeneratedBy.Native(builder => builder.AddParam("sequence", "CONIntegratorSEQ"));

            Map(x => x.Name).Column("Name").Not.Nullable().Length(50);

            Map(x => x.Active).Column("Active").Not.Nullable();

            Map(x => x.XMLDefinition).Column("XMLDefinition").Nullable().Length(50);

            Map(x => x.XMLRoot).Column("XMLRoot").Nullable().Length(50);

            Map(x => x.UpdatedBy).Column("UpdatedBy").Not.Nullable().Length(50);

            Map(x => x.LastUpdate).Column("LastUpdate").Not.Nullable();

        }
    }
}