using EasyTools.Infrastructure.Mappings.Base;

namespace EasyTools.Infrastructure.Mappings
{
    public class CONErrorMap : BaseCONErrorMap
    {
        public CONErrorMap() : base()
        {
            References(x => x.Record).Column("RecordId").Not.Insert().Not.Update();

        }
    }
}