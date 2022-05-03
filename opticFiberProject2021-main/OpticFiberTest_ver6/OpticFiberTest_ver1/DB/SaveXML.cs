using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;

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
            xdoc.Save(System.IO.Path.GetFullPath(@"..\..\DB\") + "fiberData.xml");
        }
    }
}
