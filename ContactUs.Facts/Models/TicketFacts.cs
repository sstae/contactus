using ContactUs.Models;
using ContactUs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContactUs.Facts.Models {
    public class TicketFacts {
        // 1. NewTicketStatus_ShouldBeNew
        // 2. NewTicket_AbleToChangeToAcceptedAndRejected_ButNotClosed
        // 3. AcceptedTicket_AbleToChangeToClosedOrRejected
        // 4. RejectedAndClosedTicket_CannotChangeStatusAnymore
        public class Ticket_Status {
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
                t.Reject();
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
    }
}
