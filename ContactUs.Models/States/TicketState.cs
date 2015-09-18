using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactUs.Models.States {
    public abstract class TicketState {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        [InverseProperty("TicketStates")]
        public virtual Ticket Ticket { get; set; }
        public virtual bool CanChangeTo(TicketStatus toStatus) {
            return false;
        }

        public abstract TicketStatus Status { get; }

        public TicketState(Ticket ticket) {
            this.Ticket = ticket;
            this.Date = DateTime.Now;
        }

        public TicketState(): this(null) {

        }


    }
}
