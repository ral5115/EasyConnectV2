using EasyTools.Domains.Base;
using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace EasyTools.Domains
{
    public class CONSQLDetailBLL : BaseCONSQLDetailBLL
    {
        private CONSQLDetailBLL cONSQLDetailDl;

        public CONSQLDetailBLL(IUnitOfWork settings)
            : base(settings)
        {
        }

        public CONSQLDetailBLL(DatabaseSetting settings)
            : base(settings)
        {
        }

        public override CONSQLDetail Execute(CONSQLDetail data, Actions action, Options option, string token)
        {
            try
            {
                if (action == Actions.Add || action == Actions.Modify || action == Actions.Remove || (action == Actions.Find && (option == Options.Me || option == Options.Exist)))
                {
                    if ((action == Actions.Add || action == Actions.Modify) && option == Options.All)
                    {
                        BenginTransaction();
                        cONSQLDetailDl = new CONSQLDetailBLL(Work);
                    }
                    data = base.Execute(data, action, option, token);
                    if (action == Actions.Find && option == Options.Me)
                    {
                        //cONSQLDetailDl = new CONSQLDetailBLL(this.Work.Settings);
                        //data.MainSQLDetails = cONSQLDetailDl.FindAll(new CONSQLDetail { MainSQLDetailId = data.Id }, Options.All);
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
                if (action == Actions.Process && option == Options.All)
                {
                    return GetColumnsFromSQL(data);
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

        public void AddDetails(CONSQLDetail data)
        {
            //if (data.MainSQLDetails != null && data.MainSQLDetails.Count > 0)
            //{
            //    for (int i = 0; i < data.MainSQLDetails.Count; i++)
            //    {
            //        data.MainSQLDetails[i].MainSQLDetailId = data.Id;
            //        data.MainSQLDetails[i].LastUpdate = DateTime.Now;
            //        data.MainSQLDetails[i].UpdatedBy = data.UpdatedBy;
            //        if (data.MainSQLDetails[i].Equivalence != null)
            //            data.MainSQLDetails[i].EquivalenceId = data.MainSQLDetails[i].Equivalence.Id;
            //        if (data.MainSQLDetails[i].SQL != null)
            //            data.MainSQLDetails[i].SQLId = data.MainSQLDetails[i].SQL.Id;
            //        if (data.MainSQLDetails[i].StructureDetail != null)
            //            data.MainSQLDetails[i].StructureDetailId = data.MainSQLDetails[i].StructureDetail.Id;
            //        if (data.MainSQLDetails[i].Id == 0)
            //            data.MainSQLDetails[i] = cONSQLDetailDl.Add(data.MainSQLDetails[i]);
            //        else
            //            data.MainSQLDetails[i] = cONSQLDetailDl.Modify(data.MainSQLDetails[i]);
            //    }
            //}
        }

        public override void CommonRules(CONSQLDetail data)
        {
            base.CommonRules(data);
        }

        public override void AddRules(CONSQLDetail data)
        {
            base.AddRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void ModifyRules(CONSQLDetail data)
        {
            base.ModifyRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void RemoveRules(CONSQLDetail data)
        {
            base.RemoveRules(data);
        }

        public override void FindByIdRules(CONSQLDetail data)
        {
            base.FindByIdRules(data);
        }

        public void MappingRules(CONSQL data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "CONSQL", "CONSQLs");
            if (data.Structure == null)
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "Structure");
            if (String.IsNullOrWhiteSpace(data.SQLSentence))
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "SQLSentence");
        }

        public CONSQLDetail GetColumnsFromSQL(CONSQLDetail data)
        {
            MappingRules(data.SQL);
            if (!HasErrors)
            {
                Database daacess = new Database(UtilBLL.GetConnectionString(data.SQL.Connection), UtilBLL.GetConnectionDBType(data.SQL.Connection.DbType));
                SECConnectionBLL dlConnection = new SECConnectionBLL(Work.Settings);
                CONStructureDetailBLL dlStructureDetail = new CONStructureDetailBLL(Work.Settings);

                cONSQLDetailDl = new CONSQLDetailBLL(Work.Settings);
                data.SQL.Connection = dlConnection.FindById(data.SQL.Connection);
                if (data.SQL != null && data.SQL.Id != 0 && !data.SQL.GenerateFile)
                {
                    List<CONSQLDetail> details = cONSQLDetailDl.FindAll(new CONSQLDetail { SQL = data.SQL }, Options.All);
                    foreach (CONSQLDetail item in details)
                    {
                        cONSQLDetailDl.Remove(item);
                    }
                }
                ResultList result = daacess.ExecuteQuery(data.SQL.SQLSentence, new List<SQLParameter>(), 1);
                List<CONSQLDetail> columns = new List<CONSQLDetail>();
                if (result.GetColumns() != null && result.GetColumns().Count > 0)
                {
                    for (int i = 0; i < result.GetColumns().Count; i++)
                    {
                        CONSQLDetail sqlColumn = new CONSQLDetail();
                        sqlColumn.Secuence = Int16.Parse(i.ToString());
                        sqlColumn.Field = result.GetColumnName(i);
                        sqlColumn.DBType = result.GetColumnType(i);
                        columns.Add(sqlColumn);
                    }
                }
                data.SQL.Structure.StructureDetails = dlStructureDetail.FindAll(new CONStructureDetail { Structure = data.SQL.Structure }, Options.All);
                if (data.SQL.Structure.StructureDetails != null && data.SQL.Structure.StructureDetails.Count > 0)
                {
                    foreach (CONSQLDetail item in columns)
                    {

                        CONStructureDetail sDetail = data.SQL.Structure.StructureDetails.FirstOrDefault(x => x.Field.ToUpper() == item.Field.ToUpper());
                        if (data != null)
                            item.StructureDetail = sDetail;
                    }
                    if (columns.Count() < (data.SQL.Structure.StructureDetails.Count() - 4) && !data.SQL.GenerateFile)
                    {
                        string message = " Las columnas Pendientes de Mapeo son: \n";

                        List<CONStructureDetail> pending = new List<CONStructureDetail>();
                        for (int i = 4; i < data.SQL.Structure.StructureDetails.Count(); i++)
                        {
                            var exist = columns.FirstOrDefault(x => x.StructureDetail.Field.ToUpper() == data.SQL.Structure.StructureDetails[i].Field.ToUpper());
                            if (exist == null && data.SQL.Structure.StructureDetails[i].Visible)
                            {
                                pending.Add(data.SQL.Structure.StructureDetails[i]);
                            }
                        }

                        if (pending.Count > 0)
                        {
                            foreach (var item in pending)
                            {
                                message += item.Field + ",\n";
                            }
                            throw new Exception("La consulta SQL no tiene el nro de columnas minimo requerido. Nro Minimo de Columnas = " + (data.SQL.Structure.StructureDetails.Count()) + "\n" + message.ToUpper());
                        }
                    }
                }

                //List<CONStructureDetail> pendingMapping = new List<CONStructureDetail>();

                //foreach (CONStructureDetail item in data.SQL.Structure.StructureDetails)
                //{
                //    CONSQLDetail exist = columns.FirstOrDefault(x => x.StructureDetail.Id == item.Id);
                //    if (exist == null && item.Visible)
                //        pendingMapping.Add(item);
                //}
                //if (pendingMapping.Count > 0)
                //{
                //    data.ServerMessage = "Falta por mapear las columnas: ";
                //    foreach (CONStructureDetail item in pendingMapping)
                //    {
                //        data.ServerMessage += item.Field + ", ";
                //    }
                //    data.ServerMessage += "Por favor verifique e intente de nuevo.";
                //}
                data.Entities = columns;
                return data;
            }
            else
            {
                    Work.Rollback();
                BusinessException exception = new BusinessException(GetLocalizedMessage(Language.DLBUSINESSEXCEPTION));
                foreach (string item in ExceptionMessages)
                {
                    exception.AppMessageDetails.Add(item);
                }
                throw exception.GetFaultException();
            }
        }

    }
}