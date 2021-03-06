using EasyConnect.Infrastructure.Entities;
using EasyTools.Framework.Data;
using System;
using System.Runtime.Serialization;

namespace EasyTools.Infrastructure.Entities.Base
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(CONEquivalenceDetail))]
    [KnownType(typeof(CONEquivalence))]
    [KnownType(typeof(CONError))]
    [KnownType(typeof(CONIntegratorConfiguration))]
    [KnownType(typeof(CONIntegrator))]
    [KnownType(typeof(CONRecordDetail))]
    [KnownType(typeof(CONRecord))]
    [KnownType(typeof(CONSQLDetail))]
    [KnownType(typeof(CONSQLParameter))]
    [KnownType(typeof(CONSQL))]
    [KnownType(typeof(CONSQLSend))]
    [KnownType(typeof(CONStructureAssociation))]
    [KnownType(typeof(CONStructureDetail))]
    [KnownType(typeof(CONStructure))]
    [KnownType(typeof(SECCompany))]
    [KnownType(typeof(SECConnection))]
    [KnownType(typeof(SECRolePermission))]
    [KnownType(typeof(SECRole))]
    [KnownType(typeof(SECUserCompany))]
    [KnownType(typeof(SECUser))]
    [KnownType(typeof(OptionValue))]
    [KnownType(typeof(EXTFileOpera))]
    [KnownType(typeof(EXTFileOperaDetail))]
    [KnownType(typeof(CONWSEquivalenciasFormasPago))]

    public class BaseEntity : FrameworkEntity
    {
    }

    [DataContract]
    public class OptionValue : BaseEntity
    {
        [DataMember]
        public String Code { get; set; }

        [DataMember]
        public Boolean BooleanValue { get; set; }

        [DataMember]
        public String Name { get; set; }

        [DataMember]
        public virtual Int32? Int32Value { get; set; }

        [DataMember]
        public virtual String StringValue { get; set; }

        public override Int32 GetHashCode()
        {
            if (!String.IsNullOrEmpty(Code))
                return Code.GetHashCode();
            return 3 * 3 * "".GetHashCode();
        }

        public override Boolean Equals(object obj)
        {
            if ((obj == null) || (obj.GetType() != this.GetType()))
                return false;
            OptionValue castObj = (OptionValue)obj;
            return (castObj != null) && (this.Code == castObj.Code);
        }
    }
}