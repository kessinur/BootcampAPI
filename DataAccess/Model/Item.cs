using Core.BaseModel;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Item : BaseModel
    {
        //public Item(ItemParam itemParam)
        //{
        //    this.Id = itemParam.Id;
        //    this.Name = itemParam.Name;
        //    this.Price = itemParam.Price;
        //    this.Stock = itemParam.Stock;
        //    this.CreateDate = DateTimeOffset.UtcNow.LocalDateTime;
        //}

        //public Item()
        //{
        //}

        //public virtual void Update(int Id, ItemParam itemParam)
        //{
        //    this.Id = Id;
        //    this.Name = itemParam.Name;
        //    this.Price = itemParam.Price;
        //    this.Stock = itemParam.Stock;
        //    this.UpdateDate = DateTimeOffset.UtcNow.LocalDateTime;
        //}

        //public virtual void Delete()
        //{
        //    this.IsDelete = true;
        //    this.DeleteDate = DateTimeOffset.UtcNow.LocalDateTime;
        //}

        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public virtual Supplier Suppliers { get; set; }
    }
}
