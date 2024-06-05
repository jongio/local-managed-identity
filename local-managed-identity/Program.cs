using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Identity;
using Azure.ResourceManager;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .Build();

string? subscriptionId = builder["AZURE_SUBSCRIPTION_ID"];
if (string.IsNullOrEmpty(subscriptionId))
{
    Console.WriteLine("AZURE_SUBSCRIPTION_ID environment variable is not set.");
    return;
}
using AzureEventSourceListener listener =  AzureEventSourceListener.CreateConsoleLogger();

var credential = new ManagedIdentityCredential();
var client = new ArmClient(credential, subscriptionId);
var subscription = client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{subscriptionId}"));

Console.WriteLine("Listing resource groups in the subscription...");

await foreach (var resourceGroup in subscription.GetResourceGroups().GetAllAsync())
{
    Console.WriteLine($"Resource Group Name: {resourceGroup.Data.Name}");
}

Console.WriteLine("Listing completed.");