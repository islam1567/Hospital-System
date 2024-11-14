using Hospital_Management_System.Cores.ApplicationDbContext;
using Hospital_Management_System.Cores.Dtos;
using Hospital_Management_System.Cores.Entities;
using Hospital_Management_System.Cores.Interfaces;

namespace Hospital_Management_System.Cores.Repos
{
    public class RoomRepo : IRepository<RoomsDto>
    {
        private readonly AppDbContext context;

        public RoomRepo(AppDbContext context)
        {
            this.context = context;
        }

        public List<RoomsDto> GetAll()
        {
            var result = context.Rooms.
                Select(e => new RoomsDto
                {
                    Id = e.Id,
                    Type = e.Type,
                    Floor_No = e.Floor_No,
                }).ToList();
            return result;
        }

        public RoomsDto GetById(string id)
        {
            var result = context.Rooms.
                 Select(e => new RoomsDto
                 {
                     Id = e.Id,
                     Type = e.Type,
                     Floor_No = e.Floor_No,
                 }).FirstOrDefault(e => e.Id == id);
            return result;
        }

        public void Add(RoomsDto entity)
        {
            var room = new Rooms
            {
                Id = entity.Id,
                Type = entity.Type,
                Floor_No = entity.Floor_No,
            };
            context.Rooms.Add(room);
            context.SaveChanges();
        }

        public void Update(string id, RoomsDto entity)
        {
            var room = context.Rooms.FirstOrDefault(x => x.Id == id);
            room.Id = entity.Id;
            room.Type = entity.Type;
            room.Floor_No = entity.Floor_No;
        }

        public void Delete(string id)
        {
            var room = context.Rooms.FirstOrDefault(x => x.Id == id);
            context.Remove(room);
            context.SaveChanges();
        }
        
    }
}
