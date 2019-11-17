using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnkoSoftware_Application.Model
{
    public class CompanyRecordsViewModel
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Street { get; set; }
        public int StreetNo { get; set; }
        public int ZipCode { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}
