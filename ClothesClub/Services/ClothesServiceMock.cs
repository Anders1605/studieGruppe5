using System.Reflection.Metadata;
using System.Threading.Tasks;
using ClothesClub.Interfaces;
using core;
//using Blazored.LocalStorage.ILocalStorageService localStore;

namespace ClothesClub.Services
{
    public class ClothesServiceMock : IClothesService
    {
     
        public async Task AddClothingItem(ClothingItem item, List<ClothingItem> storedList)
        {
            ClothingItem clothingItem = new();
            storedList.Add(new ClothingItem() { Type = item.Type, Size = item.Size, Color = item.Color, ClothingId = item.ClothingId, Image = item.Image, LentOut = item.LentOut, OwnerId = item.OwnerId});
            storedList = await localStore.SetItemAsync<List<ClothingItem>>("ClothingStorage", storedList);
            GetAll(storedList);
        }

        public List<ClothingItem> GetAll(List<ClothingItem> storedList)
        {
            storedList = localStore.GetItemAsync<List<ClothingItem>>("ClothingStorage");
            if (storedList != null)
            {
                return storedList;
            } else
            {
                //Codepath mangler
            }
        }

        public void LentOutClothingItem(ClothingItem item, List<ClothingItem> storedList, List<ClothingItem> LentList)
        {
            item.LentOut = true;
            storedList.RemoveAll(c => c.ClothingId == item.ClothingId);
            storedList.Add(item);
            storedList = localStore.SetItemAsync<List<ClothingItem>>("ClothingStorage", storedList);
        }

        public void RemoveClothingItem(ClothingItem item, List<ClothingItem> storedList)
        {
            storedList.RemoveAll(c => c.ClothingId == item.ClothingId);
            GetAll(storedList);
        }
    }
}
