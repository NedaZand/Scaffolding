using Store.Core.Domain.StoreTables;
using Store.Service.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Store.WebEssential.Helper
{
    /// <summary>
    /// Select list helper
    /// </summary>
    public static class SelectListHelper
    {
        /// <summary>
        /// Get company list
        /// </summary>
        /// <param name="companyService">Company service</param>
        /// <returns>Company list</returns>
        public static List<SelectListItem> GetCompanyList(ICompanyService companyService, bool showHidden = false)
        {

            var companies = companyService.GetAll();

            var companyListItems = companies.Select(c => new SelectListItem
            {
                Text = c.GetFormattedBreadCrumb(companies),
                Value = c.Id.ToString()
            });


            var result = new List<SelectListItem>();
            //clone the list to ensure that "selected" property is not set
            foreach (var item in companyListItems)
            {
                result.Add(new SelectListItem
                {
                    Text = item.Text,
                    Value = item.Value
                });
            }

            return result;
        }

        public static string GetFormattedBreadCrumb(this Company company,
          IList<Company> allCompanies,
          string separator = ">>", int languageId = 0)
        {
            string result = string.Empty;

            var breadcrumb = GetCategoryBreadCrumb(company, allCompanies);
            for (int i = 0; i <= breadcrumb.Count - 1; i++)
            {
                var categoryName = breadcrumb[i].Title;
                result = String.IsNullOrEmpty(result)
                    ? categoryName
                    : string.Format("{0} {1} {2}", result, separator, categoryName);
            }

            return result;
        }

        /// <returns>Category breadcrumb </returns>
        public static IList<Company> GetCategoryBreadCrumb(this Company company,
            IList<Company> allcompanies,
            bool showHidden = false)
        {
            if (company == null)
                throw new ArgumentNullException("company");

            var result = new List<Company>();

            //used to prevent circular references
            var alreadyProcessedCategoryIds = new List<int>();

            while (company != null && 
                !alreadyProcessedCategoryIds.Contains(company.Id)) //prevent circular references
            {
                result.Add(company);

                alreadyProcessedCategoryIds.Add(company.Id);

                company = (from c in allcompanies
                            where c.Id == company.ParentID
                            select c).FirstOrDefault();
            }
            result.Reverse();
            return result;
        }
    }
}