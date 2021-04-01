using EasyConnect.Infrastructure.Entities;
using EasyTools.Domains.Base;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains
{
   public class WSCONCESIONESTIENDABLL : BaseWSCONCESIONESTIENDABLL
   {
      #region Ctor

      public WSCONCESIONESTIENDABLL(IUnitOfWork settings)
      : base(settings)
      {
      }

      public WSCONCESIONESTIENDABLL(DatabaseSetting settings)
      : base(settings)
      {
      }

      #endregion

      #region CRUD Methods

      public override WSCONCESIONESTIENDA Execute(WSCONCESIONESTIENDA data, Actions action, Options option, string token)
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

      //public override void SaveOrUpdateDetails(WSCONCESIONESTIENDA data)
      //{
      //}

      //public override void RemoveDetails(WSCONCESIONESTIENDA data)
      //{
      //}

      #endregion

      #region Query Methods

      //public override void AddFindByIdDetails(WSCONCESIONESTIENDA data)
      //{
      //   //base.AddFindByIdDetails(data);
      //}

      #endregion

      #region Business Rules

      public override void CommonRules(WSCONCESIONESTIENDA data)
      {
         base.CommonRules(data);
      }

      public override void AddRules(WSCONCESIONESTIENDA data)
      {
         base.AddRules(data);
         data.LastUpdate = DateTime.Now;
      }

      public override void ModifyRules(WSCONCESIONESTIENDA data)
      {
         base.ModifyRules(data);
         data.LastUpdate = DateTime.Now;
      }

      public override void RemoveRules(WSCONCESIONESTIENDA data)
      {
         base.RemoveRules(data);
      }

      public override void FindByIdRules(WSCONCESIONESTIENDA data)
      {
         base.FindByIdRules(data);
      }

      #endregion

      #region Custom Methods

      #endregion

   }
}
