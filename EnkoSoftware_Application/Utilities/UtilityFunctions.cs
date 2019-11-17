using EnkoSoftware_Application.EF_EnkoSoftware;
using EnkoSoftware_Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EnkoSoftware_Application.Utilities
{
    static class UtilityFunctions
    {
        public static List<CompanyRecordsViewModel> reArrangeData_GridColumns(List<CompanyRecord> companyRecords)
        {
            return companyRecords.Select(c => new CompanyRecordsViewModel
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

        public static bool IsValidZipCode(string inputZipCode)
        {
            string strRegex = @"^[0-9]{5}";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputZipCode))
                return (true);
            else
                return (false);
        }

    }
}
