using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Param;
using DataAccess.Context;

namespace Common.Interfaces.Master
{
    public class ItemRepository : IItemRepository
    {
        MyContext myContext = new MyContext();
        Item item = new Item();
        bool status;

        public bool Delete(int? Id)
        {
            var result = 0;
            Item getItem = Get(Id);
            getItem.IsDelete = true;
            getItem.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Item> Get()
        {
            var getItems = myContext.Items.Where(x => x.IsDelete == false).ToList();
            return getItems;
        }

        public Item Get(int? Id)
        {
            var getItem = myContext.Items.Find(Id);
            return getItem;
        }

        public bool Insert(ItemParam itemParam)
        {
            var result = 0;
            item.Name = itemParam.Name;
            item.Price = itemParam.Price;
            item.Stock = itemParam.Stock;
            item.Suppliers = myContext.Suppliers.Find(itemParam.Suppliers_Id);
            item.CreateDate = DateTimeOffset.Now.LocalDateTime;
            item.IsDelete = false;
            myContext.Items.Add(item);
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(int? Id, ItemParam itemParam)
        {
            var result = 0;
            Item getItem = Get(Id);
            getItem.Name = itemParam.Name;
            getItem.Price = itemParam.Price;
            getItem.Stock = itemParam.Stock;
            getItem.Suppliers = myContext.Suppliers.Find(itemParam.Suppliers_Id);
            getItem.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
