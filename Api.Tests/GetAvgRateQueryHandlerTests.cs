using API.Application.Queries;
using API.Application.Queries.GetAvg;
using API.Domain.Common;
using API.Domain.DTOs;
using API.Domain.Interfaces;
using FluentAssertions;
using MediatR;
using Moq;

namespace Api.Tests;

public class GetAvgRateQueryHandlerTests
{
    [Fact]
    public async Task ValidRequest_ShouldReturnAvgRate()
    {
        //Arrange
        var mockMediator = new Mock<IMediator>();
        var mockRepo = new Mock<IRepository>();

        var fakeExchangeRate = new ExchangeRate()
        {
            Code = "EUR",
            Currency = "euro",
            Table = "A",
            Rates = new List<Rate>()
            {
                new Rate() { No = "1", EffectiveDate = DateTime.Now, mid = 5 },
                new Rate() { No = "2", EffectiveDate = DateTime.Now.AddDays(-1), mid = 10 },
                new Rate() { No = "2", EffectiveDate = DateTime.Now.AddDays(-2), mid = 15 }
            }
        };

        var fakeResult = new OperationResult<ExchangeRate>
        {
            Data = new ExchangeRate()
            {
                Code = fakeExchangeRate.Code,
                Currency = fakeExchangeRate.Currency,
                Table = fakeExchangeRate.Table,
                Rates = fakeExchangeRate.Rates
            }
        };

        var dto = new GetExchangeRatesRequestDto()
        {
            Code = fakeExchangeRate.Code,
            Days = fakeExchangeRate.Rates.Count.ToString(),
            Table = fakeExchangeRate.Table
        };
        
        mockMediator.Setup(x => x.Send(It.IsAny<GetAllRatesQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(fakeResult);
        
        var handler = new GetAvgRateQueryHandler(mockMediator.Object);
        
        //Act

        var result = await handler.Handle(new GetAvgRateQuery(dto), CancellationToken.None);

        //Assert
        result.ErrorsList.Should().BeEmpty();
        result.Success.Should().BeTrue();
        result.Data.Code.Should().Be(fakeExchangeRate.Code);
        result.Data.Currency.Should().Be(fakeExchangeRate.Currency);
        result.Data.Table.Should().Be(fakeExchangeRate.Table);
        result.Data.Average.Should().Be(10);
        result.Data.Rate.Should().Be(fakeExchangeRate.Rates[1]);
    }
}