using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpCompilerApp
{
    public partial class Form2 : Form
    {

        private Form MainForm;
        public Form2(Form form)
        {
            InitializeComponent();
            MainForm = form;
        }

        public void End_Compile()
        {
            label1.Text = "コンパイルが完了しました";
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm.Focus();
            this.Close();
        }
    }
}
