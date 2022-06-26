namespace bankbackend
{
    public interface IJWTAuthentication
    {
        string Authenticate(string token);
    }

    
}
