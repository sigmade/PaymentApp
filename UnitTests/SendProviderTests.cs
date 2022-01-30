using Application;
using Domain.Dto;
using Shared.Translations.Exceptions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class SendProviderTests
    {
        private readonly PaymentService PaymentService = new();

        [Fact]
        public async void Send_To_Beeline()
        {
            //Arrange
            var payment705 = new PaymentDto { Phone = new("+77058774213"), Amount = new(100) };
            var payment777 = new PaymentDto { Phone = new("+77778774213"), Amount = new(100) };

            var successMesage = "Beeline success";

            //Act
            var result705 = await PaymentService.SendToProvider(payment705, new CancellationToken());
            var result777 = await PaymentService.SendToProvider(payment777, new CancellationToken());

            //Assert
            Assert.Equal(successMesage, result705);
            Assert.Equal(successMesage, result777);
        }

        [Fact]
        public async void Send_To_Active()
        {
            //Arrange
            var payment701 = new PaymentDto { Phone = new("+77018774213"), Amount = new(100) };
            var successMesage = "Active success";

            //Act
            var result701 = await PaymentService.SendToProvider(payment701, new CancellationToken());

            //Assert
            Assert.Equal(successMesage, result701);
        }

        [Fact]
        public async void Send_To_Altel()
        {
            //Arrange
            var payment700 = new PaymentDto { Phone = new("+77008774213"), Amount = new(100) };
            var payment708 = new PaymentDto { Phone = new("+77088774213"), Amount = new(100) };

            var successMesage = "Altel success";

            //Act
            var result700 = await PaymentService.SendToProvider(payment700, new CancellationToken());
            var result708 = await PaymentService.SendToProvider(payment708, new CancellationToken());

            //Assert
            Assert.Equal(successMesage, result700);
            Assert.Equal(successMesage, result708);
        }

        [Fact]
        public async void Send_To_Tele2()
        {
            //Arrange
            var payment707 = new PaymentDto { Phone = new("+77078774213"), Amount = new(100) };
            var payment747 = new PaymentDto { Phone = new("+77478774213"), Amount = new(100) };

            var successMesage = "Tele2 success";

            //Act
            var result707 = await PaymentService.SendToProvider(payment707, new CancellationToken());
            var result747 = await PaymentService.SendToProvider(payment747, new CancellationToken());

            //Assert
            Assert.Equal(successMesage, result707);
            Assert.Equal(successMesage, result747);
        }

        [Fact]
        public async Task Throws_Exception_When_Send_Unknown_Provider()
        {
            //Arrange
            var payment = new PaymentDto { Phone = new("+77998774213"), Amount = new(100) };

            //Act - Assert
            await Assert.ThrowsAsync<TranslatableException>(async () =>
                await PaymentService.SendToProvider(payment, new CancellationToken()));
        }
    }
}
