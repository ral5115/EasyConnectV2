using EasyTools.Infrastructure.Mappings.Base;

namespace EasyTools.Infrastructure.Mappings
{
    public class CONStructureDetailMap : BaseCONStructureDetailMap
    {
        public CONStructureDetailMap() : base()
        {
            References(x => x.Structure).Column("StructureId").Not.Insert().Not.Update();

        }
    }
}