using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

using OpticFiberTest_ver1.Protocols_classes;


namespace OpticFiberTest_ver1.SaveData
{
    class SaveExcel
    {
        public static string createExcel(Dictionary<int, Protocols> MainDictionary)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                //saving_progress_bar.Maximum = 200;
                //saving_progress_bar.Visible = true;

                string folderName = folderBrowserDialog1.SelectedPath;

                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                string file_to_save = "Page_" + "Page" + ".xls";

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                xlWorkSheet.Cells[1, 1] = "Byte";
                xlWorkSheet.Cells[1, 2] = "Name";
                xlWorkSheet.Cells[1, 3] = "Data";
                xlWorkSheet.Cells[1, 4] = "Id";
                xlWorkSheet.Cells[1, 5] = "PageId";
                xlWorkSheet.Cells[1, 6] = "testPassed";

                int row = 2;
                //saving_progress_bar.Visible = true;
                for (int i = 0; i < MainDictionary.Keys.Count(); i++)
                {
                    int col = 1;
                    //saving_progress_bar.Value = i * saving_progress_bar.Maximum / (MainDictionary.Keys.Count() - 1);

                    xlWorkSheet.Cells[row, col++].Value = MainDictionary[i + 1].GetAddress();
                    xlWorkSheet.Cells[row, col++].Value = MainDictionary[i + 1].GetTitle();
                    string data = MainDictionary[i + 1].GethasRead();

                    //when class RxOutputEmphasisType is invoked and the message is: "=00b Peak-to-peak amplitude stays constant, or not\n\timplemented, or no informationstays\n\tconstant, or not implemented, or no\n\tinformation\n\t"
                    //some excel error occurs because the first character so i delete it from message
                    if (i == 80)
                    {
                        data = "Peak-to-peak amplitude stays constant, or not\n\timplemented, or no informationstays\n\tconstant, or not implemented, or no\n\tinformation\n\t";
                    }

                    xlWorkSheet.Cells[row, col++].Value = data;
                    xlWorkSheet.Cells[row, col++].Value = "sff_8636";
                    xlWorkSheet.Cells[row, col++].Value = MainDictionary[i + 1].GetPage().ToString();

                    if (MainDictionary[i + 1].getColor() == "Green")
                    {
                        xlWorkSheet.Cells[row, col].Value = "Passed";
                    }
                    else
                    {
                        xlWorkSheet.Cells[row, col].Value = "Test Failed";
                    }
                    row++;
                }

                //saving_progress_bar.Visible = false;

                try
                {
                    xlWorkBook.SaveAs(folderName + "\\" + file_to_save, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlNoChange, misValue, misValue, misValue, misValue, misValue);
                }
                catch
                {
                    //saving_progress_bar.Visible = false;
                    return "Error in saving file";
                }
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                //saving_progress_bar.Visible = false;
                //MessageBox.Show("Excel file created , you can find the file " + folderName + "\\" + file_to_save);

            }

            return "data has been saved succesfully";
        }
    }
}
