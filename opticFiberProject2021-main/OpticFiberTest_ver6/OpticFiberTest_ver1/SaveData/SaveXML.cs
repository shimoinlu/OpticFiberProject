using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using OpticFiberTest_ver1.Protocols_classes;


namespace OpticFiberTest_ver1.SaveData
{
    class SaveXML
    {

        static public string createXML(Dictionary<int, Protocols> MainDictionary)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "xml files (*.xml)|*.xml";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    XmlDocument xdoc;
                    XmlElement rootElement;
                    XmlNode field, Byte, Name, Data, Test_status, page;
                    int pageNum = -1;

                    xdoc = new XmlDocument();
                    rootElement = xdoc.CreateElement("body");
                    xdoc.AppendChild(rootElement);

                    page = xdoc.CreateElement("page_0"); //only for initializing. no using in it

                    //saving_progress_bar.Maximum = 200;
                    //saving_progress_bar.Visible = true;

                    for (int i = 0; i < MainDictionary.Keys.Count(); i++)
                    {
                        //saving_progress_bar.Value = i * saving_progress_bar.Maximum / (MainDictionary.Keys.Count() - 1);

                        field = xdoc.CreateElement("Field"); //represent one field in protocol

                        if (MainDictionary[i + 1].GetPage() != pageNum)
                        {
                            pageNum = MainDictionary[i + 1].GetPage();
                            //if (pageNum == 1) { pageNum--; }    //fix problem of pageNum is 1 instead 0
                            page = xdoc.CreateElement("page_" + pageNum.ToString()); //current page
                            rootElement.AppendChild(page);
                        }

                        Byte = xdoc.CreateElement("Byte");
                        Byte.InnerText = MainDictionary[i + 1].GetAddress().ToString(); //????? i added the toString() need to check
                        field.AppendChild(Byte);

                        Name = xdoc.CreateElement("Name");
                        Name.InnerText = MainDictionary[i + 1].GetTitle();
                        field.AppendChild(Name);

                        Data = xdoc.CreateElement("Data");
                        Data.InnerText = MainDictionary[i + 1].GethasRead();
                        field.AppendChild(Data);

                        //ID = xdoc.CreateElement("Protocol");
                        //ID.InnerText = "sff_8636";
                        //field.AppendChild(ID);

                        //XmlNode pageNum = xdoc.CreateElement("pageNum");
                        //pageNum.InnerText = MainDictionary[i + 1].GetPage().ToString();      ////////should be changed to current page
                        //field.AppendChild(pageNum);

                        Test_status = xdoc.CreateElement("Test_status");
                        if (MainDictionary[i + 1].getColor() == "Green") { Test_status.InnerText = "Test Passed"; }
                        else { Test_status.InnerText = "Test Failed"; }
                        field.AppendChild(Test_status);

                        page.AppendChild(field);
                    }

                    //rootElement.AppendChild(page);

                    xdoc.Save(myStream);
                    myStream.Close();
                }
            }

            return "data has been saved succesfully";
            //saving_progress_bar.Visible = false;
        }
    }
}