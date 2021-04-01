using EasyConnect.Infrastructure.Entities;
using EasyTools.Domains.Base;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains
{
   public class CONWSEquivalenciasFormasPagoBLL : BaseCONWSEquivalenciasFormasPagoBLL
   {
      #region Ctor

      public CONWSEquivalenciasFormasPagoBLL(IUnitOfWork settings)
      : base(settings)
      {
      }

      public CONWSEquivalenciasFormasPagoBLL(DatabaseSetting settings)
      : base(settings)
      {
      }

      #endregion

      #region CRUD Methods

      public CONWSEquivalenciasFormasPago Execute(CONWSEquivalenciasFormasPago data, Actions action, Options option, String token)
      {
         if (action == Actions.Add || action == Actions.Modify || action == Actions.Remove || (action == Actions.Find && (option == Options.Me || option == Options.Exist)))
         {
            data = base.Execute(data, action, option, "");
            return data;
         }
         else if (action == Actions.Find && (option == Options.All || option == Options.Light))
         {
            data.Entities = FindAll(data, option);
            return data;
         }
         else
            throw new NotImplementedException(GetLocalizedMessage(Language.DLACTIONNOTIMPLEMENT, action.ToString(), option.ToString()));
      }

      //public override void SaveOrUpdateDetails(CONWSEquivalenciasFormasPago data)
      //{
      //}

      //public override void RemoveDetails(CONWSEquivalenciasFormasPago data)
      //{
      //}

      #endregion

      #region Query Methods

      //public override void AddFindByIdDetails(CONWSEquivalenciasFormasPago data)
      //{
      //   //base.AddFindByIdDetails(data);
      //}

      #endregion

      #region Business Rules

      public override void CommonRules(CONWSEquivalenciasFormasPago data)
      {
         base.CommonRules(data);
      }

      public override void AddRules(CONWSEquivalenciasFormasPago data)
      {
         base.AddRules(data);
         data.LastUpdate = DateTime.Now;
      }

      public override void ModifyRules(CONWSEquivalenciasFormasPago data)
      {
         base.ModifyRules(data);
         data.LastUpdate = DateTime.Now;
      }

      public override void RemoveRules(CONWSEquivalenciasFormasPago data)
      {
         base.RemoveRules(data);
      }

      public override void FindByIdRules(CONWSEquivalenciasFormasPago data)
      {
         base.FindByIdRules(data);
      }

      #endregion

      #region Custom Methods

      #endregion

   }
}
