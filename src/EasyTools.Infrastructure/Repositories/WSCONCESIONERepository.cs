
using EasyConnect.Infrastructure.Entities;
using EasyConnect.Infrastructure.Repositories.Base;
using EasyTools.Framework.Persistance;
using NHibernate;
using System;

namespace EasyConnect.Infrastructure.Repositories
{

   public class WSCONCESIONERepository : BaseWSCONCESIONERepository
   {

      public WSCONCESIONERepository(IUnitOfWork context) : base(context)
      {
      }

        public override String GetQuery(WSCONCESIONE data, Boolean byId)
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

        public override void SetQueryParameters(IQuery query, WSCONCESIONE data, Boolean byId)
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

   }
}
