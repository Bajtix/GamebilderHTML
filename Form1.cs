using HtmlAgilityPack;
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

namespace Gamebilder
{
    public partial class Form1 : Form
    {
        string path;
        string html;
        public Form1(string selectedFile,string projectPath)
        {
            InitializeComponent();
            path = projectPath;
            //MessageBox.Show(selectedFile);
            if (selectedFile != null)
                import(selectedFile);
        }

        private void update_Tick(object sender, EventArgs e)
        {
            html = "<html>\r\n<head> <link rel=\"stylesheet\" type=\"text/css\" href=\"ustyle.css\"> </head><body>\r\n<h1>" + textBox3.Text + "</h1>\r\n<h2>" + textBox4.Text + "</h2> \r\n <img src=\"" + textBox11.Text +"\"> <br/> \r\n<a id=\"0\" href=\"" + textBox6.Text + ".html\">" + textBox5.Text +"</a><br/>" + "\r\n<a id=\"1\" href =\"" + textBox9.Text + ".html\">" + textBox7.Text + "</a> <br/>"+ "\r\n<a id=\"2\" href =\"" + textBox10.Text + ".html\">" + textBox8.Text + "</a><br/>" + "\r\n<a id=\"3\" href =\"" + textBox12.Text + ".html\">" + textBox13.Text + "</a><br/>" + "\r\n<a id=\"4\" href =\"" + textBox14.Text + ".html\">" + textBox15.Text + "</a>" + "\r\n</body></html>";
            html.Replace("-n", "\r\n");
            textBox2.Text = html;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 1)
            {
                StreamWriter sw = new StreamWriter("temp.html");
                sw.Write(html);
                sw.Close();
                webBrowser1.Url = new Uri(Path.GetFullPath("temp.html"));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                StreamWriter sw = new StreamWriter("temp.html");
                sw.Write(html);
                sw.Close();
                webBrowser1.Url = new Uri(Path.GetFullPath("temp.html"));
            }
        }
        void import(string pathl)
        {
            //MessageBox.Show(path + "/" + pathl);
            StreamReader sr = new StreamReader(path + "/" +pathl);
            string text = sr.ReadToEnd();
            sr.Close();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(text);

            HtmlNodeCollection node = doc.DocumentNode.SelectNodes("//a[@href]"); //Here, you can also do something like (".//span[@id='point_total' class='tooltip' jQuery16207621750175125325='23' oldtitle='Note: If the number is black, your points are actually a little bit negative.  Don't worry, this just means you need to start subbing again.']"); to select specific spans, etc...
            HtmlNode title = doc.DocumentNode.SelectSingleNode("//h1");
            HtmlNode desc = doc.DocumentNode.SelectSingleNode("//h2");
            HtmlNode img = doc.DocumentNode.SelectSingleNode("//img[@src]");
            textBox3.Text = title.InnerHtml;
            textBox4.Text = desc.InnerHtml;
            textBox11.Text = img.Attributes.ElementAt(0).Value;
            textBox6.Text = node.ElementAt(0).Attributes.ElementAt(1).Value.Substring(0, node.ElementAt(0).Attributes.ElementAt(1).Value.Length - 5); ;
            textBox5.Text = node.ElementAt(0).InnerText;
            textBox9.Text = node.ElementAt(1).Attributes.ElementAt(1).Value.Substring(0, node.ElementAt(1).Attributes.ElementAt(1).Value.Length - 5); ;
            textBox7.Text = node.ElementAt(1).InnerText;
            textBox10.Text = node.ElementAt(2).Attributes.ElementAt(1).Value.Substring(0, node.ElementAt(2).Attributes.ElementAt(1).Value.Length - 5);
            textBox8.Text = node.ElementAt(2).InnerText;
            textBox12.Text = node.ElementAt(3).Attributes.ElementAt(1).Value.Substring(0, node.ElementAt(3).Attributes.ElementAt(1).Value.Length - 5);
            textBox13.Text = node.ElementAt(3).InnerText;
            textBox15.Text = node.ElementAt(4).Attributes.ElementAt(1).Value.Substring(0, node.ElementAt(4).Attributes.ElementAt(1).Value.Length - 5);
            textBox14.Text = node.ElementAt(4).InnerText;
            textBox1.Text = pathl.Substring(0, pathl.Length - 5);

            
            
            //MessageBox.Show(value);
        }

        private void sav_Click(object sender, EventArgs e)
        {
            if (!File.Exists(path + "/" + textBox1.Text + ".html"))
            {
                StreamWriter sw = new StreamWriter(path + "/" + textBox1.Text + ".html");
                sw.Write(html);
                sw.Close();
            }
            else
                MessageBox.Show("File already exists!");

            if(!File.Exists(path + "/ustyle.css"))
            {
                File.Copy("ustyle.css", path + "/ustyle.css");
            }
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label4.Visible = false;
        }
    }
}
