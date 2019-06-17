using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpCompilerApp
{
    public partial class Form1 : Form
    {
        private string SorceFileName;      //コンパイルするファイル名
        private string CompilerFileName;   //コンパイラー名
        private string OutDirectoryName;   //コンパイルしたファイルを保存するディレクトリ名

        public Form1()
        {
            InitializeComponent();

            this.Text = "C#コンパイラ";
            this.Icon = new Icon("Iconc#.ico");
            CompilerFileName = "C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\csc.exe";
            OutDirectoryName      = "out_program\\";
            
        }

        internal string CompileFileDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "C#ソースファイル(*.cs)|*.cs|すべてのファイル(*.*)|*.*";
            ofd.RestoreDirectory = true;
            ofd.FilterIndex = 1;
            ofd.Title = "csファイルを選択してください";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                return ofd.FileName;
            }
            else
            {
                return "ファイルを選択してください。";
            }
        }


        //コンパイルするファイルを選択する
        private void fileOpen_Click(object sender, EventArgs e)
        {
            string fn = CompileFileDialog();
            SorceFileName = fn;
            textBox1.Text = fn;
        }

        //コンパイル開始
        private void CompileStart_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = CompilerFileName;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;

            //ファイルのパスからファイル名を取得
            string fileName = Path.GetFileName(SorceFileName);
            int namelength = fileName.Length;

            //ソースファイルの拡張子 (.cs)をファイル名から取り除く
            fileName = fileName.Remove(namelength - 3) + ".exe";

            string command = "/target:winexe " + "/out:" + OutDirectoryName + fileName + " " + SorceFileName;
            process.StartInfo.Arguments = command;
            process.Start();

            Form2 form = new Form2(this);
            form.Show();


            while (true)
            {
                if (process.HasExited)
                {
                    form.End_Compile(process.StandardOutput.ReadToEnd());
                    break;
                }
            }
        }

        /***************MENU STRIP*********************/
        //ファイル->ファイルを開く
        private void OpenFileMenu_Click(object sender, EventArgs e)
        {
            CompileFileDialog();
        }

        //ファイル->設定
        private void OpenSetMenu_Click(object sender, EventArgs e)
        {
            Form setting_form = new SettingForm();
            setting_form.ShowDialog();
        }

        //その他->バージョン情報
        private void OpenVersionInformation_Click(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            AssemblyName assemblyName = assembly.GetName();
            AssemblyCopyrightAttribute copyrightAttribute = 
                (AssemblyCopyrightAttribute)assembly.GetCustomAttribute(typeof(AssemblyCopyrightAttribute));

            string copyright = copyrightAttribute.Copyright;

            string msg = "Version:" + assemblyName.Version.ToString() + 
                         "\n" +copyright;

            MessageBox.Show(msg,"バージョン情報");
        }
        /*******************END************************/
    }
}
