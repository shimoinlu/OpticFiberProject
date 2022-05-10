using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Windows.Forms;
using System.IO;

namespace OpticFiberTest_ver1.DB
{
    class SaveData
    {

        static XmlDocument xdoc;
        static XmlElement rootElement;

        static SaveData()
        {
            xdoc = new XmlDocument();
            rootElement = xdoc.CreateElement("body");
            xdoc.AppendChild(rootElement);
        }

        public static void addNode(byte address, string value)
        {
            XmlNode ByteNode = xdoc.CreateElement("Byte");

            XmlNode addressNode = xdoc.CreateElement("address");
            addressNode.InnerText = address.ToString();
            ByteNode.AppendChild(addressNode);

            XmlNode valueNode = xdoc.CreateElement("value");
            valueNode.InnerText = value.ToString();
            ByteNode.AppendChild(valueNode);

            rootElement.AppendChild(ByteNode);
        }

        public static void save()
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //lets see if you find it

            saveFileDialog1.Filter = "xml files (*.xml)|*.xml";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }
        }
    }
}
