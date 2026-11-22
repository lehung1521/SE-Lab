using System.Web.Mvc;

namespace ASPNETWebAppMVCStudentApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute()); // bat buoc dang nhap (Account da co [AllowAnonymous])
        }
    }
}
