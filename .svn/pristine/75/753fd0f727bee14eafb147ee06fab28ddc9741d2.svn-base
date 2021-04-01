using EasyTools.Framework.Data;
using System;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities.Base
{
    /// <summary>
    /// SECMenu object for mapped table SECMenus.
    /// </summary>
    [DataContract(IsReference = true)]
    public class BaseSECMenu : BaseEntity
    {

       public BaseSECMenu()
       {
       }

       public BaseSECMenu(BaseSECMenu data, Options option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light
             this.Id = data.Id;
                this.Code = data.Code;
                this.Name = data.Name;
                this.Active = data.Active;

             if (option == Options.Me || option == Options.All)
             {

                this.Code = data.Code;
                this.Name = data.Name;
                this.Active = data.Active;
                this.Option1 = data.Option1;
                this.Option2 = data.Option2;
                this.Option3 = data.Option3;
                this.Option4 = data.Option4;
                this.Option5 = data.Option5;
                this.Option6 = data.Option6;
                this.Option7 = data.Option7;
                this.Option8 = data.Option8;
                this.Option9 = data.Option9;
                this.Option10 = data.Option10;
                this.UpdatedBy = data.UpdatedBy;
                this.LastUpdate = data.LastUpdate;
             }
          }
       }

       [DataMember]
       public virtual String Code { get; set; }

       [DataMember]
       public virtual String Name { get; set; }

       [DataMember]
       public virtual Boolean Active { get; set; }

       [DataMember]
       public virtual String Option1 { get; set; }

       [DataMember]
       public virtual String Option2 { get; set; }

       [DataMember]
       public virtual String Option3 { get; set; }

       [DataMember]
       public virtual String Option4 { get; set; }

       [DataMember]
       public virtual String Option5 { get; set; }

       [DataMember]
       public virtual String Option6 { get; set; }

       [DataMember]
       public virtual String Option7 { get; set; }

       [DataMember]
       public virtual String Option8 { get; set; }

       [DataMember]
       public virtual String Option9 { get; set; }

       [DataMember]
       public virtual String Option10 { get; set; }


    }
 }
