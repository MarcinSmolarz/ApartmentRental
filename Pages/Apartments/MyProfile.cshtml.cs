using ApartmentRental.Uyility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApartmentRental.Pages.Apartments

{
    [Authorize]
    public class MyProfileModel : PageModel
    {
        public void OnGet()
        {        
        }
    }
}
