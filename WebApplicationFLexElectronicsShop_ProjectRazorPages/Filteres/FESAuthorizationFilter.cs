using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FLexElectronicsShop.Filteres
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // получаем URL страницы
            var route = context.ActionDescriptor.DisplayName;

            if (route!.Contains("/UserAccount/Login") || route.Contains("/UserAccount/Register") || route.Contains("/UserAccount/NotAuthorized") || route.Contains("/Index"))
            {
                return;
            }

            if (!context.HttpContext.User.Identity!.IsAuthenticated)
            {
                context.Result = new RedirectToPageResult("/Index");
            }
        }
    }
}
