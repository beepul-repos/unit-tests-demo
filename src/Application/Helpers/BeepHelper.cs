namespace Application.Helpers;

public static class BeepHelper
{
    public static int GetCalculatedBeeps(decimal paymentAmount, decimal beepRate, int beepRateFactor)
    {
        return (int) Math.Truncate(paymentAmount / beepRate) * beepRateFactor;
    }
}