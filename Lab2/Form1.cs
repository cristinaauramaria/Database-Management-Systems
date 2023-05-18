using Microsoft.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.ComponentModel;
using System.Windows.Forms;

namespace WF_App_222_2023
{
    public partial class Form1 : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString.ToString();
        SqlDataAdapter da = new SqlDataAdapter();
        BindingSource bsP = new BindingSource();
        BindingSource bsC = new BindingSource();
        DataSet dsP = new DataSet();
        DataSet dsC = new DataSet();

        private string childTableName = ConfigurationManager.AppSettings["ChildTableName"];
        private string parentTableName = ConfigurationManager.AppSettings["ParentTableName"];
        private string columnNamesInsertParameters = ConfigurationManager.AppSettings["ColumnNamesInsertParameters"];
        private List<string> columnNames = new List<string>(ConfigurationManager.AppSettings["ChildLabelNames"].Split(','));
        private List<string> paramsNames = new List<string>(ConfigurationManager.AppSettings["ColumnNamesInsertParameters"].Split(','));
        private int nr = Convert.ToInt32(ConfigurationManager.AppSettings["ChildNumberOfColumns"]);
        private TextBox[] textBoxes;
        private Label[] labels;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show(connection.State.ToString());

                    string select = ConfigurationSettings.AppSettings["SelectParent"];
                    da.SelectCommand = new SqlCommand(select, connection);
                    dsP.Clear();
                    da.Fill(dsP);
                    dataGridViewParent.DataSource = dsP.Tables[0];
                    bsP.DataSource = dsP.Tables[0];

                    bsP.MoveLast();

                    PopulatePanel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PopulatePanel()
        {
            textBoxes = new TextBox[nr];
            labels = new Label[nr];

            for (int i = 0; i < nr; i++)
            {
                labels[i] = new Label();
                labels[i].Text = columnNames[i];
                textBoxes[i] = new TextBox();
            }

            for (int i = 0; i < nr; i++)
            {

                flowLayoutPanel1.Controls.Add(labels[i]);
                flowLayoutPanel1.Controls.Add(textBoxes[i]);
            }
        }

        private void dataGridViewParent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewParent.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                return;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    int cod_f = (int)dataGridViewParent.CurrentRow.Cells[0].Value;
                    string select = ConfigurationSettings.AppSettings["SelectChild"];
                    da.SelectCommand = new SqlCommand(select, connection);
                    da.SelectCommand.Parameters.AddWithValue("@id", cod_f);
                    dsC.Clear();
                    da.Fill(dsC);
                    dataGridViewChild.DataSource = dsC.Tables[0];
                    bsC.DataSource = dsC.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (dataGridViewParent.SelectedCells.Count == 0)
            {
                MessageBox.Show("O linie in parinte trebuie selectata!");
                return;
            }
            else if (dataGridViewParent.SelectedCells.Count > 1)
            {
                MessageBox.Show("O singura linie in parinte trebuie selectata!");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    da.InsertCommand = new SqlCommand("insert into " + childTableName + " ( " + ConfigurationManager.AppSettings["ChildLabelNames"] + " ) values ( " + columnNamesInsertParameters + " )", connection);
                    for (int i = 0; i < nr; i++)
                    {
                        da.InsertCommand.Parameters.AddWithValue(paramsNames[i], textBoxes[i].Text);
                        textBoxes[i].Clear();
                    }
                    da.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("Adaugat cu succes!");

                    // actualizare tabel fiu cu noile date
                    dsC.Clear();
                    int cod_f = (int)dataGridViewParent.CurrentRow.Cells[0].Value;
                    string select = ConfigurationSettings.AppSettings["SelectChild"];
                    da.SelectCommand = new SqlCommand(select, connection);
                    da.SelectCommand.Parameters.AddWithValue("@id", cod_f);
                    da.Fill(dsC);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (dataGridViewChild.SelectedCells.Count == 0)
            {
                MessageBox.Show("O linie in copil trebuie selectata!");
                return;
            }
            else if (dataGridViewChild.SelectedCells.Count > 1)
            {
                MessageBox.Show("O singura linie in copil trebuie selectata!");
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string delete = ConfigurationManager.AppSettings["DeleteChild"];
                    da.DeleteCommand = new SqlCommand(delete, connection);
                    da.DeleteCommand.Parameters.AddWithValue("@id", (int)dataGridViewChild.CurrentRow.Cells[0].Value);
                    da.DeleteCommand.ExecuteNonQuery();
                    MessageBox.Show("Delete succes!");

                    // actualizare tabel fiu cu noile date
                    dsC.Clear();
                    int cod_f = (int)dataGridViewParent.CurrentRow.Cells[0].Value;
                    string select = ConfigurationSettings.AppSettings["SelectChild"];
                    da.SelectCommand = new SqlCommand(select, connection);
                    da.SelectCommand.Parameters.AddWithValue("@id", cod_f);
                    da.Fill(dsC);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (dataGridViewChild.SelectedCells.Count == 0)
            {
                MessageBox.Show("O linie in copil trebuie selectata!");
                return;
            }
            else if (dataGridViewChild.SelectedCells.Count > 1)
            {
                MessageBox.Show("O singura linie in copil trebuie selectata!");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    int x;
                    connection.Open();
                    string update = ConfigurationManager.AppSettings["UpdateQuery"];
                    da.UpdateCommand = new SqlCommand(update, connection);
                    for (int i = 0; i < nr; i++)
                    {
                        da.UpdateCommand.Parameters.AddWithValue(paramsNames[i], textBoxes[i].Text);
                        textBoxes[i].Clear();
                    }
                    da.UpdateCommand.Parameters.AddWithValue("@id", (int)dataGridViewChild.CurrentRow.Cells[0].Value);


                    x = da.UpdateCommand.ExecuteNonQuery();
                    if (x >= 1)
                    {
                        MessageBox.Show("The record has been updated");
                    }

                    // actualizare tabel fiu cu noile date
                    dsC.Clear();
                    int cod_f = (int)dataGridViewParent.CurrentRow.Cells[0].Value;
                    string select = ConfigurationSettings.AppSettings["SelectChild"];
                    da.SelectCommand = new SqlCommand(select, connection);
                    da.SelectCommand.Parameters.AddWithValue("@id", cod_f);
                    da.Fill(dsC);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}