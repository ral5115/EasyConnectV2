using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using System.ComponentModel;
using System.Linq;

namespace EasyTools.UI.WPF.EasyConnect.Module.Models
{
    public class CONSQLExecuteModel : BaseModel
    {
        public CONSQL Entity
        {
            get
            {
                CONSQL data = new CONSQL();
                data.Id = this.Id;
                if (this.SQLDetails != null && this.SQLDetails.Count > 0)
                    data.Entities = this.SQLDetails.ToList<CONSQL>();
                if (this.SQLParameters != null && this.SQLParameters.Count > 0)
                    data.SQLParameters = this.SQLParameters.ToList<CONSQLParameter>();
                if (this.SQLSends != null && this.SQLSends.Count > 0)
                    data.SQLSends = this.SQLSends.ToList<CONSQLSend>();
                return data;
            }
            set
            {
                this.Id = value.Id;
                if (value.SQLDetails != null && value.SQLDetails.Count > 0)
                    this.SQLDetails = new BindingList<CONSQL>(value.Entities);
                if (value.SQLParameters != null && value.SQLParameters.Count > 0)
                    this.SQLParameters = new BindingList<CONSQLParameter>(value.SQLParameters);
                if (value.SQLSends != null && value.SQLSends.Count > 0)
                    this.SQLSends = new BindingList<CONSQLSend>(value.SQLSends);
                this.NotifyPropertyChanged("Entity");
            }
        }

        public virtual BindingList<CONSQL> SQLDetails
        {
            get { return GetValue(() => SQLDetails); }
            set { SetValue(() => SQLDetails, value); }
        }

        public virtual BindingList<CONSQLParameter> SQLParameters
        {
            get { return GetValue(() => SQLParameters); }
            set { SetValue(() => SQLParameters, value); }
        }

        public virtual bool Send
        {
            get { return GetValue(() => Send); }
            set { SetValue(() => Send, value); }
        }

        public virtual BindingList<CONSQLSend> SQLSends
        {
            get { return GetValue(() => SQLSends); }
            set { SetValue(() => SQLSends, value); }
        }



        public virtual bool Accounting
        {
            get { return GetValue(() => Accounting); }
            set { SetValue(() => Accounting, value); }
        }
    }
}