using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Project
{

        public partial class Form1 : Form
        {
            Fasad fasad;
            MySqlConnection con;
            MySqlCommand command;
            public Form1()
            {
                InitializeComponent();

                this.fasad = new Fasad();
                this.con = new MySqlConnection("server=127.0.0.1;username=root;password=root;database=arenda");
                podkl();

            }

            void podkl()
            {
                string zapros = "SELECT * FROM arenda_";
                DataTable table = new DataTable();
                MySqlDataAdapter adp = new MySqlDataAdapter(zapros, con);
                adp.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    fasad.create_arenda_list(row.ItemArray);
                }
                zapros = "SELECT * FROM car";
                adp = new MySqlDataAdapter(zapros, con);
                table = new DataTable();
                adp.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    fasad.create_car_list(row.ItemArray);
                }
                zapros = "SELECT * FROM client";
                adp = new MySqlDataAdapter(zapros, con);
                table = new DataTable();
                adp.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    fasad.create_client_list(row.ItemArray);
                }
            }

            public Form1(Fasad fasad)
            {
                InitializeComponent();

                this.fasad = fasad;
                this.con = new MySqlConnection("server=127.0.0.1;username=root;password=root;database=arenda");

            }

            private void Label1_Click(object sender, EventArgs e)
            {

            }

            private void ComboBox_pic_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            private void Button_done_Click(object sender, EventArgs e)
            {
                if (comboBox_pic.SelectedIndex == 0)
                {
                    Client per_1 = new Client(fasad);
                    per_1.Show();
                    this.Visible = false;
                }
                if (comboBox_pic.SelectedIndex == 1)
                {
                    Car per_1 = new Car(fasad);
                    per_1.Show();
                    this.Visible = false;
                }
                if (comboBox_pic.SelectedIndex == 2)
                {
                    Arenda per_1 = new Arenda(fasad);
                    per_1.Show();
                    this.Visible = false;
                }
            }
        }
}
