using EasyTools.Infrastructure.Entities;
using EasyTools.UI.WPF.EasyConnect.Module.ViewModels.Base;
using EasyTools.UI.WPF.EasyConnect.Module.Views;
using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.Practices.Unity;

namespace EasyTools.UI.WPF.EasyConnect.Module.ViewModels
{
   public class CONEquivalenceViewModel : BaseCONEquivalenceViewModel
   {

      public CONEquivalenceViewModel(IUnityContainer container,CONEquivalenceView view)  : base(container, view)
      {
      }

      public override void RegisterPermisions()
      {
         base.RegisterPermisions();

         //Register additional permission here!!!.
      }

      #region Commands

      public override void NewAction()
      {
         base.NewAction();

         //Register new actions here!!!.
      }

      public override void SaveAction(bool createNew)
      {
         base.SaveAction(createNew);

         //Register new actions here!!!.
      }

      public override void DeleteAction()
      {
         base.DeleteAction();

         //Register new actions here!!!.
      }

      public override void FindAction()
      {
         base.FindAction();

         //Register new actions here!!!.
      }

      #endregion

      #region Events

      public override void OnDataGridDetailSelectionChange(object sender, DataEventArgs<CONEquivalence> e)
      {
         base.OnDataGridDetailSelectionChange(sender, e);

            //Register new actions here!!!.
            if (Model.EquivalenceDetails == null)
            {
                Model.EquivalenceDetails = new System.ComponentModel.BindingList<CONEquivalenceDetail>();
            }
            
            
      }

      #endregion
   }

}
