using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlReader {
    public class XmlReader {
        XmlTextReader xmlReader;
        private int[] chances = new int[8];
        public XmlReader() {
            /* xmlReader = new XmlTextReader("chances.xml");
             int i = 0;
             while (xmlReader.Read())
             {
                 switch (xmlReader.NodeType)
                 {
                     case XmlNodeType.Element:
                         Debug.WriteLine(xmlReader.Name);
                         break;
                     case XmlNodeType.Text:
                         if (xmlReader.Value != null)
                         {
                             chances[i]=System.Convert.ToInt32(xmlReader.Value);
                         }
                         break;
                     case XmlNodeType.EndElement:
                         ++i;
                         break;
                 }
             }/
         }
         /public int[] getChances()
         {
             return chances;
         }*/
        }
    }
}