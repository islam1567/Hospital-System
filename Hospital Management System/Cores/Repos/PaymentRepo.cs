using Hospital_Management_System.Cores.ApplicationDbContext;
using Hospital_Management_System.Cores.Dtos;
using Hospital_Management_System.Cores.Entities;
using Hospital_Management_System.Cores.Interfaces;

namespace Hospital_Management_System.Cores.Repos
{
    public class PaymentRepo : IRepository<PaymentDto>
    {
        private readonly AppDbContext context;

        public PaymentRepo(AppDbContext context)
        {
            this.context = context;
        }

        public List<PaymentDto> GetAll()
        {
            var result = context.Payments.
                Select(e => new PaymentDto
                {
                    Id = e.Id,
                    Amount = e.Amount,
                    Disease = e.Disease,
                }).ToList();
            return result;
        }

        public PaymentDto GetById(string id)
        {
            var result = context.Payments.
                Select(e => new PaymentDto
                {
                    Id = e.Id,
                    Amount = e.Amount,
                    Disease = e.Disease,
                }).FirstOrDefault(e => e.Id== id);
            return result;
        }
        public void Add(PaymentDto entity)
        {
            var payment = new Payment
            {
                Id = entity.Id,
                Amount = entity.Amount,
                Disease = entity.Disease
            };
            context.Payments.Add(payment);
            context.SaveChanges();
        }

        public void Update(string id, PaymentDto entity)
        {
            var patient = context.Payments.FirstOrDefault(x => x.Id == id);
            patient.Id = entity.Id;
            patient.Amount = entity.Amount;
            patient.Disease = entity.Disease;
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            var payment = context.Payments.FirstOrDefault(x => x.Id == id);
            context.Remove(payment);
            context.SaveChanges();
        }

    }
}
