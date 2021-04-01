using EasyTools.Infrastructure.Mappings.Base;

namespace EasyTools.Infrastructure.Mappings
{
    public class CONRecordDetailMap : BaseCONRecordDetailMap
    {
        public CONRecordDetailMap() : base()
        {
            References(x => x.SQL).Column("SQLId").Not.Insert().Not.Update();

            References(x => x.Record).Column("RecordId").Not.Insert().Not.Update();

        }
    }
}