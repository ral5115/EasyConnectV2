using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyTools.Framework.Data
{
    [DataContract(IsReference = true)]
    public class FrameworkEntity
    {
        [DataMember]
        public virtual Int32 Id { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as FrameworkEntity);
        }

        private static bool IsTransient(FrameworkEntity obj)
        {
            return obj != null && Equals(obj.Id, default(int));
        }

        public virtual bool Equals(FrameworkEntity other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            if (Equals(Id, default(int)))
                return base.GetHashCode();
            return Id.GetHashCode();
        }

        public static bool operator ==(FrameworkEntity x, FrameworkEntity y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(FrameworkEntity x, FrameworkEntity y)
        {
            return !(x == y);
        }

        [DataMember]
        public virtual bool HasPaging { get; set; }

        [DataMember]
        public virtual int PageSize { get; set; }

        [DataMember]
        public virtual int CurrentPage { get; set; }

        [DataMember]
        public virtual int ParallelNumber { get; set; }

        [DataMember]
        public virtual DateTime LastUpdate { get; set; }

        [DataMember]
        public virtual String UpdatedBy { get; set; }

        [DataMember]
        public virtual bool Exist { get; set; }

        private  Dictionary<string, object> additionalProperties;

        public virtual void AddAditionalProperty(string name, object value)
        {
            if (additionalProperties == null)
                additionalProperties = new Dictionary<string, object>();
            if (additionalProperties.ContainsKey(name))
                additionalProperties[name] = name;
            else
                additionalProperties.Add(name, value);
        }

        public virtual object GetAditionalProperty(string name)
        {
            if (additionalProperties != null)
                if (additionalProperties.ContainsKey(name))
                    return additionalProperties[name];
            return null;
        }

    }
}