using Integration.Model;
using Integration.Repository.Sql;
using Model.DataBaseContext;
using Renci.SshNet;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Reflection;
using Integration.DTOs;


namespace Integration.Service
{
    public class DrugsConsumptionReportService
    {
        public DrugsConsumptionSqlRepository DrugsConsumptionRepository { get; set; }

        public DrugsConsumptionReportService(MyDbContext dbContext)
        {
            DrugsConsumptionRepository = new DrugsConsumptionSqlRepository(dbContext);
        }

        public bool UploadDrugConsumptionReport(string fileName)
        {
            using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.1.107", "user", "password")))
            {
                try
                {
                    client.Connect();
                    string sourceFile = FormatPath(fileName);
                    if (File.Exists(sourceFile))
                    {
                        using (Stream stream = File.OpenRead(sourceFile))
                        {
                            client.UploadFile(stream, @"\public\Drugstore files\" + Path.GetFileName(sourceFile), x => { Console.WriteLine(x); });
                            client.Disconnect();
                            return true;
                        }
                    }
                }
                catch (SocketException se) 
                {
                    string ErrorString = se.Message;
                }
                return false;
            }
        }

        private string FormatPath(string fileName)
        {
            string[] absolute = Directory.GetCurrentDirectory().Split("src");
            return Path.Combine(absolute[0], "src\\Integration\\Reports\\" + fileName);
        }

        public int SaveDrugsConsumptionReport(DateRange range)
        {
            int counter = 0;
            using (PdfDocument Document = new PdfDocument())
            {
                PdfPage Page = Document.Pages.Add();
                PdfGraphics Graphics = Page.Graphics;
                PdfFont Font = new PdfStandardFont(PdfFontFamily.Helvetica, 16);
                Graphics.DrawString("Izvestaj o potrosnji lekova - " + FormatDateRange(range), Font, PdfBrushes.Black, new PointF(70, 20));
                PdfLightTable PdfLightTable = new PdfLightTable();
                DataTable Table = new DataTable();
                Table.Columns.Add("Ime leka");
                Table.Columns.Add("Potrosena kolicina");
                Table.Rows.Add(new string[] { "Ime leka", "Potrosena kolicina"});
                foreach (DrugConsumed drug in FormatDrugConsumptionList(range))
                {
                    Table.Rows.Add(new string[] { drug.Name, drug.Amount.ToString() });
                    counter++;
                }
                PdfLightTable.DataSource = Table;
                PdfLightTable.Draw(Page, new PointF(0, 70));
                string FileName = "Izvestaj o potrosnji lekova " + FormatDateRange(range) + ".pdf";
                Document.Save("..\\..\\src\\Integration\\Reports\\" + FileName);
                Document.Close(true);
                this.UploadDrugConsumptionReport(FileName);
            }
            return counter;
        }
        

        private bool IsDateInRange(DateRange range, DrugConsumed drug)
        {
            if (DateTime.Compare(drug.DateConsumed, range.From) >= 0 && DateTime.Compare(drug.DateConsumed, range.To) <= 0)
                return true;
            else
                return false;
        }

        private List<DrugConsumed> FormatDrugConsumptionList(DateRange range)
        {
            List<DrugConsumed> FormattedList = new List<DrugConsumed>();
            bool exists;
            foreach (DrugConsumed drug in DrugsConsumptionRepository.GetAll())
            {
                if (IsDateInRange(range, drug))
                {
                    if (FormattedList.Count != 0)
                    {
                        exists = false;
                        foreach (DrugConsumed formattedDrug in FormattedList)
                        {
                            if (drug.Name.Equals(formattedDrug.Name))
                            {
                                exists = true;
                                formattedDrug.Amount += drug.Amount;
                                break;
                            }
                        }
                        if (!exists)
                            FormattedList.Add(drug);
                    }
                    else
                        FormattedList.Add(drug);
                }
            }
            return FormattedList;
        }

        public List<string> GetReportNames()
        {
            List<string> filenames = new List<string>();
            DirectoryInfo d = new DirectoryInfo(@"..\\..\\src\\Integration\\Reports\\"); 
            FileInfo[] Files = d.GetFiles("*.pdf"); 
            foreach (FileInfo file in Files)
            {
                filenames.Add(file.Name);
            }
            return filenames;
        }

    public String FormatDate(DateTime date)
        {
            return date.Day + "." + date.Month + "." + date.Year + ".";
        }

    public String FormatDateRange(DateRange range) 
        {
            return range.From.Day + "." + range.From.Month + "." + range.From.Year + "." + " - " + range.To.Day + "." + range.To.Month + "." + range.To.Year + ".";
        }
    }
}
