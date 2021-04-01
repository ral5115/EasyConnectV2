using EasyTools.Framework.Application;
using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Framework.Resources;
using EasyTools.Infrastructure;
using EasyTools.Infrastructure.Entities;
using System;

namespace EasyTools.Domains.Base
{
    public class BaseEXTFileOperaDetailBLL : IDomainLogic<EXTFileOperaDetail>
    {

        public BaseEXTFileOperaDetailBLL(IUnitOfWork settings)
        {
            Work = settings;
            CommitTransaction = false;
        }

        public BaseEXTFileOperaDetailBLL(DatabaseSetting settings)
        {
            Work = new UnitOfWork(settings);
            CommitTransaction = true;
        }

        public override void CommonRules(EXTFileOperaDetail data)
        {
            if (data.COD_D == null)
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "COD_D");
            if (!String.IsNullOrWhiteSpace(data.COD_D) && data.COD_D.Length > 18)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "COD_D", "18");
            if (data.HAB == null)
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "HAB");
            if (!String.IsNullOrWhiteSpace(data.HAB) && data.HAB.Length > 18)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "HAB", "18");
            if (data.RESERVA == null)
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "RESERVA");
            if (!String.IsNullOrWhiteSpace(data.RESERVA) && data.RESERVA.Length > 18)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "RESERVA", "18");
            if (data.VALOR == null)
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "VALOR");
            if (!String.IsNullOrWhiteSpace(data.VALOR) && data.VALOR.Length > 18)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "VALOR", "18");
            if (data.FECHA == null)
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "FECHA");
            if (!String.IsNullOrWhiteSpace(data.FECHA) && data.FECHA.Length > 18)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "FECHA", "18");
            if (data.DIA == null)
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "DIA");
            if (!String.IsNullOrWhiteSpace(data.DIA) && data.DIA.Length > 18)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "DIA", "18");
            if (data.IVA == null)
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "IVA");
            if (!String.IsNullOrWhiteSpace(data.IVA) && data.IVA.Length > 18)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "IVA", "18");
            if (data.PAGO == null)
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "PAGO");
            if (!String.IsNullOrWhiteSpace(data.PAGO) && data.PAGO.Length > 3)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "PAGO", "3");
            if (data.IMP1 == null)
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "IMP1");
            if (!String.IsNullOrWhiteSpace(data.IMP1) && data.IMP1.Length > 18)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "IMP1", "18");
            if (data.NIT == null)
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "NIT");
            if (!String.IsNullOrWhiteSpace(data.NIT) && data.NIT.Length > 18)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "NIT", "18");
            if (data.TIPO_DOC == null)
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "TIPO_DOC");
            if (!String.IsNullOrWhiteSpace(data.TIPO_DOC) && data.TIPO_DOC.Length > 18)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "TIPO_DOC", "18");
            if (data.TRX_NO == null)
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "TRX_NO");
            if (!String.IsNullOrWhiteSpace(data.TRX_NO) && data.TRX_NO.Length > 18)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "TRX_NO", "18");
            if (data.BILL_NO == null)
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "BILL_NO");
            if (!String.IsNullOrWhiteSpace(data.BILL_NO) && data.BILL_NO.Length > 18)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "BILL_NO", "18");
            if (data.ORIGINAL_ROOM == null)
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "ORIGINAL_ROOM");
            if (!String.IsNullOrWhiteSpace(data.ORIGINAL_ROOM) && data.ORIGINAL_ROOM.Length > 18)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "ORIGINAL_ROOM", "18");
            if (data.ORIGINAL_RESV == null)
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "ORIGINAL_RESV");
            if (!String.IsNullOrWhiteSpace(data.ORIGINAL_RESV) && data.ORIGINAL_RESV.Length > 18)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "ORIGINAL_RESV", "18");
            if (data.RESV_ACTUAL == null)
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "RESV_ACTUAL");
            if (!String.IsNullOrWhiteSpace(data.RESV_ACTUAL) && data.RESV_ACTUAL.Length > 18)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "RESV_ACTUAL", "18");
            if (data.SUC == null)
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "SUC");
            if (!String.IsNullOrWhiteSpace(data.SUC) && data.SUC.Length > 18)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "SUC", "18");
            if (data.CAJERO == null)
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "CAJERO");
            if (!String.IsNullOrWhiteSpace(data.CAJERO) && data.CAJERO.Length > 18)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "CAJERO", "18");
            if (data.FVENCIMIENTO == null)
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "FVENCIMIENTO");
            if (!String.IsNullOrWhiteSpace(data.FVENCIMIENTO) && data.FVENCIMIENTO.Length > 18)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "FVENCIMIENTO", "18");
            if (data.REFERENCIA == null)
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "REFERENCIA");
            if (!String.IsNullOrWhiteSpace(data.REFERENCIA) && data.REFERENCIA.Length > 50)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "REFERENCIA", "50");
            if (data.VTARJETA == null)
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "VTARJETA");
            if (!String.IsNullOrWhiteSpace(data.VTARJETA) && data.VTARJETA.Length > 18)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "VTARJETA", "18");
            if (data.TASACAMBIO == null)
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "TASACAMBIO");
            if (!String.IsNullOrWhiteSpace(data.TASACAMBIO) && data.TASACAMBIO.Length > 18)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "TASACAMBIO", "18");
            if (data.CURRENCY == null)
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "CURRENCY");
            if (!String.IsNullOrWhiteSpace(data.CURRENCY) && data.CURRENCY.Length > 18)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "CURRENCY", "18");
            if (data.TIPO_FAC == null)
                AddExceptionMessage(Language.DLCOLUMNISREQUIRED, "TIPO_FAC");
            if (!String.IsNullOrWhiteSpace(data.TIPO_FAC) && data.TIPO_FAC.Length > 18)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "TIPO_FAC", "18");
            if (!String.IsNullOrWhiteSpace(data.FACT_ASOC) && data.FACT_ASOC.Length > 18)
                AddExceptionMessage(Language.DLCOLUMNMAXLENGTH, "FACT_ASOC", "18");
        }

        public override void AddRules(EXTFileOperaDetail data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "EXTFileOperaDetail", "EXTFileOperaDetails");
            if (data.Id != 0)
                AddExceptionMessage(Language.DLTABLEIDNULL, "EXTFileOperaDetail");
        }

        public override void ModifyRules(EXTFileOperaDetail data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "EXTFileOperaDetail", "EXTFileOperaDetails");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "EXTFileOperaDetail");
        }

        public override void RemoveRules(EXTFileOperaDetail data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "EXTFileOperaDetail", "EXTFileOperaDetails");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "EXTFileOperaDetail");
        }

        public override void FindByIdRules(EXTFileOperaDetail data)
        {
            if (data == null)
                AddExceptionMessage(Language.DLTABLEVALUENULL, "EXTFileOperaDetail", "EXTFileOperaDetails");
            if (data.Id == 0)
                AddExceptionMessage(Language.DLTABLEIDNOTNULL, "EXTFileOperaDetail");
        }

    }
}