using EasyConnect.Infrastructure.Entities;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains.Base
{
    public class BaseCONWSEquivalenciasFormasPagoBLL : IDomainLogic<CONWSEquivalenciasFormasPago>
   {

      #region Ctor

      public BaseCONWSEquivalenciasFormasPagoBLL(IUnitOfWork settings)
      {
         Work = settings;
         CommitTransaction = false;
      }

      public BaseCONWSEquivalenciasFormasPagoBLL(DatabaseSetting settings)
      {
         Work = new UnitOfWork(settings);
         CommitTransaction = true;
      }

      #endregion

      #region Business Rules

      public override void CommonRules(CONWSEquivalenciasFormasPago data)
      {
      if (!String.IsNullOrWhiteSpace(data.FormaPagoZapa) && data.FormaPagoZapa.Length > 50)
         AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "FormaPagoZapa", "50");
      if (!String.IsNullOrWhiteSpace(data.FPagoDet_Zapa) && data.FPagoDet_Zapa.Length > 50)
         AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "FPagoDet_Zapa", "50");
      if (!String.IsNullOrWhiteSpace(data.FormaPagoUNOEE) && data.FormaPagoUNOEE.Length > 50)
         AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "FormaPagoUNOEE", "50");
      if (!String.IsNullOrWhiteSpace(data.RefFP) && data.RefFP.Length > 50)
         AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "RefFP", "50");
      if (!String.IsNullOrWhiteSpace(data.CuentaContable) && data.CuentaContable.Length > 50)
         AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "CuentaContable", "50");
      }

      public override void AddRules(CONWSEquivalenciasFormasPago data)
      {
         if (data == null)
            AddExceptionMessage(Language.DLTABLEVALUENULL, "CONWSEquivalenciasFormasPago", "WS_Equivalencias_Formas_Pago");
         if (data.Id != 0)
             AddExceptionMessage(Language.DLTABLEIDNULL, "CONWSEquivalenciasFormasPago");
      }

      public override void ModifyRules(CONWSEquivalenciasFormasPago data)
      {
         if (data == null)
            AddExceptionMessage(Language.DLTABLEVALUENULL, "WSEquivalenciasFormasPago", "WS_Equivalencias_Formas_Pago");
         if (data.Id == 0)
            AddExceptionMessage(Language.DLTABLEIDNOTNULL, "WSEquivalenciasFormasPago");
      }

      public override void RemoveRules(CONWSEquivalenciasFormasPago data)
      {
         if (data == null)
             AddExceptionMessage(Language.DLTABLEVALUENULL, "CONWSEquivalenciasFormasPago", "WS_Equivalencias_Formas_Pago");
         if (data.Id == 0)
             AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONWSEquivalenciasFormasPago");
      }

      public override void FindByIdRules(CONWSEquivalenciasFormasPago data)
      {
         if (data == null)
             AddExceptionMessage(Language.DLTABLEVALUENULL, "CONWSEquivalenciasFormasPago", "WS_Equivalencias_Formas_Pago");
         if (data.Id == 0)
             AddExceptionMessage(Language.DLTABLEIDNOTNULL, "CONWSEquivalenciasFormasPago");
      }

      #endregion

   }
}
