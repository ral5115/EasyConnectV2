using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace EasyTools.Infrastructure.Repositories.Base
{

    public class BaseSECUserRepository : BaseRepository<SECUser>
    {

        public BaseSECUserRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(SECUser data, Boolean byId)
        {
            String dml = "Select a from SECUser as a where 1=1 ";
            if (byId)
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
            }
            else
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
                if (!String.IsNullOrWhiteSpace(data.Login))
                    dml += "             AND upper(a.Login) like :Login \n";
                if (!String.IsNullOrWhiteSpace(data.Password))
                    dml += "             AND upper(a.Password) like :Password \n";
                if (!String.IsNullOrWhiteSpace(data.Names))
                    dml += "             AND upper(a.Names) like :Names \n";
                if (!String.IsNullOrWhiteSpace(data.FatherLastName))
                    dml += "             AND upper(a.FatherLastName) like :FatherLastName \n";
                if (!String.IsNullOrWhiteSpace(data.MotherLastName))
                    dml += "             AND upper(a.MotherLastName) like :MotherLastName \n";
                if (!String.IsNullOrWhiteSpace(data.IdentificationNumber))
                    dml += "             AND upper(a.IdentificationNumber) like :IdentificationNumber \n";
                if (!String.IsNullOrWhiteSpace(data.Email))
                    dml += "             AND upper(a.Email) like :Email \n";
                if (!String.IsNullOrWhiteSpace(data.RepeatPassword))
                    dml += "             AND upper(a.RepeatPassword) like :RepeatPassword \n";
                if (data.RoleId != null && data.RoleId != 0)
                    dml += "             AND a.RoleId = :RoleId \n";

            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, SECUser data, Boolean byId)
        {
            if (byId)
            {
                if (data.Id != 0)
                    query.SetInt32("Id", data.Id);
            }
            else
            {
                if (data.Id != 0)
                    query.SetInt32("Id", data.Id);
                if (!String.IsNullOrWhiteSpace(data.Login))
                    query.SetString("Login", "%" + data.Login.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.Password))
                    query.SetString("Password", "%" + data.Password.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.Names))
                    query.SetString("Names", "%" + data.Names.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.FatherLastName))
                    query.SetString("FatherLastName", "%" + data.FatherLastName.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.MotherLastName))
                    query.SetString("MotherLastName", "%" + data.MotherLastName.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.IdentificationNumber))
                    query.SetString("IdentificationNumber", "%" + data.IdentificationNumber.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.Email))
                    query.SetString("Email", "%" + data.Email.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.RepeatPassword))
                    query.SetString("RepeatPassword", "%" + data.RepeatPassword.ToUpper() + "%");
                if (data.RoleId != null && data.RoleId != 0)
                    query.SetInt32("RoleId", (Int32)data.RoleId);
            }
        }

        public override void SaveOrUpdateDetails(SECUser data)
        {
        }

        public override void AddMoreDetailFindById(SECUser data)
        {
        }

        public override SECUser FindById(SECUser data)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, true));
            SetQueryParameters(query, data, true);
            data = query.UniqueResult<SECUser>();
            if (data != null)
            {
                data = new SECUser(data, Options.Me);
                AddMoreDetailFindById(data);
            }
            return data;
        }

        public override List<SECUser> FindAll(SECUser data, Options option)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, false));
            SetQueryParameters(query, data, false);
            if (data.HasPaging)
            {
                query.SetFirstResult((data.PageSize * data.CurrentPage) - data.PageSize);
                query.SetMaxResults(data.PageSize);
            }
            return (from a in query.List<SECUser>() select new SECUser(a, option)).ToList<SECUser>();
        }
    }
}