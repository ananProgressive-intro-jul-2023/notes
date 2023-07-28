
using EmployeeDirectoryApi.Models;

namespace EmployeeDirectoryApi.Controllers;

public class DeveloperLookup : ILookupOnCallDevelopers
{
    private readonly IProvideTheBusinessClock _businessClock;

    public DeveloperLookup(IProvideTheBusinessClock businessClock)
    {
        _businessClock = businessClock;
    }

    public async Task<OnCallDeveloperResponseModel> FindCurrentDeveloperAsync()
    {
        bool isDuringBusinessHours = _businessClock.AreWeOpen();
        OnCallDeveloperResponseModel response;
        if (isDuringBusinessHours)
        {
            response = new OnCallDeveloperResponseModel
            {
                Name = "Eli",
                PhoneNumber = "555-1212",
                Email = "eli@aol.com"
            };
        }
        else
        {
            response = new OnCallDeveloperResponseModel
            {
                Name = "Becky",
                PhoneNumber = "555-9999",
                Email = "becky@aol.com"
            };
        }

        return response;
    }
}