﻿

namespace StringCalculatorKata;

public class StringCalculatorInteractions
{
    [Theory]
    [InlineData("15", "15")]
    [InlineData("1,2", "3")]
    public void ResultsAreLogged(string numbers, string expectedToBeLogged)
    {
        var loggerMock = new Mock<ILogger>();
        var mockedWebService = new Mock<IWebService>();
        var calculator = new StringCalculator(loggerMock.Object, mockedWebService.Object);

        calculator.Add(numbers);


        loggerMock.Verify(logger => logger.Log(expectedToBeLogged));
        mockedWebService.Verify(m => m.NotifyOfLoggerFailure(It.IsAny<string>()), Times.Never);


    }

    [Fact]

    public void WebServiceIsCalledOnLoggerFailure()
    {
        // Given
        var loggerStub = new Mock<ILogger>();
        var mockedWebService = new Mock<IWebService>();
        var calculator = new StringCalculator(loggerStub.Object, mockedWebService.Object);
        loggerStub.Setup(m => m.Log(It.IsAny<string>()))
            .Throws<CalculatorLoggerException>();



        // When
        calculator.Add("1");



        // ??
      
        mockedWebService.Verify(m => m.NotifyOfLoggerFailure("Blammo!"), Times.Once);
    }
}

