using System.Reflection.Metadata;
using System.Threading.Tasks;
using ClothesClub.Interfaces;
using core;

namespace ClothesClub.Services
{
    public class ClothesServiceMock : IClothesService
    {
     
        public void AddClothingItem(ClothingItem item, List<ClothingItem> storedList)
        {
            ClothingItem clothingItem = new();
            storedList.Add(new ClothingItem() { Type = item.Type, Size = item.Size, Color = item.Color, ClothingId = item.ClothingId, Image = item.Image, LentOut = item.LentOut, OwnerId = item.OwnerId});
            GetAll(storedList);
        }

        public List<ClothingItem> GetAll(List<ClothingItem> storedList)
        {
            return storedList;
        }

        public void LentOutClothingItem(ClothingItem item, List<ClothingItem> storedList)
        {
            item.LentOut = true;
            storedList.RemoveAll(c => c.ClothingId == item.ClothingId);
            storedList.Add(item);
        }

        public void RemoveClothingItem(ClothingItem item, List<ClothingItem> storedList)
        {
            storedList.RemoveAll(c => c.ClothingId == item.ClothingId);
            GetAll(storedList);
        }
    }
}
