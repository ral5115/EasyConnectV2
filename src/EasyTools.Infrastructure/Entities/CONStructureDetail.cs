using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities
{
    /// <summary>
    /// CONStructureDetail object for mapped table CONStructureDetails.
    /// </summary>
    [DataContract(IsReference = true)]
    public class CONStructureDetail : BaseCONStructureDetail
    {

       public CONStructureDetail() : base()
       {
       }

       public CONStructureDetail(CONStructureDetail data, Options option) : base(data, option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light

             if (option == Options.Me || option == Options.All)
             {

                this.Structure = (data.Structure != null) ? new CONStructure(data.Structure, Options.Light) : null; 
             }
          }
       }

       [DataMember]
       public virtual CONStructure Structure { get; set; }

       [DataMember]
       public virtual List<CONStructureDetail> Entities { get; set; }

       [DataMember]
       public virtual List<CONSQLDetail> SQLDetails { get; set; }

       public override Int32 GetHashCode()
       {
           return this.Id.GetHashCode();
       }

       public override Boolean Equals(object obj)
       {
           if ((obj == null) || (obj.GetType() != this.GetType()))
               return false;
           CONStructureDetail castObj = (CONStructureDetail)obj;
           return (castObj != null) && (this.Id == castObj.Id);
       }
    }
 }
