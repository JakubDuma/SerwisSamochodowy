using AutoMapper;
using ProjectCar.Data.Interface;
using ProjectCar.Services.DTO;
using ProjectCar.Services.Interface;

namespace ProjectCar.Services.Service
{
    internal class OrderStatusService : IOrderStatusService
    {
        private readonly ITimetableRepository _timetableRepository;
        private readonly IMapper _mapper;

        public OrderStatusService(ITimetableRepository timetableRepository, IMapper mapper)
        {
            _timetableRepository = timetableRepository;
            _mapper = mapper;
        }

        public List<TimetableDTO> GetWorkingOrders(string status)
        {
            var orders = _timetableRepository.GetWorkingOrders(status);
            return _mapper.Map<List<TimetableDTO>>(orders);
        }

        public void Update(OrderStatusDTO status)
        {
            var order = _timetableRepository.Get(status.Id);
            order.Part = status.PartId;
            order.ExecutionDate = status.ExecutionDate;
            order.Name = status.Name;
            order.Status = status.Status;
            _timetableRepository.Update(order);
        }
    }
}