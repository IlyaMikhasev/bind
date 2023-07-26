using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bind
{
    public partial class Form1 : Form
    {
        
        Binding BindingNumeric;
        Binding BindingSymbol;
        public Form1()
        {
            InitializeComponent();
            BindingSeparation();
        }
        private void BindingSeparation() {
            Binding BindingText = new Binding("Text", textBox1, "Text");
            BindingText.Format += serchSTRING;
            label1.DataBindings.Add(BindingText);
            
            BindingNumeric = label2.DataBindings.Add("Text", textBox1, "Text");
            BindingNumeric.Format += serchNUMBER;   

            BindingSymbol = label3.DataBindings.Add("Text", textBox1, "Text");
            BindingSymbol.Format += serchCHAR;
        }
        private void serchNUMBER(object sender, ConvertEventArgs e) {
            Regex regNUm = new Regex(@"\d+");
            MatchCollection match = regNUm.Matches(e.Value.ToString());
            foreach (Match m in match)
            {
                e.Value = m.Value;
            }
        }
        private void serchSTRING(object sender, ConvertEventArgs e)
        {
            Regex regSTR = new Regex(@"[A-Za-z]+");
            MatchCollection match = regSTR.Matches(e.Value.ToString());
            foreach (Match m in match)
            {
                e.Value = m.Value;
            }

        }
        private void serchCHAR(object sender, ConvertEventArgs e)
        {
            Regex regCH = new Regex(@"[.,!@#$%^&*?;:]+");
            MatchCollection match = regCH.Matches(e.Value.ToString());
            foreach (Match m in match)
            {
                e.Value =  m.Value;
            }

        }

    }
}
