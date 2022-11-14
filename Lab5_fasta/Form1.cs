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

namespace Lab5_fasta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string a = "";
        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();
            StreamReader sr = File.OpenText(openFileDialog.FileName);
            string s = "";

            textBox1.Text = sr.ReadLine();
            while ((s = sr.ReadLine()) != null)
            {
                a = a + s;
                textBox2.Text = a;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            a = textBox2.Text;
            string rezultat = "";
            List<string> list = new List<string>();
            List<int> list2 = new List<int>();
            
            for (int i = a.Length; i > 4 ; i--)               
            {
                string s = (a[(i - 4)].ToString() + a[i - 3].ToString() + a[i - 2].ToString() + a[i-1].ToString());
                
                if (list.Contains(s))
                {
                    int test = list.IndexOf(s);
                    list2[test] = list2[test]+1;
                    
                }
                else
                {
                    list.Add(s);
                    list2.Add(1);
                    
                }
            }
            
            
            for(int n = list2.Count; n > 0; n--)
            {
                if (list2[n-1] > 1){
                    rezultat = rezultat + list[n-1] + " " + list2[n-1] + "\r\t";
                }
            }
            textBox3.Text = rezultat;           
        }
    }
}
