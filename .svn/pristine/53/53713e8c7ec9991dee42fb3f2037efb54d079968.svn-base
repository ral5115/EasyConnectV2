using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities.Base;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities
{
     [DataContract(IsReference = true)]
    public class CONFinal : BaseEntity
    {

        [DataMember]
        public string RecordNumber { get; set; }

        [DataMember]
        public string RecordType { get; set; }

        [DataMember]
        public string SubRecordType { get; set; }

        [DataMember]
        public string Version { get; set; }

        [DataMember]
        public string Company { get; set; }

        public string PlainText
        {
            get
            {
                string accString = "";
                accString += Utils.ValidateNumber(RecordNumber, 7, "F_NUMERO_REG");
                accString += Utils.ValidateNumber(RecordType, 4, "F_TIPO_REG");
                accString += Utils.ValidateNumber(SubRecordType, 2, "F_SUBTIPO_REG");
                accString += Utils.ValidateNumber(Version, 2, "F_VERSION_REG");
                accString += Utils.ValidateNumber(Company, 3, "F_CIA");
                return accString;
            }
        }

        //public override string ToString()
        //{
        //    if (String.IsNullOrEmpty(RecordNumber) || String.IsNullOrEmpty(RecordType) || String.IsNullOrEmpty(SubRecordType) || String.IsNullOrEmpty(Version) || String.IsNullOrEmpty(Company))
        //        throw new ArgumentException("El registro tiene valores nulos. ");
        //    //return recordNumber + recordType + subRecordType + version + company;
        //    string accString = "";
        //    accString += Utils.ValidateNumber(RecordNumber, 7, "F_NUMERO_REG");
        //    accString += Utils.ValidateNumber(RecordType, 4, "F_TIPO_REG");
        //    accString += Utils.ValidateNumber(SubRecordType, 2, "F_SUBTIPO_REG");
        //    accString += Utils.ValidateNumber(Version, 2, "F_VERSION_REG");
        //    accString += Utils.ValidateNumber(Company, 3, "F_CIA");
        //    return accString;
        //}
    }
}
