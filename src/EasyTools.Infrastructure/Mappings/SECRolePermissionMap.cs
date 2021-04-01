using EasyTools.Infrastructure.Mappings.Base;

namespace EasyTools.Infrastructure.Mappings
{
    public class SECRolePermissionMap : BaseSECRolePermissionMap
    {
        public SECRolePermissionMap() : base()
        {
            References(x => x.Role).Column("RoleId").Not.Insert().Not.Update();
        }
    }
}