using Application.Helpers;

namespace Application.UnitTests.Helpers;

public class BeepHelperTests
{
    [Fact]
    public void GetCalculatedBeeps_WhenValidInputs_ShouldReturnValidResult()
    {
        // Arrange
        decimal paymentAmount = 10000;
        decimal beepRate = 1000; // 10
        int beepRateFactor = 2; // 20

        int expectedBeeps = 20;

        // Act
        var result = BeepHelper.GetCalculatedBeeps(paymentAmount, beepRate, beepRateFactor);

        // Assert
        Assert.Equal(expectedBeeps, result);
    }
    
    [Theory]
    [InlineData(10000, 1000, 2, 20)]
    [InlineData(1000, 2000, 2, 0)]
    public void GetCalculatedBeeps_WhenInlineInputs_ShouldReturnValidResult(
        decimal paymentAmount, 
        decimal beepRate, 
        int beepRateFactor,
        int expectedBeeps
        )
    {
        // Act
        var result = BeepHelper.GetCalculatedBeeps(paymentAmount, beepRate, beepRateFactor);

        // Assert
        Assert.Equal(expectedBeeps, result);
    }
}