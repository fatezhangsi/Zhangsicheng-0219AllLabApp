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

namespace LabAss3
{
    public partial class frmCustomerDateEntry : Form
    {
        public frmCustomerDateEntry()
        {
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            string Gender, Hobby, Status = "";
            if (radioMale.Checked) Gender = "Male";
            else Gender = "Female";
            if (chkReading.Checked) Hobby = "Reading";
            else Hobby = "Painting";
            if (radioMarried.Checked) Status = "Married";
            else Status = "UnMarried";
            try
            {
                CustomerValiditaon objVal = new CustomerValiditaon();
                objVal.CheckCustomerName(txtName.Text);


           
          

            frmCustomerPreview objPreview = new frmCustomerPreview();
        objPreview.SetValues(txtName.Text, cmbCountry.Text, Gender, Hobby, Status);
            objPreview.Show();
        }
           catch (Exception ex)
            { MessageBox.Show(ex.Message.ToString()); }
}




private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void From1_Load(object sender, EventArgs e)
        {
            loadCustomer();
        }
        private void loadCustomer()
        {


            string strConnection = "Data Source=LAPTOP-BMNIF6V9;Initial Catalog=CustomerDB;Persist Security Info=True;User ID=sa;Pooling=False;Password=zsc132412;";
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();

            string strCommand = "Select * from  Customer";
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);

            DataSet objDataset=new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
            objAdapter.Fill(objDataset);
            dtgCustomer.DataSource= objDataset.Tables[0];

            objConnection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clearForm();
            string id= dtgCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();
            displayCustomer(id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Gender, Hobby, Status = "";
            if (radioMale.Checked) Gender = "Male";
            else Gender = "Female";
            if (chkPainting.Checked) Hobby = "Reading";
            else Hobby = "Painting";
            if (radioMarried.Checked) Status = "1";
            else Status = "0";

            string strConnection = "Data Source=LAPTOP-BMNIF6V9;Initial Catalog=CustomerDB;Persist Security Info=True;User ID=sa;Pooling=False;Password=zsc132412;";
            SqlConnection objConnection  = new SqlConnection(strConnection);
            objConnection.Open();

            string strCommand = "insert into Customer(CustomerName,Country,Gender,Hobby,Married)Values('" + txtName.Text + "','" + cmbCountry.Text + "','" + Gender + "','" + Hobby + "'," + Status + ")";
                SqlCommand objCommand = new SqlCommand(strCommand, objConnection);
            objCommand.ExecuteNonQuery();

            objConnection.Close();
            loadCustomer();
        }
        private void clearForm()
        {
            txtName.Text = "";
            cmbCountry.Text = "";
            radioMale.Checked = false;
            radioMarried.Checked = false;
            radioFemale.Checked = false;
            radioUnmarried.Checked = false;
            chkPainting.Checked = false;
            chkReading.Checked = false;
        }
        private  void displayCustomer(string id)
        {
            string strConnection = "Data Source=LAPTOP-BMNIF6V9;Initial Catalog=CustomerDB;Persist Security Info=True;User ID=sa;Pooling=False;Password=zsc132412;";
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();

            string strCommand = "Select * from Customer  where id = " + id;
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);

            DataSet objDataset = new DataSet();
            SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
            objAdapter.Fill(objDataset);
              

            objConnection.Close();
            lblID.Text = objDataset.Tables[0].Rows[0][0].ToString().Trim();
            txtName.Text = objDataset.Tables[0].Rows[0][1].ToString().Trim();
            cmbCountry.Text = objDataset.Tables[0].Rows[0][2].ToString().Trim();
            string Gender = objDataset.Tables[0].Rows[0][3].ToString().Trim();
            if(Gender.Equals("Male"))radioMale.Checked=true;
            else radioFemale.Checked=true;
            string Hobby = objDataset.Tables[0].Rows[0][4].ToString().Trim();
            if(Hobby.Equals("Reading"))chkReading.Checked=true;
            else  chkPainting.Checked=true;
            string Married = objDataset.Tables[0].Rows[0][5].ToString().Trim();
            if(Married.Equals("True"))radioMarried.Checked=true;
            else radioUnmarried.Checked=true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Gender, Hobby, Status = "";
            if (radioMale.Checked) Gender = "Male";
            else Gender = "Female";
            if (chkReading.Checked) Hobby = "Reading";
            else Hobby = "Painting";
            if (radioMarried.Checked) Status = "1";
            else Status = "0";

            string strConnection = "Data Source=LAPTOP-BMNIF6V9;Initial Catalog=CustomerDB;Persist Security Info=True;User ID=sa;Pooling=False;Password=zsc132412;";
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();

            string strCommand = "Update Customer set CustomerName =@CustomerName, Country=@Country, " +
                "Gender=@Gender,Hobby=@Hobby,Married= @Married WHERE id=@id";
            SqlCommand objCommand = new SqlCommand(strCommand, objConnection);
            objCommand.Parameters.AddWithValue("@CustomerName", txtName.Text.Trim());
            objCommand.Parameters.AddWithValue("@Country",cmbCountry.Text.Trim());
            objCommand.Parameters.AddWithValue("@Gender",Gender);
            objCommand.Parameters.AddWithValue("@Hobby", Hobby);
            objCommand.Parameters.AddWithValue("@Married", Status);
            objCommand.Parameters.AddWithValue("@id",lblID.Text.Trim());
            objCommand.ExecuteNonQuery();

            objConnection.Close();
            clearForm();
            loadCustomer();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strConnection = "Data Source=LAPTOP-BMNIF6V9;Initial Catalog=CustomerDB;Persist Security Info=True;User ID=sa;Pooling=False;Password=zsc132412;";
            SqlConnection objConnection = new SqlConnection(strConnection);
            objConnection.Open();


            string strCommand = "Delete from Customer where id ='" +lblID.Text+ "' ";
            SqlCommand objCommand = new SqlCommand(strCommand,objConnection);
            objCommand.ExecuteNonQuery();
            objConnection.Close();

            clearForm();
            loadCustomer();

        }

    }
    }

 