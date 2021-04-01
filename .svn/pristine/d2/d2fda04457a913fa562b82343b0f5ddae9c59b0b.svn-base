using EasyTools.Infrastructure.Entities;
using FluentNHibernate.Mapping;

namespace EasyTools.Infrastructure.Mappings.Base
{
    public class BaseSECUserMap : ClassMap<SECUser>
    {
        public BaseSECUserMap()
        {
            Table("SECUsers");
            Id(x => x.Id).Column("UserId").GeneratedBy.Native(builder => builder.AddParam("sequence", "SECUserSEQ"));

            Map(x => x.Login).Column("Login").Not.Nullable().Length(50);

            Map(x => x.Password).Column("Password").Not.Nullable().Length(256);

            Map(x => x.Active).Column("Active").Not.Nullable();

            Map(x => x.Names).Column("Names").Not.Nullable().Length(50);

            Map(x => x.FatherLastName).Column("FatherLastName").Not.Nullable().Length(20);

            Map(x => x.MotherLastName).Column("MotherLastName").Nullable().Length(30);

            Map(x => x.IdentificationNumber).Column("IdentificationNumber").Not.Nullable().Length(16);

            Map(x => x.Email).Column("Email").Not.Nullable().Length(256);

            Map(x => x.UpdatedBy).Column("UpdatedBy").Not.Nullable().Length(50);

            Map(x => x.LastUpdate).Column("LastUpdate").Not.Nullable();

            Map(x => x.Locked).Column("Locked").Not.Nullable();

            Map(x => x.RequiresVerification).Column("RequiresVerification").Not.Nullable();

            Map(x => x.RepeatPassword).Column("RepeatPassword").Not.Nullable().Length(256);

            Map(x => x.RoleId).Column("RoleId").Nullable();

        }
    }
}