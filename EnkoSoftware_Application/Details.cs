using EnkoSoftware_Application.EF_EnkoSoftware;
using EnkoSoftware_Application.Implementations;
using EnkoSoftware_Application.Model;
using EnkoSoftware_Application.Repositories;
using EnkoSoftware_Application.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnkoSoftware_Application
{
    public partial class Details : Form
    {
        static IGenericRepository<CompanyRecord> repository = null;
        private readonly CompanyRecord _companyRecord = null;
        private readonly Company _compForm;

        public bool validateControls()
        {
            bool validateRecord = false;

            if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
            {
                lblCompanyName.ForeColor = System.Drawing.Color.Red;
                txtCompanyName.ForeColor = System.Drawing.Color.Red;

                validateRecord = false;
            }
            else
            {
                lblCompanyName.ForeColor = System.Drawing.Color.Black;
                txtCompanyName.ForeColor = System.Drawing.Color.Black;

                validateRecord = true;
            }

            if (string.IsNullOrWhiteSpace(txtStreet.Text))
            {
                lblStreet.ForeColor = System.Drawing.Color.Red;
                txtStreet.ForeColor = System.Drawing.Color.Red;

                validateRecord = false;
            }
            else
            {
                lblStreet.ForeColor = System.Drawing.Color.Black;
                txtStreet.ForeColor = System.Drawing.Color.Black;

                validateRecord = true;
            }

            if (string.IsNullOrWhiteSpace(txtStreetNo.Text))
            {
                label3.ForeColor = System.Drawing.Color.Red;
                txtStreetNo.ForeColor = System.Drawing.Color.Red;

                validateRecord = false;
            }
            else
            {
                label3.ForeColor = System.Drawing.Color.Black;
                txtStreetNo.ForeColor = System.Drawing.Color.Black;

                validateRecord = true;
            }

            if (string.IsNullOrWhiteSpace(txtZipCode.Text))
            {
                lblZipCode.ForeColor = System.Drawing.Color.Red;
                txtZipCode.ForeColor = System.Drawing.Color.Red;

                validateRecord = false;
            }
            else
            {
                if (UtilityFunctions.IsValidZipCode(txtZipCode.Text))
                {
                    lblZipCode.ForeColor = System.Drawing.Color.Black;
                    txtZipCode.ForeColor = System.Drawing.Color.Black;

                    validateRecord = true;
                }
                else
                {
                    lblZipCode.ForeColor = System.Drawing.Color.Red;
                    txtZipCode.ForeColor = System.Drawing.Color.Red;

                    validateRecord = false;
                }
                
            }

            return validateRecord;
        }

        public Details(CompanyRecord companyRecords, Company compForm)
        {
            repository = new GenericRepository<CompanyRecord>();
            _companyRecord = companyRecords;
            _compForm = compForm;

            //Base Controls
            InitializeComponent();

            
        }

        private void Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'enkoSoftwareDataSet.City' table. You can move, or remove it, as needed.
            this.cityTableAdapter.Fill(this.enkoSoftwareDataSet.City);

            if (_companyRecord != null)
            {
                lblCustomTitle.Text = "Address Details";
                lblCompanyId.Text = _companyRecord.CompanyId.ToString();
                txtCompanyName.Text = _companyRecord.CompanyName;
                txtStreet.Text = _companyRecord.Street;
                txtStreetNo.Text = _companyRecord.StreetNo.ToString();
                txtZipCode.Text = _companyRecord.ZipCode.ToString();
                cmbCity.SelectedIndex = cmbCity.FindString(_companyRecord.City.CityName);
            }
            else
            {
                lblCustomTitle.Text = "New Address";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateControls())
            {
                if (_companyRecord != null)
                {
                    CompanyRecord companyRecord = new CompanyRecord();
                    companyRecord.CompanyId = Convert.ToInt32(lblCompanyId.Text);
                    companyRecord.CompanyName = txtCompanyName.Text;
                    companyRecord.Street = txtStreet.Text;
                    companyRecord.StreetNo = Convert.ToInt32(txtStreetNo.Text);
                    companyRecord.ZipCode = Convert.ToInt32(txtZipCode.Text);
                    companyRecord.CityId = Convert.ToInt32(cmbCity.SelectedValue.ToString());
                    companyRecord.CreatedDate = _companyRecord.CreatedDate;
                    companyRecord.ModifiedDate = DateTime.Now;

                    repository.Update(companyRecord);
                    repository.Save();
                }
                else
                {
                    CompanyRecord companyRecord = new CompanyRecord();
                    companyRecord.CompanyName = txtCompanyName.Text;
                    companyRecord.Street = txtStreet.Text;
                    companyRecord.StreetNo = Convert.ToInt32(txtStreetNo.Text);
                    companyRecord.ZipCode = Convert.ToInt32(txtZipCode.Text);
                    companyRecord.CityId = Convert.ToInt32(cmbCity.SelectedValue.ToString());
                    companyRecord.CreatedDate = DateTime.Now;

                    repository.Insert(companyRecord);
                    repository.Save();
                }

                //Close Curret Dialog & Update Main Form Grid
                DataGridView grdCompanyManagement = (DataGridView)_compForm.Controls["grdCompanyManagement"];
                try
                {
                    grdCompanyManagement.DataSource = repository.GetAll().Select(c => new CompanyRecordsViewModel
                    {
                        CompanyId = c.CompanyId,
                        CompanyName = c.CompanyName,
                        Street = c.Street,
                        StreetNo = c.StreetNo,
                        ZipCode = c.ZipCode,
                        CityId = c.CityId,
                        CityName = c.City.CityName
                    }).ToList();
                }
                catch
                {

                }

                this.Close();
            }
        }
    }
}
