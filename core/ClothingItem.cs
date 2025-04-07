namespace core
{
    public class ClothingItem
    {
        public string Type { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int ClothingId { get; set; }
        public bool LentOut { get; set; } = true;
        public int OwnerId { get; set; }

    }
}
