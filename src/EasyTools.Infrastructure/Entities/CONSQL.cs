using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities
{
    /// <summary>
    /// CONSQL object for mapped table CONSQLs.
    /// </summary>
    [DataContract(IsReference = true)]
    public class CONSQL : BaseCONSQL
    {

        public CONSQL()
            : base()
        {
        }

        public CONSQL(CONSQL data, Options option)
            : base(data, option)
        {

            if (option == Options.Light || option == Options.Me || option == Options.All)
            {
                //OptionName.Light

                if (option == Options.Me || option == Options.All)
                {

                    this.Connection = (data.Connection != null) ? new SECConnection(data.Connection, Options.Light) : null;
                    this.StoreProcedureConnection = (data.StoreProcedureConnection != null) ? new SECConnection(data.StoreProcedureConnection, Options.Light) : null;
                    //this.DestinyConnection = (data.DestinyConnection != null) ? new SECConnection(data.DestinyConnection, Options.Light) : null;
                    this.Company = (data.Company != null) ? new SECCompany(data.Company, Options.Light) : null;
                    this.MainSQL = (data.MainSQL != null) ? new CONSQL(data.MainSQL, Options.Light) : null;
                    this.Structure = (data.Structure != null) ? new CONStructure(data.Structure, Options.Light) : null;
                }
            }
        }

        [DataMember]
        public virtual SECConnection Connection { get; set; }

        [DataMember]
        public virtual SECConnection StoreProcedureConnection { get; set; }

        //[DataMember]
        //public virtual SECConnection DestinyConnection { get; set; }

        [DataMember]
        public virtual SECCompany Company { get; set; }

        [DataMember]
        public virtual CONSQL MainSQL { get; set; }

        [DataMember]
        public virtual CONStructure Structure { get; set; }

        [DataMember]
        public virtual List<CONSQL> Entities { get; set; }

        [DataMember]
        public virtual List<CONRecordDetail> RecordDetails { get; set; }

        [DataMember]
        public virtual List<CONRecord> Records { get; set; }

        [DataMember]
        public virtual List<CONSQLDetail> SQLDetails { get; set; }

        [DataMember]
        public virtual List<CONSQLParameter> SQLParameters { get; set; }

        [DataMember]
        public virtual List<CONSQL> ChildSQLs { get; set; }

        [DataMember]
        public virtual List<CONSQLSend> SQLSends { get; set; }

        public override Int32 GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override Boolean Equals(object obj)
        {
            if ((obj == null) || (obj.GetType() != this.GetType()))
                return false;
            CONSQL castObj = (CONSQL)obj;
            return (castObj != null) && (this.Id == castObj.Id);
        }

    }
}