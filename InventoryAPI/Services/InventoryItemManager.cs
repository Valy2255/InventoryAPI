using InventoryAPI.Context;
using InventoryAPI.Models;

namespace InventoryAPI.Services
{
    public class InventoryItemManager
    {
        private readonly InventoryContext inventoryContext;
        public InventoryItemManager()
        {
            inventoryContext=new InventoryContext();
        }

        public List<InventoryItem> GetInventoryItems()
        {
            return inventoryContext.InventoryItems.ToList();
        }

        public InventoryItem GetInventoryItem(int id)
        {
            return inventoryContext.InventoryItems.FirstOrDefault(i => i.Id == id);
        }
        public void AddItem(InventoryItem item)
        {
            inventoryContext.InventoryItems.Add(item);
            inventoryContext.SaveChanges();
        }
        public void UpdateItem(InventoryItem item)
        {
            var existingItem = inventoryContext.InventoryItems.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Name = item.Name;
                existingItem.Description = item.Description;
                existingItem.Location = item.Location;
                existingItem.ModifiedAt = DateTime.Now;
                existingItem.Deleted = item.Deleted;

                inventoryContext.InventoryItems.Update(existingItem);
                inventoryContext.SaveChanges();
            }
            else
            {
                throw new Exception("Item not found");
            }
        }
        public void RemoveItem(int id)
        {
            var item = inventoryContext.InventoryItems.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                inventoryContext.InventoryItems.Remove(item);
                inventoryContext.SaveChanges();
            }
            else
            {
                throw new Exception("Item not found");
            }
        }
    }
}
