// Controller/SmoketestController.cs
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Net;
using AZF2S_Backend.Service.ThirdParty.Interface;
using AZF2S_Backend.Model;
using Microsoft.Extensions.Logging;

namespace AZF2S_Backend.Controller;

public class SmoketestController(
    IAppInsightsService appInsights,
    IMongoDbService mongoDb,
    IGoogleSheetService googleSheet,
    IMailchimpService mailchimp,
    INodeBbService nodeBb,
    ISendInBlueService sendInBlue,
    ILogger<SmoketestController> logger)
{
    private readonly IAppInsightsService _appInsights = appInsights;
    private readonly IMongoDbService _mongoDb = mongoDb;
    private readonly IGoogleSheetService _googleSheet = googleSheet;
    private readonly IMailchimpService _mailchimp = mailchimp;
    private readonly INodeBbService _nodeBb = nodeBb;
    private readonly ISendInBlueService _sendInBlue = sendInBlue;
    private readonly ILogger<SmoketestController> _logger = logger;

    [Function("SmoketestAll")]
    public async Task<HttpResponseData> RunAllSmoketests(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "smoketest/all")] HttpRequestData req)
    {
        _logger.LogInformation("Starting all smoke tests");
        
        var response = req.CreateResponse(HttpStatusCode.OK);
        var results = new Dictionary<string, Task<ServiceResponse<bool>>>
        {
            { "AppInsights", _appInsights.SmoketestAsync() },
            { "MongoDB", _mongoDb.SmoketestAsync() },
            { "GoogleSheets", _googleSheet.SmoketestAsync() },
            { "MailChimp", _mailchimp.SmoketestAsync() },
            { "NodeBB", _nodeBb.SmoketestAsync() },
            { "SendInBlue", _sendInBlue.SmoketestAsync() }
        };

        await Task.WhenAll(results.Values);

        var smokeTestResults = new Dictionary<string, ServiceResponse<bool>>();
        foreach (var result in results)
        {
            smokeTestResults.Add(result.Key, await result.Value);
        }

        await response.WriteAsJsonAsync(smokeTestResults);
        return response;
    }

    [Function("SmoketestAppInsights")]
    public async Task<HttpResponseData> RunAppInsightsSmoketest(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "smoketest/appinsights")] HttpRequestData req)
    {
        _logger.LogInformation("Starting AppInsights smoke test");
        var response = req.CreateResponse(HttpStatusCode.OK);
        var result = await _appInsights.SmoketestAsync();
        await response.WriteAsJsonAsync(result);
        return response;
    }

    [Function("SmoketestMongoDB")]
    public async Task<HttpResponseData> RunMongoDBSmoketest(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "smoketest/mongodb")] HttpRequestData req)
    {
        _logger.LogInformation("Starting MongoDB smoke test");
        var response = req.CreateResponse(HttpStatusCode.OK);
        var result = await _mongoDb.SmoketestAsync();
        await response.WriteAsJsonAsync(result);
        return response;
    }

    [Function("SmoketestGoogleSheets")]
    public async Task<HttpResponseData> RunGoogleSheetsSmoketest(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "smoketest/googlesheets")] HttpRequestData req)
    {
        _logger.LogInformation("Starting Google Sheets smoke test");
        var response = req.CreateResponse(HttpStatusCode.OK);
        var result = await _googleSheet.SmoketestAsync();
        await response.WriteAsJsonAsync(result);
        return response;
    }

    [Function("SmoketestMailChimp")]
    public async Task<HttpResponseData> RunMailChimpSmoketest(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "smoketest/mailchimp")] HttpRequestData req)
    {
        _logger.LogInformation("Starting MailChimp smoke test");
        var response = req.CreateResponse(HttpStatusCode.OK);
        var result = await _mailchimp.SmoketestAsync();
        await response.WriteAsJsonAsync(result);
        return response;
    }

    [Function("SmoketestNodeBB")]
    public async Task<HttpResponseData> RunNodeBBSmoketest(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "smoketest/nodebb")] HttpRequestData req)
    {
        _logger.LogInformation("Starting NodeBB smoke test");
        var response = req.CreateResponse(HttpStatusCode.OK);
        var result = await _nodeBb.SmoketestAsync();
        await response.WriteAsJsonAsync(result);
        return response;
    }

    [Function("SmoketestSendInBlue")]
    public async Task<HttpResponseData> RunSendInBlueSmoketest(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "smoketest/sendinblue")] HttpRequestData req)
    {
        _logger.LogInformation("Starting SendInBlue smoke test");
        var response = req.CreateResponse(HttpStatusCode.OK);
        var result = await _sendInBlue.SmoketestAsync();
        await response.WriteAsJsonAsync(result);
        return response;
    }
}