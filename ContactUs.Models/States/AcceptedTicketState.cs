using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactUs.Models.States {
    public class AcceptedTicketState : TicketState {
        public override TicketStatus Status {
            get { return TicketStatus.Accepted; }
        }
        public AcceptedTicketState()
            : base() {

        }
        public AcceptedTicketState(Ticket ticket)
            : base(ticket) {

        }

        public override bool CanChangeTo(TicketStatus toStatus) {
            switch (toStatus) {
                case TicketStatus.New:
                    return false;
                case TicketStatus.Accepted:
                    return false;
                case TicketStatus.Rejected:
                    return true;
                case TicketStatus.Closed:
                    return true;
                default:
                    return false;
            }
        }
    }
}
