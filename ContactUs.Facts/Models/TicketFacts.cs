using ContactUs.Models;
using ContactUs.Models.States;
using ContactUs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContactUs.Facts.Models {
    public class TicketFacts {
        public class ChangingStatus {
            [Fact]
            public void NewTicket_ShouldBeNew() {
                var t = new Ticket();
                t.Title = "Test Ticket";
                t.Body = "Blah blah";
                Assert.True(t.Status == TicketStatus.New);
            }
            [Fact]
            public void NewTicket_ableToChangeToAcceptedOrRejected_ButNotClosed() {
                var t = new Ticket();
                t.Title = "Test Ticket";
                t.Body = "Blah blah";
                Assert.False(t.CanChangeTo(TicketStatus.New));
                Assert.True(t.CanChangeTo(TicketStatus.Accepted));
                Assert.True(t.CanChangeTo(TicketStatus.Rejected));
                Assert.False(t.CanChangeTo(TicketStatus.Closed));
            }
            [Fact]
            public void AcceptedTicket_ableToChangeToClosedOrRejected() {
                var t = new Ticket();
                t.Title = "Test Ticket";
                t.Body = "Blah blah";
                t.Accept();
                Assert.False(t.CanChangeTo(TicketStatus.New));
                Assert.False(t.CanChangeTo(TicketStatus.Accepted));
                Assert.True(t.CanChangeTo(TicketStatus.Rejected));
                Assert.True(t.CanChangeTo(TicketStatus.Closed));
            }
            [Fact]
            public void RejectedTicket_CannotChangeStatusAnymore() {
                var t = new Ticket();
                t.Title = "Test Ticket";
                t.Body = "Blah blah";
                t.Reject(reason:"Blah hhh");
                Assert.False(t.CanChangeTo(TicketStatus.New));
                Assert.False(t.CanChangeTo(TicketStatus.Accepted));
                Assert.False(t.CanChangeTo(TicketStatus.Rejected));
                Assert.False(t.CanChangeTo(TicketStatus.Closed));
            }
            [Fact]
            public void ClosedTicket_CannotChangeStatusAnymore() {
                var t = new Ticket();
                t.Title = "Test Ticket";
                t.Body = "Blah blah";
                t.Accept();
                t.Close();
                Assert.False(t.CanChangeTo(TicketStatus.New));
                Assert.True(t.CanChangeTo(TicketStatus.Accepted));
                Assert.False(t.CanChangeTo(TicketStatus.Rejected));
                Assert.False(t.CanChangeTo(TicketStatus.Closed));
            }
        }
        public class ChangStatus {
            [Fact]
            public void ChangeFromNewToAccepted() {
                var t = new Ticket();

                Assert.True(t.Status == TicketStatus.New);
                Assert.Equal(1, t.TicketStates.Count());

                t.Accept();

                Assert.True(t.Status == TicketStatus.Accepted);
                Assert.Equal(2, t.TicketStates.Count());
            }

            [Fact]
            public void ChangeFromNewToRejected() {
                var t = new Ticket();

                Assert.True(t.Status == TicketStatus.New);
                Assert.Equal(1, t.TicketStates.Count());

                t.Reject(reason: "test reject");

                Assert.True(t.Status == TicketStatus.Rejected);
                Assert.Equal(2, t.TicketStates.Count());

                var s2 = t.CurrentState as RejectedTicketState;
                Assert.Equal("test reject", s2.Reason);

            }

            
        }
    }
}
