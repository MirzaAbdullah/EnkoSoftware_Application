using EnkoSoftware_Application.EF_EnkoSoftware;
using EnkoSoftware_Application.Implementations;
using EnkoSoftware_Application.Model;
using EnkoSoftware_Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnkoSoftware_Application.Utilities
{
    static class OnStartUp_AddRecords
    {
        static List<CompanyRecordsViewModel> company = new List<CompanyRecordsViewModel>();
        static IGenericRepository<CompanyRecord> repository = null;

        static OnStartUp_AddRecords()
        {
            company.Add(new CompanyRecordsViewModel { CompanyName = "ENKO Software OHG", CityId = 1, CityName = "Föhren", Street = "Europa-Allee", StreetNo = 9, ZipCode = 54343 });
            company.Add(new CompanyRecordsViewModel { CompanyName = "10Geeks - Software Engineering", CityId = 1, CityName = "Föhren", Street = "Europa-Allee", StreetNo = 9, ZipCode = 54343 });
            company.Add(new CompanyRecordsViewModel { CompanyName = "Intelligix IT - Services GmbH", CityId = 1, CityName = "Föhren", Street = "Europa-Allee", StreetNo = 12, ZipCode = 54343 });

            repository = new GenericRepository<CompanyRecord>();
        }

        public static void checkRecords()
        {
            /*
             * If there is no record in company records table - Add all 3 records
             * Else then check one by one and then add the missing record
             */

            List<CompanyRecord> allCompanyRecords = repository.GetAll().ToList();
            if (allCompanyRecords.Count > 0)
            {
                foreach (CompanyRecordsViewModel recordItem in company)
                {
                    if (!allCompanyRecords.Any( c => c.CompanyName == recordItem.CompanyName && c.Street == recordItem.Street && c.StreetNo == recordItem.StreetNo && c.ZipCode == recordItem.ZipCode && c.City.CityName == recordItem.CityName ))
                    {
                        repository.Insert(new CompanyRecord
                        {
                            CompanyName = recordItem.CompanyName,
                            Street = recordItem.Street,
                            StreetNo = recordItem.StreetNo,
                            ZipCode = recordItem.ZipCode,
                            CityId = recordItem.CityId,
                            CreatedDate = DateTime.Now
                        });

                        repository.Save();
                    }
                }
            }
            else
            {
                foreach (CompanyRecordsViewModel recordItem in company)
                {
                    repository.Insert(new CompanyRecord {
                        CompanyName = recordItem.CompanyName,
                        Street = recordItem.Street,
                        StreetNo = recordItem.StreetNo,
                        ZipCode = recordItem.ZipCode,
                        CityId = recordItem.CityId,
                        CreatedDate = DateTime.Now
                    });

                    repository.Save();
                }
            }
        }
    }
}
