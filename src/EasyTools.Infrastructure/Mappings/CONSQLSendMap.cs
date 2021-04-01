using EasyTools.Infrastructure.Mappings.Base;

namespace EasyTools.Infrastructure.Mappings
{
    public class CONSQLSendMap : BaseCONSQLSendMap
    {
        public CONSQLSendMap() : base()
        {
            References(x => x.CONIntegratorConfiguration).Column("CONIntegratorConfigurationId").Not.Insert().Not.Update();

            References(x => x.SQL).Column("SQLId").Not.Insert().Not.Update();

        }
    }
}