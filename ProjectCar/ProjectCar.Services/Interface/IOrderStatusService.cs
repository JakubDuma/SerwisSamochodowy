using ProjectCar.Services.DTO;

namespace ProjectCar.Services.Interface
{
    public interface IOrderStatusService
    {
        void Update(OrderStatusDTO status);

        List<TimetableDTO> GetWorkingOrders(string status);
    }
}