using NHibernate;

namespace EasyTools.Framework.Persistance
{
    public class DatabaseContext : DatabaseSetting
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DatabaseSetting data)
        {
            this.DbName = data.DbName;
            this.DBType = data.DBType;
            this.Default = data.Default;
            this.Language = data.Language;
            this.Name = data.Name;
            this.Password = data.Password;
            this.Server = data.Server;
            this.Types = data.Types;
            this.UserName = data.UserName;
        }
        public ISessionFactory SessionFactory { get; set; }
    }
}