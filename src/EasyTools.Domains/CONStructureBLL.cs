using EasyTools.Domains.Base;
using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure.Entities;
using System;
using System.ServiceModel;

namespace EasyTools.Domains
{
    public class CONStructureBLL : BaseCONStructureBLL
    {
        private CONSQLBLL cONSQLDl;

        private CONStructureAssociationBLL cONStructureAssociationDl;

        private CONStructureDetailBLL cONStructureDetailDl;

        public CONStructureBLL(IUnitOfWork settings)
            : base(settings)
        {
        }

        public CONStructureBLL(DatabaseSetting settings)
            : base(settings)
        {
        }

        public override CONStructure Execute(CONStructure data, Actions action, Options option, string token)
        {
            try
            {
                if (action == Actions.Add || action == Actions.Modify || action == Actions.Remove || (action == Actions.Find && (option == Options.Me || option == Options.Exist)))
                {
                    if ((action == Actions.Add || action == Actions.Modify) && option == Options.All)
                    {
                        BenginTransaction();
                        cONSQLDl = new CONSQLBLL(Work);
                        cONStructureAssociationDl = new CONStructureAssociationBLL(Work);
                        cONStructureDetailDl = new CONStructureDetailBLL(Work);
                    }
                    data = base.Execute(data, action, option, token);
                    if (action == Actions.Find && option == Options.Me)
                    {
                        cONSQLDl = new CONSQLBLL(this.Work.Settings);
                        cONStructureAssociationDl = new CONStructureAssociationBLL(this.Work.Settings);
                        cONStructureDetailDl = new CONStructureDetailBLL(this.Work.Settings);
                        data.SQLs = cONSQLDl.FindAll(new CONSQL { StructureId = data.Id }, Options.All);
                        data.MainStructures = cONStructureAssociationDl.FindAll(new CONStructureAssociation { MainStructureId = data.Id }, Options.All);
                        data.ChildStructures = cONStructureAssociationDl.FindAll(new CONStructureAssociation { ChildStructureId = data.Id }, Options.All);
                        data.StructureDetails = cONStructureDetailDl.FindAll(new CONStructureDetail { StructureId = data.Id }, Options.All);
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

        public void AddDetails(CONStructure data)
        {
            if (data.SQLs != null && data.SQLs.Count > 0)
            {
                for (int i = 0; i < data.SQLs.Count; i++)
                {
                    data.SQLs[i].StructureId = data.Id;
                    data.SQLs[i].LastUpdate = DateTime.Now;
                    data.SQLs[i].UpdatedBy = data.UpdatedBy;
                    if (data.SQLs[i].Company != null)
                        data.SQLs[i].CompanyId = data.SQLs[i].Company.Id;
                    if (data.SQLs[i].MainSQL != null)
                        data.SQLs[i].MainSQLId = data.SQLs[i].MainSQL.Id;
                    if (data.SQLs[i].Id == 0)
                        data.SQLs[i] = cONSQLDl.Add(data.SQLs[i]);
                    else
                        data.SQLs[i] = cONSQLDl.Modify(data.SQLs[i]);
                }
            }
            if (data.MainStructures != null && data.MainStructures.Count > 0)
            {
                for (int i = 0; i < data.MainStructures.Count; i++)
                {
                    data.MainStructures[i].MainStructureId = data.Id;
                    data.MainStructures[i].LastUpdate = DateTime.Now;
                    data.MainStructures[i].UpdatedBy = data.UpdatedBy;
                    if (data.MainStructures[i].Id == 0)
                        data.MainStructures[i] = cONStructureAssociationDl.Add(data.MainStructures[i]);
                    else
                        data.MainStructures[i] = cONStructureAssociationDl.Modify(data.MainStructures[i]);
                }
            }
            if (data.ChildStructures != null && data.ChildStructures.Count > 0)
            {
                for (int i = 0; i < data.ChildStructures.Count; i++)
                {
                    data.ChildStructures[i].ChildStructureId = data.Id;
                    data.ChildStructures[i].LastUpdate = DateTime.Now;
                    data.ChildStructures[i].UpdatedBy = data.UpdatedBy;
                    if (data.ChildStructures[i].Id == 0)
                        data.ChildStructures[i] = cONStructureAssociationDl.Add(data.ChildStructures[i]);
                    else
                        data.ChildStructures[i] = cONStructureAssociationDl.Modify(data.ChildStructures[i]);
                }
            }
            if (data.StructureDetails != null && data.StructureDetails.Count > 0)
            {
                for (int i = 0; i < data.StructureDetails.Count; i++)
                {
                    data.StructureDetails[i].StructureId = data.Id;
                    data.StructureDetails[i].LastUpdate = DateTime.Now;
                    data.StructureDetails[i].UpdatedBy = data.UpdatedBy;
                    if (data.StructureDetails[i].Id == 0)
                        data.StructureDetails[i] = cONStructureDetailDl.Add(data.StructureDetails[i]);
                    else
                        data.StructureDetails[i] = cONStructureDetailDl.Modify(data.StructureDetails[i]);
                }
            }
        }

        public override void CommonRules(CONStructure data)
        {
            base.CommonRules(data);
        }

        public override void AddRules(CONStructure data)
        {
            base.AddRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void ModifyRules(CONStructure data)
        {
            base.ModifyRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void RemoveRules(CONStructure data)
        {
            base.RemoveRules(data);
        }

        public override void FindByIdRules(CONStructure data)
        {
            base.FindByIdRules(data);
        }

    }
}