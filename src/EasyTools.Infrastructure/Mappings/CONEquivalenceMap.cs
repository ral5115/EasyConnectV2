using EasyTools.Infrastructure.Mappings.Base;

namespace EasyTools.Infrastructure.Mappings
{
    public class CONEquivalenceMap : BaseCONEquivalenceMap
    {
        public CONEquivalenceMap() : base()
        {
            References(x => x.Company).Column("CompanyId").Not.Insert().Not.Update();

        }
    }
}