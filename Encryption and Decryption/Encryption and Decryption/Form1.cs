using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Encryption_and_Decryption
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MySqlConnection con;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.Enabled = true;
            textBox2.Enabled = false;
            textBox2.ReadOnly = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                // Numbers
                Random r = new Random();
                int[] num = new int[5];

                for (int i = 0; i < num.Length; i++)
                {
                    num[i] = r.Next(1000,9999);
                }


                // Characters a - z
                Random r2 = new Random();
                string pin = "";

                for (int j = 0; j < 5; j++)
                {
                    int[] num2 = new int[2];

                    for (int i = 0; i < num2.Length; i++)
                    {
                        num2[i] = r2.Next(97, 123);

                        pin += (char)num2[i];
                    }
                }

                string val1 = pin.Substring(0, 2);
                string val2 = pin.Substring(2, 2);
                string val3 = pin.Substring(4, 2);
                string val4 = pin.Substring(6, 2);
                string val5 = pin.Substring(8, 2);


                string hash = val1 + "" + num[0] + "" + val2 + "" + num[1] + "" + val3 + "" + num[2] + "" + val4 + "" + num[3] + "" + val5 + "" + num[4];

                textBox2.Text = hash;
                textBox2.Enabled = true;
                textBox2.ReadOnly = true;

                //   Server=remotemysql.com;Database=2YZIINJ2tI;Uid=2YZIINJ2tI;Pwd=Ju6sOU6rxz;
                con = new MySqlConnection("Server=remotemysql.com;Database=2YZIINJ2tI;Uid=2YZIINJ2tI;Pwd=Ju6sOU6rxz;");
                con.Open();

                MySqlCommand cmd = new MySqlCommand("insert into code(text,hash)values('" + richTextBox1.Text + "','" + textBox2.Text + "')", con);
                cmd.ExecuteNonQuery();

                con.Close();
                
                
            }
            else if(radioButton2.Checked==true)
            {
                con = new MySqlConnection("Server=remotemysql.com;Database=2YZIINJ2tI;Uid=2YZIINJ2tI;Pwd=Ju6sOU6rxz;");
                con.Open();

                MySqlDataAdapter sadp = new MySqlDataAdapter("select * from code where hash='" + textBox2.Text + "'", con);
                DataTable dt = new DataTable();
                sadp.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if(textBox2.Text==dt.Rows[i]["hash"].ToString())
                    {
                        richTextBox1.Text = dt.Rows[i]["text"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Not found");
                    }
                }
                con.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox2.ReadOnly = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.Enabled = false;
            textBox2.Enabled = true;
            textBox2.ReadOnly = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            textBox2.Clear();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            textBox2.Clear();
        }
    }
}
