﻿using Bootcamp.API.DataAccess.Model;
using Bootcamp.API.DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.API.Common.Interfaces
{
    public interface ISupplierRepository
    {
        bool Insert(SupplierParam supplierParam);
        bool Update(int? Id, SupplierParam supplierParam);
        bool Delete(int? Id);
        List<Supplier> Get();
        Supplier Get(int? Id);
    }
}
