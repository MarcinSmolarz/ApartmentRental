using ApartmentRental.Data;
using ApartmentRental.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ApartmentRental.Pages.Apartments
{
    public class MyOffersModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MyOffersModel(ApplicationDbContext db, IHttpContextAccessor IHttpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = IHttpContextAccessor;

        }
        public IList<Apartment> Apartments { get; set; }

        public async Task OnGet()
        {
            var ownerId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var apartments = from m in _db.Apartment select m;
            apartments = apartments.Where(s => s.ownerId.Contains(ownerId));

            Apartments = await apartments.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var apartment = await _db.Apartment.FindAsync(id);
            if (apartment == null)
            {
                return NotFound();
            }
            _db.Apartment.Remove(apartment);
            await _db.SaveChangesAsync();

            return RedirectToPage("MyOffers");
        }
    }
}
