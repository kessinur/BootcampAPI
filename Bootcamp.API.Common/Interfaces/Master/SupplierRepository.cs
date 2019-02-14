using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp.API.DataAccess.Model;
using Bootcamp.API.DataAccess.Param;
using Bootcamp.API.DataAccess.Context;

namespace Bootcamp.API.Common.Interfaces.Master
{
    public class SupplierRepository : ISupplierRepository
    {
        MyContext myContext = new MyContext();

        public bool Delete(int? Id)
        {
            var result = 0;
            Supplier supplier = Get(Id);

            supplier.IsDelete = true;
            supplier.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Supplier> Get()
        {
            var get = myContext.Suppliers.Where(x => x.IsDelete == false).ToList();
            return get;
        }

        public Supplier Get(int? Id)
        {
            var get = myContext.Suppliers.Find(Id);
            return get;
        }

        public bool Insert(SupplierParam supplierParam)
        {
            var result = 0;
            var supplier = new Supplier();
            supplier.Name = supplierParam.Name;
            supplier.CreateDate = DateTimeOffset.Now.LocalDateTime;
            supplier.JoinDate = DateTimeOffset.Now.LocalDateTime;
            myContext.Suppliers.Add(supplier);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(int? Id, SupplierParam supplierParam)
        {

            var result = 0;
            Supplier supplier = Get(Id);
            supplier.Name = supplierParam.Name;
            supplier.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            myContext.Entry(supplier).State = System.Data.Entity.EntityState.Modified;
            myContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
