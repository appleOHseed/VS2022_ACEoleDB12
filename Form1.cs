using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAccess
{
    public partial class Form1 : Form
    {
        public static DataTable CreateSimpleDataTable()
        {
            // 1. Create the DataTable object and name it "Music"
            DataTable musicTable = new DataTable("Music");

            // 2. Define columns and their data types
            DataColumn idColumn = new DataColumn();
            idColumn.DataType = System.Type.GetType("System.Int32");
            idColumn.ColumnName = "SongID";
            idColumn.Caption = "ID";
            idColumn.ReadOnly = true;
            idColumn.Unique = true;
            musicTable.Columns.Add(idColumn);

            musicTable.Columns.Add("SongTitle", typeof(string));
            musicTable.Columns.Add("Artist", typeof(string));
            musicTable.Columns.Add("Genre", typeof(string));

            // Set the primary key
            musicTable.PrimaryKey = new DataColumn[] { idColumn };

            // 3. Add data rows
            DataRow row;

            row = musicTable.NewRow();
            row["SongID"] = 1;
            row["SongTitle"] = "Bohemian Rhapsody";
            row["Artist"] = "Queen";
            row["Genre"] = "Rock";
            musicTable.Rows.Add(row);

            // Alternative way to add a row (requires columns in correct order)
            musicTable.Rows.Add(2, "Stairway to Heaven", "Led Zeppelin", "Rock");
            musicTable.Rows.Add(3, "Hotel California", "Eagles", "Rock");

            return musicTable;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string dbPath = @"I:\Data\WFAccess\Garden.accdb";
            string connStr = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};Persist Security Info=False;";
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                try
                {
                    conn.Open();
                    //string query = "SELECT * FROM TableName";
                    string query = "SELECT * FROM Employees";
                    OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    // Use DataTable (dt) here
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            // Call the method to get the DataTable
         //   DataTable dataTable = DataTableExample.CreateSimpleDataTable();

            // Set the DataGridView's data source to the DataTable
            //  dataGridView1.DataSource = dataTable;
            
        }
    }
}
