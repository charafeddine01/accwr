using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.SqlServer;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System.Collections;
using System.IO;
using System.Xml.Linq;
using System.Globalization;
//using 

namespace accwr2
{

    public partial class Form1 : Form
    {
        Boolean lockk = false;
        //DateTime dateTime1;
        //DateTime dateTime2;
        //string connectionString = ConfigurationManager.ConnectionStrings["accwr.Properties.Settings.accwrConnectionString"].ConnectionString;
        //string connectionString = "root@localhost:3306"; //"Data Source=ABBASPC\\SQLEXPRESS;Initial Catalog=accwr;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        //string connectionString = "Data Source=ABBASPC\\SQLEXPRESS;Initial Catalog=accwr;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;";
        
        string connectionString = "Server=localhost;Database=Finance;User ID=root;Password=root;";
        // Properties.Settings.Default.accwrConnectionString
        //new SqlConnection("Data Source=IT-2;Initial Catalog=accwr;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }




        private void refresh()
        {

            //Connection c = new Connection;
            //dataGridView1.DataSource = new DataGrid();
            //string con = Properties.Settings.Default.connectionString;
            string query;
            query = "select * from data_tbl";
            SqlConnection conn = new SqlConnection(connectionString);
            //using (SqlConnection conn = new SqlConnection(connectionString));

            SqlDataAdapter sda = new SqlDataAdapter(query, conn);

            DataTable datatable = new DataTable();

            try
            {
                conn.Open();
                sda.Fill(datatable);
            //    dataGridView1.DataSource = datatable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            /*
            sql = "select * from accwr where 1";
            SqlConnection conn = new SqlConnection(connectionString);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(dataAdapter);

            dataGridView1.DataSource = dataAdapter;
            dataGridView1.fill;

            
            DataTable table = new DataTable();
            //table.Columns.Add()
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            table.Columns.Add("id"); ;
            dataAdapter.Fill(table);
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = table;

            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = bindingSource1;
            */
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadIP(GetIp());
            
            this.WindowState = FormWindowState.Maximized;
            dateFromdateTimePicker.Value = (DateTime)GetLastDate(connectionString);
            //dateFromdateTimePicker.Value = DateTime.Now;
            //refresh();
            //weeknumericUpDown.Controls[0].Visible = false;
        }
        private void loadIP(string s)
        {
        connectionString = "Server="+s+";Database=Finance;User ID=root;Password=root;";
        }

        public static DateTime? GetLastDate(string connectionString)
        {
            DateTime? lastDate = null;

            // Query to get the maximum date
            string query = "SELECT MAX(dateOfWeek) AS LastDate FROM alldata";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != DBNull.Value && result != null)
                        {
                            lastDate = Convert.ToDateTime(result);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
            }

            return lastDate;
        }


        private void tabPage2_Click_1(object sender, EventArgs e)
        {
            //crRiayitextBox.Controls.RemoveAt(0);
            //crWizaratextBox.Controls.RemoveAt(0);
            //crDamantextBox.Controls.RemoveAt(0);
            //crKafalattextBox.Controls.RemoveAt(0);
            //crOthertextBox.Controls.RemoveAt(0);
            //debDoctorstextBox.Controls.RemoveAt(0);
            //debCentraltextBox.Controls.RemoveAt(0);
            //depSuptextBox.Controls.RemoveAt(0);
            //debOthertextBox.Controls.RemoveAt(0);
        }

        //private void crRiayitextBox_ValueChanged(object sender, EventArgs e)
        //{
        //    refresh_values(crRiayitextBox);
        //}

        //private void crWizaratextBox_ValueChanged(object sender, EventArgs e)
        //{
        //    refresh_values(crWizaratextBox);
        //}

        //private void crDamantextBox55_ValueChanged(object sender, EventArgs e)
        //{
        //    refresh_values(crDamantextBox);
        //}

        //private void crKafalattextBox56_ValueChanged(object sender, EventArgs e)
        //{
        //    refresh_values(crKafalattextBox);
        //}

        //private void crOthertextBox57_ValueChanged(object sender, EventArgs e)
        //{
        //    refresh_values(crOthertextBox);
        //}

        //private void debDoctorstextBox53_ValueChanged(object sender, EventArgs e)
        //{
        //    refresh_values(debDoctorstextBox);
        //}

        //private void debCentraltextBox49_ValueChanged(object sender, EventArgs e)
        //{
        //    refresh_values(debCentraltextBox);
        //}

        //private void depSuptextBox50_ValueChanged(object sender, EventArgs e)
        //{
        //    refresh_values(depSuptextBox);
        //}

        //private void debOthertextBox51_ValueChanged(object sender, EventArgs e)
        //{
        //    refresh_values(debOthertextBox);
        //}

        private void dateTodateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            //DateTime date;
            //date.Year = dateTodateTimePicker3.Value.Year;
            //daystextBox.Text = dateTodateTimePicker.Value.DayOfYear.ToString();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            //tab2
            insertquery();

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }
        //refresh();
        //}

        private void button5_Click(object sender, EventArgs e)
        {
            
            if (weeknumericUpDown.Value==0)
            //if (isFirstWeek(dateFromdateTimePicker.Value) && dateFromdateTimePicker.Value.DayOfWeek!=DayOfWeek.Monday)
                    dateFromdateTimePicker.Value = GetLastMonday(dateFromdateTimePicker.Value);
            else
                dateFromdateTimePicker.Value = dateFromdateTimePicker.Value.AddDays(-7);
                //if (weeknumericUpDown.Value > 0)
                //{
                //    button5.Enabled = false;
                //    //System.Threading.Thread.Sleep(1000); // Waits for 1 second
                //    try
                //    {
                //        weeknumericUpDown.Value -= 1;
                //    }
                //    catch (MySqlException ex)
                //    {
                //        MessageBox.Show($"Error: {ex.Message}");
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show($"Unexpected error: {ex.Message}");
                //    }
                //    finally
                //    {
                //        button5.Enabled = true;
                //    }
                //}
            }
        public static bool ValidateControls(Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control is TextBox textBox)
                {
                    // Check if the TextBox is empty
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        MessageBox.Show($"Control '{textBox.Name}' is empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    // Check if the TextBox contains a non-numeric value
                    if (!double.TryParse(textBox.Text, out _))
                    {
                        MessageBox.Show($"Control '{textBox.Name}' does not contain a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                // Recursively check child controls (e.g., controls inside a Panel or GroupBox)
                if (control.HasChildren)
                {
                    ValidateControls(control);
                }
            }

            //MessageBox.Show("All controls are valid.", "Validation Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private void insertquery()
        {
            if (!ValidateControls(tabPage2)) { return; }
            String query =
    "INSERT INTO alldata(" +
    "    `week`," +
    "    `dateOfWeek`," +
    "    `متوسط الايراد اليومي`," +
    "    `متوسط المصروف اليومي`," +
    "    `مجموع الايرادات`," +
    "    `مجموع الاعباء`," +
    "    `متوسط النتيجة`," +
    "    `متوسط الاستهلاك`," +
    "    `متوسط مؤونات الديون`," +
    "    `ديون لنا رعاية`," +
    "    `ديون لنا وزارة`," +
    "    `ديون لنا ضمان`," +
    "    `ديون لنا كفالات`," +
    "    `ديون لنا جهات اخرى`," +
    "    `ديون علينا اتعاب اطباء`," +
    "    `ديون علينا مركزية`," +
    "    `ديون علينا موردون`," +
    "    `ديون علينا جهات اخرى`," +
    "    `النقدية صندوق`," +
    "    `النقدية صندوق احتياطي`," +
    "    `النقدية صادرات`," +
    "    `النقدية صادرات ضمان`," +
    "    `النقدية قرض حسن`," +
    "    `النقدية قرض حسن رواتب واتعاب اطباء`," +
    "    `عدد المرضى خلال الاسبوع داخلي`," +
    "    `عدد المرضى خلال الاسبوع خارجي`," +
    "    `عدد المرضى  الى تاريخه داخلي`," +
    "    `عدد المرضى  الى تاريخه خارجي`," +
    "    `مجموع الايرادات الاسبوعية`," +
    "    `مجموع الاعباء الاسبوعية`" +
    //") VALUES(" +
    ") VALUES (" +
    "    @week, " +
    "    @dateOfWeek, " +
    "    @متوسط_الايراد_اليومي, " +
    "    @متوسط_المصروف_اليومي, " +
    "    @مجموع_الايرادات, " +
    "    @مجموع_الاعباء, " +
    "    @متوسط_النتيجة, " +
    "    @متوسط_الاستهلاك, " +
    "    @متوسط_مؤونات_الديون, " +
    "    @ديون_لنا_رعاية, " +
    "    @ديون_لنا_وزارة, " +
    "    @ديون_لنا_ضمان, " +
    "    @ديون_لنا_كفالات, " +
    "    @ديون_لنا_جهات_اخرى, " +
    "    @ديون_علينا_اتعاب_اطباء, " +
    "    @ديون_علينا_مركزية, " +
    "    @ديون_علينا_موردون, " +
    "    @ديون_علينا_جهات_اخرى, " +
    "    @النقدية_صندوق, " +
    "    @النقدية_صندوق_احتياطي, " +
    "    @النقدية_صادرات, " +
    "    @النقدية_صادرات_ضمان, " +
    "    @النقدية_قرض_حسن, " +
    "    @النقدية_قرض_حسن_رواتب_واتعاب_اطباء, " +
    "    @عدد_المرضى_خلال_الاسبوع_داخلي, " +
    "    @عدد_المرضى_خلال_الاسبوع_خارجي, " +
    "    @عدد_المرضى_الى_تاريخه_داخلي, " +
    "    @عدد_المرضى_الى_تاريخه_خارجي, " +
    "    @مجموع_الايرادات_الاسبوعية, " +
    "    @مجموع_الاعباء_الاسبوعية" +
    ");";

            decimal week = weeknumericUpDown.Value;
            DateTime dateTime = dateFromdateTimePicker.Value;
            decimal متوسط_الايراد_اليومي = Convert.ToInt64(dailyIradAvgtextBox.Text);
            decimal متوسط_المصروف_اليومي = Convert.ToInt64(dailyMasrofAvgtextBox.Text);
            decimal مجموع_الايرادات = Convert.ToInt64(dailyIradTottextBox.Text);
            decimal مجموع_الاعباء = Convert.ToInt64(dailyMasroufTottextBox.Text);
            decimal متوسط_النتيجة = Convert.ToInt64(resultAvgtextBox.Text);
            decimal متوسط_الاستهلاك = Convert.ToInt64(istihlakAvgtextBox.Text);
            decimal متوسط_مؤونات_الديون = Convert.ToInt64(maonatDebtAvgtextBox.Text);
            decimal ديون_لنا_رعاية = Convert.ToInt64(crRiayitextBox.Text);
            decimal ديون_لنا_وزارة = Convert.ToInt64(crWizaratextBox.Text);
            decimal ديون_لنا_ضمان = Convert.ToInt64(crDamantextBox.Text);
            decimal ديون_لنا_كفالات = Convert.ToInt64(crKafalattextBox.Text);
            decimal ديون_لنا_جهات_اخرى = Convert.ToInt64(crOthertextBox.Text);
            decimal ديون_علينا_اتعاب_اطباء = Convert.ToInt64(debDoctorstextBox.Text);
            decimal ديون_علينا_مركزية = Convert.ToInt64(debCentraltextBox.Text);
            decimal ديون_علينا_موردون = Convert.ToInt64(depSuptextBox.Text);
            decimal ديون_علينا_جهات_اخرى = Convert.ToInt64(debOthertextBox.Text);
            decimal النقدية_صندوق = Convert.ToInt64(cashCurrenttextBox.Text);
            decimal النقدية_صندوق_احتياطي = Convert.ToInt64(altCashCurrenttextBox.Text);
            decimal النقدية_صادرات = Convert.ToInt64(saderatCurrenttextBox.Text); ;
            decimal النقدية_صادرات_ضمان = Convert.ToInt64(saderatDamanrCurrenttextBox.Text); ;
            decimal النقدية_قرض_حسن = Convert.ToInt64(qardHasanCurrenttextBox.Text); ;
            decimal النقدية_قرض_حسن_رواتب_واتعاب_اطباء = Convert.ToInt64(qardHasanRawatebtextBox.Text); ;
            long عدد_المرضى_خلال_الاسبوع_داخلي = Convert.ToInt64(patientWeeklyIntextBox.Text); ;
            long عدد_المرضى_خلال_الاسبوع_خارجي = Convert.ToInt64(patientWeeklyOuttextBox.Text); ;
            long عدد_المرضى_الى_تاريخه_داخلي = Convert.ToInt64(cumuPatientIntextBox.Text); ;
            long عدد_المرضى_الى_تاريخه_خارجي = Convert.ToInt64(cumuPatientOuttextBox.Text); ;
            decimal مجموع_الايرادات_الاسبوعية = Convert.ToInt64(iradatWeeklyTottextBox.Text); ;
            decimal مجموع_الاعباء_الاسبوعية = Convert.ToInt64(a3ba2WeeklyTottextBox.Text); ;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@week", week);
                        command.Parameters.AddWithValue("@dateOfWeek", dateTime);
                        command.Parameters.AddWithValue("@متوسط_الايراد_اليومي", متوسط_الايراد_اليومي);
                        command.Parameters.AddWithValue("@متوسط_المصروف_اليومي", متوسط_المصروف_اليومي);
                        command.Parameters.AddWithValue("@مجموع_الايرادات", مجموع_الايرادات);
                        command.Parameters.AddWithValue("@مجموع_الاعباء", مجموع_الاعباء);
                        command.Parameters.AddWithValue("@متوسط_النتيجة", متوسط_النتيجة);
                        command.Parameters.AddWithValue("@متوسط_الاستهلاك", متوسط_الاستهلاك);
                        command.Parameters.AddWithValue("@متوسط_مؤونات_الديون", متوسط_مؤونات_الديون);
                        command.Parameters.AddWithValue("@ديون_لنا_رعاية", ديون_لنا_رعاية);
                        command.Parameters.AddWithValue("@ديون_لنا_وزارة", ديون_لنا_وزارة);
                        command.Parameters.AddWithValue("@ديون_لنا_ضمان", ديون_لنا_ضمان);
                        command.Parameters.AddWithValue("@ديون_لنا_كفالات", ديون_لنا_كفالات);
                        command.Parameters.AddWithValue("@ديون_لنا_جهات_اخرى", ديون_لنا_جهات_اخرى);
                        command.Parameters.AddWithValue("@ديون_علينا_اتعاب_اطباء", ديون_علينا_اتعاب_اطباء);
                        command.Parameters.AddWithValue("@ديون_علينا_مركزية", ديون_علينا_مركزية);
                        command.Parameters.AddWithValue("@ديون_علينا_موردون", ديون_علينا_موردون);
                        command.Parameters.AddWithValue("@ديون_علينا_جهات_اخرى", ديون_علينا_جهات_اخرى);
                        command.Parameters.AddWithValue("@النقدية_صندوق", النقدية_صندوق);
                        command.Parameters.AddWithValue("@النقدية_صندوق_احتياطي", النقدية_صندوق_احتياطي);
                        command.Parameters.AddWithValue("@النقدية_صادرات", النقدية_صادرات);
                        command.Parameters.AddWithValue("@النقدية_صادرات_ضمان", النقدية_صادرات_ضمان);
                        command.Parameters.AddWithValue("@النقدية_قرض_حسن", النقدية_قرض_حسن);
                        command.Parameters.AddWithValue("@النقدية_قرض_حسن_رواتب_واتعاب_اطباء", النقدية_قرض_حسن_رواتب_واتعاب_اطباء);
                        command.Parameters.AddWithValue("@عدد_المرضى_خلال_الاسبوع_داخلي", عدد_المرضى_خلال_الاسبوع_داخلي);
                        command.Parameters.AddWithValue("@عدد_المرضى_خلال_الاسبوع_خارجي", عدد_المرضى_خلال_الاسبوع_خارجي);
                        command.Parameters.AddWithValue("@عدد_المرضى_الى_تاريخه_داخلي", عدد_المرضى_الى_تاريخه_داخلي);
                        command.Parameters.AddWithValue("@عدد_المرضى_الى_تاريخه_خارجي", عدد_المرضى_الى_تاريخه_خارجي);
                        command.Parameters.AddWithValue("@مجموع_الايرادات_الاسبوعية", مجموع_الايرادات_الاسبوعية);
                        command.Parameters.AddWithValue("@مجموع_الاعباء_الاسبوعية", مجموع_الاعباء_الاسبوعية);

                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show($"{rowsAffected} row(s) inserted successfully.");
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"MySQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected Error: {ex.Message}");
            }
        }
        private void LoadDataByWeek()
        {
            string query = @"
        SELECT 
            `week`, `dateOfWeek`, `متوسط الايراد اليومي`, `متوسط المصروف اليومي`, 
            `مجموع الايرادات`, `مجموع الاعباء`, `متوسط النتيجة`, `متوسط الاستهلاك`, 
            `متوسط مؤونات الديون`, `ديون لنا رعاية`, `ديون لنا وزارة`, `ديون لنا ضمان`, 
            `ديون لنا كفالات`, `ديون لنا جهات اخرى`, `ديون علينا اتعاب اطباء`, 
            `ديون علينا مركزية`, `ديون علينا موردون`, `ديون علينا جهات اخرى`, 
            `النقدية صندوق`, `النقدية صندوق احتياطي`, `النقدية صادرات`, 
            `النقدية صادرات ضمان`, `النقدية قرض حسن`, 
            `النقدية قرض حسن رواتب واتعاب اطباء`, `عدد المرضى خلال الاسبوع داخلي`, 
            `عدد المرضى خلال الاسبوع خارجي`, `عدد المرضى  الى تاريخه داخلي`, 
            `عدد المرضى  الى تاريخه خارجي`, `مجموع الايرادات الاسبوعية`, 
            `مجموع الاعباء الاسبوعية`
        FROM alldata
        WHERE `dateOfWeek` = @dateOfWeek
        ORDER BY id DESC
        LIMIT 1;"; // Assuming `id` is the primary key that auto-increments.

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Add the parameter for the week value
                        command.Parameters.AddWithValue("@dateOfWeek", dateFromdateTimePicker.Value);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Assign values to controls
                                weeknumericUpDown.Value = reader.GetDecimal("week");
                                dateFromdateTimePicker.Value = reader.GetDateTime("dateOfWeek");
                                dailyIradAvgtextBox.Text = reader.GetDecimal("متوسط الايراد اليومي").ToString();
                                dailyMasrofAvgtextBox.Text = reader.GetDecimal("متوسط المصروف اليومي").ToString();
                                dailyIradTottextBox.Text = reader.GetDecimal("مجموع الايرادات").ToString();
                                dailyMasroufTottextBox.Text = reader.GetDecimal("مجموع الاعباء").ToString();
                                resultAvgtextBox.Text = reader.GetDecimal("متوسط النتيجة").ToString();
                                istihlakAvgtextBox.Text = reader.GetDecimal("متوسط الاستهلاك").ToString();
                                maonatDebtAvgtextBox.Text = reader.GetDecimal("متوسط مؤونات الديون").ToString();
                                crRiayitextBox.Text = reader.GetDecimal("ديون لنا رعاية").ToString();
                                crWizaratextBox.Text = reader.GetDecimal("ديون لنا وزارة").ToString();
                                crDamantextBox.Text = reader.GetDecimal("ديون لنا ضمان").ToString();
                                crKafalattextBox.Text = reader.GetDecimal("ديون لنا كفالات").ToString();
                                crOthertextBox.Text = reader.GetDecimal("ديون لنا جهات اخرى").ToString();
                                debDoctorstextBox.Text = reader.GetDecimal("ديون علينا اتعاب اطباء").ToString();
                                debCentraltextBox.Text = reader.GetDecimal("ديون علينا مركزية").ToString();
                                depSuptextBox.Text = reader.GetDecimal("ديون علينا موردون").ToString();
                                debOthertextBox.Text = reader.GetDecimal("ديون علينا جهات اخرى").ToString();
                                cashCurrenttextBox.Text = reader.GetDecimal("النقدية صندوق").ToString();
                                altCashCurrenttextBox.Text = reader.GetDecimal("النقدية صندوق احتياطي").ToString();
                                saderatCurrenttextBox.Text = reader.GetDecimal("النقدية صادرات").ToString();
                                saderatDamanrCurrenttextBox.Text = reader.GetDecimal("النقدية صادرات ضمان").ToString();
                                qardHasanCurrenttextBox.Text = reader.GetDecimal("النقدية قرض حسن").ToString();
                                qardHasanRawatebtextBox.Text = reader.GetDecimal("النقدية قرض حسن رواتب واتعاب اطباء").ToString();
                                patientWeeklyIntextBox.Text = reader.GetInt32("عدد المرضى خلال الاسبوع داخلي").ToString();
                                patientWeeklyOuttextBox.Text = reader.GetInt32("عدد المرضى خلال الاسبوع خارجي").ToString();
                                cumuPatientIntextBox.Text = reader.GetInt32("عدد المرضى  الى تاريخه داخلي").ToString();
                                cumuPatientOuttextBox.Text = reader.GetInt32("عدد المرضى  الى تاريخه خارجي").ToString();
                                iradatWeeklyTottextBox.Text = reader.GetDecimal("مجموع الايرادات الاسبوعية").ToString();
                                a3ba2WeeklyTottextBox.Text = reader.GetDecimal("مجموع الاعباء الاسبوعية").ToString();
                            }
                            else
                            {
                                MessageBox.Show("No data found for the specified week.");
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"MySQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected Error: {ex.Message}");
            }
        }

        private void UpdateDataByWeek()
        {
            string query = @"
        UPDATE alldata
        SET 
            `dateOfWeek` = @dateOfWeek,
            `متوسط الايراد اليومي` = @dailyIradAvg,
            `متوسط المصروف اليومي` = @dailyMasrofAvg,
            `مجموع الايرادات` = @dailyIradTot,
            `مجموع الاعباء` = @dailyMasroufTot,
            `متوسط النتيجة` = @resultAvg,
            `متوسط الاستهلاك` = @istihlakAvg,
            `متوسط مؤونات الديون` = @maonatDebtAvg,
            `ديون لنا رعاية` = @crRiayih,
            `ديون لنا وزارة` = @crWizarah,
            `ديون لنا ضمان` = @crDaman,
            `ديون لنا كفالات` = @crKafalat,
            `ديون لنا جهات اخرى` = @crOther,
            `ديون علينا اتعاب اطباء` = @debDoctors,
            `ديون علينا مركزية` = @debCentral,
            `ديون علينا موردون` = @depSup,
            `ديون علينا جهات اخرى` = @debOther,
            `النقدية صندوق` = @cashCurrent,
            `النقدية صندوق احتياطي` = @altCashCurrent,
            `النقدية صادرات` = @saderatCurrent,
            `النقدية صادرات ضمان` = @saderatDaman,
            `النقدية قرض حسن` = @qardHasan,
            `النقدية قرض حسن رواتب واتعاب اطباء` = @qardHasanRawateb,
            `عدد المرضى خلال الاسبوع داخلي` = @patientWeeklyIn,
            `عدد المرضى خلال الاسبوع خارجي` = @patientWeeklyOut,
            `عدد المرضى  الى تاريخه داخلي` = @cumuPatientIn,
            `عدد المرضى  الى تاريخه خارجي` = @cumuPatientOut,
            `مجموع الايرادات الاسبوعية` = @iradatWeeklyTot,
            `مجموع الاعباء الاسبوعية` = @a3ba2WeeklyTot
        WHERE `dateOfWeek` = @dateOfWeek;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Add parameters
                        command.Parameters.AddWithValue("@week", weeknumericUpDown.Value);
                        command.Parameters.AddWithValue("@dateOfWeek", dateFromdateTimePicker.Value);
                        command.Parameters.AddWithValue("@dailyIradAvg", decimal.Parse(dailyIradAvgtextBox.Text));
                        command.Parameters.AddWithValue("@dailyMasrofAvg", decimal.Parse(dailyMasrofAvgtextBox.Text));
                        command.Parameters.AddWithValue("@dailyIradTot", decimal.Parse(dailyIradTottextBox.Text));
                        command.Parameters.AddWithValue("@dailyMasroufTot", decimal.Parse(dailyMasroufTottextBox.Text));
                        command.Parameters.AddWithValue("@resultAvg", decimal.Parse(resultAvgtextBox.Text));
                        command.Parameters.AddWithValue("@istihlakAvg", decimal.Parse(istihlakAvgtextBox.Text));
                        command.Parameters.AddWithValue("@maonatDebtAvg", decimal.Parse(maonatDebtAvgtextBox.Text));
                        command.Parameters.AddWithValue("@crRiayih", decimal.Parse(crRiayitextBox.Text));
                        command.Parameters.AddWithValue("@crWizarah", decimal.Parse(crWizaratextBox.Text));
                        command.Parameters.AddWithValue("@crDaman", decimal.Parse(crDamantextBox.Text));
                        command.Parameters.AddWithValue("@crKafalat", decimal.Parse(crKafalattextBox.Text));
                        command.Parameters.AddWithValue("@crOther", decimal.Parse(crOthertextBox.Text));
                        command.Parameters.AddWithValue("@debDoctors", decimal.Parse(debDoctorstextBox.Text));
                        command.Parameters.AddWithValue("@debCentral", decimal.Parse(debCentraltextBox.Text));
                        command.Parameters.AddWithValue("@depSup", decimal.Parse(depSuptextBox.Text));
                        command.Parameters.AddWithValue("@debOther", decimal.Parse(debOthertextBox.Text));
                        command.Parameters.AddWithValue("@cashCurrent", decimal.Parse(cashCurrenttextBox.Text));
                        command.Parameters.AddWithValue("@altCashCurrent", decimal.Parse(altCashCurrenttextBox.Text));
                        command.Parameters.AddWithValue("@saderatCurrent", decimal.Parse(saderatCurrenttextBox.Text));
                        command.Parameters.AddWithValue("@saderatDaman", decimal.Parse(saderatDamanrCurrenttextBox.Text));
                        command.Parameters.AddWithValue("@qardHasan", decimal.Parse(qardHasanCurrenttextBox.Text));
                        command.Parameters.AddWithValue("@qardHasanRawateb", decimal.Parse(qardHasanRawatebtextBox.Text));
                        command.Parameters.AddWithValue("@patientWeeklyIn", int.Parse(patientWeeklyIntextBox.Text));
                        command.Parameters.AddWithValue("@patientWeeklyOut", int.Parse(patientWeeklyOuttextBox.Text));
                        command.Parameters.AddWithValue("@cumuPatientIn", int.Parse(cumuPatientIntextBox.Text));
                        command.Parameters.AddWithValue("@cumuPatientOut", int.Parse(cumuPatientOuttextBox.Text));
                        command.Parameters.AddWithValue("@iradatWeeklyTot", decimal.Parse(iradatWeeklyTottextBox.Text));
                        command.Parameters.AddWithValue("@a3ba2WeeklyTot", decimal.Parse(a3ba2WeeklyTottextBox.Text));

                        // Execute the update
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data updated successfully.");
                        }
                        else
                        {
                            MessageBox.Show("No data found for the specified week.");
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"MySQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected Error: {ex.Message}");
            }
        }



        private void onlyNumeric(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is not a digit or not a control key (like backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != '.')
            {
                e.Handled = true;  // Reject the key press
                return;
            }
            
            //TextBox textBox = sender as TextBox;
            //if (textBox == null) return;

            //string userInput = textBox.Text.Replace(",", ""); // Remove existing commas
            //if (decimal.TryParse(userInput, out decimal number))
            //{
            //    // Reformat the number with thousand separators
            //    textBox.Text = string.Format(CultureInfo.InvariantCulture, "{0:N2}", number);
            //    textBox.SelectionStart = textBox.Text.Length; // Move the cursor to the end
            //}
            //else if (!string.IsNullOrEmpty(userInput))
            //{
            //    // If input is invalid, revert to the last valid value
            //    textBox.Text = string.Empty;
            //}


        }

        private bool IsLastWeekOfYear(DateTime date)
        {
            DateTime lastDayOfYear = new DateTime(date.Year, 12, 31);
            DateTime firstDayOfLastWeek = GetLastMonday(lastDayOfYear);
            return date >= firstDayOfLastWeek && date <= lastDayOfYear;
        }
        private void dateFromdateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (!lockk)
            {
                lockk = true;
                DateTime selectedDate = dateFromdateTimePicker.Value;

                // Check if the selected date is not a Monday

                if (isFirstWeek(selectedDate))
                {
                    dateFromdateTimePicker.Value = new DateTime(selectedDate.Year, 1, 1);
                    dateTodateTimePicker.Value = GetNextSunday(dateFromdateTimePicker.Value);
                    
                    
                }
                else if (IsLastWeekOfYear(selectedDate))
                {
                    dateFromdateTimePicker.Value = GetLastMonday(dateFromdateTimePicker.Value);
                    dateTodateTimePicker.Value = new DateTime(selectedDate.Year, 12, 31);
                    
                    
                }
                else
                {
                    dateFromdateTimePicker.Value = GetLastMonday(selectedDate);
                    dateTodateTimePicker.Value = GetNextSunday(dateFromdateTimePicker.Value);
                    
                    
                }
                lockk = false;
            }
            setDays();
            numericYear.Value = dateFromdateTimePicker.Value.Year;
            weeknumericUpDown.Value = getWeekNumber(dateFromdateTimePicker.Value);



            if (CheckdateOfWeekExists(dateFromdateTimePicker.Value))
            {
                if (!lockk)
                {
                    lockk = true;
                    LoadDataByWeek();
                    lockk = false;
                }
                
            }
            else
            {
                ResetControls();
                MessageBox.Show("لم يتم إدخال هذا الأسبوع مسبقاً. أدخله الآن؟");
            }

        }
        private int getWeekNumber(DateTime dt)
        {
            int dayoffirstSun = firstSun(dt).DayOfYear;
            return 1 + (7 - dayoffirstSun + dt.DayOfYear) / 7;
        }
        private DateTime GetLastMonday(DateTime date)
        {
            while (date.DayOfWeek != DayOfWeek.Monday)
            {
                date = date.AddDays(-1);
            }
            return date;
        }
        private DateTime GetNextMonday(DateTime date)
        {
            while (date.DayOfWeek != DayOfWeek.Monday)
            {
                date = date.AddDays(+1);
            }
            return date;
        }
        private DateTime GetNextSunday(DateTime date)
        {
            while (date.DayOfWeek != DayOfWeek.Sunday)
            {
                date = date.AddDays(+1);
            }
            return date;
        }

        private void weeknumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            

            //if (weeknumericUpDown.Value <1) {
            //    weeknumericUpDown.Value = 1;
            //    lockk = false;
            //    return; }
            //if (weeknumericUpDown.Value > 53) {
            //    weeknumericUpDown.Value = 53;
            //    lockk = false;
            //    return ; }
            //if (!lockk)
            //{
            //    lockk = true;
            //    if (weeknumericUpDown.Value == 1)
            //    {
            //        dateTime1 = new DateTime((int)numericYear.Value, 1, 1);
            //        dateTime2 = GetNextSunday(dateTime1);
            //        dateFromdateTimePicker.Value = dateTime1;
            //        dateTodateTimePicker.Value = dateTime2;
            //    }
            //    else if (weeknumericUpDown.Value == 53)
            //    {
            //        dateTime2 = new DateTime((int)numericYear.Value, 12, 31);
            //        dateTime1 = GetLastMonday(dateTime2);
            //        dateFromdateTimePicker.Value = dateTime1;
            //        dateTodateTimePicker.Value = dateTime2;
            //    }
            //    else
            //    {
            //        //DateTime firstMon = GetNextMonday(new DateTime((int)numericYear.Value, 1, 1));
            //        //dateFromdateTimePicker.Value = firstMon.AddDays((int)weeknumericUpDown.Value * 7);
            //        dateFromdateTimePicker.Value = GetLastMonday(new DateTime((int)numericYear.Value,1,1).AddDays(((int)weeknumericUpDown.Value-1) * 7));
            //        dateTodateTimePicker.Value = GetNextSunday(dateFromdateTimePicker.Value);
            //    }
            //}
            //setDays();
            //lockk = false;
        }
        private void setDays()
        {
            daystextBox.Text = dateFromdateTimePicker.Value.DayOfYear.ToString();
        }
        private void sum_totals(object sender, EventArgs e)
        {
            try
            {

                crTotal.Text = (Convert.ToInt64(crRiayitextBox.Text) + Convert.ToInt64(crWizaratextBox.Text) + Convert.ToInt64(crDamantextBox.Text) + Convert.ToInt64(crKafalattextBox.Text) + Convert.ToInt64(crOthertextBox.Text)).ToString();
                debTottextBox.Text = (Convert.ToInt64(depSuptextBox.Text) + Convert.ToInt64(debCentraltextBox.Text) + Convert.ToInt64(debOthertextBox.Text) + Convert.ToInt64(debDoctorstextBox.Text)).ToString();
                cashTotal.Text = (Convert.ToInt64(cashCurrenttextBox.Text) + Convert.ToInt64(altCashCurrenttextBox.Text) + Convert.ToInt64(saderatCurrenttextBox.Text) + Convert.ToInt64(saderatDamanrCurrenttextBox.Text) + Convert.ToInt64(qardHasanCurrenttextBox.Text) + Convert.ToInt64(qardHasanRawatebtextBox.Text)).ToString();
                textBox34.Text = (Convert.ToInt64(patientWeeklyIntextBox.Text) + Convert.ToInt64(patientWeeklyOuttextBox.Text)).ToString();
                textBox33.Text = (Convert.ToInt64(cumuPatientIntextBox.Text) + Convert.ToInt64(cumuPatientOuttextBox.Text)).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (isFirstWeek(dateFromdateTimePicker.Value))
            //{
            //    if (weeknumericUpDown.Value < 1)
            //    {
            //        dateFromdateTimePicker.Value = GetLastMonday(dateFromdateTimePicker.Value);
            //    }
            //}
            //else
            if (IsLastWeekOfYear(dateFromdateTimePicker.Value))
                    dateFromdateTimePicker.Value = new DateTime(dateFromdateTimePicker.Value.Year+1, 1, 1);
            else
                dateFromdateTimePicker.Value = dateFromdateTimePicker.Value.AddDays(7);
            //button2.Enabled = false;
            ////System.Threading.Thread.Sleep(1000); // Waits for 1 second
            //try
            //{
            //    weeknumericUpDown.Value += 1;
            //}
            //catch (MySqlException ex)
            //{
            //    MessageBox.Show($"Error: {ex.Message}");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Unexpected error: {ex.Message}");
            //}
            //finally
            //{
            //    button2.Enabled = true;
            //}
        }
        private Boolean isFirstWeek (DateTime dt)
        {
            if(dt<=firstSun(dt) && dt>=new DateTime (dt.Year,1,1))
                return true;
            else return false;
        }
        private DateTime firstSun (DateTime dt)
        {
            DateTime dt2 = new DateTime(dt.Year,1,1);
            while (dt2.DayOfWeek != DayOfWeek.Sunday)
                dt2 = dt2.AddDays(1);
            return dt2;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            UpdateDataByWeek();
        }
        private void ResetControls()
        {
            try
            {
                
                // TextBoxes - Set to "0" for numeric inputs
                dailyIradAvgtextBox.Text = "0";
                dailyMasrofAvgtextBox.Text = "0";
                dailyIradTottextBox.Text = "0";
                dailyMasroufTottextBox.Text = "0";
                resultAvgtextBox.Text = "0";
                istihlakAvgtextBox.Text = "0";
                maonatDebtAvgtextBox.Text = "0";
                crRiayitextBox.Text = "0";
                crWizaratextBox.Text = "0";
                crDamantextBox.Text = "0";
                crKafalattextBox.Text = "0";
                crOthertextBox.Text = "0";
                debDoctorstextBox.Text = "0";
                debCentraltextBox.Text = "0";
                depSuptextBox.Text = "0";
                debOthertextBox.Text = "0";
                cashCurrenttextBox.Text = "0";
                altCashCurrenttextBox.Text = "0";
                saderatCurrenttextBox.Text = "0";
                saderatDamanrCurrenttextBox.Text = "0";
                qardHasanCurrenttextBox.Text = "0";
                qardHasanRawatebtextBox.Text = "0";
                patientWeeklyIntextBox.Text = "0";
                patientWeeklyOuttextBox.Text = "0";
                cumuPatientIntextBox.Text = "0";
                cumuPatientOuttextBox.Text = "0";
                iradatWeeklyTottextBox.Text = "0";
                a3ba2WeeklyTottextBox.Text = "0";

                // Dates - Keep as is
                // No action needed for dateFromdateTimePicker
                //MessageBox.Show("All controls have been reset");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during reset: {ex.Message}");
            }
        }

        private bool CheckdateOfWeekExists(DateTime? dateOfWeek)
        {
            bool exists = false;
            string query = "SELECT COUNT(*) FROM alldata WHERE `dateOfWeek` = @dateOfWeek";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@dateOfWeek", dateOfWeek);

                        // Execute the query and get the count
                        long count = Convert.ToInt64(command.ExecuteScalar());
                        exists = count > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"MySQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected Error: {ex.Message}");
            }

            return exists;
        }

        

        // Function to change the connection string
        public static void ChangeConnectionString(string newConnectionString)
        {
            try
            {
                // Get the current configuration file
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // Update the connection string in the configuration
                if (config.ConnectionStrings.ConnectionStrings["accwr.Properties.Settings.accwrConnectionString"] != null)
                {
                    config.ConnectionStrings.ConnectionStrings["accwr.Properties.Settings.accwrConnectionString"].ConnectionString = newConnectionString;

                    // Save the changes to the config file
                    config.Save(ConfigurationSaveMode.Modified);

                    // Refresh the section to apply the changes
                    ConfigurationManager.RefreshSection("connectionStrings");

                    MessageBox.Show("Connection string updated successfully!");
                }
                else
                {
                    MessageBox.Show("Connection string not found in the config file.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating connection string: " + ex.Message);
            }
        }

        private void serverRefreshBtn_Click(object sender, EventArgs e)
        {
            //loadIP(getIP());
        }
        public static string GetIp()
        {
            string filePath = @"C:\acc2\connection.txt";

            try
            {
                // Check if file exists first
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File not found: {filePath}");
                    return null; // or return a default value
                }

                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Read the first line from the file
                    string line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        Console.WriteLine("File is empty.");
                        return null; // or return a default value
                    }

                    return line;
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You do not have permission to access this file.");
                return null;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"IO error: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                return null;
            }
        }

        private void serverRefreshBtn_Click_1(object sender, EventArgs e)
        {
            loadIP(GetIp());
            iptextbox.Text = GetIp();
        }
    }
}
