﻿using Bootcamp.API.BusinessLogic.Services;
using Bootcamp.API.BusinessLogic.Services.Master;
using Bootcamp.API.DataAccess.Model;
using Bootcamp.API.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace Bootcamp.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SuppliersController : ApiController
    {
        private readonly ISupplierService _supplierService;
        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        // GET: api/Suppliers
        //public JsonResult<IEnumerable<Supplier>> Get()
        //{
          //  IEnumerable<Supplier> getSupplier = _supplierService.Get().Select(x => new Supplier
            //{
              //  Id = x.Id,
               // Name = x.Name
            //}).ToArray();
            //return Json(getSupplier);
        //}
        public IEnumerable<Supplier> Get()
        {
            return _supplierService.Get();
        }

        // GET: api/Suppliers/5
        public Supplier Get(int id)
        {
            var getSupplierId = _supplierService.Get(id);
            return getSupplierId;
        }

        [HttpPost]
        // POST: api/Suppliers
        public void Post(SupplierParam supplierParam)
        {
            _supplierService.Insert(supplierParam);
        }

        // PUT: api/Suppliers/5
        public void Put(int id, SupplierParam supplierParam)
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
