using System.Linq;

namespace DancingGoat.Models
{
    public record CafeViewModel(string Name, string PhotoPath, string PhotoShortDescription, string Street, string City, string Country, string ZipCode, string Phone)
    {
        /// <summary>
        /// Maps <see cref=Cafe"/> to a <see cref="CafeViewModel"/>.
        /// </summary>
        public static CafeViewModel GetViewModel(Cafe cafe)
        {
            var cafePhoto = cafe.CafePhoto?.FirstOrDefault();

            return new CafeViewModel(
                cafe.CafeName,
                cafePhoto?.ImageFile.Url,
                cafePhoto?.ImageShortDescription,
                cafe.CafeAddresses.FirstOrDefault()?.Street,
                cafe.CafeAddresses.FirstOrDefault()?.City,
                cafe.CafeAddresses.FirstOrDefault()?.Country,
                cafe.CafeAddresses.FirstOrDefault()?.PostalCode,
                cafe.CafeAddresses.FirstOrDefault()?.Phone);
        }
    }
}
