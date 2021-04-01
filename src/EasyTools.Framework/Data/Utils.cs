using System;
using System.Collections.Generic;

namespace EasyTools.Framework.Data
{
    public static class Utils
    {
        //Tipo de documento del banco
        //Valor alfanumerico de 2 caracteres
        public static string ValidateDocumentTypeBank(String documentTypeBank, string column)
        {
            if (!String.IsNullOrWhiteSpace(documentTypeBank))
            {
                if (documentTypeBank.Length > 2)
                    throw new ArgumentException("El tamaño del campo " + column + " es de 2 caracteres ");
                if (!String.IsNullOrEmpty(documentTypeBank) && documentTypeBank != "  " && documentTypeBank != "CH" && documentTypeBank != "CG" && documentTypeBank != "ND" && documentTypeBank != "NC")
                    throw new ArgumentException("El valor del campo " + column + " es '" + documentTypeBank + "' y debe ser CH = Cheque, CG = Consignaciones, ND = Notas debito, NC = Notas Credito");
            }
            else
                documentTypeBank = "";
            documentTypeBank = documentTypeBank.PadLeft(2, Char.Parse(" "));
            return documentTypeBank;
        }

        public static string ValidateString(String value, int pos, string column)
        {
            if (String.IsNullOrWhiteSpace(value))
                value = "";
            value = value.Replace(Convert.ToChar((byte)0x1F), ' ');
            if (value.Length > pos)
                throw new ArgumentException("El tamaño del campo " + column + " tiene mas de " + (pos).ToString() + " caracteres");
            value = value.PadRight(pos, Char.Parse(" "));
            return value;
        }

        public static string ValidateNumber(Int32? documentNumer, int pos, string column)
        {
            string data = "";
            if (documentNumer != null)
                data = documentNumer.ToString();
            return ValidateNumber(data, pos, column);
        }

        public static string ValidateNumber(Int32 documentNumer, int pos, string column)
        {
            string data = "";
            data = documentNumer.ToString();
            return ValidateNumber(data, pos, column);
        }

        public static string ValidateNumber(String documentNumer, int pos, string column)
        {
            if (String.IsNullOrWhiteSpace(documentNumer))
                documentNumer = "";
            if (documentNumer.Length > pos)
                throw new ArgumentException("El tamaño del campo " + column + " tiene mas de " + (pos).ToString() + " caracteres");
            documentNumer = documentNumer.PadLeft(pos, Char.Parse("0"));
            return documentNumer;
        }

        public static string ValidateDecimal(Decimal? documentNumer, int pos, int res, string column, bool withSign)
        {
            string data = "";
            if (documentNumer != null)
                data = documentNumer.ToString().Replace("-", "");
            string sign = "";
            if (withSign)
            {
                sign = documentNumer >= 0 ? "+" : "-";
            }
            return ValidateDecimal(data, pos, res, column, sign);
        }

        public static string ValidateDecimal(Decimal documentNumer, int pos, int res, string column, bool withSign)
        {
            string data = "";
            data = documentNumer.ToString().Replace("-", "");
            string sign = "";
            if (withSign)
            {
                sign = documentNumer >= 0 ? "+" : "-";
            }
            return ValidateDecimal(data, pos, res, column, sign);
        }

        public static string ValidateDecimal(String documentNumer, int pos, int res, string column, string signo)
        {
            documentNumer = documentNumer.Replace("-", "");
            if (String.IsNullOrWhiteSpace(documentNumer))
                documentNumer = "";
            string decimalPart = "";
            documentNumer = documentNumer.Replace(",", ".");
            if (documentNumer.Length > pos + res + 1)
                throw new ArgumentException("El tamaño del campo " + column + " es de " + (res + pos + 1).ToString() + " caracteres");
            if (documentNumer.IndexOf(".") != -1)
            {
                decimalPart = documentNumer.Substring(documentNumer.IndexOf("."), documentNumer.Length - documentNumer.IndexOf("."));
                documentNumer = documentNumer.Substring(0, documentNumer.IndexOf(".")).Replace("-", "").Replace("+", "");
                if (decimalPart.Length > res + 1)
                    decimalPart = decimalPart.Substring(0, res + 1);
                //throw new ArgumentException("El formato del campo " + column + " la parte decimal del numero es de " + res.ToString() + " digitos");
                decimalPart = decimalPart.PadRight(res + 1, Char.Parse("0"));
            }
            else
            {
                if (res == 4)
                    decimalPart = ".0000";
                else
                    decimalPart = ".00";
            }
            documentNumer = signo + documentNumer.PadLeft(pos, Char.Parse("0")) + decimalPart;
            return documentNumer;
        }

        public static string ValidateIndicator(Int16 automaticConsecutive, int beg, int end, string column)
        {
            string data = "";
            data = automaticConsecutive.ToString();
            return ValidateIndicator(data, beg, end, column);
        }

        public static string ValidateIndicator(String automaticConsecutive, int beg, int end, string column)
        {
            List<String> options = new List<String>();
            for (int i = beg; i <= end; i++)
            {
                options.Add(i.ToString());
            }
            if (!String.IsNullOrWhiteSpace(automaticConsecutive))
            {
                if (!(options.Contains(automaticConsecutive)))
                    throw new ArgumentException("El valor del campo " + column + " debe ser 0, 1 valor actual: " + automaticConsecutive);
            }

            return automaticConsecutive;
        }

        public static int GetIntValue(String name, Object val)
        {
            try
            {
                if (val.GetType() == typeof(String))
                    return Convert.ToInt32((String)val);
                else if (val.GetType() == typeof(Int16))
                    return Convert.ToInt32((Int16)val);
                else
                    return (Int32)val;

            }
            catch (Exception)
            {
                throw new ArgumentException("El campo " + name + " no se puede convertir a entero");
            }
        }

        public static decimal GetDecimalValue(String name, Object val)
        {
            try
            {
                if (val.GetType() == typeof(String))
                    return Decimal.Parse(val.ToString());
                else if (val.GetType() == typeof(Int16) || val.GetType() == typeof(Int32))
                    return new Decimal((Int32)val);
                else if (val.GetType() == typeof(Int64))
                    return new Decimal((Int64)val);
                else if (val.GetType() == typeof(float))
                    return new Decimal((float)val);
                else if (val.GetType() == typeof(Double))
                    return new Decimal((Double)val);
                return (Decimal)val;
            }
            catch (Exception)
            {
                throw new ArgumentException("El campo " + name + " no se puede convertir a decimal");
            }
        }

        public static string ValidateDate(String date, string column)
        {
            if (!String.IsNullOrWhiteSpace(date))
            {
                if (date.Length > 8 || date.Length < 8)
                    throw new ArgumentException("Formato de fecha incorecto. Campo " + column + " El tamaño del campo es de 8 caracteres");
                if (Int16.Parse(date.Substring(0, 4)) < 1900)
                    throw new ArgumentException("Formato de fecha incorecto. Campo " + column + " El año no puede ser inferior a 1900");
                if (Int16.Parse(date.Substring(4, 2)) < 1)
                    throw new ArgumentException("Formato de fecha incorecto. Campo " + column + " El mes no puede ser inferior a 1");
                if (Int16.Parse(date.Substring(4, 2)) > 12)
                    throw new ArgumentException("Formato de fecha incorecto. Campo " + column + " El mes no puede ser mayor a 12");
                if (Int16.Parse(date.Substring(6, 2)) < 1)
                    throw new ArgumentException("Formato de fecha incorecto. Campo " + column + " El dia no puede ser inferior a 1");
                if (Int16.Parse(date.Substring(6, 2)) > 31)
                    throw new ArgumentException("Formato de fecha incorecto. Campo " + column + " El dia no puede ser mayor a 31");
            }
            date = (date + "").PadLeft(8, Char.Parse(" "));
            return date;
        }

        public static string ValidateDate(DateTime date, string column)
        {
            return date.ToString("yyyyMMdd");
        }

        public static string ValidateDate(DateTime? date, string column)
        {
            if (date == null)
                return "        ";
            else
                return date.Value.ToString("yyyyMMdd");
        }

    }
}
