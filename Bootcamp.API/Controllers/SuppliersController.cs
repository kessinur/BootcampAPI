using BusinessLogic.Services;
using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Bootcamp.API.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class SuppliersController : ApiController
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        // GET: api/Suppliers
        public IEnumerable<Supplier> Get()
        {
            var getData = _supplierService.Get();
            return getData;
        }

        // GET: api/Suppliers/5
        public Supplier Get(int id)
        {
            var getData = _supplierService.Get(id);
            return getData;
        }

        // POST: api/Suppliers
        public void Post([FromBody]SupplierParam supplierParam)
        {
            _supplierService.Insert(supplierParam);
        }

        // PUT: api/Suppliers/5
        public void Put(int id, [FromBody]SupplierParam supplierParam)
        {
            _supplierService.Update(id, supplierParam);
        }

        // DELETE: api/Suppliers/5
        public void Delete(int id)
        {
            _supplierService.Delete(id);
        }
    }
}
