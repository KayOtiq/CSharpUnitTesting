using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests

        /*
         * Reservations can be cancelled by either an admin user or the person who created the reservation
         * Else the user cannot cancel the reservation
         */
        
    {
        [Test]
        public void CanBeCancelledBy_AdminCancelling_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();

            //Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            //Assert
            Assert.IsTrue(result);
            Assert.That(result, Is.True);

        }
        [Test]
        public void CanBeCancelledBy_AntherUserCancelling_ReturnsFalse()
        {
            //Arrange
            //var user = new User();
            var reservation = new Reservation { MadeBy = new User() };


            //Act
            var result = reservation.CanBeCancelledBy(new User());

            //Assert
            Assert.IsFalse(result);

        }

        [Test]
        public void CanBeCancelledBy_SameUserCancelling_ReturnsTrue()
        {
            //Arrange
            
            var user = new User();  
            var reservation = new Reservation { MadeBy = user };
           

            //Act
            var result = reservation.CanBeCancelledBy(user);

            //Assert
            Assert.IsTrue(result);

        }
    }
}
