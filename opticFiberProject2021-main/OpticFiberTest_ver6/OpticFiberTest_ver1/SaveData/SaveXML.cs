/*using system;
using system.collections.generic;
using system.linq;
using system.text;
using system.threading.tasks;
using system.xml;
using system.xml.serialization;
using system.xml.linq;
using system.windows.forms;
using system.io;*/

namespace opticfibertest_ver1.savedata
{
    class savexml
    {

        //static xmldocument xdoc;
        //static xmlelement rootelement;

        //static savexml()
        //{
        //    xdoc = new xmldocument();
        //    rootelement = xdoc.createelement("body");
        //    xdoc.appendchild(rootelement);
        //}

        //public static void addnode(byte address, string value)
        //{
        //    xmlnode bytenode = xdoc.createelement("byte");

        //    xmlnode addressnode = xdoc.createelement("address");
        //    addressnode.innertext = address.tostring();
        //    bytenode.appendchild(addressnode);

        //    xmlnode valuenode = xdoc.createelement("value");
        //    valuenode.innertext = value.tostring();
        //    bytenode.appendchild(valuenode);

        //    rootelement.appendchild(bytenode);
        //}

        //public static void save()
        //{            
        //    stream mystream;
        //    savefiledialog savefiledialog1 = new savefiledialog();

        //    savefiledialog1.filter = "xml files (*.xml)|*.xml";
        //    savefiledialog1.filterindex = 2;
        //    savefiledialog1.restoredirectory = true;

        //    if (savefiledialog1.showdialog() == dialogresult.ok)
        //    {
        //        if ((mystream = savefiledialog1.openfile()) != null)
        //        {
        //            xdoc.save(mystream);
        //            mystream.close();
        //        }
        //    }
        //}
    }
}
