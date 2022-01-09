using Drugstore.Models;
using Drugstore.Repository.Interfaces;
using Drugstore.Service;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DrugstoreApiTests.Unit
{

    [Trait("Type", "UnitTest")]
    public class UsersNotificationsTests
    {
        [Theory]
        [MemberData(nameof(Notifications))]
        public void List_notifications_by_username(string username, List<Notification> expected)
        {
            //arrange
            var notificationService = new NotificationService(GenerateStubData());
            //act
            List<Notification> retVal = notificationService.GetUserNotification(username);
            //assert

            retVal.ShouldBe(expected);

        }

        public static IEnumerable<object[]> Notifications()
        {
            var retVal = new List<object[]>();
            retVal.Add(new object[] { "kupac", new List<Notification>() { new Notification(2, new DateTime(2021, 7, 7), "Novi lekovi", "Stigli su novi lekovi", new List<string> { "kupac" }), new Notification(3, new DateTime(2021, 8, 8), "Vazno obavestenje", "Obavestenje o promeni cena", new List<string> { "kupac", "farmaceut" }) } });
            retVal.Add(new object[] { "farmaceut", new List<Notification>() { new Notification(1, new DateTime(2021, 6, 6), "Uzbuna", "Aloaloalo", new List<string> { "farmaceut" }), new Notification(3, new DateTime(2021, 8, 8), "Vazno obavestenje", "Obavestenje o promeni cena", new List<string> { "kupac", "farmaceut" }) } });

            return retVal;
        }


        private static INotificationRepository GenerateStubData()
        {
            var notificationStubRepository = new Mock<INotificationRepository>();
            List<Notification> usersNotifications = new List<Notification>();

            usersNotifications.Add(new Notification(1, new DateTime(2021, 6, 6), "Uzbuna", "Aloaloalo", new List<string> { "farmaceut" }));
            usersNotifications.Add(new Notification(2, new DateTime(2021, 7, 7), "Novi lekovi", "Stigli su novi lekovi", new List<string> { "kupac" }));
            usersNotifications.Add(new Notification(3, new DateTime(2021, 8, 8), "Vazno obavestenje", "Obavestenje o promeni cena", new List<string> { "kupac", "farmaceut" }));

            notificationStubRepository.Setup(n => n.GetAll()).Returns(usersNotifications);

            return notificationStubRepository.Object;
        }
    }
}
