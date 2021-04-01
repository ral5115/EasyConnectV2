using EasyTools.Infrastructure.Mappings.Base;

namespace EasyTools.Infrastructure.Mappings
{
    public class CONStructureMap : BaseCONStructureMap
    {
        public CONStructureMap() : base()
        {
            References(x => x.Integrator).Column("IntegratorId").Not.Insert().Not.Update();

        }
    }
}