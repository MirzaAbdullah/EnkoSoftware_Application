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
    public partial class Company : Form
    {
        static IGenericRepository<CompanyRecord> repository = null;
        public Company()
        {
            repository = new GenericRepository<CompanyRecord>();
            InitializeComponent();
        }

        private void btnAddAddress_Click(object sender, EventArgs e)
        {
            //Open Dialog
            Details details = new Details(null, this);
            details.ShowDialog();
        }

        public void loadCompanies()
        {
            List<CompanyRecordsViewModel> dataSet = repository.GetAll().Select(c => new CompanyRecordsViewModel
            {
                CompanyId = c.CompanyId,
                CompanyName = c.CompanyName,
                Street = c.Street,
                StreetNo = c.StreetNo,
                ZipCode = c.ZipCode,
                CityId = c.CityId,
                CityName = c.City.CityName
            }).ToList();

            if (dataSet.Count > 0)
            {
                grdCompanyManagement.DataSource = dataSet;

                //Hide Columns 0 & 5
                grdCompanyManagement.Columns["CompanyId"].Visible = false;
                grdCompanyManagement.Columns["CityId"].Visible = false;
            }
        }

        private void Company_Load(object sender, EventArgs e)
        {
            //On Form Load Fill DataGrid
            loadCompanies();
        }

        private void grdCompanyManagement_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var CompanyId = Convert.ToInt32(grdCompanyManagement[0, e.RowIndex].Value.ToString());

            //Getting Record against Company Id
            CompanyRecord companyRecord = repository.GetById(CompanyId);

            //Open Dialog
            Details details = new Details(companyRecord, this);
            details.ShowDialog();
        }
    }
}
