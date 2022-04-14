using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            if (checkReading.Checked) Hobby = "Reading";
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
