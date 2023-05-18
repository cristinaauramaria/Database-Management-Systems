using Microsoft.Data.SqlClient;
using System.Data;

namespace WF_App_222_2023
{
    public partial class Form1 : Form
    {
        string connectionString = @"Server=DESKTOP-4BATE1U\SQLEXPRESS;Database=Dealership_Auto_Final;Integrated Security=true;Trust Server Certificate=true;";
        SqlDataAdapter da = new SqlDataAdapter();
        BindingSource bsP = new BindingSource();
        BindingSource bsC = new BindingSource();
        DataSet dsP = new DataSet();
        DataSet dsC = new DataSet();
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

                    da.SelectCommand = new SqlCommand("SELECT * FROM Funcție", connection);
                    dsP.Clear();
                    da.Fill(dsP);
                    dataGridViewParent.DataSource = dsP.Tables[0];
                    bsP.DataSource = dsP.Tables[0];

                    bsP.MoveLast();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    string cod_f = dataGridViewParent.CurrentRow.Cells[0].Value.ToString();
                    da.SelectCommand = new SqlCommand("SELECT * from Angajat " +
                    "where cod_f = " + cod_f + "; ", connection);
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
                    da.InsertCommand = new SqlCommand("INSERT INTO Angajat(nume_a,cnp_a,cod_f)" + " VALUES (@nume, @cnp, @cod_f);", connection);
                    da.InsertCommand.Parameters.Add("@nume", SqlDbType.VarChar).Value = textNume.Text;
                    da.InsertCommand.Parameters.Add("@cnp", SqlDbType.VarChar).Value = textCnp.Text;
                    da.InsertCommand.Parameters.Add("@cod_f", SqlDbType.Int).Value = dsP.Tables[0].Rows[dataGridViewParent.CurrentRow.Index][0];
                    da.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("Adaugat cu succes!");

                    textNume.Clear();
                    textCnp.Clear();

                    // actualizare tabel fiu cu noile date
                    dsC.Clear();
                    da.SelectCommand = new SqlCommand("SELECT * from Angajat WHERE cod_f = @cod_f", connection);
                    da.SelectCommand.Parameters.Add("@cod_f", SqlDbType.Int).Value = dsP.Tables[0].Rows[dataGridViewParent.CurrentRow.Index][0];
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
                    da.DeleteCommand = new SqlCommand("Delete from Angajat where cod_a = @id;", connection);
                    da.DeleteCommand.Parameters.AddWithValue("@id", (int)dataGridViewChild.CurrentRow.Cells[0].Value);
                    da.DeleteCommand.ExecuteNonQuery();
                    MessageBox.Show("Delete succes!");

                    // actualizare tabel fiu cu noile date
                    dsC.Clear();
                    da.SelectCommand = new SqlCommand("SELECT * from Angajat WHERE cod_f = @cod_f", connection);
                    da.SelectCommand.Parameters.Add("@cod_f", SqlDbType.Int).Value = dsP.Tables[0].Rows[dataGridViewParent.CurrentRow.Index][0];
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
                    da.UpdateCommand = new SqlCommand("Update Angajat set nume_a=@nume, cnp_a=@cnp, cod_f=@cod_f where cod_a=@id", connection);
                    da.UpdateCommand.Parameters.AddWithValue("@nume", (string)dataGridViewChild.CurrentRow.Cells[1].Value);
                    da.UpdateCommand.Parameters.AddWithValue("@cnp", (string)dataGridViewChild.CurrentRow.Cells[2].Value);
                    da.UpdateCommand.Parameters.AddWithValue("@cod_f", (int)dataGridViewChild.CurrentRow.Cells[3].Value);
                    da.UpdateCommand.Parameters.AddWithValue("@id", (int)dataGridViewChild.CurrentRow.Cells[0].Value);


                    x = da.UpdateCommand.ExecuteNonQuery();
                    if (x >= 1)
                    {
                        MessageBox.Show("The record has been updated");
                    }

                    // actualizare tabel fiu cu noile date
                    dsC.Clear();
                    da.SelectCommand = new SqlCommand("SELECT * from Angajat WHERE cod_f = @cod_f", connection);
                    da.SelectCommand.Parameters.Add("@cod_f", SqlDbType.Int).Value = dsP.Tables[0].Rows[dataGridViewParent.CurrentRow.Index][0];
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