using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactUs.Models.States {
    [Table("RejectedTicketStates")]
    public class RejectedTicketState :TicketState {
        public string Reason { get; set; }
        public override TicketStatus Status {
            get { return TicketStatus.Rejected; }
        }
        public RejectedTicketState()
            : base() {

        }
        public RejectedTicketState(Ticket ticket)
            : base(ticket) {

        }

        public override bool CanChangeTo(TicketStatus toStatus) {
            switch (toStatus) {
                case TicketStatus.New:
                    return false;
                case TicketStatus.Accepted:
                    return false;
                case TicketStatus.Rejected:
                    return false;
                case TicketStatus.Closed:
                    return false;
                default:
                    return false;
            }
        }
    }
}
