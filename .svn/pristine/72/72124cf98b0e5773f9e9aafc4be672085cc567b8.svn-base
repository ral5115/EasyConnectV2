
using EasyConnect.Infrastructure.Entities;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyConnect.Infrastructure.Repositories.Base
{

   public class BaseWSCONCESIONERepository : BaseRepository<WSCONCESIONE>
   {

      public BaseWSCONCESIONERepository(IUnitOfWork context) : base(context)
      {
      }

        public override String GetQuery(WSCONCESIONE data, Boolean byId)
        {
           String dml = "Select a from WSCONCESIONE as a where 1=1 ";
           if (byId)
           {
              if (  data.Id != 0 )
                 dml += "             AND a.Id = :Id \n" ;
           }
           else
           {
              if (  data.Id != 0 )
                 dml += "             AND a.Id = :Id \n" ;
              if (  !String.IsNullOrWhiteSpace(data.RazonSocial) )
                         dml += "             AND upper(a.RazonSocial) like :RazonSocial \n" ;
              if (  !String.IsNullOrWhiteSpace(data.NomComercial) )
                         dml += "             AND upper(a.NomComercial) like :NomComercial \n" ;
              if (  !String.IsNullOrWhiteSpace(data.Cif) )
                         dml += "             AND upper(a.Cif) like :Cif \n" ;
              if ( data.FechaAlta !=null && data.FechaAlta != DateTime.MinValue )
                         dml += "             AND a.FechaAlta = :FechaAlta \n" ;
              if ( data.FechaBaja !=null && data.FechaBaja != DateTime.MinValue )
                         dml += "             AND a.FechaBaja = :FechaBaja \n" ;
              if (  !String.IsNullOrWhiteSpace(data.Tratamiento) )
                         dml += "             AND upper(a.Tratamiento) like :Tratamiento \n" ;
              if ( data.FechaModificacion !=null && data.FechaModificacion != DateTime.MinValue )
                         dml += "             AND a.FechaModificacion = :FechaModificacion \n" ;

           }
           return dml;
        }

        public override void SetQueryParameters(IQuery query, WSCONCESIONE data, Boolean byId)
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
              if (  !String.IsNullOrWhiteSpace(data.RazonSocial) )
                 query.SetString("RazonSocial",  "%" + data.RazonSocial.ToUpper() + "%" );
              if (  !String.IsNullOrWhiteSpace(data.NomComercial) )
                 query.SetString("NomComercial",  "%" + data.NomComercial.ToUpper() + "%" );
              if (  !String.IsNullOrWhiteSpace(data.Cif) )
                 query.SetString("Cif",  "%" + data.Cif.ToUpper() + "%" );
              if (  data.FechaAlta != null && data.FechaAlta != DateTime.MinValue )
                 query.SetDateTime("FechaAlta", (DateTime) data.FechaAlta);
              if (  data.FechaBaja != null && data.FechaBaja != DateTime.MinValue )
                 query.SetDateTime("FechaBaja", (DateTime) data.FechaBaja);
              if (  !String.IsNullOrWhiteSpace(data.Tratamiento) )
                 query.SetString("Tratamiento",  "%" + data.Tratamiento.ToUpper() + "%" );
              if (  data.FechaModificacion != null && data.FechaModificacion != DateTime.MinValue )
                 query.SetDateTime("FechaModificacion", (DateTime) data.FechaModificacion);
           }
        }

      public override WSCONCESIONE FindById(WSCONCESIONE data)
      {
         IQuery query = work.Session.CreateQuery(GetQuery(data, true));
         SetQueryParameters(query, data, true);
         data = query.UniqueResult<WSCONCESIONE>();
         if (data != null)
            data = new WSCONCESIONE(data, Options.Me);
         return data;
      }

      public override List<WSCONCESIONE> FindAll(WSCONCESIONE data, Options option)
      {
         IQuery query = work.Session.CreateQuery(GetQuery(data, false));
         SetQueryParameters(query, data, false);
         if (data.HasPaging)
         {
            query.SetFirstResult((data.PageSize * data.CurrentPage) - data.PageSize);
            query.SetMaxResults(data.PageSize);
         }
         return (from a in query.List<WSCONCESIONE>() select new WSCONCESIONE(a, option)).ToList<WSCONCESIONE>();
      }

        public override void SaveOrUpdateDetails(WSCONCESIONE data)
        {
            //throw new NotImplementedException();
        }

        public override void AddMoreDetailFindById(WSCONCESIONE data)
        {
            //throw new NotImplementedException();
        }
    }
}
