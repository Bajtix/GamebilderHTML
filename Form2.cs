using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Gamebilder
{
    public partial class Form2 : Form
    {
        string selected;
        public Form2()
        {
            InitializeComponent();
            createCss();

            Directory.CreateDirectory(textBox1.Text);
            
            listView1.Items.Clear();
            string[] items = Directory.GetFiles(textBox1.Text);
            foreach (string i in items)
            {
                listView1.Items.Add(Path.GetFileName(i));
            }
            if (File.Exists("uset.set"))
            {
                StreamReader sr = new StreamReader("uset.set");
                textBox1.Text = sr.ReadLine();
                sr.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(textBox1.Text + "/" + selected);
            if (listView1.SelectedItems.Count > 0)
            {
                Form1 f = new Form1(listView1.SelectedItems[0].Text, textBox1.Text);
                f.Show();
                Directory.CreateDirectory(textBox1.Text);
            }
            else
                MessageBox.Show("Select a file!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1(null,textBox1.Text);
            f.Show();
            Directory.CreateDirectory(textBox1.Text);
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count != 0)
                selected = listView1.SelectedItems[0].Text;
            else
                MessageBox.Show("Select a file!");
            //MessageBox.Show(listView1.SelectedItems[0].Text);
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string[] items = Directory.GetFiles(textBox1.Text);
            foreach (string i in items)
            {
                listView1.Items.Add(Path.GetFileName(i));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            File.Delete(textBox1.Text + "/" + listView1.SelectedItems[0].Text);
            listView1.Items.Remove(listView1.SelectedItems[0]);
            listView1.SelectedItems.Clear();
            listView1.Items.Clear();
            string[] items = Directory.GetFiles(textBox1.Text);
            foreach (string i in items)
            {
                listView1.Items.Add(Path.GetFileName(i));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            Process.Start(textBox1.Text + "/" + listView1.SelectedItems[0].Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if(folderBrowserDialog1.SelectedPath != "" && folderBrowserDialog1.SelectedPath != null)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        void createCss()
        {
            //MessageBox.Show(File.Exists("ustyle.css").ToString());
            if(!File.Exists("ustyle.css"))
            {
                MessageBox.Show("ustyle");
                StreamWriter css = new StreamWriter("ustyle.css");
                css.WriteLine("body {background-color: white; text-align: center;}");
                css.WriteLine("img {border-radius: 25px;}");
                css.WriteLine("a {color:red;}");
                css.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void sp_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("uset.set");
            sw.Write(textBox1.Text);
            sw.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
