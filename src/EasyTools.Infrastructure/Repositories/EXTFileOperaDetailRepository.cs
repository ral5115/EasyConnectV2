using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using EasyTools.Infrastructure.Repositories.Base;
using NHibernate;
using System;
using System.Collections.Generic;

namespace EasyTools.Infrastructure.Repositories
{

    public class EXTFileOperaDetailRepository : BaseEXTFileOperaDetailRepository
    {

        public EXTFileOperaDetailRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(EXTFileOperaDetail data, Boolean byId)
        {
            String dml = base.GetQuery(data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {

                //add more parameters to method for query by any field

                if (data.FileOpera != null && data.FileOpera.Id != 0)
                    dml += "             AND a.FileOpera.Id = :FileOpera \n";

                dml += " order by a.Id asc ";
            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, EXTFileOperaDetail data, Boolean byId)
        {
            base.SetQueryParameters(query, data, byId);
            if (byId)
            {
                //add more parameters to method for query by id
            }
            else
            {


                //add more parameters to method for query by any field

                if (data.FileOpera != null && data.FileOpera.Id != 0)
                    query.SetInt32("FileOpera", data.FileOpera.Id);
            }
        }

        public override void SaveOrUpdateDetails(EXTFileOperaDetail data)
        {
            base.SaveOrUpdateDetails(data);
        }

        public override void AddMoreDetailFindById(EXTFileOperaDetail data)
        {
        }

        public override EXTFileOperaDetail FindById(EXTFileOperaDetail data)
        {
            return base.FindById(data);
        }

        public override List<EXTFileOperaDetail> FindAll(EXTFileOperaDetail data, Options option)
        {
            return base.FindAll(data, option);
        }

    }
}