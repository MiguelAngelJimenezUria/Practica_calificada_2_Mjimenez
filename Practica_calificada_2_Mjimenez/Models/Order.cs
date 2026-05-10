using System;
using System.Collections.Generic;

namespace Practica_calificada_2_Mjimenez.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int ClientId { get; set; }

    public DateTime OrderDate { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();
}
