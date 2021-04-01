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

    public class BaseSECRolePermissionRepository : BaseRepository<SECRolePermission>
    {

        public BaseSECRolePermissionRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(SECRolePermission data, Boolean byId)
        {
            String dml = "Select a from SECRolePermission as a where 1=1 ";
            if (byId)
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
            }
            else
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
                if (data.MenuId != 0)
                    dml += "             AND a.MenuId = :MenuId \n";
                if (data.PermissionId != 0)
                    dml += "             AND a.PermissionId = :PermissionId \n";
                if (data.RoleId != 0)
                    dml += "             AND a.RoleId = :RoleId \n";

            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, SECRolePermission data, Boolean byId)
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
                if (data.MenuId != 0)
                    query.SetInt32("MenuId", data.MenuId);
                if (data.PermissionId != 0)
                    query.SetInt32("PermissionId", data.PermissionId);
                if (data.RoleId != 0)
                    query.SetInt32("RoleId", data.RoleId);
            }
        }

        public override void SaveOrUpdateDetails(SECRolePermission data)
        {
        }

        public override void AddMoreDetailFindById(SECRolePermission data)
        {
        }

        public override SECRolePermission FindById(SECRolePermission data)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, true));
            SetQueryParameters(query, data, true);
            data = query.UniqueResult<SECRolePermission>();
            if (data != null)
            {
                data = new SECRolePermission(data, Options.Me);
                AddMoreDetailFindById(data);
            }
            return data;
        }

        public override List<SECRolePermission> FindAll(SECRolePermission data, Options option)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, false));
            SetQueryParameters(query, data, false);
            if (data.HasPaging)
            {
                query.SetFirstResult((data.PageSize * data.CurrentPage) - data.PageSize);
                query.SetMaxResults(data.PageSize);
            }
            return (from a in query.List<SECRolePermission>() select new SECRolePermission(a, option)).ToList<SECRolePermission>();
        }
    }
}