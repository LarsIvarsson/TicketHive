using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketHive.Shared.Models
{
   
    public class CartItemsModel
    {
        public int EventId { get; set; }
        public string? EventName { get; set; }//
        public int Price { get; set; }//

        //public int TotalPrice => Quantity * Event.Price;
        public EventModel Event { get; set; }
        public int Quantity { get; set; }

    }
}
