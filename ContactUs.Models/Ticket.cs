using ContactUs.Models.States;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Required]
        [InverseProperty("Ticket")]       
        public virtual ICollection<TicketState> TicketStates { get; set; }
        public TicketState CurrentState {
            get {
                return TicketStates
                  .OrderBy(t => t.Date)
                  .LastOrDefault();
            }
        }
        public Ticket() {
            TicketStates = new HashSet<TicketState>();
            TicketState toState = (new NewTicketState(this));
            TicketStates.Add(toState);
        }
        public TicketStatus Status {
            get { return CurrentState.Status; }
        }
        public void Accept() {
            ChangeTo(new AcceptedTicketState(this));
        }

        public void Close() {
            ChangeTo(new ClosedTicketState(this));
        }

        public void Reject(string reason) {
            var toState = new RejectedTicketState(this);
            toState.Reason = reason;
            ChangeTo(toState);
        }

        public void ReOpen() {
            ChangeTo(new AcceptedTicketState(this));
        }

        internal void ChangeTo(TicketState toState) {
            if (CurrentState.CanChangeTo(toState.Status)) {
                TicketStates.Add(toState);
            }
        }
        public bool CanChangeTo(TicketStatus toStatus) {
            return CurrentState.CanChangeTo(toStatus);
        }
    }
}
