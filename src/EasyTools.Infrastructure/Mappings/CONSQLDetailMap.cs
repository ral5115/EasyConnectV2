using EasyTools.Infrastructure.Mappings.Base;

namespace EasyTools.Infrastructure.Mappings
{
    public class CONSQLDetailMap : BaseCONSQLDetailMap
    {
        public CONSQLDetailMap() : base()
        {
            References(x => x.Equivalence).Column("EquivalenceId").Not.Insert().Not.Update();

            //References(x => x.MainSQLDetail).Column("MainSQLDetailId").Not.Insert().Not.Update();

            References(x => x.SQL).Column("SQLId").Not.Insert().Not.Update();

            References(x => x.StructureDetail).Column("StructureDetailId").Not.Insert().Not.Update();

        }
    }
}