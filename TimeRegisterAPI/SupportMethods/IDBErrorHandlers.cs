namespace TimeRegisterAPI.SupportMethods;

public interface IDBErrorHandlers
{
    public bool ProjectIdExists(int id);
    public bool TimeRepIdExists(int id);
    public bool CustomerIdExists(int id);
}