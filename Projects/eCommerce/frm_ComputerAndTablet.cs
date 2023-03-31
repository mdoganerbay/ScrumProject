using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace eCommerce
{
    public partial class frm_ComputerAndTablet : Form
    {
        public frm_ComputerAndTablet()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=TEKNOLOGYDB;Integrated Security=True");
        private void ComputerAndTablet_Load(object sender, EventArgs e)
        {

            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Normal;

            panelMenu.Visible = false;
            panelLaptop.Visible = false;
            panelacer.Visible = false;
            panelsamsung.Visible = false;
            panelTablet.Visible = false;    
            
        }
        private void button6_Click(object sender, EventArgs e)
        {
            //----------------------------------------------------------------------
            panelacer.Visible = true; // Acer paneli görünür, diğerleri gizlenir
            panelsamsung.Visible = false;
            panelhp.Visible = false;
            panelLaptop.Visible = false;

            cboxMemory.Items.Clear();
            SqlCommand commandMemory = new SqlCommand("SELECT Memory FROM TBLDESKTOPS WHERE Model='ACER'", conn);
            SqlDataReader memory;

            conn.Open();
            memory = commandMemory.ExecuteReader();

            while (memory.Read())
            {
                cboxMemory.Items.Add(memory["Memory"]); // Acer'ın bellek seçenekleri comboBox'a eklenir
            }
            conn.Close();

            //----------------------------------------------------------------------

            cboxHDD.Items.Clear();
            SqlCommand commandHDD = new SqlCommand("SELECT HDD FROM TBLDESKTOPS WHERE Model ='ACER'", conn);
            SqlDataReader HDD;

            conn.Open();
            HDD = commandHDD.ExecuteReader();
            while (HDD.Read())
            {
                cboxHDD.Items.Add(HDD["HDD"]); // Acer'ın HDD seçenekleri comboBox'a a
            }
            conn.Close();

            //----------------------------------------------------------------------
            cboxSSD.Items.Clear();
            SqlCommand commandSSD = new SqlCommand("SELECT SSD FROM TBLDESKTOPS WHERE Model = 'ACER'", conn);
            SqlDataReader SSD;

            // SSD'leri seçmek için bir sorgu çalıştırın ve sonuçları döngü kullanarak ComboBox'a ekleniyor.
            conn.Open();
            SSD = commandSSD.ExecuteReader();
            while (SSD.Read())
            {
                cboxSSD.Items.Add(SSD["SSD"]);
            }
            conn.Close();

            //----------------------------------------------------------------------

            cboxMonitor.Items.Clear();
            SqlCommand commandMonitor = new SqlCommand("SELECT Monitor FROM TBLDESKTOPS WHERE Model = 'ACER'", conn);
            SqlDataReader Monitor;

            // Monitörleri seçmek için bir sorgu çalıştırın ve sonuçları döngü kullanarak ComboBox'a ekleniyor.
            conn.Open();
            Monitor = commandMonitor.ExecuteReader();
            while (Monitor.Read())
            {
                cboxMonitor.Items.Add(Monitor["Monitor"]);
            }
            conn.Close();

            //----------------------------------------------------------------------

            cboxColor.Items.Clear();
            SqlCommand commandColor = new SqlCommand("SELECT Color FROM TBLDESKTOPS WHERE Model = 'ACER'", conn);
            SqlDataReader Color;

            // Renkleri seçmek için bir sorgu çalıştırın ve sonuçları döngü kullanarak ComboBox'a ekleniyor.
            conn.Open();
            Color = commandColor.ExecuteReader();
            while (Color.Read())
            {
                cboxColor.Items.Add(Color["Color"]);
            }
            conn.Close();

        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            // bağlantı cümlesini ayarlandı
            string connectionString = ("Data Source=.\\SQLEXPRESS;Initial Catalog=TEKNOLOGYDB;Integrated Security=True");

            SqlConnection connection = new SqlConnection(connectionString);

            // ürün özelliklerini combobox'lardan aldık            
            string memory = (cboxMemory.SelectedItem.ToString());
            string hdd = (cboxHDD.SelectedItem.ToString());
            string ssd = (cboxSSD.SelectedItem.ToString());
            string monitor = cboxMonitor.SelectedItem.ToString();
            string color = cboxColor.SelectedItem.ToString();

            // SQL sorgusu için parametreleri ayarlandı
            string query = "SELECT Model, Price FROM TBLDESKTOPS WHERE Memory = @Memory AND HDD = @HDD AND SSD = @SSD AND Monitor = @Monitor AND Color = @Color";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Memory", memory);
            command.Parameters.AddWithValue("@HDD", hdd);
            command.Parameters.AddWithValue("@SSD", ssd);
            command.Parameters.AddWithValue("@Monitor", monitor);
            command.Parameters.AddWithValue("@Color", color);

            // bağlantıyı açın ve fiyatları okuyun
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                tboxPrice.Text = reader["Price"].ToString();
            }
              connection.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = true;
            panelhp.Visible = false;
        }  


        //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-**-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
        //-----SAMSUNG----
        private void btonSamsung_Click(object sender, EventArgs e)
        {
            panelsamsung.Visible = true;
            panelacer.Visible = false;
            panelhp.Visible = false;
            cboxSMemory.Items.Clear();

            SqlCommand commandMemory1 = new SqlCommand("SELECT Memory FROM TBLDESKTOPS WHERE Model='SAMSUNG'", conn);
            SqlDataReader memory1;

            conn.Open();
            memory1 = commandMemory1.ExecuteReader();
            while (memory1.Read())
            {
                cboxSMemory.Items.Add(memory1["Memory"]);
            }
            conn.Close();
            //----------------------------------------------------------------------

            cboxSHDD.Items.Clear();
            SqlCommand commandHDD = new SqlCommand("SELECT HDD FROM TBLDESKTOPS WHERE Model ='SAMSUNG'", conn);
            SqlDataReader HDD;

            conn.Open();
            HDD = commandHDD.ExecuteReader();
            while (HDD.Read())
            {
                cboxSHDD.Items.Add(HDD["HDD"]);
            }
            conn.Close();
             //----------------------------------------------------------------------

            cboxSSSD.Items.Clear();
            SqlCommand commandSSD = new SqlCommand("SELECT SSD FROM TBLDESKTOPS WHERE Model = 'SAMSUNG'", conn);
            SqlDataReader SSD;

            conn.Open();
            SSD = commandSSD.ExecuteReader();
            while (SSD.Read())
            {
                cboxSSSD.Items.Add(SSD["SSD"]);
            }
            conn.Close();
            //----------------------------------------------------------------------

            cboxSMonitor.Items.Clear();
            SqlCommand commandMonitor = new SqlCommand("SELECT Monitor FROM TBLDESKTOPS WHERE Model = 'SAMSUNG'", conn);
            SqlDataReader Monitor;

            conn.Open();
            Monitor = commandMonitor.ExecuteReader();
            while (Monitor.Read())
            {
                cboxSMonitor.Items.Add(Monitor["Monitor"]);
            }
            conn.Close();
            //----------------------------------------------------------------------

            cboxSColor.Items.Clear();
            SqlCommand commandColor = new SqlCommand("SELECT Color FROM TBLDESKTOPS WHERE Model = 'SAMSUNG'", conn);
            SqlDataReader Color;

            conn.Open();
            Color = commandColor.ExecuteReader();
            while (Color.Read())
            {
                cboxSColor.Items.Add(Color["Color"]);
            }
            conn.Close();
        }
        private void btonGetirS_Click_1(object sender, EventArgs e)
        {
            // Veritabanına bağlanmak için gerekli bağlantı dizesi tanımlandı
            string connectionString = ("Data Source=.\\SQLEXPRESS;Initial Catalog=TEKNOLOGYDB;Integrated Security=True");

            // SqlConnection sınıfı kullanarak veritabanı bağlantısı oluşturuldu
            SqlConnection connection = new SqlConnection(connectionString);

            // Seçilen ürün özellikleri combobox'lardan alındı
            string memory = (cboxSMemory.SelectedItem.ToString());
            string hdd = (cboxSHDD.SelectedItem.ToString());
            string ssd = (cboxSSSD.SelectedItem.ToString());
            string monitor = cboxSMonitor.SelectedItem.ToString();
            string color = cboxSColor.SelectedItem.ToString();

            // SQL sorgusu için parametreler belirlendi
            string query = "SELECT Model, Price FROM TBLDESKTOPS WHERE Memory = @Memory AND HDD = @HDD AND SSD = @SSD AND Monitor = @Monitor AND Color = @Color";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Memory", memory);
            command.Parameters.AddWithValue("@HDD", hdd);
            command.Parameters.AddWithValue("@SSD", ssd);
            command.Parameters.AddWithValue("@Monitor", monitor);
            command.Parameters.AddWithValue("@Color", color);

            // Bağlantı açılarak fiyat bilgileri okundu
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                textBoxSam.Text = reader["Price"].ToString();
            }
            connection.Close();
        }






            //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-**-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-

            ///------HP-------/
            private void btonHp_Click(object sender, EventArgs e)
        {
            panelhp.Visible = true;
            panelLaptop.Visible = false;
            panelacer.Visible = false;
            panelsamsung.Visible = false;



            cboxHMemory.Items.Clear();
            SqlCommand commandMemory = new SqlCommand("SELECT Memory FROM TBLDESKTOPS WHERE Model='HP'", conn);

            SqlDataReader memory;

            conn.Open();
            memory = commandMemory.ExecuteReader();

            while (memory.Read())
            {
                cboxHMemory.Items.Add(memory["Memory"]);

            }
            conn.Close();


            //----------------------------------------------------------------------

            cboxHHDD.Items.Clear();
            SqlCommand commandHDD = new SqlCommand("SELECT HDD FROM TBLDESKTOPS WHERE Model ='HP'", conn);
            SqlDataReader HDD;

            conn.Open();
            HDD = commandHDD.ExecuteReader();

            while (HDD.Read())
            {
                cboxHHDD.Items.Add(HDD["HDD"]);

            }
            conn.Close();

            //    //----------------------------------------------------------------------

            cboxHSSD.Items.Clear();
            SqlCommand commandSSD = new SqlCommand("SELECT SSD FROM TBLDESKTOPS WHERE Model = 'HP'", conn);
            SqlDataReader SSD;

            conn.Open();
            SSD = commandSSD.ExecuteReader();

            while (SSD.Read())
            {
                cboxHSSD.Items.Add(SSD["SSD"]);

            }
            conn.Close();
            //----------------------------------------------------------------------

            cboxHMonitor.Items.Clear();
            SqlCommand commandMonitor = new SqlCommand("SELECT Monitor FROM TBLDESKTOPS WHERE Model = 'HP'", conn);
            SqlDataReader Monitor;

            conn.Open();
            Monitor = commandMonitor.ExecuteReader();

            while (Monitor.Read())
            {
                cboxHMonitor.Items.Add(Monitor["Monitor"]);

            }
            conn.Close();
            //----------------------------------------------------------------------

            cboxHColor.Items.Clear();
            SqlCommand commandColor = new SqlCommand("SELECT Color FROM TBLDESKTOPS WHERE Model = 'HP'", conn);
            SqlDataReader Color;

            conn.Open();
            Color = commandColor.ExecuteReader();

            while (Color.Read())
            {
                cboxHColor.Items.Add(Color["Color"]);

            }
            conn.Close();


        }
        private void btonGetirHp_Click(object sender, EventArgs e)
        {
            // bağlantı cümlesini ayarlandı
            string connectionString = ("Data Source=.\\SQLEXPRESS;Initial Catalog=TEKNOLOGYDB;Integrated Security=True");

            SqlConnection connection = new SqlConnection(connectionString);

            // ürün özelliklerini combobox'lardan aldık
            //string model = cboxModel.SelectedItem.ToString();
            string memory = (cboxHMemory.SelectedItem.ToString());
            string hdd = (cboxHHDD.SelectedItem.ToString());
            string ssd = (cboxHSSD.SelectedItem.ToString());
            string monitor = cboxHMonitor.SelectedItem.ToString();
            string color = cboxHColor.SelectedItem.ToString();

            // SQL sorgusu için parametreleri ayarlandı
            string query = "SELECT Model, Price FROM TBLDESKTOPS WHERE Memory = @Memory AND HDD = @HDD AND SSD = @SSD AND Monitor = @Monitor AND Color = @Color";

            SqlCommand command = new SqlCommand(query, connection);
            //command.Parameters.AddWithValue("@Model", model);
            command.Parameters.AddWithValue("@Memory", memory);
            command.Parameters.AddWithValue("@HDD", hdd);
            command.Parameters.AddWithValue("@SSD", ssd);
            command.Parameters.AddWithValue("@Monitor", monitor);
            command.Parameters.AddWithValue("@Color", color);

            // bağlantıyı açın ve fiyatları okuyun

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                textBoxHP.Text = reader["Price"].ToString();
            }
            connection.Close();

        }

        //*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-**-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-

        ///------LAPTOP-------/

        private void btonLAPTOP_Click(object sender, EventArgs e)
        {
            panelLaptop.Visible = true;
            panelLAACER.Visible = false;
            panelLACasper.Visible = false;
            panelLAMonster.Visible = false;

        }






        //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-**-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        //-------CASPER-------

        private void btonLAACER_Click(object sender, EventArgs e)
        {
            panelLAACER.Visible = true;
            panelLACasper.Visible = false;
            panelLAMonster.Visible = false;



            cboxLAMemory.Items.Clear();
            SqlCommand commandMemory = new SqlCommand("SELECT Memory FROM TBLLAPTOPS WHERE Model='ACER'", conn);

            SqlDataReader memory;

            conn.Open();
            memory = commandMemory.ExecuteReader();

            while (memory.Read())
            {
                cboxLAMemory.Items.Add(memory["Memory"]);

            }
            conn.Close();


            //----------------------------------------------------------------------

            cboxLAHDD.Items.Clear();
            SqlCommand commandHDD = new SqlCommand("SELECT HDD FROM TBLLAPTOPS WHERE Model ='ACER'", conn);
            SqlDataReader HDD;

            conn.Open();
            HDD = commandHDD.ExecuteReader();

            while (HDD.Read())
            {
                cboxLAHDD.Items.Add(HDD["HDD"]);

            }
            conn.Close();

            //    //----------------------------------------------------------------------

            cboxLASSD.Items.Clear();
            SqlCommand commandSSD = new SqlCommand("SELECT SSD FROM TBLLAPTOPS WHERE Model = 'ACER'", conn);
            SqlDataReader SSD;

            conn.Open();
            SSD = commandSSD.ExecuteReader();

            while (SSD.Read())
            {
                cboxLASSD.Items.Add(SSD["SSD"]);

            }
            conn.Close();
            //----------------------------------------------------------------------

            cboxLAScreenSize.Items.Clear();
            SqlCommand commandScreenSize = new SqlCommand("SELECT ScreenSize FROM TBLLAPTOPS WHERE Model = 'ACER'", conn);
            SqlDataReader ScreenSize;

            conn.Open();
            ScreenSize = commandScreenSize.ExecuteReader();

            while (ScreenSize.Read())
            {
                cboxLAScreenSize.Items.Add(ScreenSize["ScreenSize"]);

            }
            conn.Close();
            //----------------------------------------------------------------------

            cboxLAColor.Items.Clear();
            SqlCommand commandColor = new SqlCommand("SELECT Color FROM TBLLAPTOPS WHERE Model = 'ACER'", conn);
            SqlDataReader Color;

            conn.Open();
            Color = commandColor.ExecuteReader();

            while (Color.Read())
            {
                cboxLAColor.Items.Add(Color["Color"]);
            }
            conn.Close();
        }

        private void btonLAGetir_Click(object sender, EventArgs e)
        {
            // bağlantı cümlesini ayarlandı
            string connectionString = ("Data Source=.\\SQLEXPRESS;Initial Catalog=TEKNOLOGYDB;Integrated Security=True");

            SqlConnection connection = new SqlConnection(connectionString);

            // ürün özelliklerini combobox'lardan aldık
            //string model = cboxModel.SelectedItem.ToString();
            string memory = (cboxLAMemory.SelectedItem.ToString());
            string hdd = (cboxLAHDD.SelectedItem.ToString());
            string ssd = (cboxLASSD.SelectedItem.ToString());
            string ScreenSize = cboxLAScreenSize.SelectedItem.ToString();
            string color = cboxLAColor.SelectedItem.ToString();

            // SQL sorgusu için parametreleri ayarlandı
            string query = "SELECT Model, Price FROM TBLLAPTOPS WHERE Memory = @Memory AND HDD = @HDD AND SSD = @SSD AND ScreenSize = @ScreenSize AND Color = @Color";

            SqlCommand command = new SqlCommand(query, connection);
            //command.Parameters.AddWithValue("@Model", model);
            command.Parameters.AddWithValue("@Memory", memory);
            command.Parameters.AddWithValue("@HDD", hdd);
            command.Parameters.AddWithValue("@SSD", ssd);
            command.Parameters.AddWithValue("@ScreenSize", ScreenSize);
            command.Parameters.AddWithValue("@Color", color);

            // bağlantıyı açın ve fiyatları okuyun

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                textBoxLAPrice.Text = reader["Price"].ToString();
            }
            connection.Close();
        }
        private void btonCAGetir_Click(object sender, EventArgs e)
        {
            // bağlantı cümlesini ayarlandı
            string connectionString = ("Data Source=.\\SQLEXPRESS;Initial Catalog=TEKNOLOGYDB;Integrated Security=True");

            SqlConnection connection = new SqlConnection(connectionString);

            // ürün özelliklerini combobox'lardan aldık
            //string model = cboxModel.SelectedItem.ToString();
            string memory = (cboxCAMemory.SelectedItem.ToString());
            string hdd = (cboxCAHDD.SelectedItem.ToString());
            string ssd = (cboxCASSD.SelectedItem.ToString());
            string ScreenSize = cboxCAScreenSize.SelectedItem.ToString();
            string color = cboxCAColor.SelectedItem.ToString();

            // SQL sorgusu için parametreleri ayarlandı
            string query = "SELECT Model, Price FROM TBLLAPTOPS WHERE Memory = @Memory AND HDD = @HDD AND SSD = @SSD AND ScreenSize = @ScreenSize AND Color = @Color";

            SqlCommand command = new SqlCommand(query, connection);
            //command.Parameters.AddWithValue("@Model", model);
            command.Parameters.AddWithValue("@Memory", memory);
            command.Parameters.AddWithValue("@HDD", hdd);
            command.Parameters.AddWithValue("@SSD", ssd);
            command.Parameters.AddWithValue("@ScreenSize", ScreenSize);
            command.Parameters.AddWithValue("@Color", color);

            // bağlantıyı açın ve fiyatları okuyun

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                textBoxCAPrice.Text = reader["Price"].ToString();
            }
            connection.Close();
        }



        //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-**-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        //-------MONSTER-------

        private void btonCACASPER_Click(object sender, EventArgs e)
        {
            panelLAACER.Visible = false;
            panelLACasper.Visible = true;
            panelLAMonster.Visible = false;

            cboxCAMemory.Items.Clear();
            SqlCommand commandMemory = new SqlCommand("SELECT Memory FROM TBLLAPTOPS WHERE Model='CASPER'", conn);

            SqlDataReader memory;

            conn.Open();
            memory = commandMemory.ExecuteReader();

            while (memory.Read())
            {
                cboxCAMemory.Items.Add(memory["Memory"]);

            }
            conn.Close();


            //----------------------------------------------------------------------

            cboxCAHDD.Items.Clear();
            SqlCommand commandHDD = new SqlCommand("SELECT HDD FROM TBLLAPTOPS WHERE Model ='CASPER'", conn);
            SqlDataReader HDD;

            conn.Open();
            HDD = commandHDD.ExecuteReader();

            while (HDD.Read())
            {
                cboxCAHDD.Items.Add(HDD["HDD"]);

            }
            conn.Close();

            //    //----------------------------------------------------------------------

            cboxCASSD.Items.Clear();
            SqlCommand commandSSD = new SqlCommand("SELECT SSD FROM TBLLAPTOPS WHERE Model = 'CASPER'", conn);
            SqlDataReader SSD;

            conn.Open();
            SSD = commandSSD.ExecuteReader();

            while (SSD.Read())
            {
                cboxCASSD.Items.Add(SSD["SSD"]);

            }
            conn.Close();
            //----------------------------------------------------------------------

            cboxCAScreenSize.Items.Clear();
            SqlCommand commandScreenSize = new SqlCommand("SELECT ScreenSize FROM TBLLAPTOPS WHERE Model = 'CASPER'", conn);
            SqlDataReader ScreenSize;

            conn.Open();
            ScreenSize = commandScreenSize.ExecuteReader();

            while (ScreenSize.Read())
            {
                cboxCAScreenSize.Items.Add(ScreenSize["ScreenSize"]);

            }
            conn.Close();
            //----------------------------------------------------------------------

            cboxCAColor.Items.Clear();
            SqlCommand commandColor = new SqlCommand("SELECT Color FROM TBLLAPTOPS WHERE Model = 'CASPER'", conn);
            SqlDataReader Color;

            conn.Open();
            Color = commandColor.ExecuteReader();

            while (Color.Read())
            {
                cboxCAColor.Items.Add(Color["Color"]);
            }
            conn.Close();

        }

        private void btonCAMonster_Click(object sender, EventArgs e)
        {

            panelLAACER.Visible = false;
            panelLAMonster.Visible = true;
            panelLACasper.Visible = false;

            cboxMOMemory.Items.Clear();
            SqlCommand commandMemory = new SqlCommand("SELECT Memory FROM TBLLAPTOPS WHERE Model='MONSTER'", conn);

            SqlDataReader memory;

            conn.Open();
            memory = commandMemory.ExecuteReader();

            while (memory.Read())
            {
                cboxMOMemory.Items.Add(memory["Memory"]);

            }
            conn.Close();


            //----------------------------------------------------------------------

            cboxMOHDD.Items.Clear();
            SqlCommand commandHDD = new SqlCommand("SELECT HDD FROM TBLLAPTOPS WHERE Model ='MONSTER'", conn);
            SqlDataReader HDD;

            conn.Open();
            HDD = commandHDD.ExecuteReader();

            while (HDD.Read())
            {
                cboxMOHDD.Items.Add(HDD["HDD"]);

            }
            conn.Close();

            //    //----------------------------------------------------------------------

            cboxMOSSD.Items.Clear();
            SqlCommand commandSSD = new SqlCommand("SELECT SSD FROM TBLLAPTOPS WHERE Model = 'MONSTER'", conn);
            SqlDataReader SSD;

            conn.Open();
            SSD = commandSSD.ExecuteReader();

            while (SSD.Read())
            {
                cboxMOSSD.Items.Add(SSD["SSD"]);

            }
            conn.Close();
            //----------------------------------------------------------------------

            cboxMOScreenSize.Items.Clear();
            SqlCommand commandScreenSize = new SqlCommand("SELECT ScreenSize FROM TBLLAPTOPS WHERE Model = 'MONSTER'", conn);
            SqlDataReader ScreenSize;

            conn.Open();
            ScreenSize = commandScreenSize.ExecuteReader();

            while (ScreenSize.Read())
            {
                cboxMOScreenSize.Items.Add(ScreenSize["ScreenSize"]);

            }
            conn.Close();
            //----------------------------------------------------------------------

            cboxMOColor.Items.Clear();
            SqlCommand commandColor = new SqlCommand("SELECT Color FROM TBLLAPTOPS WHERE Model = 'MONSTER'", conn);
            SqlDataReader Color;

            conn.Open();
            Color = commandColor.ExecuteReader();

            while (Color.Read())
            {
                cboxMOColor.Items.Add(Color["Color"]);
            }
            conn.Close();

        }

        private void btonMOGetir_Click(object sender, EventArgs e)
        {
            // bağlantı cümlesini ayarlandı
            string connectionString = ("Data Source=.\\SQLEXPRESS;Initial Catalog=TEKNOLOGYDB;Integrated Security=True");

            SqlConnection connection = new SqlConnection(connectionString);

            // ürün özelliklerini combobox'lardan aldık
            //string model = cboxModel.SelectedItem.ToString();
            string memory = (cboxMOMemory.SelectedItem.ToString());
            string hdd = (cboxMOHDD.SelectedItem.ToString());
            string ssd = (cboxMOSSD.SelectedItem.ToString());
            string ScreenSize = cboxMOScreenSize.SelectedItem.ToString();
            string color = cboxMOColor.SelectedItem.ToString();

            // SQL sorgusu için parametreleri ayarlandı
            string query = "SELECT Model, Price FROM TBLLAPTOPS WHERE Memory = @Memory AND HDD = @HDD AND SSD = @SSD AND ScreenSize = @ScreenSize AND Color = @Color";

            SqlCommand command = new SqlCommand(query, connection);
            //command.Parameters.AddWithValue("@Model", model);
            command.Parameters.AddWithValue("@Memory", memory);
            command.Parameters.AddWithValue("@HDD", hdd);
            command.Parameters.AddWithValue("@SSD", ssd);
            command.Parameters.AddWithValue("@ScreenSize", ScreenSize);
            command.Parameters.AddWithValue("@Color", color);

            // bağlantıyı açın ve fiyatları okuyun

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                textBoxMOPrice.Text = reader["Price"].ToString();
            }
            connection.Close();
        }


        //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-**-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        //-------TABLETS ACER-------



        private void btonTABLET_Click(object sender, EventArgs e)
        {
            panelLaptop.Visible = false;
            panelLAACER.Visible = false;
            panelLACasper.Visible = false;
            panelLAMonster.Visible = false;
            panelTablet.Visible = true;
            panelTACASPER.Visible = false;
            panelTAMONSTER.Visible = false;
            panelTAACER.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
            panelTAACER.Visible = true;
            panelTACASPER.Visible = false;
            panelTAMONSTER.Visible = false;



            cboxTAMemory.Items.Clear();
            SqlCommand commandMemory = new SqlCommand("SELECT Memory FROM TBLLAPTOPS WHERE Model='ACER'", conn);

            SqlDataReader memory;

            conn.Open();
            memory = commandMemory.ExecuteReader();

            while (memory.Read())
            {
                cboxTAMemory.Items.Add(memory["Memory"]);

            }
            conn.Close();


            //----------------------------------------------------------------------

            cboxTAHDD.Items.Clear();
            SqlCommand commandHDD = new SqlCommand("SELECT HDD FROM TBLLAPTOPS WHERE Model ='ACER'", conn);
            SqlDataReader HDD;

            conn.Open();
            HDD = commandHDD.ExecuteReader();

            while (HDD.Read())
            {
                cboxTAHDD.Items.Add(HDD["HDD"]);

            }
            conn.Close();

            //    //----------------------------------------------------------------------

            cboxTASSD.Items.Clear();
            SqlCommand commandSSD = new SqlCommand("SELECT SSD FROM TBLLAPTOPS WHERE Model = 'ACER'", conn);
            SqlDataReader SSD;

            conn.Open();
            SSD = commandSSD.ExecuteReader();

            while (SSD.Read())
            {
                cboxTASSD.Items.Add(SSD["SSD"]);

            }
            conn.Close();
            //----------------------------------------------------------------------

            cboxTAScreenSize.Items.Clear();
            SqlCommand commandScreenSize = new SqlCommand("SELECT ScreenSize FROM TBLLAPTOPS WHERE Model = 'ACER'", conn);
            SqlDataReader ScreenSize;

            conn.Open();
            ScreenSize = commandScreenSize.ExecuteReader();

            while (ScreenSize.Read())
            {
                cboxTAScreenSize.Items.Add(ScreenSize["ScreenSize"]);

            }
            conn.Close();
            //----------------------------------------------------------------------

            cboxTAColor.Items.Clear();
            SqlCommand commandColor = new SqlCommand("SELECT Color FROM TBLLAPTOPS WHERE Model = 'ACER'", conn);
            SqlDataReader Color;

            conn.Open();
            Color = commandColor.ExecuteReader();

            while (Color.Read())
            {
                cboxTAColor.Items.Add(Color["Color"]);
            }
            conn.Close();

        }

        private void btonMONGE_Click(object sender, EventArgs e)
        {
            // bağlantı cümlesini ayarlandı
            string connectionString = ("Data Source=.\\SQLEXPRESS;Initial Catalog=TEKNOLOGYDB;Integrated Security=True");

            SqlConnection connection = new SqlConnection(connectionString);

            // ürün özelliklerini combobox'lardan aldık
            //string model = cboxModel.SelectedItem.ToString();
            string memory = (cboxTAMemory.SelectedItem.ToString());
            string hdd = (cboxTAHDD.SelectedItem.ToString());
            string ssd = (cboxTASSD.SelectedItem.ToString());
            string ScreenSize = cboxTAScreenSize.SelectedItem.ToString();
            string color = cboxTAColor.SelectedItem.ToString();

            // SQL sorgusu için parametreleri ayarlandı
            string query = "SELECT Model, Price FROM TBLLAPTOPS WHERE Memory = @Memory AND HDD = @HDD AND SSD = @SSD AND ScreenSize = @ScreenSize AND Color = @Color";

            SqlCommand command = new SqlCommand(query, connection);
            //command.Parameters.AddWithValue("@Model", model);
            command.Parameters.AddWithValue("@Memory", memory);
            command.Parameters.AddWithValue("@HDD", hdd);
            command.Parameters.AddWithValue("@SSD", ssd);
            command.Parameters.AddWithValue("@ScreenSize", ScreenSize);
            command.Parameters.AddWithValue("@Color", color);

            // bağlantıyı açın ve fiyatları okuyun

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                textBoxTAPrice.Text = reader["Price"].ToString();
            }
            connection.Close();
        }





        //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-**-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        //-------CASPER-------


        private void button2_Click(object sender, EventArgs e)
        {
            panelTAACER.Visible = false;
            panelTACASPER.Visible = true;
            panelTAMONSTER.Visible = false;



            cboxCASMemory.Items.Clear();
            SqlCommand commandMemory = new SqlCommand("SELECT Memory FROM TBLLAPTOPS WHERE Model='CASPER'", conn);

            SqlDataReader memory;

            conn.Open();
            memory = commandMemory.ExecuteReader();

            while (memory.Read())
            {
                cboxCASMemory.Items.Add(memory["Memory"]);

            }
            conn.Close();


            //----------------------------------------------------------------------

            cboxCASHDD.Items.Clear();
            SqlCommand commandHDD = new SqlCommand("SELECT HDD FROM TBLLAPTOPS WHERE Model ='CASPER'", conn);
            SqlDataReader HDD;

            conn.Open();
            HDD = commandHDD.ExecuteReader();

            while (HDD.Read())
            {
                cboxCASHDD.Items.Add(HDD["HDD"]);

            }
            conn.Close();

            //    //----------------------------------------------------------------------

            cboxCASSSD.Items.Clear();
            SqlCommand commandSSD = new SqlCommand("SELECT SSD FROM TBLLAPTOPS WHERE Model = 'CASPER'", conn);
            SqlDataReader SSD;

            conn.Open();
            SSD = commandSSD.ExecuteReader();

            while (SSD.Read())
            {
                cboxCASSSD.Items.Add(SSD["SSD"]);

            }
            conn.Close();
            //----------------------------------------------------------------------

            cboxCASScreenSize.Items.Clear();
            SqlCommand commandScreenSize = new SqlCommand("SELECT ScreenSize FROM TBLLAPTOPS WHERE Model = 'CASPER'", conn);
            SqlDataReader ScreenSize;

            conn.Open();
            ScreenSize = commandScreenSize.ExecuteReader();

            while (ScreenSize.Read())
            {
                cboxCASScreenSize.Items.Add(ScreenSize["ScreenSize"]);

            }
            conn.Close();
            //----------------------------------------------------------------------

            cboxCASColor.Items.Clear();
            SqlCommand commandColor = new SqlCommand("SELECT Color FROM TBLLAPTOPS WHERE Model = 'CASPER'", conn);
            SqlDataReader Color;

            conn.Open();
            Color = commandColor.ExecuteReader();

            while (Color.Read())
            {
                cboxCASColor.Items.Add(Color["Color"]);
            }
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // bağlantı cümlesini ayarlandı
            string connectionString = ("Data Source=.\\SQLEXPRESS;Initial Catalog=TEKNOLOGYDB;Integrated Security=True");

            SqlConnection connection = new SqlConnection(connectionString);

            // ürün özelliklerini combobox'lardan aldık
            //string model = cboxModel.SelectedItem.ToString();
            string memory = (cboxCASMemory.SelectedItem.ToString());
            string hdd = (cboxCASHDD.SelectedItem.ToString());
            string ssd = (cboxCASSSD.SelectedItem.ToString());
            string ScreenSize = cboxCASScreenSize.SelectedItem.ToString();
            string color = cboxCASColor.SelectedItem.ToString();

            // SQL sorgusu için parametreleri ayarlandı
            string query = "SELECT Model, Price FROM TBLLAPTOPS WHERE Memory = @Memory AND HDD = @HDD AND SSD = @SSD AND ScreenSize = @ScreenSize AND Color = @Color";

            SqlCommand command = new SqlCommand(query, connection);
            //command.Parameters.AddWithValue("@Model", model);
            command.Parameters.AddWithValue("@Memory", memory);
            command.Parameters.AddWithValue("@HDD", hdd);
            command.Parameters.AddWithValue("@SSD", ssd);
            command.Parameters.AddWithValue("@ScreenSize", ScreenSize);
            command.Parameters.AddWithValue("@Color", color);

            // bağlantıyı açın ve fiyatları okuyun

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                textBoxCASPrice.Text = reader["Price"].ToString();
            }
            connection.Close();
        }




        //-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-**-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
        //-------MONSTER-------
        private void button3_Click(object sender, EventArgs e)
        {
            panelTAACER.Visible = false;
            panelTACASPER.Visible = false;
            panelTAMONSTER.Visible = true;

            cboxMONMemory.Items.Clear();
            SqlCommand commandMemory = new SqlCommand("SELECT Memory FROM TBLLAPTOPS WHERE Model='CASPER'", conn);

            SqlDataReader memory;

            conn.Open();
            memory = commandMemory.ExecuteReader();

            while (memory.Read())
            {
                cboxMONMemory.Items.Add(memory["Memory"]);

            }
            conn.Close();


            //----------------------------------------------------------------------

            cboxMONHDD.Items.Clear();
            SqlCommand commandHDD = new SqlCommand("SELECT HDD FROM TBLLAPTOPS WHERE Model ='CASPER'", conn);
            SqlDataReader HDD;

            conn.Open();
            HDD = commandHDD.ExecuteReader();

            while (HDD.Read())
            {
                cboxMONHDD.Items.Add(HDD["HDD"]);

            }
            conn.Close();

            //    //----------------------------------------------------------------------

            cboxMONSSD.Items.Clear();
            SqlCommand commandSSD = new SqlCommand("SELECT SSD FROM TBLLAPTOPS WHERE Model = 'CASPER'", conn);
            SqlDataReader SSD;

            conn.Open();
            SSD = commandSSD.ExecuteReader();

            while (SSD.Read())
            {
                cboxMONSSD.Items.Add(SSD["SSD"]);

            }
            conn.Close();
            //----------------------------------------------------------------------

            cboxMONScreenSize.Items.Clear();
            SqlCommand commandScreenSize = new SqlCommand("SELECT ScreenSize FROM TBLLAPTOPS WHERE Model = 'CASPER'", conn);
            SqlDataReader ScreenSize;

            conn.Open();
            ScreenSize = commandScreenSize.ExecuteReader();

            while (ScreenSize.Read())
            {
                cboxMONScreenSize.Items.Add(ScreenSize["ScreenSize"]);

            }
            conn.Close();
            //----------------------------------------------------------------------

            cboxMONColor.Items.Clear();
            SqlCommand commandColor = new SqlCommand("SELECT Color FROM TBLLAPTOPS WHERE Model = 'CASPER'", conn);
            SqlDataReader Color;

            conn.Open();
            Color = commandColor.ExecuteReader();

            while (Color.Read())
            {
                cboxMONColor.Items.Add(Color["Color"]);
            }
            conn.Close();
        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            // bağlantı cümlesini ayarlandı
            string connectionString = ("Data Source=.\\SQLEXPRESS;Initial Catalog=TEKNOLOGYDB;Integrated Security=True");

            SqlConnection connection = new SqlConnection(connectionString);

            // ürün özelliklerini combobox'lardan aldık
            //string model = cboxModel.SelectedItem.ToString();
            string memory = (cboxMONMemory.SelectedItem.ToString());
            string hdd = (cboxMONHDD.SelectedItem.ToString());
            string ssd = (cboxMONSSD.SelectedItem.ToString());
            string ScreenSize = cboxMONScreenSize.SelectedItem.ToString();
            string color = cboxMONColor.SelectedItem.ToString();

            // SQL sorgusu için parametreleri ayarlandı
            string query = "SELECT Model, Price FROM TBLLAPTOPS WHERE Memory = @Memory AND HDD = @HDD AND SSD = @SSD AND ScreenSize = @ScreenSize AND Color = @Color";

            SqlCommand command = new SqlCommand(query, connection);
            //command.Parameters.AddWithValue("@Model", model);
            command.Parameters.AddWithValue("@Memory", memory);
            command.Parameters.AddWithValue("@HDD", hdd);
            command.Parameters.AddWithValue("@SSD", ssd);
            command.Parameters.AddWithValue("@ScreenSize", ScreenSize);
            command.Parameters.AddWithValue("@Color", color);

            // bağlantıyı açın ve fiyatları okuyun

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                textBoxMONPrice.Text = reader["Price"].ToString();
            }
            connection.Close();
        }
    }
}



      






