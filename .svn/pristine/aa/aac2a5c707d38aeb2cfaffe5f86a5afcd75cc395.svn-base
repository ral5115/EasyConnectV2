using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using EasyTools.Infrastructure.Repositories.Base;
using NHibernate;
using System;
using System.Collections.Generic;

namespace EasyTools.Infrastructure.Repositories
{

    public class CONSQLRepository : BaseCONSQLRepository
    {

        public CONSQLRepository(IUnitOfWork context)
            : base(context)
        {
        }

        public override String GetQuery(CONSQL data, Boolean byId)
        {
            String dml = base.GetQuery(data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {
                //Determine if the boolean values ​​are taken included as part of the consultation

                //dml += "             AND a.Automatic = :Automatic \n" ;
                //dml += "             AND a.GenerateFile = :GenerateFile \n" ;

                //add more parameters to method for query by any field

                if (data.Company != null && data.Company.Id != 0)
                    dml += "             AND a.Company.Id = :Company \n";
                //if (data.MainSQL != null && data.MainSQL.Id != 0)
                //    dml += "             AND a.MainSQL.Id = :MainSQL \n";
                //if (data.MainSQL == null)
                //    dml += "             AND a.MainSQL is null \n";
                if (data.MainSQLId == null)
                {
                    dml += "             AND a.MainSQLId is null \n";
                    dml += "             AND a.Active = :Active \n";
                }
                else
                    dml += "             AND a.MainSQLId is not null \n";
                if (data.Structure != null && data.Structure.Id != 0)
                    dml += "             AND a.Structure.Id = :Structure \n";

                dml += " order by a.Id asc ";
            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, CONSQL data, Boolean byId)
        {
            base.SetQueryParameters(query, data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {
                //Determine if the boolean values ​​are taken included as part of the consultation
                if (data.MainSQLId == null)
                    query.SetBoolean("Active", data.Active);
                //query.SetBoolean("Automatic",  data.Automatic);
                //query.SetBoolean("GenerateFile",  data.GenerateFile);

                //add more parameters to method for query by any field

                if (data.Company != null && data.Company.Id != 0)
                    query.SetInt32("Company", data.Company.Id);
                //if (data.MainSQL != null && data.MainSQL.Id != 0)
                //    query.SetInt32("MainSQL", data.MainSQL.Id);
                if (data.Structure != null && data.Structure.Id != 0)
                    query.SetInt32("Structure", data.Structure.Id);
            }
        }

        public override void SaveOrUpdateDetails(CONSQL data)
        {
            //base.SaveOrUpdateDetails(data);
            if (data.SQLDetails != null && data.SQLDetails.Count > 0)
            {
                for (int i = 0; i < data.SQLDetails.Count; i++)
                {
                    data.SQLDetails[i].SQLId = data.Id;
                    data.SQLDetails[i].LastUpdate = DateTime.Now;
                    data.SQLDetails[i].UpdatedBy = data.UpdatedBy;
                    if (data.SQLDetails[i].Equivalence != null)
                        data.SQLDetails[i].EquivalenceId = data.SQLDetails[i].Equivalence.Id;
                    //if (data.SQLDetails[i].MainSQLDetail != null)
                    //    data.SQLDetails[i].MainSQLDetailId = data.SQLDetails[i].MainSQLDetail.Id;
                    if (data.SQLDetails[i].StructureDetail != null)
                        data.SQLDetails[i].StructureDetailId = data.SQLDetails[i].StructureDetail.Id;
                    if (data.SQLDetails[i].Id == 0)
                        data.SQLDetails[i] = Add(data.SQLDetails[i]);
                    else
                        data.SQLDetails[i] = Modify(data.SQLDetails[i]);
                }
            }
            if (data.SQLParameters != null && data.SQLParameters.Count > 0)
            {
                for (int i = 0; i < data.SQLParameters.Count; i++)
                {
                    data.SQLParameters[i].SQLId = data.Id;
                    data.SQLParameters[i].LastUpdate = DateTime.Now;
                    data.SQLParameters[i].UpdatedBy = data.UpdatedBy;
                    if (data.SQLParameters[i].Id == 0)
                        data.SQLParameters[i] = Add(data.SQLParameters[i]);
                    else
                        data.SQLParameters[i] = Modify(data.SQLParameters[i]);
                }
            }
            if (data.SQLSends != null && data.SQLSends.Count > 0)
            {
                for (int i = 0; i < data.SQLSends.Count; i++)
                {
                    data.SQLSends[i].SQLId = data.Id;
                    data.SQLSends[i].LastUpdate = DateTime.Now;
                    data.SQLSends[i].UpdatedBy = data.UpdatedBy;
                    if (data.SQLSends[i].CONIntegratorConfiguration != null)
                        data.SQLSends[i].CONIntegratorConfigurationId = data.SQLSends[i].CONIntegratorConfiguration.Id;
                    if (data.SQLSends[i].Id == 0)
                        data.SQLSends[i] = Add(data.SQLSends[i]);
                    else
                        data.SQLSends[i] = Modify(data.SQLSends[i]);
                }
            }
            if (data.ChildSQLs != null && data.ChildSQLs.Count > 0)
            {
                for (int i = 0; i < data.ChildSQLs.Count; i++)
                {
                    data.ChildSQLs[i].MainSQLId = data.Id;
                    data.ChildSQLs[i].LastUpdate = DateTime.Now;
                    data.ChildSQLs[i].UpdatedBy = data.UpdatedBy;
                    if (data.ChildSQLs[i].Company != null)
                        data.ChildSQLs[i].CompanyId = data.ChildSQLs[i].Company.Id;
                    if (data.ChildSQLs[i].Structure != null)
                        data.ChildSQLs[i].StructureId = data.ChildSQLs[i].Structure.Id;
                    if (data.ChildSQLs[i].Connection != null)
                        data.ChildSQLs[i].ConnectionId = data.ChildSQLs[i].Connection.Id;
                    if (data.ChildSQLs[i].Id == 0)
                        data.ChildSQLs[i] = Add(data.ChildSQLs[i]);
                    else
                        data.ChildSQLs[i] = Modify(data.ChildSQLs[i]);
                    SaveOrUpdateDetails(data.ChildSQLs[i]);
                }
            }
        }

        public override void AddMoreDetailFindById(CONSQL data)
        {

        }

        public override CONSQL FindById(CONSQL data)
        {
            return base.FindById(data);
        }

        public override List<CONSQL> FindAll(CONSQL data, Options option)
        {
            return base.FindAll(data, option);
        }

    }
}