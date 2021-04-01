using EasyTools.Framework.Persistance;
using EasyTools.Framework.UI;
using EasyTools.Infrastructure.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace EasyTools.UI.WPF.Models
{
    public class LoginModel : BaseModel
    {

        [Required(ErrorMessage = "El Login no puede estar vacio")]
        [StringLength(50, ErrorMessage = "El Login no puede tener mas de 50 caracteres")]
        [Display(Name = "Login", Description = "Usuario")]
        public String Login
        {
            get { return GetValue(() => Login); }
            set { SetValue(() => Login, value); }
        }

        [Required(ErrorMessage = "La contraseña no puede estar vacia")]
        [StringLength(50, ErrorMessage = "La contraseña no puede tener mas de 50 caracteres")]
        [Display(Name = "Contraseña", Description = "Contraseña")]
        public String Password
        {
            get { return GetValue(() => Password); }
            set { SetValue(() => Password, value); }
        }

        [Required(ErrorMessage = "Debe seleccionar una conexion")]
        [Display(Name = "Conectar a", Description = "Conexion a conectar")]
        public DatabaseSetting DatabaseSetting
        {
            get { return GetValue(() => DatabaseSetting); }
            set { SetValue(() => DatabaseSetting, value); }
        }

        public SECUser Entity
        {
            get
            {
                SECUser data = new SECUser();
                data.Login = this.Login;
                data.Password = this.Password;
                return data;
            }
            set
            {
                this.Login = value.Login;
                this.Password = value.Password;
                NotifyPropertyChanged("Entity");
            }
        }
    }
}
