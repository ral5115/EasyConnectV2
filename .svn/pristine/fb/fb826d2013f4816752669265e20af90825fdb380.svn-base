using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using EasyTools.Infrastructure.Repositories.Base;
using NHibernate;
using System;
using System.Collections.Generic;

namespace EasyTools.Infrastructure.Repositories
{

    public class SECRolePermissionRepository : BaseSECRolePermissionRepository
    {

        public SECRolePermissionRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(SECRolePermission data, Boolean byId)
        {
            String dml = base.GetQuery(data, byId);
            if (byId)
            {
                //add more parameters to method for query by id7 
                if (data.RoleId != 0)
                    dml += "             AND a.RoleId = :RoleId \n";
                if (data.MenuId != 0)
                    dml += "             AND a.MenuId = :MenuId \n";
                if (data.PermissionId != 0)
                    dml += "             AND a.PermissionId = :PermissionId \n";

            }
            else
            {
                //Determine if the boolean values ​​are taken included as part of the consultation
                //dml += "             AND a.Active = :Active \n" ;
                //dml += "             AND a.Saves = :Saves \n" ;
                //dml += "             AND a.Updates = :Updates \n" ;
                //dml += "             AND a.Deletes = :Deletes \n" ;
                //dml += "             AND a.Queries = :Queries \n" ;
                //dml += "             AND a.Option1 = :Option1 \n" ;
                //dml += "             AND a.Option2 = :Option2 \n" ;
                //dml += "             AND a.Option3 = :Option3 \n" ;
                //dml += "             AND a.Option4 = :Option4 \n" ;
                //dml += "             AND a.Option5 = :Option5 \n" ;
                //dml += "             AND a.Option6 = :Option6 \n" ;
                //dml += "             AND a.Option7 = :Option7 \n" ;
                //dml += "             AND a.Option8 = :Option8 \n" ;
                //dml += "             AND a.Option9 = :Option9 \n" ;
                //dml += "             AND a.Option10 = :Option10 \n" ;

                //add more parameters to method for query by any field
                if (data.Role != null && data.Role.Id != 0)
                    dml += "             AND a.Role.Id = :Role \n";

                dml += " order by a.Id asc ";
            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, SECRolePermission data, Boolean byId)
        {
            base.SetQueryParameters(query, data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
                if (data.RoleId != 0)
                    query.SetInt32("RoleId", data.RoleId);
                if (data.MenuId != 0)
                    query.SetInt32("MenuId", data.MenuId);
                if (data.PermissionId != 0)
                    query.SetInt32("PermissionId", data.PermissionId);
            }
            else
            {

                //Determine if the boolean values ​​are taken included as part of the consultation
                //query.SetBoolean("Active",  data.Active);
                //query.SetBoolean("Saves",  data.Saves);
                //query.SetBoolean("Updates",  data.Updates);
                //query.SetBoolean("Deletes",  data.Deletes);
                //query.SetBoolean("Queries",  data.Queries);
                //query.SetBoolean("Option1",  data.Option1);
                //query.SetBoolean("Option2",  data.Option2);
                //query.SetBoolean("Option3",  data.Option3);
                //query.SetBoolean("Option4",  data.Option4);
                //query.SetBoolean("Option5",  data.Option5);
                //query.SetBoolean("Option6",  data.Option6);
                //query.SetBoolean("Option7",  data.Option7);
                //query.SetBoolean("Option8",  data.Option8);
                //query.SetBoolean("Option9",  data.Option9);
                //query.SetBoolean("Option10",  data.Option10);

                //add more parameters to method for query by any field
                if (data.Role != null && data.Role.Id != 0)
                    query.SetInt32("Role", data.Role.Id);
            }
        }

        public override void SaveOrUpdateDetails(SECRolePermission data)
        {
            base.SaveOrUpdateDetails(data);
        }

        public override void AddMoreDetailFindById(SECRolePermission data)
        {
        }

        public override SECRolePermission FindById(SECRolePermission data)
        {
            return base.FindById(data);
        }

        public override List<SECRolePermission> FindAll(SECRolePermission data, Options option)
        {
            return base.FindAll(data, option);
        }
    }
}