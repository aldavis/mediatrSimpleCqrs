namespace domain.Model
{
    public class Product:IEntity<int>
    {
        public int Id { get; set; }

        public string PartNumber { get; set; }

        public string Description { get; set; }

        public int CurrentInventoryCount { get; set; }

        public int InventoryReorderThreshold { get; set; }

        public int OnOrderCount { get; set; }

        public decimal Price { get; set; }

        public bool Available(int requestedQty)
        {
            return CurrentInventoryCount > InventoryReorderThreshold;
        }

        public bool CanFulfillBackOrder(int requestedQty)
        {
            return CurrentInventoryCount > (InventoryReorderThreshold + OnOrderCount);
        }
    }
}
