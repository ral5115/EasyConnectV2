using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using EasyTools.Infrastructure.Repositories.Base;
using NHibernate;
using System;
using System.Collections.Generic;

namespace EasyTools.Infrastructure.Repositories
{

    public class CONStructureAssociationRepository : BaseCONStructureAssociationRepository
    {

        public CONStructureAssociationRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(CONStructureAssociation data, Boolean byId)
        {
            String dml = base.GetQuery(data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {
                //Determine if the boolean values ​​are taken included as part of the consultation
                //dml += "             AND a.Active = :Active \n" ;

                //add more parameters to method for query by any field

                if (data.MainStructure != null && data.MainStructure.Id != 0)
                    dml += "             AND a.MainStructure.Id = :MainStructure \n";
                if (data.ChildStructure != null && data.ChildStructure.Id != 0)
                    dml += "             AND a.ChildStructure.Id = :ChildStructure \n";

                dml += " order by a.Id asc ";
            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, CONStructureAssociation data, Boolean byId)
        {
            base.SetQueryParameters(query, data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {

                //Determine if the boolean values ​​are taken included as part of the consultation
                //query.SetBoolean("Active",  data.Active);

                //add more parameters to method for query by any field

                if (data.MainStructure != null && data.MainStructure.Id != 0)
                    query.SetInt32("MainStructure", data.MainStructure.Id);
                if (data.ChildStructure != null && data.ChildStructure.Id != 0)
                    query.SetInt32("ChildStructure", data.ChildStructure.Id);
            }
        }

        public override void SaveOrUpdateDetails(CONStructureAssociation data)
        {
            base.SaveOrUpdateDetails(data);
        }

        public override void AddMoreDetailFindById(CONStructureAssociation data)
        {
        }

        public override CONStructureAssociation FindById(CONStructureAssociation data)
        {
            return base.FindById(data);
        }

        public override List<CONStructureAssociation> FindAll(CONStructureAssociation data, Options option)
        {
            return base.FindAll(data, option);
        }

    }
}