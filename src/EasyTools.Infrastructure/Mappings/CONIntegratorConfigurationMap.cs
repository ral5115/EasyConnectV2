using EasyTools.Infrastructure.Mappings.Base;

namespace EasyTools.Infrastructure.Mappings
{
    public class CONIntegratorConfigurationMap : BaseCONIntegratorConfigurationMap
    {
        public CONIntegratorConfigurationMap()
            : base()
        {
            References(x => x.Integrator).Column("IntegratorId").Not.Insert().Not.Update();

            References(x => x.Connection).Column("ConnectionId").Not.Insert().Not.Update();

            References(x => x.Company).Column("CompanyId").Not.Insert().Not.Update();

        }
    }
}