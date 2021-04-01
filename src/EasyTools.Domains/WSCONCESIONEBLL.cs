using EasyConnect.Infrastructure.Entities;
using EasyTools.Domains.Base;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains
{
   public class WSCONCESIONEBLL : BaseWSCONCESIONEBLL
   {
      #region Ctor

      public WSCONCESIONEBLL(IUnitOfWork settings)
      : base(settings)
      {
      }

      public WSCONCESIONEBLL(DatabaseSetting settings)
      : base(settings)
      {
      }

      #endregion

      #region CRUD Methods

      public override WSCONCESIONE Execute(WSCONCESIONE data, Actions action, Options option, string Token)
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

      //public override void SaveOrUpdateDetails(WSCONCESIONE data)
      //{
      //}

      //public override void RemoveDetails(WSCONCESIONE data)
      //{
      //}

      #endregion

      #region Query Methods

      //public override void AddFindByIdDetails(WSCONCESIONE data)
      //{
      //   //base.AddFindByIdDetails(data);
      //}

      #endregion

      #region Business Rules

      public override void CommonRules(WSCONCESIONE data)
      {
         base.CommonRules(data);
      }

      public override void AddRules(WSCONCESIONE data)
      {
         base.AddRules(data);
         data.LastUpdate = DateTime.Now;
      }

      public override void ModifyRules(WSCONCESIONE data)
      {
         base.ModifyRules(data);
         data.LastUpdate = DateTime.Now;
      }

      public override void RemoveRules(WSCONCESIONE data)
      {
         base.RemoveRules(data);
      }

      public override void FindByIdRules(WSCONCESIONE data)
      {
         base.FindByIdRules(data);
      }

      #endregion

      #region Custom Methods

      #endregion

   }
}
