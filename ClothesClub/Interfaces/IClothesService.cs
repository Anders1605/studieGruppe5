using core;
using System.Reflection;

namespace ClothesClub.Interfaces
{
    public interface IClothesService
    {
        public List<ClothingItem> GetAll();

        public void AddClothingItem(ClothingItem item);

        public void RemoveClothingItem(ClothingItem item);

        public void LentOutClothingItem(ClothingItem item);
    }
}
