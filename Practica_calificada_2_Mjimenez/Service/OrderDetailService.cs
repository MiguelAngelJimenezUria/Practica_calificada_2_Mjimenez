using Practica_calificada_2_Mjimenez.Repository;

namespace Practica_calificada_2_Mjimenez.Service;

public class OrderDetailService: IOrderDetailService 
{
 private   readonly IUnitOfWork _unitOfWork;

    public OrderDetailService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public int GetNumberOfProductsByOrderId(int orderId) {
        var orderDetails = _unitOfWork.Orderdetail.FindAsync(od => od.OrderId == orderId).Result;
        return orderDetails.Count();
     
    }
}