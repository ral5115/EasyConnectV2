using EasyConnect.Infrastructure.Entities;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains.Base
{
   public class BaseWSCONCESIONEBLL : IDomainLogic<WSCONCESIONE>
   {

      #region Ctor

      public BaseWSCONCESIONEBLL(IUnitOfWork settings)
      {
         Work = settings;
         CommitTransaction = false;
      }

      public BaseWSCONCESIONEBLL(DatabaseSetting settings)
      {
         Work = new UnitOfWork(settings);
         CommitTransaction = true;
      }

      #endregion

      #region Business Rules

      public override void CommonRules(WSCONCESIONE data)
      {
      if (String.IsNullOrWhiteSpace(data.RazonSocial))
         AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "RazonSocial");
      if (!String.IsNullOrWhiteSpace(data.RazonSocial) && data.RazonSocial.Length > 100)
         AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "RazonSocial", "100");
      if (!String.IsNullOrWhiteSpace(data.NomComercial) && data.NomComercial.Length > 50)
         AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "NomComercial", "50");
      if (!String.IsNullOrWhiteSpace(data.Cif) && data.Cif.Length > 20)
         AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Cif", "20");
      if (!String.IsNullOrWhiteSpace(data.Tratamiento) && data.Tratamiento.Length > 15)
         AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "Tratamiento", "15");
      }

      public override void AddRules(WSCONCESIONE data)
      {
         if (data == null)
            AddExceptionMessage(Language.DLTABLEVALUENULL, "WSCONCESIONE", "WS_CONCESIONES");
         if (data.Id != 0)
            AddExceptionMessage(Language.DLTABLEIDNULL, "WSCONCESIONE");
      }

      public override void ModifyRules(WSCONCESIONE data)
      {
         if (data == null)
            AddExceptionMessage(Language.DLTABLEVALUENULL, "WSCONCESIONE", "WS_CONCESIONES");
         if (data.Id == 0)
            AddExceptionMessage(Language.DLTABLEIDNOTNULL, "WSCONCESIONE");
      }

      public override void RemoveRules(WSCONCESIONE data)
      {
         if (data == null)
            AddExceptionMessage(Language.DLTABLEVALUENULL, "WSCONCESIONE", "WS_CONCESIONES");
         if (data.Id == 0)
            AddExceptionMessage(Language.DLTABLEIDNOTNULL, "WSCONCESIONE");
      }

      public override void FindByIdRules(WSCONCESIONE data)
      {
         if (data == null)
            AddExceptionMessage(Language.DLTABLEVALUENULL, "WSCONCESIONE", "WS_CONCESIONES");
         if (data.Id == 0)
            AddExceptionMessage(Language.DLTABLEIDNOTNULL, "WSCONCESIONE");
      }

      #endregion

   }
}
