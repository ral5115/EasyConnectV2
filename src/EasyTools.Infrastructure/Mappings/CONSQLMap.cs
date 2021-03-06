    using EasyTools.Infrastructure.Mappings.Base;

namespace EasyTools.Infrastructure.Mappings
{
    public class CONSQLMap : BaseCONSQLMap
    {
        public CONSQLMap() : base()
        {
            References(x => x.Connection).Column("ConnectionId").Not.Insert().Not.Update();

            References(x => x.StoreProcedureConnection).Column("StoreProcedureConnectionId").Not.Insert().Not.Update();

            //References(x => x.DestinyConnection).Column("DestinyConnectionId").Not.Insert().Not.Update();

            References(x => x.Company).Column("CompanyId").Not.Insert().Not.Update();

            References(x => x.MainSQL).Column("MainSQLId").Not.Insert().Not.Update();

            References(x => x.Structure).Column("StructureId").Not.Insert().Not.Update();


        }
    }
}