namespace EenJaarGratis.Common;

public class AppException : Exception
{
    public AppException(): base()
    {
    }
    
    public AppException(string message): base(message)
    {
        
    }
    public AppException(string message, Exception exception): base(message, exception)
    {
        
    }
    
}