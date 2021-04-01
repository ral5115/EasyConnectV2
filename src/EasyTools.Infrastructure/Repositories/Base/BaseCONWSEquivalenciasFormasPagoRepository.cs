using EasyConnect.Infrastructure.Entities;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace EasyTools.Infrastructure.Repositories.Base
{

    public class BaseCONWSEquivalenciasFormasPagoRepository : BaseRepository<CONWSEquivalenciasFormasPago>
    {

        public BaseCONWSEquivalenciasFormasPagoRepository(IUnitOfWork context)
            : base(context)
        {
        }

        public override String GetQuery(CONWSEquivalenciasFormasPago data, Boolean byId)
        {
            String dml = "Select a from CONWSEquivalenciasFormasPago as a where 1=1 ";
            if (byId)
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
            }
            else
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
                                if (!String.IsNullOrWhiteSpace(data.FormaPagoZapa))
                    dml += "             AND upper(a.FormaPagoZapa) like :FormaPagoZapa \n";
                if (!String.IsNullOrWhiteSpace(data.FPagoDet_Zapa))
                    dml += "             AND upper(a.FPagoDet_Zapa) like :FPagoDet_Zapa \n";
                if (!String.IsNullOrWhiteSpace(data.FormaPagoUNOEE))
                    dml += "             AND upper(a.FormaPagoUNOEE) like :FormaPagoUNOEE \n";
                if (!String.IsNullOrWhiteSpace(data.RefFP))
                    dml += "             AND upper(a.RefFP) like :RefFP \n";
                if (!String.IsNullOrWhiteSpace(data.CuentaContable))
                    dml += "             AND upper(a.CuentaContable) like :CuentaContable \n";
                

            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, CONWSEquivalenciasFormasPago data, Boolean byId)
        {
            if (byId)
            {
                if (data.Id != 0)
                    query.SetInt32("Id", data.Id);
            }
            else
            {
                if (data.Id != 0)
                    query.SetInt32("Id", data.Id);
                if (!String.IsNullOrWhiteSpace(data.FormaPagoZapa))
                    query.SetString("FormaPagoZapa", "%" + data.FormaPagoZapa.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.FPagoDet_Zapa))
                    query.SetString("FPagoDet_Zapa", "%" + data.FPagoDet_Zapa.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.FormaPagoUNOEE))
                    query.SetString("FormaPagoUNOEE", "%" + data.FormaPagoUNOEE.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.RefFP))
                    query.SetString("RefFP", "%" + data.RefFP.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.CuentaContable))
                    query.SetString("CuentaContable", "%" + data.CuentaContable.ToUpper() + "%");
                
            }
        }

        public override void SaveOrUpdateDetails(CONWSEquivalenciasFormasPago data)
        {
        }

        public override void AddMoreDetailFindById(CONWSEquivalenciasFormasPago data)
        {
        }

        public override CONWSEquivalenciasFormasPago FindById(CONWSEquivalenciasFormasPago data)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, true));
            SetQueryParameters(query, data, true);
            data = query.UniqueResult<CONWSEquivalenciasFormasPago>();
            if (data != null)
            {
                data = new CONWSEquivalenciasFormasPago(data, Options.Me);
                AddMoreDetailFindById(data);
            }
            return data;
        }

        public override List<CONWSEquivalenciasFormasPago> FindAll(CONWSEquivalenciasFormasPago data, Options option)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, false));
            SetQueryParameters(query, data, false);
            if (data.HasPaging)
            {
                query.SetFirstResult((data.PageSize * data.CurrentPage) - data.PageSize);
                query.SetMaxResults(data.PageSize);
            }
            return (from a in query.List<CONWSEquivalenciasFormasPago>() select new CONWSEquivalenciasFormasPago(a, option)).ToList<CONWSEquivalenciasFormasPago>();
        }
    }
}