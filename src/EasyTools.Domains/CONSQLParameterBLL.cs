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
    public class CONSQLParameterBLL : BaseCONSQLParameterBLL
    {
        public CONSQLParameterBLL(IUnitOfWork settings)
            : base(settings)
        {
        }

        public CONSQLParameterBLL(DatabaseSetting settings)
            : base(settings)
        {
        }

        public override CONSQLParameter Execute(CONSQLParameter data, Actions action, Options option, string token)
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
                else if (action == Actions.Process && (option == Options.All || option == Options.Light))
                {
                    data.Entities = GenerateSettings(data);
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

        public void AddDetails(CONSQLParameter data)
        {
        }

        public override void CommonRules(CONSQLParameter data)
        {
            base.CommonRules(data);
        }

        public override void AddRules(CONSQLParameter data)
        {
            base.AddRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void ModifyRules(CONSQLParameter data)
        {
            base.ModifyRules(data);
            data.LastUpdate = DateTime.Now;
        }

        public override void RemoveRules(CONSQLParameter data)
        {
            base.RemoveRules(data);
        }

        public override void FindByIdRules(CONSQLParameter data)
        {
            base.FindByIdRules(data);
        }

        public List<CONSQLParameter> GetParameters(String sentence)
        {
            List<CONSQLParameter> parameters = new List<CONSQLParameter>();
            int iSecuence = 1;
            while (sentence.Length > 0)
            {
                string sparm = "";
                int i = -1;
                i = sentence.ToUpper().IndexOf("@P");
                if (i != -1)
                {
                    sentence = sentence.Substring(i, sentence.Length - i);
                    int j = -1;
                    j = sentence.IndexOf(" ");
                    if (j != -1)
                        sparm = sentence.Substring(0, j);
                    else
                        sparm = sentence;
                    if (j != -1)
                        sentence = sentence.Substring(j, sentence.Length - j);
                    else
                        sentence = "";
                    if (parameters.Count(t => t.Name.ToUpper() == sparm.ToUpper()) <= 0)
                        parameters.Add(new CONSQLParameter { Name = sparm, Secuence = (short)iSecuence });
                    iSecuence++;
                }
                else
                    sentence = "";
            }
            return parameters;
        }

        public List<CONSQLParameter> GenerateSettings(CONSQLParameter data)
        {

            try
            {
                CONSQLBLL daoSQL = new CONSQLBLL(Work.Settings);
                //CONSQLParameterBLL daoParam = daoParam = new CONSQLParameterBLL(Work.Settings); ;
                CONSQL sql = daoSQL.Execute(new CONSQL { Id = data.SQL.Id }, Actions.Find, Options.Me, "");
                //if (sql.SQLParameters != null && sql.SQLParameters.Count > 0)
                //{
                //    foreach (CONSQLParameter item in sql.SQLParameters)
                //    {                      
                //        daoParam.Execute(item, Actions.Remove, Options.All, "");
                //    }
                //}
                List<CONSQLParameter> parameters = new List<CONSQLParameter>();
                parameters = GetParameters(sql.SQLSentence);
                if (!String.IsNullOrWhiteSpace(sql.ExecuteStoreProcedure))
                    parameters.AddRange(GetParameters(sql.ExecuteStoreProcedure));
                foreach (CONSQL item in sql.ChildSQLs)
                {
                    List<CONSQLParameter> parameterChilds = GetParameters(item.SQLSentence);
                    if (!String.IsNullOrWhiteSpace(item.ExecuteStoreProcedure))
                        parameterChilds.AddRange(GetParameters(sql.ExecuteStoreProcedure));
                    foreach (CONSQLParameter sparam in parameterChilds)
                    {
                        if (parameters.Count(t => t.Name.ToUpper() == sparam.Name.ToUpper()) <= 0)
                            parameters.Add(sparam);
                    }
                }
                return parameters;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //daoSQL.Work.Commit();
            }
        }


    }
}