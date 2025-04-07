using core;
using System.Reflection;

namespace ClothesClub.Interfaces
{
    public interface IClothesService
    {
        public List<ClothingItem> GetAll(List<ClothingItem> storedList);

        public void AddClothingItem(ClothingItem item, List<ClothingItem> storedList);

        public void RemoveClothingItem(ClothingItem item, List<ClothingItem> storedList);

        public void LentOutClothingItem(ClothingItem item, List<ClothingItem> storedList);
    }
}
