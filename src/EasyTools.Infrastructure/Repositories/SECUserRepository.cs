using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using EasyTools.Infrastructure.Repositories.Base;
using NHibernate;
using System;
using System.Collections.Generic;

namespace EasyTools.Infrastructure.Repositories
{

    public class SECUserRepository : BaseSECUserRepository
    {

        public SECUserRepository(IUnitOfWork context)
            : base(context)
        {
        }

        public override String GetQuery(SECUser data, Boolean byId)
        {
            String dml = base.GetQuery(data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
                if (!string.IsNullOrWhiteSpace(data.Login))
                    dml += "             AND a.Login = :Login \n";
                if (!string.IsNullOrWhiteSpace(data.Password))
                    dml += "             AND a.Password = :Password \n";
                if (!string.IsNullOrWhiteSpace(data.Email))
                    dml += "             AND a.Email = :Email \n";
            }
            else
            {
                //Determine if the boolean values ​​are taken included as part of the consultation
                //dml += "             AND a.Active = :Active \n" ;
                //dml += "             AND a.Locked = :Locked \n" ;
                //dml += "             AND a.RequiresVerification = :RequiresVerification \n" ;

                //add more parameters to method for query by any field

                if (data.Role != null && data.Role.Id != 0)
                    dml += "             AND a.Role.Id = :Role \n";

                dml += " order by a.Id asc ";
            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, SECUser data, Boolean byId)
        {
            base.SetQueryParameters(query, data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
                if (!string.IsNullOrWhiteSpace(data.Login))
                    query.SetString("Login", data.Login);
                if (!string.IsNullOrWhiteSpace(data.Password))
                    query.SetString("Password", data.Password);
                if (!string.IsNullOrWhiteSpace(data.Email))
                    query.SetString("Email", data.Email);
            }
            else
            {

                //Determine if the boolean values ​​are taken included as part of the consultation
                //query.SetBoolean("Active",  data.Active);
                //query.SetBoolean("Locked",  data.Locked);
                //query.SetBoolean("RequiresVerification",  data.RequiresVerification);

                //add more parameters to method for query by any field

                if (data.Role != null && data.Role.Id != 0)
                    query.SetInt32("Role", data.Role.Id);
            }
        }

        public override void SaveOrUpdateDetails(SECUser data)
        {
            base.SaveOrUpdateDetails(data);
        }

        public override void AddMoreDetailFindById(SECUser data)
        {
        }

        public override SECUser FindById(SECUser data)
        {
            return base.FindById(data);
        }

        public override List<SECUser> FindAll(SECUser data, Options option)
        {
            return base.FindAll(data, option);
        }

    }
}