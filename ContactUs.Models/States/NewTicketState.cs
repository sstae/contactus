using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactUs.Models.States {
    class NewTicketState : TicketState{
        public override TicketStatus Status {
            get { return TicketStatus.New; }
        }
        public NewTicketState()
            : base() {

        }
        public NewTicketState(Ticket ticket)
            : base(ticket) {

        }

        public override bool CanChangeTo(TicketStatus toStatus) {
            switch (toStatus) {
                case TicketStatus.New:
                    return false;
                case TicketStatus.Accepted:
                    return true;
                case TicketStatus.Rejected:
                    return true;
                case TicketStatus.Closed:
                    return false;
                default:
                    return false;
            }
        }
    }
}
