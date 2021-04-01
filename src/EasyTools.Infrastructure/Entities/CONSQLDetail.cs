using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities
{
    /// <summary>
    /// CONSQLDetail object for mapped table CONSQLDetails.
    /// </summary>
    [DataContract(IsReference = true)]
    public class CONSQLDetail : BaseCONSQLDetail
    {

       public CONSQLDetail() : base()
       {
       }

       public CONSQLDetail(CONSQLDetail data, Options option) : base(data, option)
       {

          if (option == Options.Light || option == Options.Me || option == Options.All)
          {
             //OptionName.Light

             if (option == Options.Me || option == Options.All)
             {

                this.Equivalence = (data.Equivalence != null) ? new CONEquivalence(data.Equivalence, Options.Light) : null; 
                //this.MainSQLDetail = (data.MainSQLDetail != null) ? new CONSQLDetail(data.MainSQLDetail, Options.Light) : null; 
                this.SQL = (data.SQL != null) ? new CONSQL(data.SQL, Options.Light) : null; 
                this.StructureDetail = (data.StructureDetail != null) ? new CONStructureDetail(data.StructureDetail, Options.Light) : null; 
             }
          }
       }

       [DataMember]
       public virtual CONEquivalence Equivalence { get; set; }

       //[DataMember]
       //public virtual CONSQLDetail MainSQLDetail { get; set; }

       [DataMember]
       public virtual CONSQL SQL { get; set; }

       [DataMember]
       public virtual CONStructureDetail StructureDetail { get; set; }

       [DataMember]
       public virtual List<CONSQLDetail> Entities { get; set; }

       //[DataMember]
       //public virtual List<CONSQLDetail> MainSQLDetails { get; set; }

       public override Int32 GetHashCode()
       {
           return this.Id.GetHashCode();
       }

       public override Boolean Equals(object obj)
       {
           if ((obj == null) || (obj.GetType() != this.GetType()))
               return false;
           CONSQLDetail castObj = (CONSQLDetail)obj;
           return (castObj != null) && (this.Id == castObj.Id);
       }
    }
 }
