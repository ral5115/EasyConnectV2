
using EasyConnect.Infrastructure.Entities;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyConnect.Infrastructure.Repositories.Base
{

   public class BaseWSCONCESIONESTIENDARepository : BaseRepository<WSCONCESIONESTIENDA>
   {

      public BaseWSCONCESIONESTIENDARepository(IUnitOfWork context) : base(context)
      {
      }

        public override String GetQuery(WSCONCESIONESTIENDA data, Boolean byId)
        {
           String dml = "Select a from WSCONCESIONESTIENDA as a where 1=1 ";
           if (byId)
           {
              if (  data.Id != 0 )
                 dml += "             AND a.Id = :Id \n" ;
           }
           else
           {
              if (  data.Id != 0 )
                 dml += "             AND a.Id = :Id \n" ;
              if (  data.IdConcesion != 0 )
                         dml += "             AND a.IdConcesion = :IdConcesion \n" ;
              if (  !String.IsNullOrWhiteSpace(data.IdTienda) )
                         dml += "             AND upper(a.IdTienda) like :IdTienda \n" ;
              if (  !String.IsNullOrWhiteSpace(data.NickName) )
                         dml += "             AND upper(a.NickName) like :NickName \n" ;
              if (data.FechaAlta != null && data.FechaAlta != DateTime.MinValue)
                         dml += "             AND a.FechaAlta like :FechaAlta \n" ;
              if ( data.CreationDate !=null && data.CreationDate != DateTime.MinValue )
                         dml += "             AND a.CreationDate = :CreationDate \n" ;

           }
           return dml;
        }

        public override void SetQueryParameters(IQuery query, WSCONCESIONESTIENDA data, Boolean byId)
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
              if (  data.IdConcesion != 0 )
                 query.SetInt32("IdConcesion",  data.IdConcesion);
              if (  !String.IsNullOrWhiteSpace(data.IdTienda) )
                 query.SetString("IdTienda",  "%" + data.IdTienda.ToUpper() + "%" );
              if (  !String.IsNullOrWhiteSpace(data.NickName) )
                 query.SetString("NickName",  "%" + data.NickName.ToUpper() + "%" );
              if (data.FechaAlta != null && data.FechaAlta != DateTime.MinValue)
                 query.SetDateTime("FechaAlta", (DateTime)data.FechaAlta);
              if (  data.CreationDate != null && data.CreationDate != DateTime.MinValue )
                 query.SetDateTime("CreationDate", (DateTime) data.CreationDate);
           }
        }

      public override WSCONCESIONESTIENDA FindById(WSCONCESIONESTIENDA data)
      {
         IQuery query = work.Session.CreateQuery(GetQuery(data, true));
         SetQueryParameters(query, data, true);
         data = query.UniqueResult<WSCONCESIONESTIENDA>();
         if (data != null)
            data = new WSCONCESIONESTIENDA(data, Options.Me);
         return data;
      }

      public override List<WSCONCESIONESTIENDA> FindAll(WSCONCESIONESTIENDA data, Options option)
      {
         IQuery query = work.Session.CreateQuery(GetQuery(data, false));
         SetQueryParameters(query, data, false);
         if (data.HasPaging)
         {
            query.SetFirstResult((data.PageSize * data.CurrentPage) - data.PageSize);
            query.SetMaxResults(data.PageSize);
         }
         return (from a in query.List<WSCONCESIONESTIENDA>() select new WSCONCESIONESTIENDA(a, option)).ToList<WSCONCESIONESTIENDA>();
      }

        public override void SaveOrUpdateDetails(WSCONCESIONESTIENDA data)
        {
            //throw new NotImplementedException();
        }

        public override void AddMoreDetailFindById(WSCONCESIONESTIENDA data)
        {
            //throw new NotImplementedException();
        }
    }
}
