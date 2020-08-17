using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruYumPortal.Models;

namespace TruYumPortal.Helper
{
    interface IAdminInterface
    {
        public List<Items> GetAllItems();
        public void AddItem(Items item);
        public void UpdateItem(Items item);
        public Items GetItemById(int? id);

        public void DeleteItem(int id);
    }
}
