using EasyTools.Domains.Base;
using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


//using System.Management;
//using System.Collections.Generic;

namespace EasyTools.Domains
{
    public class CONSQLBLL : BaseCONSQLBLL
    {
        private CONRecordDetailBLL cONRecordDetailDl;

        private CONRecordBLL cONRecordDl;

        private CONSQLDetailBLL cONSQLDetailDl;

        private CONSQLParameterBLL cONSQLParameterDl;

        private CONSQLBLL cONSQLDl;

        private CONSQLSendBLL cONSQLSendDl;

        private CONStructureBLL cONStructureDl;

        private CONStructureDetailBLL cONStructureDetailDl;

        private CONEquivalenceDetailBLL cONEquivalenceDetailDl;

        private CONErrorBLL cONErrorDl;

        public CONSQLBLL(IUnitOfWork settings)
            : base(settings)
        {
        }

        public CONSQLBLL(DatabaseSetting settings)
            : base(settings)
        {
        }

        public void AddSelecMeDetails(CONSQL data)
        {
            data.SQLDetails = cONSQLDetailDl.FindAll(new CONSQLDetail { SQLId = data.Id }, Options.All);
            data.SQLParameters = cONSQLParameterDl.FindAll(new CONSQLParameter { SQLId = data.Id }, Options.All);
            data.ChildSQLs = cONSQLDl.FindAll(new CONSQL { MainSQLId = data.Id }, Options.All);
            if (data.ChildSQLs != null && data.ChildSQLs.Count > 0)
            {
                for (int i = 0; i < data.ChildSQLs.Count; i++)
                {
                    data.ChildSQLs[i].SQLDetails = cONSQLDetailDl.FindAll(new CONSQLDetail { SQLId = data.ChildSQLs[i].Id }, Options.All);
                }
            }
            data.SQLSends = cONSQLSendDl.FindAll(new CONSQLSend { SQLId = data.Id }, Options.All);
        }

        
        public override CONSQL Execute(CONSQL data, Actions action, Options option, string token)
        {
            
            try
            {
                if (action == Actions.Add || action == Actions.Modify || action == Actions.Remove || (action == Actions.Find && (option == Options.Me || option == Options.Exist)))
                {
                    if ((action == Actions.Add || action == Actions.Modify) && option == Options.All)
                    {
                        BenginTransaction();
                        cONRecordDetailDl = new CONRecordDetailBLL(Work);
                        cONRecordDl = new CONRecordBLL(Work);
                        cONSQLDetailDl = new CONSQLDetailBLL(Work);
                        cONSQLParameterDl = new CONSQLParameterBLL(Work);
                        cONSQLDl = new CONSQLBLL(Work);
                        cONSQLSendDl = new CONSQLSendBLL(Work);
                    }
                    data = base.Execute(data, action, option, token);
                    if (action == Actions.Find && option == Options.Me)
                    {
                        cONRecordDetailDl = new CONRecordDetailBLL(this.Work.Settings);
                        cONRecordDl = new CONRecordBLL(this.Work.Settings);
                        cONSQLDetailDl = new CONSQLDetailBLL(this.Work.Settings);
                        cONSQLParameterDl = new CONSQLParameterBLL(this.Work.Settings);
                        cONSQLDl = new CONSQLBLL(this.Work.Settings);
                        cONSQLSendDl = new CONSQLSendBLL(this.Work.Settings);
                        AddSelecMeDetails(data);
                    }
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
                else if (action == Actions.Process && (option == Options.All || option == Options.Light))
                {
                    //data = ExecuteSQLTask(data.Entities);
                    data = ExecuteSQL(data);
                    return data;
                }
                else if (action == Actions.Generate && (option == Options.All || option == Options.Light))
                {

                    data.AddAditionalProperty("Result", ImportTask(data.Records, data.ParallelNumber == null ? 0 : data.ParallelNumber ));
                    //data.AddAditionalProperty("Result", UNOEEImport(data.Records));
                    return data;
                }
                else if (action == Actions.Generate && option == Options.Me )
                {

                    data = GenerateMastersZapa(Work);
                    return data;
                }
                else
                    throw new NotImplementedException(GetLocalizedMessage(Language.DLACTIONNOTIMPLEMENT, action.ToString(), option.ToString()));
            }
            //catch (FaultException<BusinessException> f)
            //{
            //    Rollback();
            //    throw f;
            //}
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

        //public CONSQL ExecuteSQLTask(List<CONSQL> parames)
        //{
        //    CONSQL exec = null;

        //    Parallel.ForEach(parames, currentElement =>
        //    {
        //        CONSQLBLL conSQLBLL = new CONSQLBLL(Work.Settings);
        //        exec = conSQLBLL.ExecuteSQL(currentElement);
        //    });

        //    return exec;
        //}



        public CONSQL ExecuteSQL(CONSQL data)
        {
            
            try
            {
                cONStructureDl = new CONStructureBLL(Work.Settings);
                List<CONRecord> accountings = new List<CONRecord>();
                List<CONRecordDetail> accountingDetails = new List<CONRecordDetail>();
                if (data == null)
                    AddExceptionMessage(Language.DLTABLEVALUENULL, "CONSQL", "CONSQLs");
                if (data.Entities == null)
                    AddExceptionMessage("No hay Interfaces para ejecutar.");
                if (data.Description == null )
                {
                    if (data.SQLSends == null)
                        AddExceptionMessage("No hay Configuracion seleccionada para la ejecuci?n de las interfaces.");
                }
                if (!HasErrors)
                {
                    for (int i = 0; i < data.Entities.Count; i++)
                    {
                        
                        data.Entities[i] = Execute(new CONSQL { Id = data.Entities[i].Id }, Actions.Find, Options.Me, "");
                        data.Entities[i].Structure = cONStructureDl.Execute(new CONStructure { Id = data.Entities[i].StructureId }, Actions.Find, Options.Me, "");
                        if (data.SQLSends != null && data.SQLSends.Count > 0)
                        {
                            foreach (CONSQLSend item in data.SQLSends)
                                item.Active = true;
                            data.Entities[i].SQLSends = data.SQLSends;
                        }
                        if (data.SQLParameters != null && data.SQLParameters.Count > 0)
                        {
                            foreach (CONSQLParameter parm in data.SQLParameters)
                            {
                                foreach (var sqlParam in data.Entities[i].SQLParameters)
                                {
                                    if (parm.Name == sqlParam.Name)
                                    {
                                        sqlParam.DateValue = parm.DateValue;
                                        sqlParam.Int32Value = parm.Int32Value;
                                        sqlParam.StringValue = parm.StringValue;
                                    }
                                }
                            }
                        }
                        accountings.AddRange(GetDataQuery(data.Entities[i]));
                        if (data.Entities[i].ChildSQLs != null && data.Entities[i].ChildSQLs.Count > 0)
                        {
                            foreach (CONSQL item in data.Entities[i].ChildSQLs)
                            {
                                if (data.Entities[i].SQLParameters != null && data.Entities[i].SQLParameters.Count > 0)
                                    item.SQLParameters = data.Entities[i].SQLParameters;
                                accountingDetails.AddRange(GetDataQueryDetail(item));
                            }
                            if (accountings != null && accountings.Count > 0 && accountingDetails != null && accountingDetails.Count > 0)
                                foreach (CONRecord item in accountings)
                                  item.RecordDetails = accountingDetails.Where(t => t.LogicalKey == item.LogicalKey).ToList<CONRecordDetail>();
                                  
                        }
                        
                        List<SQLParameter> parames = new List<SQLParameter>();
                        if (data.Entities[i].SQLParameters != null && data.Entities[i].SQLParameters.Count > 0)
                        {
                            foreach (var item in data.Entities[i].SQLParameters)
                            {
                                SQLParameter prm = new SQLParameter();
                                prm.DateValue = item.DateValue;
                                prm.Name = item.Name;
                                prm.Int32Value = item.Int32Value;
                                prm.StringValue = item.StringValue;

                                parames.Add(prm);
                            }
                        }
                        Database daacess = new Database(UtilBLL.GetConnectionString((data.Entities[i].StoreProcedureConnection == null) ? data.Entities[i].Connection : data.Entities[i].StoreProcedureConnection), UtilBLL.GetConnectionDBType((data.Entities[i].StoreProcedureConnection == null) ? data.Entities[i].Connection.DbType : data.Entities[i].StoreProcedureConnection.DbType));
                        if (!String.IsNullOrWhiteSpace(data.Entities[i].ExecuteStoreProcedure))
                            daacess.ExecuteStoreProcedure(data.Entities[i].ExecuteStoreProcedure, parames);

                        
                        if (data.Entities[i].ChildSQLs != null && data.Entities[i].ChildSQLs.Count > 0)
                        {
                            foreach (var item in data.Entities[i].ChildSQLs)
                            {
                                daacess = new Database(UtilBLL.GetConnectionString((data.Entities[i].StoreProcedureConnection == null) ? data.Entities[i].Connection : data.Entities[i].StoreProcedureConnection), UtilBLL.GetConnectionDBType((data.Entities[i].StoreProcedureConnection == null) ? data.Entities[i].Connection.DbType : data.Entities[i].StoreProcedureConnection.DbType));
                                if (!String.IsNullOrWhiteSpace(item.ExecuteStoreProcedure))
                                    daacess.ExecuteStoreProcedure(item.ExecuteStoreProcedure, parames);
                                
                            }
                        }
                        
                    }
                    if (string.IsNullOrWhiteSpace(data.UpdatedBy))
                        data.UpdatedBy = "admin";
                    for (int k = 0; k < accountings.Count; k++)
                    {
                       
                        cONRecordDl = new CONRecordBLL(Work.Settings);
                        cONRecordDetailDl = new CONRecordDetailBLL(Work.Settings);
                        cONErrorDl = new CONErrorBLL(Work.Settings);
                        CONRecord accounting = cONRecordDl.Execute(accountings[k], Actions.Find, Options.Me, "");
                        if (accounting == null)
                        {
                            accountings[k].UpdatedBy = data.UpdatedBy;
                            accountings[k] = cONRecordDl.Execute(accountings[k], Actions.Add, Options.All, "");
                        }
                        else
                        {
                            if (!accounting.IsSend)
                            {
                                if (accounting.RecordDetails != null && accounting.RecordDetails.Count > 0)
                                    cONRecordDetailDl.Remove(accounting.RecordDetails);
                                if (accounting.Errors1 != null && accounting.Errors1.Count > 0)
                                    cONErrorDl.Remove(accounting.Errors1);

                                accountings[k].LastUpdate = data.LastUpdate;
                                accountings[k].UpdatedBy = data.UpdatedBy;
                                accountings[k].Id = accounting.Id;
                                accountings[k].DocumentNumber = accounting.DocumentNumber;
                                accountings[k] = cONRecordDl.Execute(accountings[k], Actions.Modify, Options.All, "");
                            }
                            else
                                accountings[k] = accounting;
                        }
                    }
                    if ((Boolean)data.GetAditionalProperty("Accounting"))
                        ImportTask(accountings, 0);
                }
                return data = new CONSQL();
            }
            catch (Exception e)
            {
                throw new BusinessException(e).GetFaultException();
            }
        }

        public override void CommonRules(CONSQL data)
        {
            base.CommonRules(data);
        }

        public override void AddRules(CONSQL data)
        {
            base.AddRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void ModifyRules(CONSQL data)
        {
            base.ModifyRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void RemoveRules(CONSQL data)
        {
            base.RemoveRules(data);
        }

        public override void FindByIdRules(CONSQL data)
        {
            base.FindByIdRules(data);
        }

        public List<CONRecord> GetDataQuery(CONSQL sql)
        {
            try
            {
                List<CONRecord> accountings = new List<CONRecord>();
                Database daacess = new Database(UtilBLL.GetConnectionString(sql.Connection), UtilBLL.GetConnectionDBType(sql.Connection.DbType));
                List<SQLParameter> parames = new List<SQLParameter>();
                if (sql.SQLParameters != null && sql.SQLParameters.Count > 0)
                {
                    foreach (var item in sql.SQLParameters)
                    {
                        SQLParameter prm = new SQLParameter();
                        prm.DateValue = item.DateValue;
                        if(item.DefaultDateValue != null)
                        prm.DefaultDateValue = (short)item.DefaultDateValue;
                        prm.Name = item.Name;
                        prm.Int32Value = item.Int32Value;
                        prm.StringValue = item.StringValue;
                        prm.IsDate = item.IsDate;
                        prm.IsInt = item.IsInt;
                        prm.IsString = item.IsString;

                        parames.Add(prm);
                    }
                }
                ResultList result = daacess.ExecuteQuery(sql.SQLSentence, parames, 0);
                if (result != null && result.GetRows().Count > 0)
                {

                    for (int i = 0; i < result.GetRows().Count; i++)
                    {
                        CONRecord acco = new CONRecord();
                        acco = GetInvisibleColumns(sql, acco);
                        acco.Fields = new Dictionary<string, string>();
                        acco.Fields.Add("F_NUMERO_REG", Utils.ValidateNumber(acco.RecordNumber, 7, "F_NUMERO_REG"));
                        acco.Fields.Add("F_TIPO_REG", Utils.ValidateNumber(acco.RecordType, 4, "F_TIPO_REG"));
                        acco.Fields.Add("F_SUBTIPO_REG", Utils.ValidateNumber(acco.SubRecordType, 2, "F_SUBTIPO_REG"));
                        acco.Fields.Add("F_VERSION_REG", Utils.ValidateNumber(acco.Version, 2, "F_VERSION_REG"));
                        acco.Company = Utils.ValidateNumber(GetItemFieldValue(result, i, sql.SQLDetails, "F_CIA"), 3, "F_CIA");
                        if (sql.SQLDetails != null && sql.SQLDetails.Count > 0)
                        {
                            for (int j = 0; j < sql.SQLDetails.Count; j++)
                            {
                                //acco.Fields.Add(sql.SQLDetails[j].StructureDetail.Field.ToUpper(), Utils.ValidateNumber(GetItemFieldValue(result,i sql.SQLDetails[j]),  (int)sql.SQLDetails[j].StructureDetail.Sizes, sql.SQLDetails[j].StructureDetail.Field));
                                if (sql.SQLDetails[j].StructureDetail.DBType == 1)
                                    acco.Fields.Add(sql.SQLDetails[j].StructureDetail.Field.ToUpper(), Utils.ValidateNumber(GetItemFieldValue(result, i, sql.SQLDetails[j]), (int)sql.SQLDetails[j].StructureDetail.Sizes, sql.SQLDetails[j].StructureDetail.Field));
                                else if (sql.SQLDetails[j].StructureDetail.DBType == 2)
                                    acco.Fields.Add(sql.SQLDetails[j].StructureDetail.Field.ToUpper(), Utils.ValidateString(GetItemFieldValue(result, i, sql.SQLDetails[j]), (int)sql.SQLDetails[j].StructureDetail.Sizes, sql.SQLDetails[j].StructureDetail.Field));
                                else if (sql.SQLDetails[j].StructureDetail.DBType == 3)
                                    acco.Fields.Add(sql.SQLDetails[j].StructureDetail.Field.ToUpper(), Utils.ValidateDate(GetItemFieldDateValue(result, i, sql.SQLDetails[j]), sql.SQLDetails[j].StructureDetail.Field));
                                else if (sql.SQLDetails[j].StructureDetail.DBType == 4)
                                    acco.Fields.Add(sql.SQLDetails[j].StructureDetail.Field.ToUpper(), Utils.ValidateDecimal(GetItemFieldDecimalValue(result, i, sql.SQLDetails[j]), sql.SQLDetails[j].StructureDetail.Ent, sql.SQLDetails[j].StructureDetail.Dec, sql.SQLDetails[j].StructureDetail.Field, true));
                                else if (sql.SQLDetails[j].StructureDetail.DBType == 5)
                                {
                                    var datnum = result.GetValue(i, sql.SQLDetails[j].Secuence);
                                    acco.Fields.Add(sql.SQLDetails[j].StructureDetail.Field.ToUpper(), Utils.ValidateDecimal(GetItemFieldDecimalValue(result, i, sql.SQLDetails[j]), sql.SQLDetails[j].StructureDetail.Ent, sql.SQLDetails[j].StructureDetail.Dec, sql.SQLDetails[j].StructureDetail.Field, false));
                                }
                            }
                        }
                        acco.LogicalKey = acco.Fields["LLAVELOGICA"].Replace(" ", "");
                        acco.Fields.Remove("LLAVELOGICA");

                        if (acco.Fields.ContainsKey("F350_ID_CO"))
                            acco.OperationCenter = acco.Fields["F350_ID_CO"];
                        if (acco.Fields.ContainsKey("F350_ID_TIPO_DOCTO"))
                            acco.DocumentType = acco.Fields["F350_ID_TIPO_DOCTO"];
                        if (acco.Fields.ContainsKey("F350_CONSEC_DOCTO"))
                            acco.DocumentNumber = Int32.Parse(acco.Fields["F350_CONSEC_DOCTO"]);
                        if (acco.RecordType == 420)
                        {
                            if (acco.Fields.ContainsKey("F420_ID_CO"))
                                acco.OperationCenter = acco.Fields["F420_ID_CO"];
                            if (acco.Fields.ContainsKey("F420_ID_TIPO_DOCTO"))
                                acco.DocumentType = acco.Fields["F420_ID_TIPO_DOCTO"];
                            if (acco.Fields.ContainsKey("F420_CONSEC_DOCTO"))
                                acco.DocumentNumber = Int32.Parse(acco.Fields["F420_CONSEC_DOCTO"]);
                        }
                        if (acco.Fields.ContainsKey("F440_ID_CO"))
                            acco.OperationCenter = acco.Fields["F440_ID_CO"];
                        if (acco.Fields.ContainsKey("F440_ID_TIPO_DOCTO"))
                            acco.DocumentType = acco.Fields["F440_ID_TIPO_DOCTO"];
                        if (acco.Fields.ContainsKey("F440_CONSEC_DOCTO"))
                            acco.DocumentNumber = Int32.Parse(acco.Fields["F440_CONSEC_DOCTO"]);
                        acco.SQLId = sql.Id;
                        acco.SQL = sql;
                        accountings.Add(acco);
                    }
                }
                return accountings;
            }
            catch (Exception e)
            {
                throw new BusinessException(e).GetFaultException();
            }
        }

        public List<CONRecordDetail> GetDataQueryDetail(CONSQL sql)
        {
            try
            {
                List<CONRecordDetail> accountings = new List<CONRecordDetail>();
                Database daacess = new Database(UtilBLL.GetConnectionString(sql.Connection), UtilBLL.GetConnectionDBType(sql.Connection.DbType));
                List<SQLParameter> parames = new List<SQLParameter>();
                if (sql.SQLParameters != null && sql.SQLParameters.Count > 0)
                {
                    foreach (var item in sql.SQLParameters)
                    {
                        SQLParameter prm = new SQLParameter();
                        prm.DateValue = item.DateValue;
                        if (item.DefaultDateValue != null)
                            prm.DefaultDateValue = (short)item.DefaultDateValue;
                        prm.Name = item.Name;
                        prm.Int32Value = item.Int32Value;
                        prm.StringValue = item.StringValue;
                        prm.IsDate = item.IsDate;
                        prm.IsInt = item.IsInt;
                        prm.IsString = item.IsString;

                        parames.Add(prm);
                    }
                }
                ResultList result = daacess.ExecuteQuery(sql.SQLSentence, parames, 0);
                if (result != null && result.GetRows().Count > 0)
                {

                    for (int i = 0; i < result.GetRows().Count; i++)
                    {
                        CONRecordDetail acco = new CONRecordDetail();
                        acco = GetInvisibleColumns(sql, acco);
                        acco.Fields = new Dictionary<string, string>();
                        acco.Fields.Add("F_NUMERO_REG", Utils.ValidateNumber(acco.RecordNumber, 7, "F_NUMERO_REG"));
                        acco.Fields.Add("F_TIPO_REG", Utils.ValidateNumber(acco.RecordType, 4, "F_TIPO_REG"));
                        acco.Fields.Add("F_SUBTIPO_REG", Utils.ValidateNumber(acco.SubRecordType, 2, "F_SUBTIPO_REG"));
                        acco.Fields.Add("F_VERSION_REG", Utils.ValidateNumber(acco.Version, 2, "F_VERSION_REG"));
                        acco.Company = Utils.ValidateNumber(GetItemFieldValue(result, i, sql.SQLDetails, "F_CIA"), 3, "F_CIA");
                        if (sql.SQLDetails != null && sql.SQLDetails.Count > 0)
                        {
                            for (int j = 0; j < sql.SQLDetails.Count; j++)
                            {
                                //acco.Fields.Add(sql.SQLDetails[j].StructureDetail.Field.ToUpper(), Utils.ValidateNumber(GetItemFieldValue(result,i sql.SQLDetails[j]),  (int)sql.SQLDetails[j].StructureDetail.Sizes, sql.SQLDetails[j].StructureDetail.Field));
                                if (sql.SQLDetails[j].StructureDetail.DBType == 1)
                                    acco.Fields.Add(sql.SQLDetails[j].StructureDetail.Field.ToUpper(), Utils.ValidateNumber(GetItemFieldValue(result, i, sql.SQLDetails[j]), (int)sql.SQLDetails[j].StructureDetail.Sizes, sql.SQLDetails[j].StructureDetail.Field));
                                else if (sql.SQLDetails[j].StructureDetail.DBType == 2)
                                    acco.Fields.Add(sql.SQLDetails[j].StructureDetail.Field.ToUpper(), Utils.ValidateString(GetItemFieldValue(result, i, sql.SQLDetails[j]), (int)sql.SQLDetails[j].StructureDetail.Sizes, sql.SQLDetails[j].StructureDetail.Field));
                                else if (sql.SQLDetails[j].StructureDetail.DBType == 3)
                                    acco.Fields.Add(sql.SQLDetails[j].StructureDetail.Field.ToUpper(), Utils.ValidateDate(GetItemFieldDateValue(result, i, sql.SQLDetails[j]), sql.SQLDetails[j].StructureDetail.Field));
                                else if (sql.SQLDetails[j].StructureDetail.DBType == 4)
                                    acco.Fields.Add(sql.SQLDetails[j].StructureDetail.Field.ToUpper(), Utils.ValidateDecimal(GetItemFieldDecimalValue(result, i, sql.SQLDetails[j]), sql.SQLDetails[j].StructureDetail.Ent, sql.SQLDetails[j].StructureDetail.Dec, sql.SQLDetails[j].StructureDetail.Field, true));
                                else if (sql.SQLDetails[j].StructureDetail.DBType == 5)
                                {
                                    var datnum = result.GetValue(i, sql.SQLDetails[j].Secuence);
                                    acco.Fields.Add(sql.SQLDetails[j].StructureDetail.Field.ToUpper(), Utils.ValidateDecimal(GetItemFieldDecimalValue(result, i, sql.SQLDetails[j]), sql.SQLDetails[j].StructureDetail.Ent, sql.SQLDetails[j].StructureDetail.Dec, sql.SQLDetails[j].StructureDetail.Field, false));
                                }
                            }
                        }
                        acco.LogicalKey = acco.Fields["LLAVELOGICA"].Replace(" ", "");
                        acco.Fields.Remove("LLAVELOGICA");

                        if (acco.Fields.ContainsKey("F350_ID_CO"))
                            acco.OperationCenter = acco.Fields["F350_ID_CO"];
                        if (acco.Fields.ContainsKey("F350_ID_TIPO_DOCTO"))
                            acco.DocumentType = acco.Fields["F350_ID_TIPO_DOCTO"];
                        if (acco.Fields.ContainsKey("F350_CONSEC_DOCTO"))
                            acco.DocumentNumber = Int32.Parse(acco.Fields["F350_CONSEC_DOCTO"]);
                        if (acco.RecordType == 420)
                        {
                            if (acco.Fields.ContainsKey("F420_ID_CO"))
                                acco.OperationCenter = acco.Fields["F420_ID_CO"];
                            if (acco.Fields.ContainsKey("F420_ID_TIPO_DOCTO"))
                                acco.DocumentType = acco.Fields["F420_ID_TIPO_DOCTO"];
                            if (acco.Fields.ContainsKey("F420_CONSEC_DOCTO"))
                                acco.DocumentNumber = Int32.Parse(acco.Fields["F420_CONSEC_DOCTO"]);
                        }
                        if (acco.Fields.ContainsKey("F440_ID_CO"))
                            acco.OperationCenter = acco.Fields["F440_ID_CO"];
                        if (acco.Fields.ContainsKey("F440_ID_TIPO_DOCTO"))
                            acco.DocumentType = acco.Fields["F440_ID_TIPO_DOCTO"];
                        if (acco.Fields.ContainsKey("F440_CONSEC_DOCTO"))
                            acco.DocumentNumber = Int32.Parse(acco.Fields["F440_CONSEC_DOCTO"]);
                        acco.SQLId = sql.Id;
                        acco.SQL = sql;
                        accountings.Add(acco);
                    }
                }
                return accountings;
            }
            catch (Exception e)
            {
                throw new BusinessException(e).GetFaultException();
            }
        }

        private String GetItemFieldValue(ResultList result, int row, List<CONSQLDetail> details, String fieldName)
        {
            String fieldValue = "";
            CONSQLDetail sqlDet = details.FirstOrDefault(x => x.StructureDetail.Field.ToUpper().Equals(fieldName.ToUpper()));
            fieldValue = result.GetValue(row, sqlDet.Secuence).ToString(); // dataReader.GetValue(sqlDet.Secuence).ToString();
            if (sqlDet.Equivalence != null && sqlDet.EquivalenceColumnId != null && sqlDet.EquivalenceColumnId > 0)
                fieldValue = GetEquivalenceValue(sqlDet.Equivalence.Id, (Int16)sqlDet.EquivalenceColumnId, fieldValue);
            return fieldValue;
        }

        private string GetEquivalenceValue(Int32 EquivalenceIds, short valueColumn, string code)
        {
            cONEquivalenceDetailDl = new CONEquivalenceDetailBLL(Work.Settings);
            if (!String.IsNullOrWhiteSpace(code))
            {
                CONEquivalenceDetail data = cONEquivalenceDetailDl.FindById(new CONEquivalenceDetail { Equivalence = new CONEquivalence { Id = EquivalenceIds }, Code = code });
                if (data != null)
                {
                    if (valueColumn == 1)
                        return data.Value1;
                    else if (valueColumn == 2)
                        return data.Value2;
                    else if (valueColumn == 3)
                        return data.Value3;
                    else if (valueColumn == 4)
                        return data.Value4;
                    else if (valueColumn == 5)
                        return data.Value5;
                    else if (valueColumn == 6)
                        return data.Value6;
                    else if (valueColumn == 7)
                        return data.Value7;
                    else if (valueColumn == 8)
                        return data.Value8;
                    else if (valueColumn == 9)
                        return data.Value9;
                    else if (valueColumn == 10)
                        return data.Value10;
                    else
                        return "?ER";
                }
            }
            return "?NF";
        }

        private Decimal? GetItemFieldDecimalValue(ResultList result, int row, List<CONSQLDetail> details, String fieldName)
        {
            Decimal? fieldValue = 0;
            Decimal fieldValue1 = 0;
            CONSQLDetail sqlDet = details.FirstOrDefault(x => x.StructureDetail.Field.ToUpper().Equals(fieldName.ToUpper()));
            var objectType = result.GetValue(row, sqlDet.Secuence);
            if (objectType.GetType() == typeof(Decimal))
                fieldValue = (Decimal?)result.GetDecimalValue(row, sqlDet.Secuence);
            else
            {
                if (Decimal.TryParse(objectType.ToString(), out fieldValue1))
                    fieldValue = fieldValue1;
            }
            return fieldValue;
        }

        private Decimal? GetItemFieldDecimalValue(ResultList result, int row, CONSQLDetail detail)
        {
            Decimal? fieldValue = 0;
            Decimal fieldValue1 = 0;
            var objectType = result.GetValue(row, detail.Secuence);

            if (objectType.GetType() == typeof(Decimal))
                fieldValue = result.GetDecimalValue(row, detail.Secuence);
            else
            {
                if (Decimal.TryParse(objectType.ToString(), out fieldValue1))
                    fieldValue = fieldValue1;
            }

            return fieldValue;
        }

        private String GetItemFieldValue(ResultList result, int row, CONSQLDetail detail)
        {
            String fieldValue = "";
            fieldValue = result.GetValue(row, detail.Secuence).ToString();
            if (detail.Equivalence != null && detail.EquivalenceColumnId != null && detail.EquivalenceColumnId > 0)
                fieldValue = GetEquivalenceValue(detail.Equivalence.Id, (Int16)detail.EquivalenceColumnId, fieldValue);
            return fieldValue;
        }

        private DateTime? GetItemFieldDateValue(ResultList result, int row, CONSQLDetail detail)
        {
            DateTime? fieldValue = DateTime.MinValue;
            var objectType = result.GetValue(row, detail.Secuence);
            if (objectType != null && objectType.GetType() == typeof(DateTime))
                fieldValue = result.GetDateTimeValue(row, detail.Secuence);
            else
                fieldValue = null;
            return fieldValue;
        }

        private DateTime GetItemFieldDateValue(ResultList result, int row, List<CONSQLDetail> details, String fieldName)
        {
            DateTime fieldValue = DateTime.MinValue;
            CONSQLDetail sqlDet = details.FirstOrDefault(x => x.StructureDetail.Field.ToUpper().Equals(fieldName.ToUpper()));
            var objectType = result.GetValue(row, sqlDet.Secuence);
            if (objectType.GetType() == typeof(DateTime))
                fieldValue = result.GetDateTimeValue(row, sqlDet.Secuence);
            return fieldValue;
        }

        private CONRecord GetInvisibleColumns(CONSQL sql, CONRecord data)
        {
            cONStructureDetailDl = new CONStructureDetailBLL(Work.Settings);
            List<CONStructureDetail> cols = cONStructureDetailDl.FindAll(new CONStructureDetail { Visible = false, Structure = new CONStructure { Id = sql.Structure.Id } }, Options.All);
            if (cols != null && cols.Count > 0)
            {
                foreach (CONStructureDetail col in cols)
                {
                    if (col.Field.ToUpper() == "f_numero_reg".ToUpper())
                        data.RecordNumber = Int32.Parse(col.DefaultValue);
                    else if (col.Field.ToUpper() == "f_tipo_reg".ToUpper())
                        data.RecordType = Int32.Parse(col.DefaultValue);
                    else if (col.Field.ToUpper() == "f_subtipo_reg".ToUpper())
                        data.SubRecordType = Int32.Parse(col.DefaultValue);
                    else if (col.Field.ToUpper() == "f_version_reg".ToUpper())
                        data.Version = Int32.Parse(col.DefaultValue);
                }
            }
            return data;
        }

        private CONRecordDetail GetInvisibleColumns(CONSQL sql, CONRecordDetail data)
        {
            cONStructureDetailDl = new CONStructureDetailBLL(Work.Settings);
            List<CONStructureDetail> cols = cONStructureDetailDl.FindAll(new CONStructureDetail { Visible = false, Structure = new CONStructure { Id = sql.Structure.Id } }, Options.All);
            if (cols != null && cols.Count > 0)
            {
                foreach (CONStructureDetail col in cols)
                {
                    if (col.Field.ToUpper() == "f_numero_reg".ToUpper())
                        data.RecordNumber = Int32.Parse(col.DefaultValue);
                    else if (col.Field.ToUpper() == "f_tipo_reg".ToUpper())
                        data.RecordType = Int32.Parse(col.DefaultValue);
                    else if (col.Field.ToUpper() == "f_subtipo_reg".ToUpper())
                        data.SubRecordType = Int32.Parse(col.DefaultValue);
                    else if (col.Field.ToUpper() == "f_version_reg".ToUpper())
                        data.Version = Int32.Parse(col.DefaultValue);
                }
            }
            return data;
        }

        public  bool ImportTask(List<CONRecord> parames, int ParallelNumber )
        {
            int numberProcess;
            try
            {
                foreach (CONRecord item in parames)
                {
                    string idOperationCenter = "";
                    string idDocumentType = "";
                    if (item.IsDocument())
                    {
                        int? recordType = null;
                        if (item.RecordType == 450 || item.RecordType == 461)
                            recordType = 350;
                        else
                            recordType = item.RecordType;
                        idOperationCenter = "F" + recordType + "_ID_CO";
                        idDocumentType = "F" + recordType + "_ID_TIPO_DOCTO";
                    }
                    if (item.IsDocument() && item.DocumentNumber == 0)
                        item.DocumentNumber = GetConsecutive(item.Fields[idOperationCenter] + "" + item.Fields[idDocumentType]);
                }

                bool send = false;
                //int c = 0;
                parames.OrderBy(x => x.OperationCenter).ThenBy(x => x.DocumentNumber).ThenBy(x => x.DocumentType);
                Dictionary<string, List<CONRecord>> reg = new Dictionary<string, List<CONRecord>>();
                List<string> co = (from a in parames select a.OperationCenter).Distinct().ToList();

                foreach (string item in co)
                {
                    List<CONRecord> rec = (from x in parames where x.OperationCenter == item select x).ToList();
                    reg.Add(item, rec);
                }
                parames = null;

                if (ParallelNumber == 0)
                    numberProcess = Int32.Parse(App.Current.Configuration.AppSettings["PallalelProcessNumber"]);
                else
                    numberProcess = ParallelNumber;
                
                ParallelOptions pOptions = new ParallelOptions();
                if (numberProcess == 0)
                {
                    int maxThreads = Environment.ProcessorCount;
                    pOptions.MaxDegreeOfParallelism = maxThreads;
                }
                else
                    pOptions.MaxDegreeOfParallelism = numberProcess;

                Parallel.ForEach(reg.Keys, pOptions, currentElement =>
                {
                    CONSQLBLL conSQLBLL = new CONSQLBLL(Work.Settings);

                    send = conSQLBLL.UNOEEImport(reg[currentElement]);
                    //conSQLBLL = null;
                    //reg[currentElement] = null;
                });

                return send;
            }
            catch (Exception e)
            {
                throw new BusinessException(e).GetFaultException();
            }
        }

        public bool UNOEEImport(List<CONRecord> parames)
        {
            try
            {
                int e = 0;

                if (parames != null && parames.Count > 0)
                {

                    List<CONSQL> sqls = parames.Select(x => x.SQL).Distinct().ToList<CONSQL>();
                    if (sqls != null && sqls.Count > 0)
                    {

                        foreach (var item in sqls)
                        {
                            if (item.SQLSends == null || item.SQLSends.Count == 0)
                            {
                                cONSQLSendDl = new CONSQLSendBLL(Work.Settings);
                                item.SQLSends = cONSQLSendDl.FindAll(new CONSQLSend { SQLId = item.Id }, Options.All);
                            }
                        }
                    }
                    foreach (CONRecord record in parames)
                    {
                        CONRecord data = null;
                        if (record.RecordDetails == null || record.RecordDetails.Count == 0)
                        {
                            record.RecordDetails = new CONRecordDetailBLL(Work.Settings).FindAll(new CONRecordDetail { RecordId = record.Id }, Options.All);
                        }

                        record.SQL = sqls.FirstOrDefault(x => x.Id == record.SQL.Id);
                        if (record.SQL.SQLSends != null && record.SQL.SQLSends.Count > 0)
                            foreach (var item in record.SQL.SQLSends)
                            {
                                if (item.Active == true)
                                    data = UNOEEDirectImport(UtilBLL.GetConnectionString(item.CONIntegratorConfiguration.Connection), UtilBLL.GetConnectionDBType(item.CONIntegratorConfiguration.Connection.DbType), item.CONIntegratorConfiguration, record);
                            }

                        if (data == null || (data.Errors1 != null && data.Errors1.Count > 0))
                            e++;
                        //succes = false;


                    }
                    if (e > 0)
                        return false;
                    else
                        return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                throw new BusinessException(e).GetFaultException();
            }

        }

        //public CONRecord UNOEEWebImport(string connectionString, DBType dbType, CONIntegratorConfiguration conf, CONRecord param)
        //{
        //    try
        //    {
        //        cONRecordDl = new CONRecordDL(Work.Settings);
        //        cONErrorDl = new CONErrorDL(Work.Settings);
        //        string UNOEEConnectionStringName = conf.InternalConnectionName;
        //        string UNOEEUser = conf.InternalUser;
        //        string UNOEEPasword = Crypto.DecrytedString(conf.InternalPassword);
        //        string idOperationCenter = "";
        //        string idDocumentType = "";
        //        string stringXML = string.Empty;
        //        if (param.IsDocument())
        //        {
        //            idOperationCenter = "F" + param.RecordType + "_ID_CO";
        //            idDocumentType = "F" + param.RecordType + "_ID_TIPO_DOCTO";
        //        }
        //        if (param.IsDocument() && param.DocumentNumber == 0)
        //            param.DocumentNumber = GetConsecutive(param.Fields[idOperationCenter] + "" + param.Fields[idDocumentType]);
        //        int j = 1;
        //        CONInitial inicial = new CONInitial { RecordNumber = j.ToString(), RecordType = "0", SubRecordType = "0", Version = "01", Company = param.Company + "" };
        //        j++;
        //        param.RecordNumber = j;
        //        j++;
        //        stringXML = "<Importar>\n " +
        //                        "   <NombreConexion>" + UNOEEConnectionStringName + "</NombreConexion>\n " +
        //                        "   <IdCia>" + param.Company + "</IdCia>\n " +
        //                        "   <Usuario>" + UNOEEUser + "</Usuario>\n " +
        //                        "   <Clave>" + UNOEEPasword + "</Clave>\n " +
        //                        "   <Datos>\n " +
        //                        "       <Linea>" + inicial.PlainText + "</Linea>\n";
        //        stringXML += "      <Linea>" + param.PlainText.Replace("&", " ") + "</Linea>\n";
        //        if (param.RecordDetails != null && param.RecordDetails.Count > 0)
        //            for (int i = 0; i < param.RecordDetails.Count; i++)
        //            {
        //                param.RecordDetails[i].RecordNumber = j;
        //                param.RecordDetails[i].DocumentNumber = param.DocumentNumber;
        //                stringXML += "      <Linea>" + param.RecordDetails[i].PlainText.Replace("&", " ") + "</Linea>\n";
        //                j++;
        //            }
        //        CONFinal final = new CONFinal { RecordNumber = j.ToString(), RecordType = "9999", SubRecordType = "0", Version = "01", Company = param.Company + "" };
        //        stringXML += "      <Linea>" + final.ToString() + "</Linea>\n";
        //        stringXML += "  </Datos>\n " +
        //                     "</Importar>";

        //        List<CONError> errors = ((UnitOfWork)Work).UNOEEImport(conf, stringXML);
        //        if (errors == null)
        //        {
        //            if (param.IsDocument())
        //            {
        //                if (Work.ValidateDocumentUNOEE(connectionString, dbType, Int16.Parse(param.Company), param.OperationCenter, param.DocumentType, (Int32)param.DocumentNumber))
        //                    param.IsSend = true;
        //                else
        //                    param.IsSend = false;
        //            }
        //            else
        //            {
        //                param.IsSend = true;
        //            }
        //            cONRecordDl.Execute(param, Actions.Modify, Options.Me, "");
        //        }
        //        else
        //        {
        //            List<CONError> conerrosOld = cONErrorDl.FindAll(new CONError { RecordId = param.Id, Record = new CONRecord { Id = param.Id } });
        //            if (conerrosOld != null && conerrosOld.Count > 0)
        //                cONErrorDl.Remove(conerrosOld);
        //            param.Errors1 = errors;
        //            cONRecordDl.Execute(param, Actions.Modify, Options.All, "");
        //        }
        //        return param;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new BusinessException(e).GetFaultException();
        //    }
        //}

        public CONRecord UNOEEDirectImport(string connectionString, DBType dbType, CONIntegratorConfiguration conf, CONRecord param)
        {
            try
            {
                DateTime tsProceso = DateTime.Now;
                cONRecordDl = new CONRecordBLL(Work.Settings);
                cONErrorDl = new CONErrorBLL(Work.Settings);
                string UNOEEUser = conf.InternalUser;
                string UNOEEPasword = Crypto.DecrytedString(conf.InternalPassword);
                //string idOperationCenter = "";
                //string idDocumentType = "";
                List<string> stringXML = new List<string>();
                //if (param.IsDocument())
                //{
                //    int? recordType = null;
                //    if (param.RecordType == 450)
                //        recordType = 350;
                //    else
                //        recordType = param.RecordType;
                //    idOperationCenter = "F" + recordType + "_ID_CO";
                //    idDocumentType = "F" + recordType + "_ID_TIPO_DOCTO";
                //}
                //if (param.IsDocument() && param.DocumentNumber == 0)
                //    param.DocumentNumber = GetConsecutive(param.Fields[idOperationCenter] + "" + param.Fields[idDocumentType]);
                int j = 1;
                CONInitial inicial = new CONInitial { RecordNumber = j.ToString(), RecordType = "0", SubRecordType = "0", Version = "01", Company = param.Company + "" };
                j++;
                param.RecordNumber = j;
                j++;
                stringXML.Add(inicial.PlainText);
                stringXML.Add(param.PlainText.Replace("&", " "));
                if (param.RecordDetails != null && param.RecordDetails.Count > 0)
                    for (int i = 0; i < param.RecordDetails.Count; i++)
                    {
                        param.RecordDetails[i].RecordNumber = j;
                        param.RecordDetails[i].DocumentNumber = param.DocumentNumber;
                        stringXML.Add(param.RecordDetails[i].PlainText.Replace("&", " "));
                        j++;
                    }
                CONFinal final = new CONFinal { RecordNumber = j.ToString(), RecordType = "9999", SubRecordType = "0", Version = "01", Company = param.Company + "" };
                stringXML.Add(final.PlainText);
                InsertT667ImpConectorControl(connectionString, dbType, tsProceso.ToString(), Int16.Parse(param.Company), param.LogicalKey);
                if (stringXML != null && stringXML.Count > 0)
                {
                    foreach (string item in stringXML)
                    {
                        InsertT668ImpConectorDetalle(connectionString, dbType, tsProceso.ToString(), Int16.Parse(param.Company), param.LogicalKey, item);
                    }
                }
                ProcessStartInfo startInfo = new ProcessStartInfo(conf.ProgramPath, " 1, " + conf.ConnectionNumber + ", " + conf.InternalUser + ", " + Crypto.DecrytedString(conf.InternalPassword) + ", " + Int16.Parse(param.Company) + ", " + tsProceso.ToString()+ ", " + param.LogicalKey + " , 0");
                startInfo.UseShellExecute = false;
                startInfo.ErrorDialog = true;
                startInfo.CreateNoWindow = true;
                Process process = Process.Start(startInfo);
                process.WaitForExit();
                int numRef = process.ExitCode;
                process.Close();
                List<CONError> errors = null;
                if(numRef!=0)
                    errors = GetImportErrors(connectionString, dbType, tsProceso.ToString(), Int16.Parse(param.Company), param.LogicalKey, numRef);
                if (errors == null || errors.Count==0)
                {
                    if (param.IsDocument() && numRef == 0)
                    {
                        if (ValidateDocumentUNOEE(connectionString, dbType, Int16.Parse(param.Company), param.OperationCenter, param.DocumentType, (Int32)param.DocumentNumber))
                        //if (numRef == 0)
                            param.IsSend = true;
                        else
                            param.IsSend = false;
                    }
                    else if (numRef == 0)
                    {
                        param.IsSend = true;
                    }
                    cONRecordDl.Execute(param, Actions.Modify, Options.Me, "");
                }
                else
                {
                    List<CONError> conerrosOld = cONErrorDl.FindAll(new CONError { RecordId = param.Id, Record = new CONRecord { Id = param.Id } }, Options.All);
                    if (conerrosOld != null && conerrosOld.Count > 0)
                        cONErrorDl.Remove(conerrosOld);
                    param.Errors1 = errors;
                    cONRecordDl.Execute(param, Actions.Modify, Options.All, "");
                }
                return param;
            }

            catch (Exception e)
            {
                throw new BusinessException(e).GetFaultException();
            }
        }

        public Boolean ValidateDocumentUNOEE(string connectionString, DBType dbType, short idCia, string coDocto, string tipoDocto, int consecDocto)
        {
            string sqlSentence = "";
            sqlSentence = "select count(0) Nro  from t350_co_docto_contable where f350_id_cia = " + idCia + " and f350_id_co = '" + coDocto + "' and f350_id_tipo_docto = '" + tipoDocto + "' and f350_consec_docto = " + consecDocto;
            Database databaseDirec = new Database(connectionString, dbType);
            ResultList dat = databaseDirec.ExecuteQuery(sqlSentence, new List<SQLParameter>(), 0);
            if (dat.GetIntValue(0, "Nro") == 0)
                return false;
            else
                return true;
        }

        public void InsertT667ImpConectorControl(string connectionString, DBType dbType, string f667_ts_proceso, Int16 f667_id_cia, string f667_referencia)
        {
            string sqlSentence = " INSERT INTO t667_imp_conector_control(f667_ts_proceso,f667_id_cia,f667_referencia,f667_ind_procesable,f667_ind_error,f667_estado_proceso) VALUES (@f667_ts_proceso,@f667_id_cia, @f667_referencia,@f667_ind_procesable, @f667_ind_error,@f667_estado_proceso) ";
            List<SQLParameter> parameters = new List<SQLParameter>();
            parameters.Add(new SQLParameter { Name = "@f667_ts_proceso", IsString = true, StringValue = f667_ts_proceso });
            parameters.Add(new SQLParameter { Name = "@f667_id_cia", IsInt = true, Int32Value = f667_id_cia });
            parameters.Add(new SQLParameter { Name = "@f667_referencia", IsString = true, StringValue = f667_referencia });
            parameters.Add(new SQLParameter { Name = "@f667_ind_procesable", IsInt = true, Int32Value = 1 });
            parameters.Add(new SQLParameter { Name = "@f667_ind_error", IsInt = true, Int32Value = 0 });
            parameters.Add(new SQLParameter { Name = "@f667_estado_proceso", IsInt = true, Int32Value = 0 });
            Database databaseDirec = new Database(connectionString, dbType);
            databaseDirec.ExecuteNonQuery(sqlSentence, parameters);
        }


        public void InsertT668ImpConectorDetalle(string connectionString, DBType dbType, string f667_ts_proceso, Int16 f667_id_cia, string f667_referencia, string registro)
        {
            try {
                string sqlSentence = " INSERT INTO t668_imp_conector_detalle (f668_ts_proceso, f668_id_cia, f668_referencia, f668_registro) VALUES (@f668_ts_proceso,@f668_id_cia,@f668_referencia,@f668_registro) ";
                List<SQLParameter> parameters = new List<SQLParameter>();
                parameters.Add(new SQLParameter { Name = "@f668_ts_proceso", IsString = true, StringValue = f667_ts_proceso });
                parameters.Add(new SQLParameter { Name = "@f668_id_cia", IsInt = true, Int32Value = f667_id_cia });
                parameters.Add(new SQLParameter { Name = "@f668_referencia", IsString = true, StringValue = f667_referencia });
                parameters.Add(new SQLParameter { Name = "@f668_registro", IsString = true, StringValue = registro });
                Database databaseDirec = new Database(connectionString, dbType);
                databaseDirec.ExecuteNonQuery(sqlSentence, parameters);
            }
            catch (Exception e)
            {
                throw new BusinessException(e).GetFaultException();
            }
        }

        public List<CONError> GetImportErrors(string connectionString, DBType dbType, string f667_ts_proceso, Int16 f667_id_cia, string f667_referencia, int numRef)
        {
            string stringError = string.Empty;
            string sqlSentence = "select f664_ts_proceso, f664_id_cia, f664_referencia,  ErrorLevel, ErrorValue, ErrorDetail, RecordNumber, RecordType, SubRecordType, Version, UpdatedBy, LastUpdate ";
            sqlSentence += "        from ( ";
            //sqlSentence += "               select a.f664_ts_proceso,a.f664_id_cia,a.f664_referencia, 0 ErrorId, 1 ErrorLevel, 'Encabezado' ErrorValue, a.f664_detalle ErrorDetail, 0 RecordId, 0 RecordNumber, 0 RecordType, 0 SubRecordType, 0 Version, '' UpdatedBy, a.f664_ts_inicial LastUpdate ";
            //sqlSentence += "                 from t664_imp_log_control a, ";
            //sqlSentence += "                      t665_imp_log_detalle b ";
            //sqlSentence += "                WHERE a.f664_rowid = b.f665_rowid_imp_log ";
            //sqlSentence += "                union all ";
            sqlSentence += "                select a.f664_ts_proceso,a.f664_id_cia,a.f664_referencia, 0 ErrorId, b.f665_nivel_error ErrorLevel, b.f665_valor_error ErrorValue, b.f665_detalle_error ErrorDetail, 0 RecordId, b.f665_nro_registro RecordNumber, b.f665_tipo_reg RecordType, b.f665_subtipo_reg SubRecordType, b.f665_version Version, '' UpdatedBy, a.f664_ts_final LastUpdate ";
            sqlSentence += "                  from t664_imp_log_control a, ";
            sqlSentence += "                       t665_imp_log_detalle b ";
            sqlSentence += "                 WHERE a.f664_rowid = b.f665_rowid_imp_log ";
            sqlSentence += "             ) as Errros ";
            sqlSentence += "       where f664_ts_proceso = @f664_ts_proceso and ";
            sqlSentence += "             f664_id_cia = @f664_id_cia and ";
            sqlSentence += "             f664_referencia = @f664_referencia ";
            List<SQLParameter> parameters = new List<SQLParameter>();
            parameters.Add(new SQLParameter { Name = "@f664_ts_proceso", IsString = true, StringValue = f667_ts_proceso });
            parameters.Add(new SQLParameter { Name = "@f664_id_cia", IsInt = true, Int32Value = f667_id_cia });
            parameters.Add(new SQLParameter { Name = "@f664_referencia", IsString = true, StringValue = f667_referencia });
            Database databaseDirec = new Database(connectionString, dbType);
            ResultList result = databaseDirec.ExecuteQuery(sqlSentence, parameters, 0);
            List<CONError> errors = new List<CONError>();
            if (numRef != 0)
            {
                if (numRef.Equals(1))
                    stringError = "?	1 = Problemas de Datos o Estructura.";
                if (numRef.Equals(2))
                    stringError = "?	2 = Faltan par?metros de llamado.";
                else if (numRef.Equals(3))
                    stringError = "?	3 = El usuario enviado no existe o no es v?lido.";
                else if (numRef.Equals(4))
                    stringError = "?	4 = Error al inicializar servidores de UNOEE.";
                else if (numRef.Equals(5))
                    stringError = "?	5 = Error al conectarse a la base de datos, n?mero de conexi?n no v?lida o error en la configuraci?n de la conexi?n.";
                else if (numRef.Equals(6))
                    stringError = "?	6 = Ruta del archivo enviado no existe. Aplica cuando la fuente de informaci?n es 0 (Archivo plano).";
                else if (numRef.Equals(7))
                    stringError = "?	7 = El archivo enviado no es v?lido, puede ser porque el tama?o es 0 o hubo error al accesar el archivo, aplica cuando la fuente de informaci?n es 0 (Archivo plano).";
                else if (numRef.Equals(8))
                    stringError = "?	8 = No es posible encontrar informaci?n en la tabla t667 o t668 con los par?metros 6, 7 y la compa??a enviada, aplica cuando la fuente de informaci?n es 1 (Tablas del sistema)";
                else if (numRef.Equals(9))
                    stringError = "?	9 = Compa??a no v?lida.";
                else if (numRef.Equals(10))
                    stringError = "?	10 = Windows desconocido. La versi?n del sistema operativo no pudo ser le?da.";
                else if (numRef.Equals(99))
                    stringError = "?    99 =  Otro no identificado.";
                if (!String.IsNullOrWhiteSpace(stringError) && numRef != 1)
                    errors.Add(new CONError { ErrorDetail = stringError, ErrorLevel = 1, ErrorValue = "Error de Importaci?n" });
            }
            if (result != null && result.GetRows().Count > 0)
            {
                for (int i = 0; i < result.GetRows().Count; i++)
                {
                    CONError error = new CONError();
                    error.ErrorLevel = (Int16)result.GetIntValue(i, "ErrorLevel");
                    error.ErrorValue = result.GetStringValue(i, "ErrorValue");
                    error.ErrorDetail = result.GetStringValue(i, "ErrorDetail");
                    error.RecordType = result.GetIntValue(i, "RecordType");
                    error.SubRecordType = result.GetIntValue(i, "SubRecordType");
                    error.Version = result.GetIntValue(i, "Version");
                    error.LastUpdate = result.GetDateTimeValue(i, "LastUpdate");
                    errors.Add(error);
                }
            }
            return errors;
        }

        public CONSQL GenerateMastersZapa(IUnitOfWork connectionString)
        {  
            CONSQL data =  new CONSQL();
            //Articulos Zapa
            StringBuilder text = new StringBuilder();
            /*
            StringBuilder text = new StringBuilder();
            string sqlSentence = @"SELECT DISTINCT 'idarticulo|' idarticulo, 'idfamilia|' AS idfamilia, 'idtemporada|' AS idtemporada, 'idproveedor|' AS idproveedor,'idseccion|' AS idseccion,";
            sqlSentence += @"'idcolor|' AS idcolor,'idmaterial|' AS idmaterial, 'idcorte|' AS idcorte, 'idtacon|' AS idtacon,'idlinea|' AS idlinea,'idmarcar|' AS idmarcar, 'descripcion|' AS descripcion,'bordadofab|' AS bordadofab,  ";
            sqlSentence+= @"'hormafab|' AS hormafab,'taconfab|' AS taconfab,'pisofab|' AS pisofab,'descripfab|' AS descripfab,'modeloprov|' AS modeloprov,'fechaalta|' AS fechaalta, 'fechabaja|' AS fechabaja,'codigoalfa|' AS codigoalfa,'afines|' AS afines, 'preciotarifa|' AS preciotarifa,'precioventaor|' AS precioventaor, 'preciocostomedio|' AS preciocostomedio,'tipoiva|' AS tipoiva,'id_base_talla|' AS id_base_talla, ";
            sqlSentence+=@"'id_cabecero|' AS id_cabecero,'clave_presup|' AS clave_presup, 'observaciones|' AS observaciones, 'materialforro|' AS materialforro, 'colorforro|' AS colorforro,'materialplanta|' AS materialplanta,'colorplanta' AS colorplanta FROM VDDATA.[dbo].[t120_mc_items] AS item union all ";
            sqlSentence+= @"SELECT DISTINCT top 100 convert(varchar,item.f120_id)+'|' AS idarticulo,'30|' AS idfamilia, '0|' AS idtemporada,convert(varchar,isnull(item.f120_rowid_tercero_prov,0))+'|' AS idproveedor,'0|' AS idseccion,convert(varchar,rtrim(ext1_item.f117_id))+'|' AS idcolor,'0|' AS idmaterial,convert(varchar,isnull(descTec.f103_id,0))+'|' AS idcorte,'0|' AS idtacon,'0|' AS idlinea,'0|' AS idmarcar,' |' AS descripcion, ";
            sqlSentence+=@"' |' AS bordadofab, ' |' AS hormafab, ' |' AS taconfab,' |' AS pisofab, ' |' AS descripfab,rtrim(item.f120_referencia)+'|' AS modeloprov,CONVERT(NVARCHAR,CAST(item.f120_fecha_creacion AS DATETIME),103)+'|' AS fechaalta, ' |' AS fechabaja,CONVERT(NVARCHAR,item.f120_id)+'|' AS codigoalfa, convert(varchar,item.f120_id)+'|' AS afines, convert(varchar,isnull(cast(precio.f126_precio as float),0))+'|' AS preciotarifa, ";
            sqlSentence+=@"convert(varchar,isnull(cast(precio.f126_precio as float),0))+'|' AS precioventaor, convert(varchar,isnull(cast(precio.f126_precio as float),0))+'|' AS preciocostomedio, '16|' AS tipoiva,  '1|' AS id_base_talla,'1|' AS id_cabecero, ' |' AS clave_presup, ' |' AS observaciones, ' |' AS materialforro, ' |' AS colorforro, ' |' AS materialplanta, ' ' AS colorplanta ";
            sqlSentence += @"FROM VDDATA.[dbo].[t120_mc_items] AS item INNER JOIN VDDATA.[dbo].[t121_mc_items_extensiones] AS ext_item ON item.f120_rowid = ext_item.f121_rowid_item  INNER JOIN VDDATA.[dbo].[t119_mc_extensiones2_detalle] AS ext2_item ON ext_item.f121_id_ext2_detalle = ext2_item.f119_id  INNER JOIN VDDATA.[dbo].[t117_mc_extensiones1_detalle] AS ext1_item ON ext_item.f121_id_ext1_detalle = ext1_item.f117_id  LEFT JOIN  VDDATA.[dbo].[t103_mc_descripciones_tecnicas] AS descTec ON descTec.f103_id = item.f120_id_descripcion_tecnica  LEFT JOIN  VDDATA.[dbo].[t126_mc_items_precios] AS precio ON precio.f126_rowid_item = item.f120_rowid ";
            //sqlSentence+="where f120_id_cia= @f120_id_cia ";
            //List<SQLParameter> param = new List<SQLParameter>();
            //param.Add( new SQLParameter { Name = "@f120_id_cia", IsString = true, StringValue = "1" });
            Database databaseDirec = new Database(connectionString.Settings.ConnectionString, connectionString.Settings.DBType);
            ResultList result = databaseDirec.ExecuteQuery(sqlSentence);
            if (result != null && result.GetRows().Count > 0)
            {
                
                for (int i = 0; i < result.GetRows().Count; i++)
                {
                    
                    text.Append(result.GetStringValue(i, "idarticulo"));
                    text.Append(result.GetStringValue(i, "idfamilia"));
                    text.Append(result.GetStringValue(i, "idtemporada"));
                    text.Append(result.GetStringValue(i, "idproveedor"));
                    text.Append(result.GetStringValue(i, "idseccion"));
                    text.Append(result.GetStringValue(i, "idmaterial"));
                    text.Append(result.GetStringValue(i, "idcolor"));
                    text.Append(result.GetStringValue(i, "idcorte"));
                    text.Append(result.GetStringValue(i, "idtacon"));
                    text.Append(result.GetStringValue(i, "idlinea"));
                    text.Append(result.GetStringValue(i, "idmarcar"));
                    text.Append(result.GetStringValue(i, "descripcion"));
                    text.Append(result.GetStringValue(i, "bordadofab"));
                    text.Append(result.GetStringValue(i, "hormafab"));
                    text.Append(result.GetStringValue(i, "taconfab"));
                    text.Append(result.GetStringValue(i, "pisofab"));
                    text.Append(result.GetStringValue(i, "descripfab"));
                    text.Append(result.GetStringValue(i, "modeloprov"));
                    text.Append(result.GetStringValue(i, "fechaalta"));
                    text.Append(result.GetStringValue(i, "fechabaja"));
                    text.Append(result.GetStringValue(i, "codigoalfa"));
                    text.Append(result.GetStringValue(i, "afines"));
                    text.Append(result.GetStringValue(i, "preciotarifa"));
                    text.Append(result.GetStringValue(i, "precioventaor"));
                    text.Append(result.GetStringValue(i, "preciocostomedio"));
                    text.Append(result.GetStringValue(i, "tipoiva"));
                    text.Append(result.GetStringValue(i, "id_base_talla"));
                    text.Append(result.GetStringValue(i, "id_cabecero"));
                    text.Append(result.GetStringValue(i, "clave_presup"));
                    text.Append(result.GetStringValue(i, "observaciones"));
                    text.Append(result.GetStringValue(i, "materialforro"));
                    text.Append(result.GetStringValue(i, "colorforro"));
                    text.Append(result.GetStringValue(i, "materialplanta"));
                    text.AppendLine(result.GetStringValue(i, "colorplanta"));

                    
                    
                    
                    
                }
            }
            string t = text.ToString();
            string name = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            System.IO.StreamWriter exp = new System.IO.StreamWriter(@"D:\prueba\Articulos"+name+".txt");
            exp.Write(t);
            exp.Close();
            */

            //Encabezado Pedidos
            string sqlSentence = string.Empty;
            text = new StringBuilder();
            sqlSentence = @"SELECT 
          'Numero|' AS Numero,
          'Nit|' AS Nit,
          'Tienda|' AS Tienda,
          'Temporada|' AS Temporada,
          'Fecha_Ped|' AS Fecha_Ped,
          'Fecha_Serv|' AS Fecha_Serv,
          'Fecha_Conf|' AS Fecha_Conf,
          'Fecha_Valo|' Fecha_Valo,
          'Etiqueta|' AS Etiqueta,
          'Timbrado|' AS Timbrado,
          'Observacio|' AS Observacio,
          'DiasGiro|' AS DiasGiro,
          'Pagos|' AS Pagos,
          'Pagos1|' AS Pagos1,
          'dc|' AS dc,
          'dpp' AS dpp
        

union all

SELECT
          DISTINCT 
		 convert(varchar,docto_oc.f420_consec_docto) + '|' AS Numero,
          convert(varchar, rtrim(ter.f200_id)) + '|' AS Nit,
          '""'+convert(varchar,SubString(bod.f150_id,3,5)) + '""|' AS Tienda,
          '""""|' AS Temporada,
          isnull(CONVERT(NVARCHAR,CAST(docto_oc.f420_fecha_ts_creacion AS DATETIME),101),' ')+ '|' AS FechaPed,
          isnull(CONVERT(NVARCHAR,CAST(docto_oc.f420_fecha_ts_creacion AS DATETIME),101),' ')+ '|' AS FechaServ,
          isnull(CONVERT(NVARCHAR,CAST(docto_oc.f420_fecha_ts_actualizacion AS DATETIME),101),' ')+ '|' AS FechaConf,
          isnull(CONVERT(NVARCHAR,CAST(docto_oc.f420_fecha_ts_aprobacion AS DATETIME),101)  ,' ')+ '|' FechaValo,
          '""f""|' AS Etiqueta,
          '""""|' AS Timbrado,
          '""""|' AS Observacion,
          '""90""|' AS DiasGiro,
          '100|' AS Pagos,
          '0|' AS Pagos1,
          '0|' AS dc,
          '0' AS dpp
          
FROM VDDATA.[dbo].[t420_cm_oc_docto] AS docto_oc 
INNER JOIN VDDATA.[dbo].[t421_cm_oc_movto] AS docto_mov ON docto_oc.f420_rowid  = docto_mov.[f421_rowid_oc_docto] 
INNER JOIN VDDATA.[dbo].[t150_mc_bodegas] AS bod ON docto_mov.f421_rowid_bodega = bod.f150_rowid 
INNER JOIN VDDATA.[dbo].[t202_mm_proveedores] AS prov ON docto_oc.f420_rowid_tercero_prov = prov.[f202_rowid_tercero] 
INNER JOIN VDDATA.[dbo].[t200_mm_terceros] AS ter ON prov.f202_rowid_tercero = ter.f200_rowid 
WHERE  docto_oc.f420_id_tipo_docto = 'OCP'
and CAST(docto_oc.f420_fecha_ts_creacion AS DATE) =  convert(date,DATEADD(day,-1,getdate()))";

            Database databaseDirec = new Database(connectionString.Settings.ConnectionString, connectionString.Settings.DBType);
            ResultList result = databaseDirec.ExecuteQuery(sqlSentence);

            if (result != null && result.GetRows().Count > 0)
            {

                for (int i = 0; i < result.GetRows().Count; i++)
                {

                    text.Append(result.GetStringValue(i, "Numero"));
                    text.Append(result.GetStringValue(i, "Nit"));
                    text.Append(result.GetStringValue(i, "Tienda"));
                    text.Append(result.GetStringValue(i, "Temporada"));
                    text.Append(result.GetStringValue(i, "FechaPed"));
                    text.Append(result.GetStringValue(i, "FechaServ"));
                    text.Append(result.GetStringValue(i, "FechaConf"));
                    text.Append(result.GetStringValue(i, "FechaValo"));
                    text.Append(result.GetStringValue(i, "Etiqueta"));
                    text.Append(result.GetStringValue(i, "Timbrado"));
                    text.Append(result.GetStringValue(i, "Observacion"));
                    text.Append(result.GetStringValue(i, "DiasGiro"));
                    text.Append(result.GetStringValue(i, "Pagos"));
                    text.Append(result.GetStringValue(i, "Pagos1"));
                    text.Append(result.GetStringValue(i, "dc"));
                    text.AppendLine(result.GetStringValue(i, "dpp"));
                }
            }
            string t = text.ToString();
            string name = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            System.IO.StreamWriter exp = new System.IO.StreamWriter(@"C:\Users\Public\Documents\PedidoEnc" + name + ".txt");
            exp.Write(t);
            exp.Close();


            //PEdidos Detalle
            sqlSentence = string.Empty;
            text = new StringBuilder();
            sqlSentence = @"SELECT     'pedido|' AS pedido,
          'orden|' AS orden,
          'tienda|' AS tienda,
          'referencia|' AS referencia,
          'talla|' AS talla,
          'precio|' AS precio,
          'dpto|' AS dpto,
          'ped|' AS ped,
          'recibido' AS recibido

union all

SELECT     convert(varchar,docto_oc.f420_consec_docto)+'|' AS pedido,
          convert(varchar,CAST(ROW_NUMBER() OVER(PARTITION BY docto_oc.f420_consec_docto ORDER BY docto_oc.f420_consec_docto) AS INTEGER))+'|' AS orden,
          '""'+convert(varchar,SubString(f150_id,3,5))+'""|' AS tienda,
          '""'+convert(varchar,item.f120_id)+'""|' AS referencia,
          '""'+convert(varchar,ext2_item.f119_descripcion)+'""|' AS talla,
          convert(varchar,isnull(cast(precio.f126_precio as float),0))+'|' AS precio,
          '0|' AS dpto,
          convert(varchar,CAST(docto_mov.f421_cant_pedida AS INTEGER))+'|' AS ped,
          '0' AS recibido
FROM VDDATA.[dbo].[t420_cm_oc_docto] AS docto_oc 
INNER JOIN VDDATA.[dbo].[t421_cm_oc_movto] AS docto_mov ON docto_oc.f420_rowid  = docto_mov.[f421_rowid_oc_docto] 
INNER JOIN VDDATA.[dbo].[t150_mc_bodegas] AS bod ON docto_mov.f421_rowid_bodega = bod.f150_rowid 
INNER JOIN VDDATA.[dbo].[t121_mc_items_extensiones] AS ext_item ON docto_mov.f421_rowid_item_ext = ext_item.f121_rowid 
INNER JOIN VDDATA.[dbo].[t120_mc_items] AS item ON item.f120_rowid = ext_item.f121_rowid_item 
LEFT JOIN VDDATA.[dbo].[t119_mc_extensiones2_detalle] AS ext2_item ON ext_item.f121_id_ext2_detalle = ext2_item.f119_id 
LEFT JOIN VDDATA.[dbo].[t126_mc_items_precios] AS precio ON precio.f126_rowid_item = item.f120_rowid 
WHERE docto_oc.f420_id_tipo_docto = 'OCP'
and CAST(docto_oc.f420_fecha_ts_creacion AS DATE) = convert(date,DATEADD(day,-1,getdate())) ";
            
            databaseDirec = new Database(connectionString.Settings.ConnectionString, connectionString.Settings.DBType);
             result = databaseDirec.ExecuteQuery(sqlSentence);

            if (result != null && result.GetRows().Count > 0)
            {

                for (int i = 0; i < result.GetRows().Count; i++)
                {

                    text.Append(result.GetStringValue(i, "pedido"));
                    text.Append(result.GetStringValue(i, "orden"));
                    text.Append(result.GetStringValue(i, "tienda"));
                    text.Append(result.GetStringValue(i, "referencia"));
                    text.Append(result.GetStringValue(i, "talla"));
                    text.Append(result.GetStringValue(i, "precio"));
                    text.Append(result.GetStringValue(i, "dpto"));
                    text.Append(result.GetStringValue(i, "ped"));
                    text.AppendLine(result.GetStringValue(i, "recibido"));
                   
                }
            }
             t = text.ToString();
             name = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
             exp = new System.IO.StreamWriter(@"C:\Users\Public\Documents\PedidoDet" + name + ".txt");
            exp.Write(t);
            exp.Close();

            return data;
        }

    }
    //ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
    //ManagementObjectCollection collection = searcher.Get();
    //var items = new List<Win32_Processor>();
    //var b = Environment.ProcessorCount;
    //foreach (ManagementObject obj in collection)
    //{
    //    var item = new Win32_Processor();
    //    item.AddressWidth = (ushort?)obj["AddressWidth"];
    //    item.Architecture = (ushort?)obj["Architecture"];
    //    item.Availability = (ushort?)obj["Availability"];
    //    item.Caption = (string)obj["Caption"];
    //    item.ConfigManagerErrorCode = (uint?)obj["ConfigManagerErrorCode"];
    //    item.ConfigManagerUserConfig = (bool?)obj["ConfigManagerUserConfig"];
    //    item.CpuStatus = (ushort?)obj["CpuStatus"];
    //    item.CreationClassName = (string)obj["CreationClassName"];
    //    item.CurrentClockSpeed = (uint?)obj["CurrentClockSpeed"];
    //    item.CurrentVoltage = (ushort?)obj["CurrentVoltage"];
    //    item.DataWidth = (ushort?)obj["DataWidth"];
    //    item.Description = (string)obj["Description"];
    //    item.DeviceID = (string)obj["DeviceID"];
    //    item.ErrorCleared = (bool?)obj["ErrorCleared"];
    //    item.ErrorDescription = (string)obj["ErrorDescription"];
    //    item.ExtClock = (uint?)obj["ExtClock"];
    //    item.Family = (ushort?)obj["Family"];
    //    item.InstallDate = (DateTime?)obj["InstallDate"];
    //    item.L2CacheSize = (uint?)obj["L2CacheSize"];
    //    item.L2CacheSpeed = (uint?)obj["L2CacheSpeed"];
    //    item.L3CacheSize = (uint?)obj["L3CacheSize"];
    //    item.L3CacheSpeed = (uint?)obj["L3CacheSpeed"];
    //    item.LastErrorCode = (uint?)obj["LastErrorCode"];
    //    item.Level = (ushort?)obj["Level"];
    //    item.LoadPercentage = (ushort?)obj["LoadPercentage"];
    //    item.Manufacturer = (string)obj["Manufacturer"];
    //    item.MaxClockSpeed = (uint?)obj["MaxClockSpeed"];
    //    item.Name = (string)obj["Name"];
    //    item.NumberOfCores = (uint?)obj["NumberOfCores"];
    //    item.NumberOfLogicalProcessors = (uint?)obj["NumberOfLogicalProcessors"];
    //    item.OtherFamilyDescription = (string)obj["OtherFamilyDescription"];
    //    item.PNPDeviceID = (string)obj["PNPDeviceID"];
    //    item.PowerManagementCapabilities = (ushort[])obj["PowerManagementCapabilities"];
    //    item.PowerManagementSupported = (bool?)obj["PowerManagementSupported"];
    //    item.ProcessorId = (string)obj["ProcessorId"];
    //    item.ProcessorType = (ushort?)obj["ProcessorType"];
    //    item.Revision = (ushort?)obj["Revision"];
    //    item.Role = (string)obj["Role"];
    //    item.SocketDesignation = (string)obj["SocketDesignation"];
    //    item.Status = (string)obj["Status"];
    //    item.StatusInfo = (ushort?)obj["StatusInfo"];
    //    item.Stepping = (string)obj["Stepping"];
    //    item.SystemCreationClassName = (string)obj["SystemCreationClassName"];
    //    item.SystemName = (string)obj["SystemName"];
    //    item.UniqueId = (string)obj["UniqueId"];
    //    item.UpgradeMethod = (ushort?)obj["UpgradeMethod"];
    //    item.Version = (string)obj["Version"];
    //    item.VoltageCaps = (uint?)obj["VoltageCaps"];

    //    items.Add(item);
    //}
    
}