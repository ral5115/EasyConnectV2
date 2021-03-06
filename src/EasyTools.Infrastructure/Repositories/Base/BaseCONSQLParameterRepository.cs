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

   public class BaseCONSQLParameterRepository : BaseRepository<CONSQLParameter>
   {

      public BaseCONSQLParameterRepository(IUnitOfWork context) : base(context)
      {
      }


        public override String GetQuery(CONSQLParameter data, Boolean byId)
        {
           String dml = "Select a from CONSQLParameter as a where 1=1 ";
           if (byId)
           {
              if (  data.Id != 0 )
                 dml += "             AND a.Id = :Id \n" ;
           }
           else
           {
              if (  data.Id != 0 )
                 dml += "             AND a.Id = :Id \n" ;
              if (  !String.IsNullOrWhiteSpace(data.Name) )
                         dml += "             AND upper(a.Name) like :Name \n" ;
              if ( data.DateValue !=null && data.DateValue != DateTime.MinValue )
                         dml += "             AND a.DateValue = :DateValue \n" ;
              if (data.DefaultDateValue != null && data.DefaultDateValue != 0 )
                         dml += "             AND a.DefaultDateValue = :DefaultDateValue \n" ;
              if (data.Int32Value != null && data.Int32Value != 0 )
                         dml += "             AND a.Int32Value = :Int32Value \n" ;
              if (  !String.IsNullOrWhiteSpace(data.StringValue) )
                         dml += "             AND upper(a.StringValue) like :StringValue \n" ;
              if (  data.Secuence != 0 )
                         dml += "             AND a.Secuence = :Secuence \n" ;
              if (  data.SQLId != 0 )
                         dml += "             AND a.SQLId = :SQLId \n" ;

           }
           return dml;
        }

        public override void SetQueryParameters(IQuery query, CONSQLParameter data, Boolean byId)
        {
           if (byId)
           {
              if (  data.Id != 0 )
                 query.SetInt32("Id", data.Id);
           }
           else
           {
              if (  data.Id != 0 )
                 query.SetInt32("Id", data.Id);
              if (  !String.IsNullOrWhiteSpace(data.Name) )
                 query.SetString("Name",  "%" + data.Name.ToUpper() + "%" );
              if (  data.DateValue != null && data.DateValue != DateTime.MinValue )
                 query.SetDateTime("DateValue", (DateTime) data.DateValue);
              if (data.DefaultDateValue != null && data.DefaultDateValue != 0 )
                 query.SetInt16("DefaultDateValue", (Int16) data.DefaultDateValue);
              if (data.Int32Value != null && data.Int32Value != 0 )
                 query.SetInt32("Int32Value", (Int32) data.Int32Value);
              if (  !String.IsNullOrWhiteSpace(data.StringValue) )
                 query.SetString("StringValue",  "%" + data.StringValue.ToUpper() + "%" );
              if (  data.Secuence != 0 )
                 query.SetInt16("Secuence",  data.Secuence);
              if (  data.SQLId != 0 )
                 query.SetInt32("SQLId",  data.SQLId);
           }
        }

        public override void SaveOrUpdateDetails(CONSQLParameter data)
        {
        }

        public override void AddMoreDetailFindById(CONSQLParameter data)
        {
        }

        public override CONSQLParameter FindById(CONSQLParameter data)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, true));
            SetQueryParameters(query, data, true);
            data = query.UniqueResult<CONSQLParameter>();
            if (data != null)
            {
                data = new CONSQLParameter(data, Options.Me);
                AddMoreDetailFindById(data);
            }
            return data;
        }

        public override List<CONSQLParameter> FindAll(CONSQLParameter data, Options option)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, false));
            SetQueryParameters(query, data, false);
            if (data.HasPaging)
            {
                query.SetFirstResult((data.PageSize * data.CurrentPage) - data.PageSize);
                query.SetMaxResults(data.PageSize);
            }
            return (from a in query.List<CONSQLParameter>() select new CONSQLParameter(a, option)).ToList<CONSQLParameter>();
        }

   }
}
