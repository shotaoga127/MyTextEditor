using System.Text.RegularExpressions;
using System.Drawing;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            drawLine();
        }

        private void Form1_Resize_1(object sender, EventArgs e)
        {
            richTextBox1.Height = this.Height;
            richTextBox1.Width = this.Width;

            richTextBox1.Font = new Font("Meirio", this.Font.Size + 10);
            label1.Font = new Font("Meirio", this.Font.Size + 12);
        }

        private void �u������ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void �u������ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox1.Text.Replace(richTextBox1.SelectedText, toolStripTextBox1.Text);

            colorDing("if", Color.Purple);
            colorDing("for", Color.Purple);
            colorDing("while", Color.Purple);
            colorDing("switch", Color.Purple);
            colorDing("public", Color.Blue);
            colorDing("private", Color.Blue);
            colorDing("protected", Color.Blue);
            colorDing("extends", Color.Blue);
            colorDing("class", Color.Blue);
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '(')
            {
                // �J���������ɑΉ��������������}�����܂��B
                richTextBox1.SelectedText = ")";
                // �J�[�\�����������̒��Ɉړ����܂��B
                richTextBox1.SelectionStart--;
            }
            else if (e.KeyChar == '{')
            {
                richTextBox1.SelectedText = "}";
                richTextBox1.SelectionStart--;
            }
            else if (e.KeyChar == '[')
            {
                richTextBox1.SelectedText = "]";
                richTextBox1.SelectionStart--;
            }
            else if (e.KeyChar == '\"')
            {
                richTextBox1.SelectedText = "\"";
                richTextBox1.SelectionStart--;
            }

            else if (e.KeyChar == '\'')
            {
                richTextBox1.SelectedText = "\'";
                richTextBox1.SelectionStart--;
            }

            else if (e.KeyChar == '<')
            {
                richTextBox1.SelectedText = ">";
                richTextBox1.SelectionStart--;
            }
        }

        bool isrep = false;
        string[] reps = new string[2];
        int index = 0;
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == (Keys.Space | Keys.Shift))
            {
                MessageBox.Show("�u������");
                isrep = true;
            }

            if (isrep)
            {
                reps[index] = richTextBox1.SelectedText;
                MessageBox.Show(reps[0]);
                index++;
                if(index< 2)
                {
                    index = 0;
                    richTextBox1.Text = richTextBox1.Text.Replace(reps[0], reps[1]);
                    reps = null;
                    isrep = false;
                }
            }
        }

        private void drawLine()
        {
            int line = richTextBox1.Text.Split("\n").Length;
            string linecode = "";
            for (int i = 1; i <= line; i++)
            {
                linecode += i + "\n";
            }

            label1.Text = linecode;
        }


        private void colorDing(string searchWoard, Color color)
        {
            //���݂̑I����Ԃ��o���Ă���
            int currentSelectionStart =  richTextBox1.SelectionStart;
            int currentSelectionLength = richTextBox1.SelectionLength;

            int pos = 0;
            for (; ; )
            {
                //��������������āA�I����Ԃɂ���
                pos = richTextBox1.Find(searchWoard, pos, RichTextBoxFinds.None);
                if (pos < 0)
                {
                    break;
                }
                //�w�i�F��Ԃɂ���
                richTextBox1.SelectionColor = color;
                pos++;
            }

            //�I����Ԃ����ɖ߂�
            richTextBox1.Select(currentSelectionStart, currentSelectionLength);
            richTextBox1.SelectionColor = Color.Black;
        }
    }
}