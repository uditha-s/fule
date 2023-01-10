using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace fule_pass_chcker
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String vno = textBox1.Text;
            String tp = textBox2.Text;
            String let = textBox4.Text;
            String dat = dateTimePicker1.Text;

            if (vno == "" )
            {
                MessageBox.Show("pleace enter values");
                textBox1.Focus();
            }
            else
            {
                //Insert data into database
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Asus\Documents\my.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "INSERT INTO Applicant (nic_number,name,phone_number,address,district,service_type,has_paid, receipt_number, appointment_date) VALUES('" + UserNic + "','" + ApplicantName + "','" + PhoneNumber + "','" + Address + "','" + Disctric + "','" + ServiceType + "' ,'" + Payment + "', '" + PaymentNumber + "', '" + AppoitmentDate + "');";
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("You are succesfully Registered !!!");
                }
                catch (SqlException msg)
                {
                    MessageBox.Show("Error!!!\n Please Try agian later");
                    Console.WriteLine(msg.Message);
                }
                finally
                {
                    con.Close();
                }

            }
    }
}
