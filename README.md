# TimeRegisterAPI

API to manage time reports for projects and customers.

## Description

API for creating and managing Customers, Projects and TimeReports. The API have HTTP calls configured with routing for some 
basic use cases. See Executing Program for descriptions of each call.

## Getting Started

The API will set up a small test database through the DataInitializer class. Just comment out line 20-22 in this class to skip setting up the test database.

### Dependencies

* Visual Studio 2022

### Installing

* The API and its code is free to use for anyone but please dont use it commercially without my consent.
* Conection string in appsettings.json might need some changes, probably not though. 

### Executing program
 These are the HTTP routes available:
 
 for Customers (/api/Customer):
* Index fetches all Customers
* Get one customer [HttpGet] Route: Id (int)
* Edit one Customer [HttpPut] Route: Id (int)
* Create a new Customer [HttpPost] 

for Projects (/api/Project):
* Index fetches all Projects
* Get one Project [HttpGet] Route: Id (int)
* Edit one Project [HttpPut] Route: Id (int)
* Create a new Project [HttpPost]
* Fetch all active Projects [HttpGet] Route: "ActiveProjects"
* Fetch all inactive Projects [HttpGet] Route: "FinishedProjects"

for TimeReports (/api/TimeReport):
* Index fetches all TimeReports
* Get one TimeReport [HttpGet] Route: Id (int)
* Edit one TimeReport [HttpPut] Route: Id (int)
* Create a new TimeReport [HttpPost]
* Fetch all unprocessed TimeReports [HttpGet] Route: "TimeRepNotProcessed"
* Fetch all processed TimeReports [HttpGet] Route: "TimeRepProcessed"
* Fetch all unprocessed timereports, grouped by project and with a total sum for invoice per project [HttpGet] Route: "GetUnprocessedInvoices"
```

```
