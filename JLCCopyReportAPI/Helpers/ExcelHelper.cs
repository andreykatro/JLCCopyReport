using JLCCopyReportService.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

namespace JLCCopyReportAPI.Helpers
{
    public static class ExcelHelper
    {
        private static List<string[]> GetHeaders(Type tableType)
        {
            PropertyInfo[] myPropertyInfo;
            var headerRow = new List<string>();
            myPropertyInfo = tableType.GetProperties();

            //Split camel case to words.
            string strRegex = @"(?<=[a-z])([A-Z])|(?<=[A-Z])([A-Z][a-z])";
            Regex myRegex = new Regex(strRegex, RegexOptions.None);
            string strReplace = @" $1$2";

            for (int i = 0; i < myPropertyInfo.Length; i++)
            {
                headerRow.Add(myRegex.Replace(myPropertyInfo[i].Name, strReplace));
            }

            return new List<string[]>() { headerRow.ToArray() };
        }

        //Fill List<char> default letters from the alphabet.
        private static void FillDefValue(ref List<char> charList, char defStartLetter = 'A')
        {
            for (int i = 0; i < charList.Count; i++)
            {
                if (charList[i] != defStartLetter)
                {
                    charList[i] = defStartLetter;
                }
            }
        }

        private static void AddLeter(ref List<char> ls, int i = 1, int defEndLetter = 'Z')
        {
            var index = ls.Count - i;

            if (ls.Count < i)
            {
                FillDefValue(ref ls);
                ls.Add('A');
            }
            else if (ls[index] < defEndLetter)
            {
                ls[index]++;
            }
            else if (ls[index] == defEndLetter)
            {
                ls[index] = 'A';
                AddLeter(ref ls, ++i);
            }

        }

        private static string CellsAddress(int rowIndexStart, int columnIndexStart = 1)
        {
            var charList = new List<char>();
            while (columnIndexStart > 0)
            {
                AddLeter(ref charList);
                columnIndexStart--;
            }

            return String.Concat(charList.ToArray()) + rowIndexStart;
        }

        private static void AddRow(ref ExcelWorksheet worksheet, Type tableType, object itemRow, int rowIndexStart,  int colomnIndexStart = 1 )
        {
            PropertyInfo[] myPropertyInfo = tableType.GetProperties();
            List<string> namesOfMethods = new List<string>();

            for (int i = 0; i < myPropertyInfo.Length; i++)
            {
                namesOfMethods.Add(myPropertyInfo[i].Name);
            }

            foreach (var nameMethod in namesOfMethods)
            {
                PropertyInfo propertyInfo = tableType.GetProperty(nameMethod);
                var result = propertyInfo.GetValue(itemRow);
                worksheet.Cells[CellsAddress(rowIndexStart, colomnIndexStart)].Value = result;
                colomnIndexStart++;

            }
        }
        public static byte[] GetExcelReport(IEnumerable<Report> report)
        {
            var rowCollection = report;
            Type tableType = typeof(Report);

            using (ExcelPackage excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add("Worksheet1");

                var headerRow = GetHeaders(tableType);

                string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";

                // Target a worksheet
                var worksheet = excel.Workbook.Worksheets["Worksheet1"];

                // Popular header row data
                var headerFont = worksheet.Cells[headerRange].LoadFromArrays(headerRow).Style.Font;
                headerFont.Bold = true;

                int rowIndexStart = 2;
                foreach (var itemRow in rowCollection)
                {
                    AddRow(ref worksheet, tableType, itemRow, rowIndexStart);
                    rowIndexStart++;
                }

                worksheet.Cells["A:AZ"].AutoFitColumns();

                return excel.GetAsByteArray();
            }
        }
    }
}