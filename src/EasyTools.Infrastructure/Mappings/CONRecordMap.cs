using EasyTools.Infrastructure.Mappings.Base;

namespace EasyTools.Infrastructure.Mappings
{
    public class CONRecordMap : BaseCONRecordMap
    {
        public CONRecordMap() : base()
        {
            References(x => x.SQL).Column("SQLId").Not.Insert().Not.Update();

        }
    }
}