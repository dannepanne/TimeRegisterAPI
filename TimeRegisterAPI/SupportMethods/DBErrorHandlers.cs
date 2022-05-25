using TimeRegisterAPI.Data;

namespace TimeRegisterAPI.SupportMethods;

public class DBErrorHandlers : IDBErrorHandlers
{
    private readonly ApplicationDbContext _context;

    public DBErrorHandlers(ApplicationDbContext context)
    {
        _context = context;
    }

    public bool ProjectIdExists(int id)
    {
        if (_context.Projects.FirstOrDefault(e => e.Id == id) != null)
            return true;
        return false;
    }

    public bool TimeRepIdExists(int id)
    {
        if (_context.TimeReports.FirstOrDefault(e => e.Id == id) != null)
            return true;
        return false;
    }

    public bool CustomerIdExists(int id)
    {
        if (_context.Customers.FirstOrDefault(e => e.Id == id) != null)
            return true;
        return false;
    }
}