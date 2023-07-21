

using Banking.Domain;

namespace Banking.UnitTests.BusinessClock;

public class BusinessClockTests
{
    [Fact]
    public void WeAReClosedBeforeOpening()
    {
        // Given
        var stubbedClock = new Mock<ISystemTime>();
        stubbedClock.Setup(c => c.GetCurrent())
            .Returns(new DateTime(1969, 4, 20, 8, 59, 59));

        var clock = new RegularBusinessClock(stubbedClock.Object);

        // When / Then 
        Assert.False(clock.IsDuringBusinessHours());

    }
    [Fact]
    public void WeAreOpenAfterNine()
    {
        var stubbedClock = new Mock<ISystemTime>();
        stubbedClock.Setup(c => c.GetCurrent())
            .Returns(new DateTime(1969, 4, 20, 9, 00, 00));

        var clock = new RegularBusinessClock(stubbedClock.Object);

        // When / Then 
        Assert.True(clock.IsDuringBusinessHours());
    }
}

