using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities;
using System;
using System.Collections.Generic;

namespace EasyTools.Domains.Installation.Data
{
    public abstract class InvariantSeedData
    {
        public List<SECRole> Roles()
        {
            var entities = new List<SECRole>
			{
                new SECRole
				{
					Name = "Administrator",
				    Active = true	 ,
                    LastUpdate = DateTime.Now,
                    UpdatedBy = "admin",
                    Users = new List<SECUser>
                    {
                        new SECUser
				        {
					        Login = "admin",
                            Password = Crypto.EncrytedString("portal"),
                            RepeatPassword = Crypto.EncrytedString("portal"),
                            Active = true ,
                            Names = "Deiber",
                            FatherLastName = "Caicedo",
                            MotherLastName = "",
                            IdentificationNumber = "94497774",
                            Email = "deibercaicedo@hotmail.com",
                            LastUpdate = DateTime.Now,
                            UpdatedBy = "admin",
				        },
                    }
				},
            };
            Alter(entities);
            return entities;
        }

        protected virtual void Alter(List<SECRole> entities)
        {
        }

        public List<SECUser> Users()
        {
            var entities = new List<SECUser>();
            Alter(entities);
            return entities;
        }

        protected virtual void Alter(List<SECUser> entities)
        {
        }

        public List<SECCompany> Companies()
        {
            var entities = new List<SECCompany>
			{
                new SECCompany
				{
			        IdentificationNumer = "890319193",
                    TradeName = "Sistemas de Información Empresarial S.A",
                    Active = true,
                    LastUpdate = DateTime.Now,
                    UpdatedBy = "admin",
				},
            };
            Alter(entities);
            return entities;
        }

        protected virtual void Alter(List<SECCompany> entities)
        {
        }



    }
}
