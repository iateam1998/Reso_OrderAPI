using AutoMapper;
using DataService.Model.Entity;
using DataService.Model.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.ServiceAPI
{
    public interface IRoomService : IBaseService<Room, RoomViewModel>
    {
        
    }

    public class RoomService : BaseService<Room, RoomViewModel>, IRoomService
    {
        private DbContext dbContext;
        public RoomService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public IEnumerable<RoomViewModel> GetAllRoomByStoreId(int terminalId)
        {
            return this.Get(g => g.IsDeleted == false && g.Category.StoreId == terminalId);
        }

        public bool UpdateStatusRoom(RoomViewModel room)
        {
            try
            {
                this.Update(room);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
