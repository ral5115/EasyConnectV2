using EasyConnect.Infrastructure.Entities;
using EasyTools.Domains;
using EasyTools.Domains.Installation.Data;
using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Infrastructure.Entities;
using EasyTools.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyTools.UI.Data
{
    public class ToolsServiceClient
    {
        public Configuration GetConfiguration()
        {
            return EasyApp.Current.Configuration;
        }

        public SECUser Authentication(string email, string login, string password, string settingName)
        {
            DomainLogic dl = new DomainLogic(App.Current.Configuration.GetDatabaseSetting(settingName));
            return dl.GetSECUserBLL().IsAuthenticate(email, login, password);
        }
        
        public void InstallLocalData()
        {
            Configuration conf = GetConfiguration();
            ENDefaultData defaultData = new ENDefaultData();
            try
            {
                DomainLogic dl = new DomainLogic(conf.DataBaseSettings[0]);
                if (defaultData.Roles() != null && defaultData.Roles().Count > 0)
                {
                    foreach (SECRole rol in defaultData.Roles())
                    {
                        SECRole data = dl.GetSECRoleBLL().Add(rol);
                        if (rol.Users != null && rol.Users.Count > 0)
                            foreach (SECUser user in rol.Users)
                            {
                                user.Role = data;
                                user.RoleId = data.Id;
                                dl.GetSECUserBLL().Add(user);
                            }
                    }
                }
                //if (defaultData.Languages() != null && defaultData.Languages().Count > 0)
                //{
                //    foreach (SECLanguage language in defaultData.Languages())
                //    {
                //        SECLanguage data = dl.GetSECLanguageDL().Add(language);
                //    }
                //}
                //if (defaultData.Types() != null && defaultData.Types().Count > 0)
                //{
                //    foreach (SECType type in defaultData.Types())
                //    {
                //        SECType data = dl.GetSECTypeDL().Add(type);
                //        if (type.TypeValues != null && type.TypeValues.Count > 0)
                //            foreach (SECTypeValue typeValue in type.TypeValues)
                //            {
                //                typeValue.TypeId = type.Id;
                //                SECTypeValue data1 = dl.GetSECTypeValueDL().Add(typeValue);
                //                if (typeValue.TypeValueDetails != null && typeValue.TypeValueDetails.Count > 0)
                //                    foreach (SECTypeValueDetail typeValueDetail in typeValue.TypeValueDetails)
                //                    {
                //                        typeValueDetail.TypeValueId = typeValue.Id;
                //                        SECTypeValueDetail data2 = dl.GetSECTypeValueDetailDL().Add(typeValueDetail);
                //                    }
                //            }
                //    }
                //}
                if (defaultData.Companies() != null && defaultData.Companies().Count > 0)
                {
                    foreach (SECCompany company in defaultData.Companies())
                    {
                        SECCompany data = dl.GetSECCompanyBLL().Add(company);
                    }
                }
                List<SECCompany> companies = dl.GetSECCompanyBLL().FindAll(new SECCompany { Active = true }, Options.All);

                List<SECUser> users = dl.GetSECUserBLL().FindAll(new SECUser { Active = true }, Options.All);
                SECUserCompany useCompany = new SECUserCompany { Active = true, CompanyId = companies[0].Id, UserId = users[0].Id, LastUpdate = DateTime.Now, UpdatedBy = "admin" };
                dl.GetSECUserCompanyBLL().Add(useCompany);

            }
            catch (Exception e)
            {
                throw new BusinessException(e).GetFaultException();
            }
        }

        public BaseEntity Execute(BaseEntity data, Actions action, Options option, string settingName, string token)
        {
            DomainLogic dl = new DomainLogic(App.Current.Configuration.GetDatabaseSetting(settingName));
            if (data.GetType() == typeof(CONEquivalenceDetail))
                return dl.GetCONEquivalenceDetailBLL().Execute((CONEquivalenceDetail)data, action, option, token);
            else if (data.GetType() == typeof(CONEquivalence))
                return dl.GetCONEquivalenceBLL().Execute((CONEquivalence)data, action, option, token);
            else if (data.GetType() == typeof(CONError))
                return dl.GetCONErrorBLL().Execute((CONError)data, action, option, token);
            else if (data.GetType() == typeof(CONIntegratorConfiguration))
                return dl.GetCONIntegratorConfigurationBLL().Execute((CONIntegratorConfiguration)data, action, option, token);
            else if (data.GetType() == typeof(CONIntegrator))
                return dl.GetCONIntegratorBLL().Execute((CONIntegrator)data, action, option, token);
            else if (data.GetType() == typeof(CONRecordDetail))
                return dl.GetCONRecordDetailBLL().Execute((CONRecordDetail)data, action, option, token);
            else if (data.GetType() == typeof(CONRecord))
                return dl.GetCONRecordBLL().Execute((CONRecord)data, action, option, token);
            else if (data.GetType() == typeof(CONSQLDetail))
                return dl.GetCONSQLDetailBLL().Execute((CONSQLDetail)data, action, option, token);
            else if (data.GetType() == typeof(CONSQLParameter))
                return dl.GetCONSQLParameterBLL().Execute((CONSQLParameter)data, action, option, token);
            else if (data.GetType() == typeof(CONSQL))
                return dl.GetCONSQLBLL().Execute((CONSQL)data, action, option, token);
            else if (data.GetType() == typeof(CONSQLSend))
                return dl.GetCONSQLSendBLL().Execute((CONSQLSend)data, action, option, token);
            else if (data.GetType() == typeof(CONStructureAssociation))
                return dl.GetCONStructureAssociationBLL().Execute((CONStructureAssociation)data, action, option, token);
            else if (data.GetType() == typeof(CONStructureDetail))
                return dl.GetCONStructureDetailBLL().Execute((CONStructureDetail)data, action, option, token);
            else if (data.GetType() == typeof(CONStructure))
                return dl.GetCONStructureBLL().Execute((CONStructure)data, action, option, token);
            else if (data.GetType() == typeof(SECCompany))
                return dl.GetSECCompanyBLL().Execute((SECCompany)data, action, option, token);
            else if (data.GetType() == typeof(SECConnection))
                return dl.GetSECConnectionBLL().Execute((SECConnection)data, action, option, token);
            else if (data.GetType() == typeof(SECRolePermission))
                return dl.GetSECRolePermissionBLL().Execute((SECRolePermission)data, action, option, token);
            else if (data.GetType() == typeof(SECRole))
                return dl.GetSECRoleBLL().Execute((SECRole)data, action, option, token);
            else if (data.GetType() == typeof(SECUserCompany))
                return dl.GetSECUserCompanyBLL().Execute((SECUserCompany)data, action, option, token);
             else if (data.GetType() == typeof(SECUser))
                return dl.GetSECUserBLL().Execute((SECUser)data, action, option, token);
            else if (data.GetType() == typeof(EXTFileOpera))
                return dl.GetEXTFileOperaBLL().Execute((EXTFileOpera)data, action, option, token);
            else if (data.GetType() == typeof(EXTFileOperaDetail))
                return dl.GetEXTFileOperaDetailBLL().Execute((EXTFileOperaDetail)data, action, option, token);
            else if (data.GetType() == typeof(CONWSEquivalenciasFormasPago))
                return dl.GetCONWSEquivalenciasFormasPagoBLL().Execute((CONWSEquivalenciasFormasPago)data, action, option, token);
            else if (data.GetType() == typeof(WSCONCESIONESTIENDA))
                return dl.GetWSCONCESIONESTIENDABLL().Execute((WSCONCESIONESTIENDA)data, action, option, token);
            else if (data.GetType() == typeof(WSCONCESIONE))
                return dl.GetWSCONCESIONEBLL().Execute((WSCONCESIONE)data, action, option, token);
            else
                throw new NotImplementedException("La Acción " + action + " Con opción: " + option + " No esta Implementada");
        }

        public async Task<BaseEntity> ExecuteAsync(BaseEntity data, Actions action, Options option, string settingName, string token)
        {
            return await Task.Run(() =>
            {
                return Execute(data, action, option,settingName, token);
            });
        }

        

    }
}