using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace VehicleManagement
{
    public class MsHelper
    {
        public static void PrintWord(DataGridView dgv, string prefixName)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string savePath = Path.Combine(Const.RESOURCE_PATH + $@"{prefixName}_{timestamp}.docx");
            Word.Application wordApp = new Word.Application();
            Word.Document document;
            Object missing = System.Reflection.Missing.Value;
            document = wordApp.Documents.Add();


            Word.Paragraph titlePara = document.Content.Paragraphs.Add(ref missing);
            titlePara.Range.Text = "TRƯỜNG ĐẠI HỌC SƯ PHẠM KỸ THUẬT TP. HỒ CHÍ MINH";
            titlePara.Range.Font.Size = 20;
            titlePara.Range.Font.Bold = 1;
            titlePara.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            titlePara.Range.InsertParagraphAfter();


            //titlePara.Range.Text = "\n";
            //titlePara.Range.Text = $"{prefixName} table".ToUpper();

            Word.Paragraph spacePara = document.Paragraphs.Add(ref missing);
            spacePara.Range.Text = "";
            spacePara.Range.InsertParagraphAfter();

            Word.Paragraph subtitlePara = document.Paragraphs.Add(ref missing);
            subtitlePara.Range.Text = $"{prefixName} table".ToUpper();
            subtitlePara.Range.Font.Size = 14;
            subtitlePara.Range.Font.Bold = 1;
            subtitlePara.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            subtitlePara.Range.InsertParagraphAfter();


            Word.Range tableRange = document.Content;
            tableRange.SetRange(titlePara.Range.End, titlePara.Range.End);
            titlePara.Range.Font.Size = 12;
            titlePara.Range.Font.Bold = 0;
            DataTable dt = (DataTable)dgv.DataSource;
            Word.Table table = document.Tables.Add(tableRange, dt.Rows.Count + 1, dt.Columns.Count);
            table.Borders.Enable = 1;
            table.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

            for (int c = 0; c < dt.Columns.Count; c++)
                table.Cell(1, c + 1).Range.Text = dt.Columns[c].ColumnName;

            for (int r = 0; r < dt.Rows.Count; r++)
            {
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    if (dt.Columns[c].ColumnName == "picture")
                    {
                        if (dt.Rows[r][c] != DBNull.Value)
                        {
                            if (dt.Rows[r][c] is byte[] imageBytes)
                            {
                                using (MemoryStream ms = new MemoryStream(imageBytes))
                                {
                                    using (Image img = Image.FromStream(ms))
                                    {
                                        string tempPath = Path.Combine(Path.GetTempPath(), $"img_{r}_{c}.jpg");
                                        img.Save(tempPath, System.Drawing.Imaging.ImageFormat.Jpeg);

                                        Word.InlineShape picture = table.Cell(r + 2, c + 1).Range.InlineShapes.AddPicture(tempPath);
                                        picture.Width = 80;
                                        picture.Height = 80;

                                        File.Delete(tempPath);
                                    }
                                }
                            }
                        }
                    }
                    else
                        table.Cell(r + 2, c + 1).Range.Text = dt.Rows[r][c].ToString();
                }
            }

            wordApp.Visible = true;
            document.SaveAs2(savePath);
            //document.Close(false);
            //wordApp.Quit();

            //System.Runtime.InteropServices.Marshal.ReleaseComObject(table);
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(document);
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
            MessageBox.Show("Exported to Word successfully!");
        }
    }
}
