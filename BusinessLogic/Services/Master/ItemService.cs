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
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        bool status = false;
        public bool Delete(int? Id)
        {
            var getId = Get(Id);
            if (getId != null)
            {
                _itemRepository.Delete(Id);
                status = true;
            }
            return status;
        }

        public List<Item> Get()
        {
            return _itemRepository.Get();
        }

        public Item Get(int? Id)
        {
            return _itemRepository.Get(Id);
        }

        public bool Insert(ItemParam itemParam)
        {
            _itemRepository.Insert(itemParam);
            return status = true;
        }

        public bool Update(int? Id, ItemParam itemParam)
        {
            _itemRepository.Update(Id, itemParam);
            return status = true;
        }
    }
}
