using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpCompilerApp
{
    public partial class Form1 : Form
    {
        private String SorceFileName;

        public Form1()
        {
            InitializeComponent();
        }

        private void fileOpenClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "C#ソースファイル(*.cs)|*.cs|すべてのファイル(*.*)|*.*";
            ofd.RestoreDirectory = true;
            ofd.FilterIndex = 1;
            ofd.Title = "csファイルを選択してください";

            if (ofd.ShowDialog() == DialogResult.OK) ;
                SorceFileName = ofd.FileName;
        }
    }
}
