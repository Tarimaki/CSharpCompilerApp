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
    public partial class SettingForm : Form
    {
        public SettingForm(Form form)
        {
            InitializeComponent();
            InitializeValue();
            
            
        }

        private void InitializeValue()
        {
            //textbox
            if (File.Exists(Form1.CompilerFile))
            {
                textBox1.Text = Form1.CompilerFile;
            }
            else
            {
                textBox1.Text = Form1.NOT_SETTING_MESSAGE;
            }
            

            //label
            label1.Text = "コンパイラーの設定をします。csc.exeファイルを選んでください。\n\n" +
                "csc.exe以外のc#コンパイラーには対応していません。";
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            apply_button_Click(sender, e);
            Dispose();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void apply_button_Click(object sender, EventArgs e)
        {

        }

        //csc.exeの指定
        private void OpenFile_Click(object sender, EventArgs e)
        {
            string filter = "csc.exe|csc.exe";
            string title = "コンパイラーを選択してください。";
            string FileName = Form1.CompileFileDialog(filter,title);

            if (FileName == Form1.NOT_SETTING_MESSAGE)
            {
                Form1.CompilerFile = null;
                textBox1.Text = Form1.NOT_SETTING_MESSAGE;
            }
            else
            {
                Form1.CompilerFile = FileName;
                textBox1.Text = FileName;
            }
        }
    }
}
