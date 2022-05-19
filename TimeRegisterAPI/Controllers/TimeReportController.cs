using Microsoft.AspNetCore.Mvc;
using TimeRegisterAPI.SupportMethods;

namespace TimeRegisterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeReportController : ControllerBase
    {
        private readonly IDbObjectMethods _objectMethods;
        private readonly IDTOreturner _dtoReturner;

        public TimeReportController(IDTOreturner dtoReturner, IDbObjectMethods objectMethods)
        {
            _objectMethods = objectMethods;
            _dtoReturner = dtoReturner;
        }




        
        
    }
}
