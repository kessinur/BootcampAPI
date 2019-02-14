using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Param;
using Common.Interfaces;

namespace BusinessLogic.Services.Master
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
            var getId = Get(Id);
            if (getId != null)
            {
                _supplierRepository.Delete(Id);
                status = true;
            }
            return status;
        }

        public List<Supplier> Get()
        {
            return _supplierRepository.Get();
        }

        public Supplier Get(int? Id)
        {
            return _supplierRepository.Get(Id);
        }

        public bool Insert(SupplierParam supplierParam)
        {
            _supplierRepository.Insert(supplierParam);
            return status = true;
        }

        public bool Update(int? Id, SupplierParam supplierParam)
        {
            _supplierRepository.Update(Id, supplierParam);
            return status = true;
        }
    }
}
