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
    public partial class Car : Form
    {
        Fasad fasad;
        MySqlConnection con;
        MySqlCommand command;
        public Car(Fasad fas)
        {
            InitializeComponent();

            this.fasad = fas;
            this.con = new MySqlConnection("server=127.0.0.1;username=root;password=root;database=arenda");
            podkl();
        }

        void init_vue()
        {
            this.dataGridView_car.Columns.Add("id_car", "id_client");
            this.dataGridView_car.Columns.Add("brend", "brend");
            this.dataGridView_car.Columns.Add("marka", "marka");
            this.dataGridView_car.Columns.Add("mileage", "mileage");
            this.dataGridView_car.Columns.Add("class", "class");
        }
        void podkl()
        {
            init_vue();
            data_resause();
        }

        void data_resause()
        {
            this.dataGridView_car.Rows.Clear();
            List<List<string>> mass_car = this.fasad.car_List.mass_car();
            foreach (List<string> i in mass_car)
            {
                dataGridView_car.Rows.Add(i[0], i[1], i[2], i[3], i[4]);
            }

        }

        private void DataGridView_client_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void Button_bec_Click(object sender, EventArgs e)
        {
            Form1 dr = new Form1(this.fasad);
            dr.Show();
            Hide();
        }

        private void Button_ins_Click(object sender, EventArgs e)
        {
            int id_car = Convert.ToInt32(fasad.client_List.ret_id());
            string brend = textBox2.Text;
            string marka = textBox3.Text;
            int brobeg = Convert.ToInt32(textBox6.Text);
            string class_ = textBox5.Text;
            if (el_is_valid(brend, marka, class_) && (!fasad.car_List.get_full_id().Contains(id_car.ToString())))
            {
                Object[] mass = { id_car, brend, marka, brobeg, class_ };
                fasad.create_car_list(mass);
                string insert_query = string.Format("INSERT INTO car(id_car,brend,marka,milleage,class) VALUES (" + id_car + ",\"" + brend + "\",\"" + marka + "\",\"" + brobeg + "\",\"" + class_ + "\")");
                executeMyQuery(insert_query);

            }
            data_resause();
        }


        private bool el_is_valid(string brend, string marka, string class_)
        {
            bool c = true;
            if (brend == "" || marka == "" || class_ == "")
            {
                c = false;
            }
            return c;
        }
        private void Btn_del_Click(object sender, EventArgs e)
        {
            fasad.car_List.delete_el(Convert.ToInt32(textBox1.Text));
            string insert_query = string.Format("DELETE FROM `car` WHERE `id_car`={0}", Convert.ToInt32(textBox1.Text));
            executeMyQuery(insert_query);
            data_resause();
        }

        private void Car_Load(object sender, EventArgs e)
        {

        }

        private void Btn_up_Click(object sender, EventArgs e)
        {
            int id_car = Convert.ToInt32(textBox1.Text);
            string brend = textBox2.Text;
            string marka = textBox3.Text;
            int brobeg = Convert.ToInt32(textBox6.Text);
            string class_ = textBox5.Text;
            if (el_is_valid(brend, marka, class_) && (fasad.car_List.get_full_id().Contains(id_car.ToString())))
            {
                Object[] mass = { id_car, brend, marka, brobeg, class_ };
                fasad.update_car_list(mass);
                string insert_query = string.Format("UPDATE car SET `id_car`={0},`brend`='{1}',`marka`='{2}',`milleage`='{3}',`class`='{4}' WHERE `id_client`={0}", id_car.ToString(), brend, marka, brobeg, class_);
                executeMyQuery(insert_query);

            }
            data_resause();
        }

        public void executeMyQuery(string query)
        {
            try
            {
                openConnection();
                command = new MySqlCommand(query, con);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Выполннено");

                }
                else
                {
                    MessageBox.Show("Не выполненно");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeConnection();
            }
        }
        public void openConnection()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
        }
        public void closeConnection()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
    }
}
