using EasyTools.Infrastructure.Entities;
using FluentNHibernate.Mapping;

namespace EasyTools.Infrastructure.Mappings.Base
{
    public class BaseCONStructureMap : ClassMap<CONStructure>
    {
        public BaseCONStructureMap()
        {
            Table("CONStructures");
            Id(x => x.Id).Column("StructureId").GeneratedBy.Native(builder => builder.AddParam("sequence", "CONStructureSEQ"));

            Map(x => x.Code).Column("Code").Not.Nullable().Length(10);

            Map(x => x.Name).Column("Name").Not.Nullable().Length(80);

            Map(x => x.Version).Column("Version").Not.Nullable();

            Map(x => x.Main).Column("Main").Not.Nullable();

            Map(x => x.Active).Column("Active").Not.Nullable();

            Map(x => x.ColumnNumber).Column("ColumnNumber").Not.Nullable();

            Map(x => x.UpdatedBy).Column("UpdatedBy").Not.Nullable().Length(50);

            Map(x => x.LastUpdate).Column("LastUpdate").Not.Nullable();

            Map(x => x.IntegratorId).Column("IntegratorId").Not.Nullable();

        }
    }
}