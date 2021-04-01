using EasyTools.Infrastructure.Entities;
using FluentNHibernate.Mapping;

namespace EasyTools.Infrastructure.Mappings.Base
{
    public class BaseCONStructureAssociationMap : ClassMap<CONStructureAssociation>
    {
        public BaseCONStructureAssociationMap()
        {
            Table("CONStructureAssociations");
            Id(x => x.Id).Column("StructureAssociationId").GeneratedBy.Native(builder => builder.AddParam("sequence", "CONStructureAssociationSEQ"));

            Map(x => x.Active).Column("Active").Not.Nullable();

            Map(x => x.UpdatedBy).Column("UpdatedBy").Not.Nullable().Length(50);

            Map(x => x.LastUpdate).Column("LastUpdate").Not.Nullable();

            Map(x => x.MainStructureId).Column("MainStructureId").Not.Nullable();

            Map(x => x.ChildStructureId).Column("ChildStructureId").Not.Nullable();

        }
    }
}