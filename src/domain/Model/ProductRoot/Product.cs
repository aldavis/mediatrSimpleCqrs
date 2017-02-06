using System;

namespace domain.Model.ProductRoot
{
    public class Product:IEntity<int>
    {

        public Product(string partNumber,decimal price,string description = null,int currentInventoryCount = 0,int inventoryReorderThreshold = 0,int onOrderCount = 0)
        {
            PartNumber = partNumber;
            Price = price;
            Description = description;
            CurrentInventoryCount = currentInventoryCount;
            InventoryReorderThreshold = inventoryReorderThreshold;
            OnOrderCount = onOrderCount;
        }

        protected Product() { }

        public int Id { get; set; }

        public string PartNumber { get; private set; }

        public string Description { get; private set; }

        public int CurrentInventoryCount { get; private set; }

        public int InventoryReorderThreshold { get; private set; }

        public int OnOrderCount { get; private set; }

        public decimal Price { get; private set; }

        public bool Available(int requestedQty)
        {
            return CurrentInventoryCount > InventoryReorderThreshold;
        }

        public bool CanFulfillBackOrder(int requestedQty)
        {
            return CurrentInventoryCount > (InventoryReorderThreshold + OnOrderCount);
        }

        public void AdjustCurrentInventory(int quantity)
        {
            if ((CurrentInventoryCount + quantity) < 0)
            {
                throw new Exception("Cannot have negative inventory count");
            }

            CurrentInventoryCount += quantity;
        }

        public void AdjustInventoryReOrderThreshold(int quantity)
        {
            if ((InventoryReorderThreshold + quantity) < 0)
            {
                throw new Exception("Cannot have negative inventory re-order threshold");
            }

            InventoryReorderThreshold += quantity;
        }

        public void AdjustOnOrderCount(int quantity)
        {
            if ((CurrentInventoryCount + quantity) < 0)
            {
                throw new Exception("Cannot have negative on order count");
            }

            OnOrderCount += quantity;
        }
    }
}
