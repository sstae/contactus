using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactUs.Models.States {
    public class ClosedTicketState :TicketState{
        public override TicketStatus Status {
            get { return TicketStatus.Closed; }
        }
        public ClosedTicketState()
            : base() {

        }
        public ClosedTicketState(Ticket ticket)
            : base(ticket) {

        }

        public override bool CanChangeTo(TicketStatus toStatus) {
            switch (toStatus) {
                case TicketStatus.New:
                    return false;
                case TicketStatus.Accepted:
                    return true;
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
