using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpCompilerApp
{
    public partial class Form1 : Form
    {
        private String SorceFileName;      //コンパイルするファイル名
        private String CompilerFileName;   //コンパイラー名

        public Form1()
        {
            InitializeComponent();

            this.Text = "C#コンパイラ";
            CompilerFileName = "C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\csc.exe";
        }


        //コンパイルするファイルを選択する
        private void fileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "C#ソースファイル(*.cs)|*.cs|すべてのファイル(*.*)|*.*";
            ofd.RestoreDirectory = true;
            ofd.FilterIndex = 1;
            ofd.Title = "csファイルを選択してください";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                SorceFileName = ofd.FileName;
                textBox1.Text = SorceFileName;
            }
        }

        //コンパイル開始
        private void CompileStart_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = CompilerFileName;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;

            String command = SorceFileName;
            process.StartInfo.Arguments = command;
            process.Start();

            Form2 form = new Form2(this);
            form.Show();

            while (true)
            {
                if (process.HasExited)
                {
                    form.End_Compile();

                    if(MessageBox.Show(process.StandardOutput.ReadToEnd(),"終了") == DialogResult.OK)
                    {
                        form.Focus();
                    }
                    break;
                }
            }
        }
    }
}
