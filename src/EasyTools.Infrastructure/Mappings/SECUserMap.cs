using EasyTools.Infrastructure.Mappings.Base;

namespace EasyTools.Infrastructure.Mappings
{
    public class SECUserMap : BaseSECUserMap
    {
        public SECUserMap() : base()
        {
            References(x => x.Role).Column("RoleId").Not.Insert().Not.Update();

        }
    }
}