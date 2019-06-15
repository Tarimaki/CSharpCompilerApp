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

        //コンパイル実行中及び完了form
        public Form2(Form form)
        {
            InitializeComponent();

            //元のフォームのアクセスを禁止する
            MainForm = form;
            MainForm.Enabled = false;
        }
        
        //コンパイル完了時のメッセージ
        public void End_Compile(string str)
        {
            label1.Text = "コンパイルが完了しました";
            button1.Enabled = true;
            this.Height = 400;

            Panel panel = new Panel();
            panel.Location = new System.Drawing.Point(20, 40);
            panel.Size = new System.Drawing.Size(270,280);

            RichTextBox tb = new RichTextBox();
            tb.Dock = DockStyle.Fill;
            tb.Multiline = true;
            tb.ScrollBars = RichTextBoxScrollBars.Vertical;
            tb.ReadOnly = true;
            tb.Text = str;

            panel.Controls.Add(tb);
            this.Controls.Add(panel);
        }

        //コンパイル完了メッセージのokボタン
        private void button1_Click(object sender, EventArgs e)
        {
            //元のフォームのアクセスを許可してフォーカスする
            MainForm.Focus();
            MainForm.Enabled = true;
            this.Close();
        }
    }
}
