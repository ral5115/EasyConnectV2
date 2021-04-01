using EasyTools.Infrastructure.Mappings.Base;

namespace EasyTools.Infrastructure.Mappings
{
    public class CONEquivalenceDetailMap : BaseCONEquivalenceDetailMap
    {
        public CONEquivalenceDetailMap() : base()
        {
            References(x => x.Equivalence).Column("EquivalenceId").Not.Insert().Not.Update();

        }
    }
}