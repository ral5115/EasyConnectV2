using EasyConnect.Infrastructure.Entities;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains.Base
{
   public class BaseWSCONCESIONESTIENDABLL : IDomainLogic<WSCONCESIONESTIENDA>
   {

      #region Ctor

      public BaseWSCONCESIONESTIENDABLL(IUnitOfWork settings)
      {
         Work = settings;
         CommitTransaction = false;
      }

      public BaseWSCONCESIONESTIENDABLL(DatabaseSetting settings)
      {
         Work = new UnitOfWork(settings);
         CommitTransaction = true;
      }

      #endregion

      #region Business Rules

      public override void CommonRules(WSCONCESIONESTIENDA data)
      {
      if (String.IsNullOrWhiteSpace(data.IdTienda))
         AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "IdTienda");
      if (!String.IsNullOrWhiteSpace(data.IdTienda) && data.IdTienda.Length > 10)
         AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "IdTienda", "10");
      if (!String.IsNullOrWhiteSpace(data.NickName) && data.NickName.Length > 40)
         AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "NickName", "40");
      //if (!String.IsNullOrWhiteSpace(data.FechaAlta) && data.FechaAlta.Length > 50)
      //   AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "FechaAlta", "50");
      }

      public override void AddRules(WSCONCESIONESTIENDA data)
      {
         if (data == null)
            AddExceptionMessage(Language.DLTABLEVALUENULL, "WSCONCESIONESTIENDA", "WS_CONCESIONES_TIENDAS");
         if (data.Id != 0)
            AddExceptionMessage(Language.DLTABLEIDNULL, "WSCONCESIONESTIENDA");
      }

      public override void ModifyRules(WSCONCESIONESTIENDA data)
      {
         if (data == null)
            AddExceptionMessage(Language.DLTABLEVALUENULL, "WSCONCESIONESTIENDA", "WS_CONCESIONES_TIENDAS");
         if (data.Id == 0)
            AddExceptionMessage(Language.DLTABLEIDNOTNULL, "WSCONCESIONESTIENDA");
      }

      public override void RemoveRules(WSCONCESIONESTIENDA data)
      {
         if (data == null)
            AddExceptionMessage(Language.DLTABLEVALUENULL, "WSCONCESIONESTIENDA", "WS_CONCESIONES_TIENDAS");
         if (data.Id == 0)
            AddExceptionMessage(Language.DLTABLEIDNOTNULL, "WSCONCESIONESTIENDA");
      }

      public override void FindByIdRules(WSCONCESIONESTIENDA data)
      {
         if (data == null)
            AddExceptionMessage(Language.DLTABLEVALUENULL, "WSCONCESIONESTIENDA", "WS_CONCESIONES_TIENDAS");
         if (data.Id == 0)
            AddExceptionMessage(Language.DLTABLEIDNOTNULL, "WSCONCESIONESTIENDA");
      }

      #endregion

   }
}
