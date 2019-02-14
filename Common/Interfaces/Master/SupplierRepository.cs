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
    public class SupplierRepository : ISupplierRepository
    {
        MyContext myContext = new MyContext();
        Supplier supplier = new Supplier();
        bool status = false;
        public bool Delete(int? Id)
        {
            var result = 0;
            Supplier getSupplier = Get(Id);
            getSupplier.IsDelete = true;
            getSupplier.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();

            if(result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Supplier> Get()
        {
            var getSupplier = myContext.Suppliers.Where(x => x.IsDelete == false).ToList();
            return getSupplier;
        }

        public Supplier Get(int? Id)
        {
            var getSupplier = myContext.Suppliers.Find(Id);
            return getSupplier;
        }

        public bool Insert(SupplierParam supplierParam)
        {
            var result = 0;
            supplier.Name = supplierParam.Name;
            supplier.JoinDate = supplierParam.JoinDate;
            supplier.CreateDate = DateTimeOffset.Now.LocalDateTime;
            supplier.IsDelete = false;
            myContext.Suppliers.Add(supplier);
            result = myContext.SaveChanges();

            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(int? Id, SupplierParam supplierParam)
        {
            var result = 0;
            Supplier getSupplier = Get(Id);
            getSupplier.Name = supplierParam.Name;
            getSupplier.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();

            if(result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
