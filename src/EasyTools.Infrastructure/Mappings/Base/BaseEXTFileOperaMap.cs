using EasyTools.Infrastructure.Entities;
using FluentNHibernate.Mapping;

namespace EasyTools.Infrastructure.Mappings.Base
{
    public class BaseEXTFileOperaMap : ClassMap<EXTFileOpera>
    {
        public BaseEXTFileOperaMap()
        {
            Table("EXTFileOpera");
            Id(x => x.Id).Column("FileOperaId").GeneratedBy.Native(builder => builder.AddParam("sequence", "EXTFileOperaSEQ"));

            Map(x => x.Name).Column("Name").Not.Nullable().Length(25);

            Map(x => x.UpdatedBy).Column("UpdatedBy").Not.Nullable().Length(50);

            Map(x => x.LastUpdate).Column("LastUpdate").Not.Nullable();

        }
    }
}