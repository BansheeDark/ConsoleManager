using ConsoleManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleManager
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            this.Text = Settings.Default.ManagerName + " - Settings";
        }
    }
}
