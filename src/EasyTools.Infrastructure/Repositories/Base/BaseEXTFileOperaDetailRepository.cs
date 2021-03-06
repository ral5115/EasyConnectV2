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

    public class BaseEXTFileOperaDetailRepository : BaseRepository<EXTFileOperaDetail>
    {
        public BaseEXTFileOperaDetailRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(EXTFileOperaDetail data, Boolean byId)
        {
            String dml = "Select a from EXTFileOperaDetail as a where 1=1 ";
            if (byId)
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
            }
            else
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
                if (!String.IsNullOrWhiteSpace(data.COD_D))
                    dml += "             AND upper(a.COD_D) like :COD_D \n";
                if (!String.IsNullOrWhiteSpace(data.HAB))
                    dml += "             AND upper(a.HAB) like :HAB \n";
                if (!String.IsNullOrWhiteSpace(data.RESERVA))
                    dml += "             AND upper(a.RESERVA) like :RESERVA \n";
                if (!String.IsNullOrWhiteSpace(data.VALOR))
                    dml += "             AND upper(a.VALOR) like :VALOR \n";
                if (!String.IsNullOrWhiteSpace(data.FECHA))
                    dml += "             AND upper(a.FECHA) like :FECHA \n";
                if (!String.IsNullOrWhiteSpace(data.DIA))
                    dml += "             AND upper(a.DIA) like :DIA \n";
                if (!String.IsNullOrWhiteSpace(data.IVA))
                    dml += "             AND upper(a.IVA) like :IVA \n";
                if (!String.IsNullOrWhiteSpace(data.PAGO))
                    dml += "             AND upper(a.PAGO) like :PAGO \n";
                if (!String.IsNullOrWhiteSpace(data.IMP1))
                    dml += "             AND upper(a.IMP1) like :IMP1 \n";
                if (!String.IsNullOrWhiteSpace(data.NIT))
                    dml += "             AND upper(a.NIT) like :NIT \n";
                if (!String.IsNullOrWhiteSpace(data.TIPO_DOC))
                    dml += "             AND upper(a.TIPO_DOC) like :TIPO_DOC \n";
                if (!String.IsNullOrWhiteSpace(data.TRX_NO))
                    dml += "             AND upper(a.TRX_NO) like :TRX_NO \n";
                if (!String.IsNullOrWhiteSpace(data.BILL_NO))
                    dml += "             AND upper(a.BILL_NO) like :BILL_NO \n";
                if (!String.IsNullOrWhiteSpace(data.ORIGINAL_ROOM))
                    dml += "             AND upper(a.ORIGINAL_ROOM) like :ORIGINAL_ROOM \n";
                if (!String.IsNullOrWhiteSpace(data.ORIGINAL_RESV))
                    dml += "             AND upper(a.ORIGINAL_RESV) like :ORIGINAL_RESV \n";
                if (!String.IsNullOrWhiteSpace(data.RESV_ACTUAL))
                    dml += "             AND upper(a.RESV_ACTUAL) like :RESV_ACTUAL \n";
                if (!String.IsNullOrWhiteSpace(data.SUC))
                    dml += "             AND upper(a.SUC) like :SUC \n";
                if (!String.IsNullOrWhiteSpace(data.CAJERO))
                    dml += "             AND upper(a.CAJERO) like :CAJERO \n";
                if (!String.IsNullOrWhiteSpace(data.FVENCIMIENTO))
                    dml += "             AND upper(a.FVENCIMIENTO) like :FVENCIMIENTO \n";
                if (!String.IsNullOrWhiteSpace(data.REFERENCIA))
                    dml += "             AND upper(a.REFERENCIA) like :REFERENCIA \n";
                if (!String.IsNullOrWhiteSpace(data.VTARJETA))
                    dml += "             AND upper(a.VTARJETA) like :VTARJETA \n";
                if (!String.IsNullOrWhiteSpace(data.TASACAMBIO))
                    dml += "             AND upper(a.TASACAMBIO) like :TASACAMBIO \n";
                if (!String.IsNullOrWhiteSpace(data.CURRENCY))
                    dml += "             AND upper(a.CURRENCY) like :CURRENCY \n";
                if (!String.IsNullOrWhiteSpace(data.TIPO_FAC))
                    dml += "             AND upper(a.TIPO_FAC) like :TIPO_FAC \n";
                if (!String.IsNullOrWhiteSpace(data.FACT_ASOC))
                    dml += "             AND upper(a.FACT_ASOC) like :FACT_ASOC \n";
                if (data.FileOperaId != 0)
                    dml += "             AND a.FileOperaId = :FileOperaId \n";

            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, EXTFileOperaDetail data, Boolean byId)
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
                if (!String.IsNullOrWhiteSpace(data.COD_D))
                    query.SetString("COD_D", "%" + data.COD_D.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.HAB))
                    query.SetString("HAB", "%" + data.HAB.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.RESERVA))
                    query.SetString("RESERVA", "%" + data.RESERVA.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.VALOR))
                    query.SetString("VALOR", "%" + data.VALOR.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.FECHA))
                    query.SetString("FECHA", "%" + data.FECHA.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.DIA))
                    query.SetString("DIA", "%" + data.DIA.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.IVA))
                    query.SetString("IVA", "%" + data.IVA.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.PAGO))
                    query.SetString("PAGO", "%" + data.PAGO.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.IMP1))
                    query.SetString("IMP1", "%" + data.IMP1.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.NIT))
                    query.SetString("NIT", "%" + data.NIT.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.TIPO_DOC))
                    query.SetString("TIPO_DOC", "%" + data.TIPO_DOC.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.TRX_NO))
                    query.SetString("TRX_NO", "%" + data.TRX_NO.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.BILL_NO))
                    query.SetString("BILL_NO", "%" + data.BILL_NO.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.ORIGINAL_ROOM))
                    query.SetString("ORIGINAL_ROOM", "%" + data.ORIGINAL_ROOM.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.ORIGINAL_RESV))
                    query.SetString("ORIGINAL_RESV", "%" + data.ORIGINAL_RESV.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.RESV_ACTUAL))
                    query.SetString("RESV_ACTUAL", "%" + data.RESV_ACTUAL.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.SUC))
                    query.SetString("SUC", "%" + data.SUC.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.CAJERO))
                    query.SetString("CAJERO", "%" + data.CAJERO.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.FVENCIMIENTO))
                    query.SetString("FVENCIMIENTO", "%" + data.FVENCIMIENTO.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.REFERENCIA))
                    query.SetString("REFERENCIA", "%" + data.REFERENCIA.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.VTARJETA))
                    query.SetString("VTARJETA", "%" + data.VTARJETA.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.TASACAMBIO))
                    query.SetString("TASACAMBIO", "%" + data.TASACAMBIO.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.CURRENCY))
                    query.SetString("CURRENCY", "%" + data.CURRENCY.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.TIPO_FAC))
                    query.SetString("TIPO_FAC", "%" + data.TIPO_FAC.ToUpper() + "%");
                if (!String.IsNullOrWhiteSpace(data.FACT_ASOC))
                    query.SetString("FACT_ASOC", "%" + data.FACT_ASOC.ToUpper() + "%");
                if (data.FileOperaId != 0)
                    query.SetInt32("FileOperaId", data.FileOperaId);
            }
        }

        public override void SaveOrUpdateDetails(EXTFileOperaDetail data)
        {
        }

        public override void AddMoreDetailFindById(EXTFileOperaDetail data)
        {
        }

        public override EXTFileOperaDetail FindById(EXTFileOperaDetail data)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, true));
            SetQueryParameters(query, data, true);
            data = query.UniqueResult<EXTFileOperaDetail>();
            if (data != null)
            {
                data = new EXTFileOperaDetail(data, Options.Me);
                AddMoreDetailFindById(data);
            }
            return data;
        }

        public override List<EXTFileOperaDetail> FindAll(EXTFileOperaDetail data, Options option)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, false));
            SetQueryParameters(query, data, false);
            if (data.HasPaging)
            {
                query.SetFirstResult((data.PageSize * data.CurrentPage) - data.PageSize);
                query.SetMaxResults(data.PageSize);
            }
            return (from a in query.List<EXTFileOperaDetail>() select new EXTFileOperaDetail(a, option)).ToList<EXTFileOperaDetail>();
        }
    }
}