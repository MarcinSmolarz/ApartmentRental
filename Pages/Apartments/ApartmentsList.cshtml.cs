using ApartmentRental.Data;
using ApartmentRental.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ApartmentRental.Pages.Apartments
{
    public class ApartmentsListModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApartmentsListModel(ApplicationDbContext db, IHttpContextAccessor IHttpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = IHttpContextAccessor;

        }
        public string imageURL { get; set; }
        public IList<Apartment> Apartments { get; set; }
        public async Task OnGet()
        {
            var apartments = from m in _db.Apartment select m;
            Apartments = await apartments.ToListAsync();

            Apartment Test = Apartments[0];
            string decodedImage = Convert.ToBase64String(Test.image);
            imageURL = string.Format("data:image/jpg;base64,{0}", decodedImage);


        }
  
    }
}
//[style.width.px]=300;
//[style.margin.px]=200> add to css file;