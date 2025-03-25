namespace APBD_D_Cw2_s31218.Exceptions;

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message) { }
    public OverfillException(string message, Exception inner) : base(message, inner) { }
}