using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ApartmentRental.Model
{
    public class Apartment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int numberOfRooms { get; set; }
        [Required]
        public int numberOfBathrooms { get; set; }
        [Required]
        public int area { get; set; }
        [Required]
        public string isKitchenSeparateRoom { get; set; }
        public string arePetsAllowed { get; set; }
        [Required]
        public byte[] image { get; set; }
        [Required]
        public string ownerId { get; set; }
        [Required]
        public string shortDescription { get; set; }  


        public Apartment( int numberOfRooms, int numberOfBathrooms, int area, string isKitchenSeparateRoom, string arePetsAllowed, byte[] image, string ownerId, string shortDescription)
        {
            this.numberOfBathrooms = numberOfBathrooms;
            this.numberOfRooms = numberOfRooms;
            this.isKitchenSeparateRoom = isKitchenSeparateRoom;
            this.area = area;
            this.arePetsAllowed = arePetsAllowed;
            this.image = image;
            this.ownerId = ownerId;
            this.shortDescription = shortDescription;  
        }

        

    }
}
