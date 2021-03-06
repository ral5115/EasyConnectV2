using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using EasyTools.Infrastructure.Repositories.Base;
using NHibernate;
using System;
using System.Collections.Generic;

namespace EasyTools.Infrastructure.Repositories
{

    public class EXTFileOperaRepository : BaseEXTFileOperaRepository
    {

        public EXTFileOperaRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(EXTFileOpera data, Boolean byId)
        {
            String dml = base.GetQuery(data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {

                //add more parameters to method for query by any field


                dml += " order by a.Id asc ";
            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, EXTFileOpera data, Boolean byId)
        {
            base.SetQueryParameters(query, data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {


                //add more parameters to method for query by any field

            }
        }

        public override void SaveOrUpdateDetails(EXTFileOpera data)
        {
            base.SaveOrUpdateDetails(data);
        }

        public override void AddMoreDetailFindById(EXTFileOpera data)
        {
        }

        public override EXTFileOpera FindById(EXTFileOpera data)
        {
            return base.FindById(data);
        }

        public override List<EXTFileOpera> FindAll(EXTFileOpera data, Options option)
        {
            return base.FindAll(data, option);
        }

    }
}