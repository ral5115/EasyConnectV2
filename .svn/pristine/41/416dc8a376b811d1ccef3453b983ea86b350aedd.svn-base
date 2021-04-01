using EasyTools.Infrastructure.Entities;
using FluentNHibernate.Mapping;

namespace EasyTools.Infrastructure.Mappings.Base
{
    public class BaseSECRolePermissionMap : ClassMap<SECRolePermission>
    {
        public BaseSECRolePermissionMap()
        {
            Table("SECRolePermissions");
            Id(x => x.Id).Column("RolePermissionId").GeneratedBy.Native(builder => builder.AddParam("sequence", "SECRolePermissionSEQ"));

            Map(x => x.Active).Column("Active").Not.Nullable();

            Map(x => x.UpdatedBy).Column("UpdatedBy").Not.Nullable().Length(50);

            Map(x => x.LastUpdate).Column("LastUpdate").Not.Nullable();

            Map(x => x.MenuId).Column("MenuId").Not.Nullable();

            Map(x => x.PermissionId).Column("PermissionId").Not.Nullable();

            Map(x => x.RoleId).Column("RoleId").Not.Nullable();

        }
    }
}