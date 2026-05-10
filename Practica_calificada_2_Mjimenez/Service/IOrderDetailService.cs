using Practica_calificada_2_Mjimenez.Models;

namespace Practica_calificada_2_Mjimenez.Service;

public interface IOrderDetailService
{
    public int GetNumberOfProductsByOrderId(int orderId);
    
}