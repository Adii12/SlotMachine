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
        XmlTextWriter xmlWriter;
<<<<<<< HEAD
        private int[] chances = new int[8];
=======
        private int[] chances = new int[9];
>>>>>>> bb88726c59962a3df6a4cd7c1586eba428ab59e8
        public XmlReader() {
            xmlReader = new XmlTextReader("chances.xml");
            int i = 0;
            while (xmlReader.Read()) {
                switch (xmlReader.NodeType) {
                    case XmlNodeType.Element:
                        Debug.WriteLine(xmlReader.Name);
                        break;
                    case XmlNodeType.Text:
                        if (xmlReader.Value != null) {
                            chances[i] = System.Convert.ToInt32(xmlReader.Value);
                        }
                        break;
                    case XmlNodeType.EndElement:
                        ++i;
                        break;
                }
            }
            xmlReader.Close();
        }
        public int[] getChances() {
            return chances;
        }
        public void updateJackpot(double chance) {
            xmlWriter = new XmlTextWriter("chances.xml", null);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteWhitespace("\n");
            xmlWriter.WriteStartElement("chances");
            xmlWriter.WriteWhitespace("\n\t");
<<<<<<< HEAD
            xmlWriter.WriteElementString("cherry", "30");
            xmlWriter.WriteWhitespace("\n\t");
            xmlWriter.WriteElementString("orange", "15");
            xmlWriter.WriteWhitespace("\n\t");
            xmlWriter.WriteElementString("lemon", "15");
            xmlWriter.WriteWhitespace("\n\t");
            xmlWriter.WriteElementString("plum", "15");
=======
            xmlWriter.WriteElementString("cherry", "29");
            xmlWriter.WriteWhitespace("\n\t");
            xmlWriter.WriteElementString("orange", "13");
            xmlWriter.WriteWhitespace("\n\t");
            xmlWriter.WriteElementString("lemon", "13");
            xmlWriter.WriteWhitespace("\n\t");
            xmlWriter.WriteElementString("plum", "13");
>>>>>>> bb88726c59962a3df6a4cd7c1586eba428ab59e8
            xmlWriter.WriteWhitespace("\n\t");
            xmlWriter.WriteElementString("grapes", "10");
            xmlWriter.WriteWhitespace("\n\t");
            xmlWriter.WriteElementString("melon", "10");
            xmlWriter.WriteWhitespace("\n\t");
<<<<<<< HEAD
=======
            xmlWriter.WriteElementString("start", "7");
            xmlWriter.WriteWhitespace("\n\t");
>>>>>>> bb88726c59962a3df6a4cd7c1586eba428ab59e8
            xmlWriter.WriteElementString("seven", "5");
            xmlWriter.WriteWhitespace("\n\t");
            xmlWriter.WriteElementString("jackpot", chance.ToString());
            xmlWriter.WriteWhitespace("\n");
            xmlWriter.WriteEndElement();
            xmlWriter.Flush();
            xmlWriter.Close();
        }
    }
}
