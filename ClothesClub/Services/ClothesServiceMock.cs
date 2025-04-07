using ClothesClub.Interfaces;
using core;

namespace ClothesClub.Services
{
    public class ClothesServiceMock : IClothesService
    {
        public void AddClothingItem(ClothingItem item)
        {
            throw new NotImplementedException();
        }

        public List<ClothingItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public void LentOutClothingItem(ClothingItem item)
        {
            throw new NotImplementedException();
        }

        public void RemoveClothingItem(ClothingItem item)
        {
            throw new NotImplementedException();
        }
    }
}
