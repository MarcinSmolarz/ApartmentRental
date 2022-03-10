using ApartmentRental.Data;
using ApartmentRental.Model;
using ApartmentRental.Uyility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApartmentRental.Pages.Apartments
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EditModel(ApplicationDbContext db, IHttpContextAccessor IHttpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = IHttpContextAccessor;
        }
        [BindProperty]
        public Apartment Apartment { get; set; }
        [BindProperty]
        public int numberOfRooms { get; set; }
        [BindProperty]
        public int numberOfBathrooms { get; set; }
        [BindProperty]
        public int area { get; set; }
        [BindProperty]
        public string isKitchenSeparate { get; set; }
        [BindProperty]
        public string arePetsAllowed { get; set; }
        [BindProperty]
        public byte[] image { get; set; }
        [BindProperty]
        public string shortDescription { get; set; }
        public async Task OnGet(int id)
        {
            Apartment = await _db.Apartment.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var ApartmentFromDb = await _db.Apartment.FindAsync(Apartment.Id);
                ApartmentFromDb.numberOfRooms = Apartment.numberOfRooms;
                ApartmentFromDb.numberOfBathrooms = Apartment.numberOfBathrooms;
                ApartmentFromDb.area = Apartment.area;
                ApartmentFromDb.isKitchenSeparateRoom = Apartment.isKitchenSeparateRoom;
                ApartmentFromDb.arePetsAllowed = Apartment.arePetsAllowed;
                ApartmentFromDb.image = Apartment.image;

                await _db.SaveChangesAsync();
                return RedirectToPage("MyOffers");
            }
            return RedirectToPage();
        }
    }
}
