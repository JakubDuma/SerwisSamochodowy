using ProjectCar.Data.Interface;
using ProjectCar.Services.DTO;

namespace ProjectCar.Services.Service
{
    internal class OrderStatusService
    {
        private readonly ITimetableRepository _timetableRepository;

        public OrderStatusService(ITimetableRepository timetableRepository)
        {
            _timetableRepository = timetableRepository;
        }
        public void Update(OrderStatusDTO status)
        {
            var order = _timetableRepository.Get(status.Id);
            order.ExecutionDate = status.ExecutionDate;
            order.Name = status.Name;
            order.Status = status.Status;
            _timetableRepository.Update(order);
        }
    }
}
