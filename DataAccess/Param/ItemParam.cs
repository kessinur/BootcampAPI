using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Param
{
    public class ItemParam
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public int Suppliers_Id { get; set; }

        //public class ItemData : DataTableResult
        //{
        //  public List<ItemParam> data { get; set; }
        //}
    }
}
