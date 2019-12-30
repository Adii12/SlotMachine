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
using System.Diagnostics;

namespace SlotMachine {
    public partial class SlotMachineScreen : Form {
        Assembly xml;
        dynamic xmlReader;
        private int[] chances = new int[8];
        private int jackpotChance;
        public SlotMachineScreen() {
            InitializeComponent();
            xml = Assembly.Load("XmlReader");
            xmlReader = xml.CreateInstance("XmlReader.XmlReader");
            chances = xmlReader.getChances();
            for (int i = 0; i < 8; i++) {
                Debug.WriteLine(chances[i]);
            }
            jackpotChance = chances[7];
        }
    }
}
