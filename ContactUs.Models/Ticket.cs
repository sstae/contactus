using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactUs.Models {
    public class Ticket {

        public string Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime LastActivityDate { get; set; }
        public string LastActivityByUser { get; set; }
        public TicketStatus Status { get; protected set; }

        public void Accept() {
            if (CanChangeTo(TicketStatus.Accepted))
            Status = TicketStatus.Accepted;
        }

        public void Close() {
            if (CanChangeTo(TicketStatus.Closed))
                Status = TicketStatus.Closed;
        }

        public void Reject() {
            if (CanChangeTo(TicketStatus.Rejected))
                Status = TicketStatus.Rejected;
        }
        public void ReOpen() {
            if (CanChangeTo(TicketStatus.Rejected))
                Status = TicketStatus.Rejected;
        }

        public void ChangeTo(TicketStatus toStatus) {
            if (CanChangeTo(toStatus))
                Status = toStatus;
        }
        public bool CanChangeTo(TicketStatus toStatus) {
            switch (Status) {
                case TicketStatus.New:
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
                case TicketStatus.Accepted:
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
                case TicketStatus.Closed:
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
                case TicketStatus.Rejected:
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
                default:
                    return false;
            }
        }
    }
}
