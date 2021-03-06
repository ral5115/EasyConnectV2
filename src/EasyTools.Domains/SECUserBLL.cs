using EasyTools.Domains.Base;
using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure.Entities;
using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace EasyTools.Domains
{
    public class SECUserBLL : BaseSECUserBLL
    {
        private SECUserCompanyBLL sECUserCompanyDl;

        private SECRoleBLL secRoleDl;

        public SECUserBLL(IUnitOfWork settings)
            : base(settings)
        {
        }

        public SECUserBLL(DatabaseSetting settings)
            : base(settings)
        {
        }

        public override SECUser Execute(SECUser data, Actions action, Options option, string token)
        {
            try
            {
                if (action == Actions.Add || action == Actions.Modify || action == Actions.Remove || (action == Actions.Find && (option == Options.Me || option == Options.Exist)))
                {
                    if ((action == Actions.Add || action == Actions.Modify) && option == Options.All)
                    {
                        BenginTransaction();
                        sECUserCompanyDl = new SECUserCompanyBLL(Work);
                    }
                    data = base.Execute(data, action, option, token);
                    if (action == Actions.Find && option == Options.Me && data != null)
                    {
                        sECUserCompanyDl = new SECUserCompanyBLL(this.Work.Settings);
                        secRoleDl = new SECRoleBLL(this.Work.Settings);
                        data.UserCompanies = sECUserCompanyDl.FindAll(new SECUserCompany { UserId = data.Id }, Options.All);
                        data.Role = secRoleDl.Execute(new SECRole { Id = (Int32)data.RoleId }, Actions.Find, Options.Me, "");
                    }
                    if ((action == Actions.Add || action == Actions.Modify) && option == Options.All)
                        AddDetails(data);
                    //if (option == Options.All)
                    //    Work.Commit();
                    return data;
                }
                else if (action == Actions.Find && (option == Options.All || option == Options.Light))
                {
                    if (option == Options.All)
                        data.Entities = FindAll(data, Options.All);
                    else if (option == Options.Light)
                        data.Entities = FindAll(data, Options.Light);
                    return data;
                }
                else
                    throw new NotImplementedException(GetLocalizedMessage(Language.DLACTIONNOTIMPLEMENT, action.ToString(), option.ToString()));
            }
            catch (FaultException<BusinessException> f)
            {
                Rollback();
                throw f;
            }
            catch (Exception e)
            {
                Rollback();
                throw new BusinessException(e).GetFaultException();
            }
            finally
            {
                Commit();
            }
        }

        public void AddDetails(SECUser data)
        {
            if (data.UserCompanies != null && data.UserCompanies.Count > 0)
            {
                for (int i = 0; i < data.UserCompanies.Count; i++)
                {
                    data.UserCompanies[i].UserId = data.Id;
                    data.UserCompanies[i].LastUpdate = DateTime.Now;
                    data.UserCompanies[i].UpdatedBy = data.UpdatedBy;
                    if (data.UserCompanies[i].Company != null)
                        data.UserCompanies[i].CompanyId = data.UserCompanies[i].Company.Id;
                    if (data.UserCompanies[i].Id == 0)
                        data.UserCompanies[i] = sECUserCompanyDl.Add(data.UserCompanies[i]);
                    else
                        data.UserCompanies[i] = sECUserCompanyDl.Modify(data.UserCompanies[i]);
                }
            }
        }

        public override void CommonRules(SECUser data)
        {
            base.CommonRules(data);
        }

        public override void AddRules(SECUser data)
        {
            base.AddRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void ModifyRules(SECUser data)
        {
            base.ModifyRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void RemoveRules(SECUser data)
        {
            base.RemoveRules(data);
        }

        public override void FindByIdRules(SECUser data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "SECUser", "SECUsers");
            if (string.IsNullOrWhiteSpace(data.Login))
                if (string.IsNullOrWhiteSpace(data.Email))
                    if (data.Id == 0)
                        AddExceptionMessage(Language.DLTABLEIDNOTNULL, "SECUsers");
        }

        public SECUser IsAuthenticate(string email, string login, string password)
        {
            return Execute(new SECUser { Login = login, Password = password, Email = email }, Actions.Find, Options.Me, "");
        }

        public async Task<SECUser> IsAuthenticateAsync(string email, string login, string password)
        {
            return await Task.Run(() =>
            {
                return IsAuthenticate(email, login, password);
            });
        }

    }
}