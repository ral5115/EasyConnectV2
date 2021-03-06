using System;
using System.Runtime.Serialization;

namespace EasyTools.Framework.Persistance
{
    public class SQLParameter
    {
        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual bool IsDate { get; set; }

        [DataMember]
        public virtual DateTime? DateValue { get; set; }

        [DataMember]
        public virtual Int16? DefaultDateValue { get; set; }

        [DataMember]
        public virtual bool IsInt { get; set; }

        [DataMember]
        public virtual Int32? Int32Value { get; set; }

        [DataMember]
        public virtual bool IsString { get; set; }

        [DataMember]
        public virtual string StringValue { get; set; }

        [DataMember]
        public virtual string Direction { get; set; }
    }
}