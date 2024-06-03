
# Local Managed Identity Solutions

This repo explores various solutions for enabling local development and testing of applications that rely on Azure Managed Identities. The solutions include a local IMDS service and a proxy for the Azure IMDS service. The local IMDS service can be used to retrieve tokens for managed identities in a local development environment. The proxy can be used to retrieve tokens from the local IMDS service or the live Azure IMDS service. The solutions are useful for developing and testing applications that rely on managed identities without the need to deploy to Azure.

## Setup
            
1. Open local-managed-identity.sln in Visual Studio.
1. Set Azure Subscription ID in user secrets.
    ```powershell
    az account show --query id --output tsv
    dotnet user-secrets set AZURE_SUBSCRIPTION_ID {YOUR_AZURE_SUB_ID}
    ```

## Option 1: IMDS Azure CLI Extension

The azure-cli-extension-imds project is an Azure CLI extension that simulates the Azure Instance Metadata Service (IMDS) locally. This allows developers to obtain tokens as if they were interacting with a live Azure environment. The extension can be installed from build artifacts and supports commands to start the local IMDS service. Tokens can be retrieved using environment variables and the Azure SDK, enabling seamless local development and testing of applications relying on managed identities.

[GitHub - noelbundick/azure-cli-extension-imds](https://github.com/noelbundick/azure-cli-extension-imds)

### Install
```powershell
az extension add --source https://github.com/noelbundick/azure-cli-extension-imds/releases/download/hack/imds-0.1.0-py3-none-any.whl
az imds start --port 53028 --secret foo
```

### Run

1. Open the 'local-managed-identity' project in Visual Studio and run the project. The `MSI_ENDPOINT` and `MSI_SECRET` environment variables will be set in the debug launch profile.

## Option 2: Smartersoft.Identity.Client.Assertion.Proxy

The Smartersoft.Identity.Client.Assertion.Proxy project is a .NET library that provides a proxy for the Azure Instance Metadata Service (IMDS). The proxy can be used to retrieve tokens from the local IMDS service or the live Azure IMDS service. The proxy is useful for local development and testing of applications relying on managed identities.

[GitHub - Smartersoft/identity-client-assertion](https://github.com/Smartersoft/identity-client-assertion)



### Install
```powershell
dotnet tool install --global Smartersoft.Identity.Client.Assertion.Proxy --version 0.9.0
az-kv-proxy
```

### Run
1. Open 'local-managed-identity' properties and go to debug profile in Visual Studio.  
1. Set MSI_ENDPOINT environment var to: http://localhost:5616/api/msi/forward
1. Run the 'local-managed-identity' project in Visual Studio.

