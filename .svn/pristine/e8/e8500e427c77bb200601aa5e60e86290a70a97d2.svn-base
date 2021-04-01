using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities
{
    /// <summary>
    /// CONRecordDetail object for mapped table CONRecordDetails.
    /// </summary>
    [DataContract(IsReference = true)]
    public class CONRecordDetail : BaseCONRecordDetail
    {

        public CONRecordDetail()
            : base()
        {
        }

        public CONRecordDetail(CONRecordDetail data, Options option)
            : base(data, option)
        {

            if (option == Options.Light || option == Options.Me || option == Options.All)
            {
                //OptionName.Light

                if (option == Options.Me || option == Options.All)
                {
                    this.RecordNumber = data.RecordNumber;
                    this.DocumentNumber = data.DocumentNumber;
                    this.Fields = XMLSerializer.DeserializeFromString<Dictionary<string, string>>(data.XMLData);
                    this.SQL = (data.SQL != null) ? new CONSQL(data.SQL, Options.Light) : null;
                    this.Record = (data.Record != null) ? new CONRecord(data.Record, Options.Light) : null;
                }
            }
        }

        [DataMember]
        public virtual CONSQL SQL { get; set; }

        [DataMember]
        public virtual CONRecord Record { get; set; }

        [DataMember]
        public virtual List<CONRecordDetail> Entities { get; set; }

        public override Int32 GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override Boolean Equals(object obj)
        {
            if ((obj == null) || (obj.GetType() != this.GetType()))
                return false;
            CONRecordDetail castObj = (CONRecordDetail)obj;
            return (castObj != null) && (this.Id == castObj.Id);
        }

        [DataMember]
        public virtual Dictionary<string, string> Fields { get; set; }

        public virtual void GetPlaintText()
        {
            if (this.Fields != null && this.Fields.Count > 0)
            {
                PlainText = "";
                foreach (var item in Fields)
                {
                    PlainText += item.Value;
                }
            }
        }

        private int? recordNumber;

        [DataMember]
        public virtual int? RecordNumber
        {
            get
            {
                return recordNumber;
            }
            set
            {
                recordNumber = value;
                for (int i = 0; i < CONRecord.GetRecordNumberKeys().Count; i++)
                {
                    if (Fields != null && Fields.ContainsKey(CONRecord.GetRecordNumberKeys()[i]))
                    {
                        Fields[CONRecord.GetRecordNumberKeys()[i]] = Utils.ValidateNumber(recordNumber, 7, CONRecord.GetRecordNumberKeys()[i]);
                        PlainText = "";
                        foreach (var item in Fields)
                        {
                            PlainText += item.Value;
                        }
                    }
                }

            }
        }

        private int? documentNumber;

        [DataMember]
        public virtual Int32? DocumentNumber
        {
            get
            {
                return documentNumber;
            }
            set
            {
                documentNumber = value;
                for (int i = 0; i < CONRecord.GetDocumentNumberKeys().Count; i++)
                {
                    if (Fields != null && Fields.ContainsKey(CONRecord.GetDocumentNumberKeys()[i]))
                    {
                        Fields[CONRecord.GetDocumentNumberKeys()[i]] = Utils.ValidateNumber(documentNumber, 8, CONRecord.GetDocumentNumberKeys()[i]);
                        PlainText = "";
                        foreach (var item in Fields)
                        {
                            PlainText += item.Value;
                        }
                    }
                }

            }
        }
    }
}