﻿using DataAccess.Model;
using DataAccess.Param;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IItemService
    {
        bool Insert(ItemParam itemParam);
        bool Update(int? Id, ItemParam itemParam);
        bool Delete(int? Id);
        List<Item> Get();
        Item Get(int? Id);
    }
}
