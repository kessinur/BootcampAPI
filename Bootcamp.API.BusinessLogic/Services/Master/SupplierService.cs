using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp.API.DataAccess.Model;
using Bootcamp.API.DataAccess.Param;
using Bootcamp.API.Common.Interfaces;
using Bootcamp.API.Common.Interfaces.Master;

namespace Bootcamp.API.BusinessLogic.Services.Master
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        bool status = false;
        public bool Delete(int? Id)
        {
            if (string.IsNullOrEmpty(Id.ToString()) == true)
            {
                Console.WriteLine("Please Insert Supplier Id");
                Console.Read();
            }
            else if (string.IsNullOrWhiteSpace(Id.ToString()) == true)
            {
                Console.WriteLine("Don't insert blank character");
                Console.Read();
            }
            else
            {
                status = _supplierRepository.Delete(Id);
                Console.WriteLine("Delete Successfully");
                Console.Read();
            }
            return status;
        }

        public List<Supplier> Get()
        {
            return _supplierRepository.Get();
        }

        public Supplier Get(int? Id)
        {
            var getSupplierId = _supplierRepository.Get(Id);
            if (getSupplierId == null)
            {
                Console.WriteLine("Please Insert Supplier Id");
                Console.Read();
            }
            return getSupplierId;
        }

        public bool Insert(SupplierParam supplierParam)
        {
            if (string.IsNullOrEmpty(supplierParam.ToString()) == true)
            {
                Console.WriteLine("Please Insert Supplier");
                Console.Read();
            }
            if (string.IsNullOrWhiteSpace(supplierParam.ToString()) == true)
            {
                Console.WriteLine("Don't insert blank character");
                Console.Read();
            }
            else
            {
                status = _supplierRepository.Insert(supplierParam);
                Console.WriteLine("Insert Succesfully");
                Console.Read();
            }
            return status;
        }

        public bool Update(int? Id, SupplierParam supplierParam)
        {
            if (string.IsNullOrEmpty(Id.ToString()) == true)
            {
                Console.WriteLine("Please Insert Supplier Id");
                Console.Read();
            }
            if (string.IsNullOrWhiteSpace(Id.ToString()) == true)
            {
                Console.WriteLine("Don't insert blank character");
                Console.Read();
            }
            else
            {
                status = _supplierRepository.Update(Id, supplierParam);
                Console.WriteLine("Update Succesfully");
                Console.Read();
            }
            return status;
        }
    }
}
