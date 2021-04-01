using EasyTools.Infrastructure.Mappings.Base;

namespace EasyTools.Infrastructure.Mappings
{
    public class CONSQLParameterMap : BaseCONSQLParameterMap
    {
        public CONSQLParameterMap() : base()
        {
            References(x => x.SQL).Column("SQLId").Not.Insert().Not.Update();

        }
    }
}