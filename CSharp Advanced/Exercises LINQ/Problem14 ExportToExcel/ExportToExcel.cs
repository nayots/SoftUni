using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem14_ExportToExcel
{
    class ExportToExcel
    {
        private static void Main(string[] args)
        {
            var filePath = @"..\..\StudentData.txt";
            var excelFile = @"StudentData.xlsx";
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"{filePath} not found");
                return;
            }

            if (File.Exists(excelFile))
            {
                try
                {
                    File.Delete(excelFile);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Could not delete already existing file, because: {e.Message}");
                    return;
                }
            }
            Console.WriteLine("Reading data...");

            var text = File.ReadAllLines(filePath);

            FileInfo excFile = new FileInfo(excelFile);

            ExcelPackage package = new ExcelPackage(excFile);
            Console.WriteLine("Exporting to excel");
            var ws = package.Workbook.Worksheets.Add("StudentData");
            var headerCells = ws.Cells[1, 1, 1, 11];
            var headerFont = headerCells.Style.Font;
            var hf = headerCells.Style.Fill;
            hf.PatternType = ExcelFillStyle.Solid;
            hf.BackgroundColor.SetColor(Color.DarkGreen);
            headerFont.Bold = true;
            headerFont.Color.SetColor(Color.White);
            for (int c = 1; c <= 11; c++)
            {
                if (c < 4)
                {
                    ws.Column(c).Width = 10;
                }
                else if (c == 4)
                {
                    ws.Column(c).Width = 25;
                }
                else if (c > 4 && c < 11)
                {
                    ws.Column(c).Width = 8;
                }
                else
                {
                    ws.Column(c).Width = 15;
                }
            }
            for (int i = 0; i < text.Length; i++)
            {
                var values = text[i].Split('\t');
                for (int j = 0; j < values.Length; j++)
                {
                    ws.Cells[i + 1, j + 1].Value = values[j];
                }
            }
            package.Save();
            Console.WriteLine("Ready.");
            Console.WriteLine("Navigating to location...");
            var currentFolder = Directory.GetCurrentDirectory();
            Process.Start(currentFolder);
            Console.WriteLine("All done.");
        }
    }
}