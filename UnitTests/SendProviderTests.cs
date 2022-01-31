using Application;
using Application.MoblieProviders;
using Application.Models;
using Domain.Models;
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
            var payment705 = new Payment { Phone = new("+77058774213"), Amount = new(100) };
            var payment777 = new Payment { Phone = new("+77778774213"), Amount = new(100) };

            var successResponse = new ProviderResponse { Provider = Provider.Beeline, Status = ResponseStatus.Success};

            //Act
            var result705 = await PaymentService.SendToProvider(payment705, new CancellationToken());
            var result777 = await PaymentService.SendToProvider(payment777, new CancellationToken());

            //Assert
            Assert.Equal(successResponse.Provider, result705.Provider);
            Assert.Equal(successResponse.Provider, result777.Provider);
            Assert.Equal(successResponse.Status, result705.Status);
            Assert.Equal(successResponse.Status, result777.Status);
        }

        [Fact]
        public async void Send_To_Active()
        {
            //Arrange
            var payment701 = new Payment { Phone = new("+77018774213"), Amount = new(100) };
            var successResponse = new ProviderResponse { Provider = Provider.Active, Status = ResponseStatus.Success };

            //Act
            var result701 = await PaymentService.SendToProvider(payment701, new CancellationToken());

            //Assert
            Assert.Equal(successResponse.Provider, result701.Provider);
            Assert.Equal(successResponse.Status, result701.Status);
        }

        [Fact]
        public async void Send_To_Altel()
        {
            //Arrange
            var payment700 = new Payment { Phone = new("+77008774213"), Amount = new(100) };
            var payment708 = new Payment { Phone = new("+77088774213"), Amount = new(100) };

            var successResponse = new ProviderResponse { Provider = Provider.Altel, Status = ResponseStatus.Success };

            //Act
            var result700 = await PaymentService.SendToProvider(payment700, new CancellationToken());
            var result708 = await PaymentService.SendToProvider(payment708, new CancellationToken());

            //Assert
            Assert.Equal(successResponse.Provider, result700.Provider);
            Assert.Equal(successResponse.Status, result708.Status);
        }

        [Fact]
        public async void Send_To_Tele2()
        {
            //Arrange
            var payment707 = new Payment { Phone = new("+77078774213"), Amount = new(100) };
            var payment747 = new Payment { Phone = new("+77478774213"), Amount = new(100) };

            var successResponse = new ProviderResponse { Provider = Provider.Tele2, Status = ResponseStatus.Success };

            //Act
            var result707 = await PaymentService.SendToProvider(payment707, new CancellationToken());
            var result747 = await PaymentService.SendToProvider(payment747, new CancellationToken());

            //Assert
            Assert.Equal(successResponse.Provider, result707.Provider);
            Assert.Equal(successResponse.Status, result747.Status);
        }

        [Fact]
        public async Task Throws_Exception_When_Send_Unknown_Provider()
        {
            //Arrange
            var payment = new Payment { Phone = new("+77998774213"), Amount = new(100) };

            //Act - Assert
            await Assert.ThrowsAsync<TranslatableException>(async () =>
                await PaymentService.SendToProvider(payment, new CancellationToken()));
        }
    }
}
