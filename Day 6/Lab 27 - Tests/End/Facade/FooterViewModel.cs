using System;

namespace Facade
{
    public class FooterViewModel
    {
        public FooterViewModel(string company)
        {
            setCompanyName(company);
            setYear();
        }
        public string CompanyName { get; set; } = "TTÜ";
        public string Year { get; set; }

        internal void setCompanyName(string c)
        {
            CompanyName = c;
        }
        internal void setYear()
        {
            Year = DateTime.Now.Year.ToString();
        }
    }
}
