using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace SlotMachine
{
    public partial class Form1 : Form
    {
        Assembly xmlDLL;
        dynamic xml;
        public Form1()
        {
            InitializeComponent();
             xmlDLL = System.Reflection.Assembly.Load("XmlReader");
            if (xmlDLL == null) {
                MessageBox.Show("Could not load database assembly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(1);
            }

            xml = xmlDLL.CreateInstance("XmlReader.XmlReader");
            
        }
    }
}
