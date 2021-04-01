using EasyTools.Infrastructure.Mappings.Base;

namespace EasyTools.Infrastructure.Mappings
{
    public class CONStructureAssociationMap : BaseCONStructureAssociationMap
    {
        public CONStructureAssociationMap() : base()
        {
            References(x => x.MainStructure).Column("MainStructureId").Not.Insert().Not.Update();

            References(x => x.ChildStructure).Column("ChildStructureId").Not.Insert().Not.Update();

        }
    }
}