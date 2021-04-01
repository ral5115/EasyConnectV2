using EasyTools.Infrastructure.Entities;
using FluentNHibernate.Mapping;

namespace EasyTools.Infrastructure.Mappings.Base
{
    public class BaseSECRoleMap : ClassMap<SECRole>
    {
        public BaseSECRoleMap()
        {
            Table("SECRols");
            Id(x => x.Id).Column("RoleId").GeneratedBy.Native(builder => builder.AddParam("sequence", "SECRoleSEQ"));

            Map(x => x.Name).Column("Name").Not.Nullable().Length(50);

            Map(x => x.Active).Column("Active").Not.Nullable();

            Map(x => x.UpdatedBy).Column("UpdatedBy").Not.Nullable().Length(50);

            Map(x => x.LastUpdate).Column("LastUpdate").Not.Nullable();

        }
    }
}