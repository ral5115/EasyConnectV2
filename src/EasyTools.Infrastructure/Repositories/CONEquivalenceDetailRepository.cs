using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using EasyTools.Infrastructure.Repositories.Base;
using NHibernate;
using System;
using System.Collections.Generic;

namespace EasyTools.Infrastructure.Repositories
{

    public class CONEquivalenceDetailRepository : BaseCONEquivalenceDetailRepository
    {

        public CONEquivalenceDetailRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(CONEquivalenceDetail data, Boolean byId)
        {
            String dml = base.GetQuery(data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {

                //add more parameters to method for query by any field

                if (data.Equivalence != null && data.Equivalence.Id != 0)
                    dml += "             AND a.Equivalence.Id = :Equivalence \n";

                dml += " order by a.Id asc ";
            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, CONEquivalenceDetail data, Boolean byId)
        {
            base.SetQueryParameters(query, data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {


                //add more parameters to method for query by any field

                if (data.Equivalence != null && data.Equivalence.Id != 0)
                    query.SetInt32("Equivalence", data.Equivalence.Id);
            }
        }

        public override void SaveOrUpdateDetails(CONEquivalenceDetail data)
        {
            base.SaveOrUpdateDetails(data);
        }

        public override void AddMoreDetailFindById(CONEquivalenceDetail data)
        {
        }

        public override CONEquivalenceDetail FindById(CONEquivalenceDetail data)
        {
            return base.FindById(data);
        }

        public override List<CONEquivalenceDetail> FindAll(CONEquivalenceDetail data, Options option)
        {
            return base.FindAll(data, option);
        }

    }
}