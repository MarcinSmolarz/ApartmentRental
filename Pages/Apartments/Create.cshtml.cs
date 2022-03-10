using ApartmentRental.Data;
using ApartmentRental.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace ApartmentRental.Pages.Apartments
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateModel(ApplicationDbContext db, IHttpContextAccessor IHttpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = IHttpContextAccessor;
        }
        
        [BindProperty]
        public int numberOfRooms { get; set; }
        [BindProperty]
        public int numberOfBathrooms { get; set; }
        [BindProperty]
        public int area { get; set; }
        [BindProperty]
        public string isKitchenSeparate { get; set; } //zmieniæ na drop list
        [BindProperty]
        public string arePetsAllowed { get; set; } //zmieniæ na drop list
        [BindProperty]
        public byte[] image { get; set; }
        int ownerId { get; set; }
        [BindProperty]
        public string shortDescription { get; set; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            Console.WriteLine("Post task");
            foreach(var file in Request.Form.Files)
                {
                Console.WriteLine("foreach loop");
                MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);
                    image = ms.ToArray();
                    ms.Close();
                    ms.Dispose();
                }
            Console.WriteLine("behind foreach loop");


            var ownerId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Apartment Apartment = new Apartment(numberOfRooms, numberOfBathrooms, area, isKitchenSeparate, arePetsAllowed, image, ownerId, shortDescription);
            //if (ModelState.IsValid)
            //{
                Console.WriteLine("add apartment");
                await _db.Apartment.AddAsync(Apartment);
                await _db.SaveChangesAsync();
                return RedirectToPage("MyProfile");
            //}
            //else
            //{
            //    return Page();
            //}
        }
    }
}
