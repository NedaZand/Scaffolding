using System;
using System.Collections.Generic;
using System.Linq;
using Store.Core.Domain.StoreTables;
namespace Store.Service.Stores
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class CompanyExtensions
    {
       
        public static string GetFormattedBreadCrumb(this Company company,
            ICompanyService companyService,
            string separator = "/")
        {
            string result = string.Empty;

            var breadcrumb = GetCompanyBreadCrumb(company, companyService);
           
                for (int i = 0; i <= breadcrumb.Count - 2; i++)
                {
                    var companyName = breadcrumb[i].Title;
                    result = String.IsNullOrEmpty(result)
                        ? companyName
                        : string.Format("{0} {1} {2}", result, separator, companyName);
                }
            
            

            return result;
        }

      
        public static string GetFormattedBreadCrumb(this Company company,
            IList<Company> allCompanies,
            string separator = "/", int languageId = 0)
        {
            string result = string.Empty;

            var breadcrumb = GetCompanyBreadCrumb(company, allCompanies);
            for (int i = 0; i <= breadcrumb.Count - 1; i++)
            {
                var companyName = breadcrumb[i].Title;
                result = String.IsNullOrEmpty(result)
                    ? companyName
                    : string.Format("{0} {1} {2}", result, separator, companyName);
            }

            return result;
        }

        
        public static IList<Company> GetCompanyBreadCrumb(this Company company,
            ICompanyService companyService)
        {
            if (company == null)
                throw new ArgumentNullException("company");

            var result = new List<Company>();

            //used to prevent circular references
            var alreadyProcessedCompanyIds = new List<int>();

            while (company != null && !alreadyProcessedCompanyIds.Contains(company.Id)) //prevent circular references
            {
                result.Add(company);

                alreadyProcessedCompanyIds.Add(company.Id);
                if(company.ParentID.HasValue)
                company = companyService.GetById(company.ParentID.Value);
            }
            result.Reverse();
            return result;
        }

        public static IList<Company> GetCompanyBreadCrumb(this Company company,
            IList<Company> allCompanies)
        {
            if (company == null)
                throw new ArgumentNullException("company");

            var result = new List<Company>();

            //used to prevent circular references
            var alreadyProcessedCompanyIds = new List<int>();

            while (company != null && !alreadyProcessedCompanyIds.Contains(company.Id)) //prevent circular references
            {
                result.Add(company);

                alreadyProcessedCompanyIds.Add(company.Id);

                company = (from c in allCompanies
                            where c.Id == company.ParentID
                            select c).FirstOrDefault();
            }
            result.Reverse();
            return result;
        }
    }
}
