using EasyTools.Domains.Base;
using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace EasyTools.Domains
{
    public class CONRecordDetailBLL : BaseCONRecordDetailBLL
    {
        public CONRecordDetailBLL(IUnitOfWork settings)
            : base(settings)
        {
        }

        public CONRecordDetailBLL(DatabaseSetting settings)
            : base(settings)
        {
        }

        public override CONRecordDetail Execute(CONRecordDetail data, Actions action, Options option, string token)
        {
            try
            {
                if (action == Actions.Add || action == Actions.Modify || action == Actions.Remove || (action == Actions.Find && (option == Options.Me || option == Options.Exist)))
                {
                    if ((action == Actions.Add || action == Actions.Modify) && option == Options.All)
                    {
                        BenginTransaction();
                    }
                    data = base.Execute(data, action, option, token);
                    if (action == Actions.Find && option == Options.Me)
                    {
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

        public void AddDetails(CONRecordDetail data)
        {
        }

        public override void CommonRules(CONRecordDetail data)
        {

            base.CommonRules(data);
        }

        public override void AddRules(CONRecordDetail data)
        {
            base.AddRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void ModifyRules(CONRecordDetail data)
        {
            base.ModifyRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void RemoveRules(CONRecordDetail data)
        {
            base.RemoveRules(data);
        }

        public override void FindByIdRules(CONRecordDetail data)
        {
            base.FindByIdRules(data);
        }

        

    }
}