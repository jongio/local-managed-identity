# Local Managed Identity

This is a repo to test out the POC `azd auth serve`

## Setup
            
1. Set AZURE_SUBSCRIPTION_ID environment variable to the subscription id of the Azure subscription you want to use.
1. Open .env file and set AZURE_SUBSCRIPTION_ID to the subscription id of the Azure subscription you want to use.

## Start the server
1. Open a terminal and install the Azure Developer CLI.
https://github.com/Azure/azure-dev/pull/3979#issuecomment-2148992687
  
1. Login to Azure.
	```powershell
	azd login
	``` 
                                                                        
1. Start the local Managed Identity service.
    ```powershell
    azd auth serve
	```
## Run on local machine


1. Open 'local-managed-identity' and hit F5 to run the project.


## Run in container

1. Open a terminal, cd to local-managed-identity, and run `docker compose up --build`
2. See the results in the console window.