# Cloud Answerphone

## Overview

This project was started as a Web Service to answer my UK cellphone number whilst living in Australia. I had moved the
number onto Twilio so I decided to build an Azure function that would have a request sent to it everytime my number would be called.

### Dependencies

- .NET 8 SDK installed ([Download .NET SDK](https://dotnet.microsoft.com/download))
- Ngrok Installed (For local builds) ([Download NGROK](https://ngrok.com/download)) 
- Azure subscription ([Create Azure account](https://azure.microsoft.com/en-us/free/))
- Twilio subscription ([Create Twilio account](https://login.twilio.com/u/signup))

## Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/antland01/CloudAnswerPhone
   
2. **Navigate to the project directory:**
   ```bash
   cd CloudAnswerPhone
   ```
3. **Restore dependencies:**
   ```bash
   dotnet restore
   ```
   
## Configuration

1. **Azure Resources Setup:**
- Create an Azure Function App in the Azure portal.
- Obtain the connection string or other required credentials for your Azure resources (e.g., Azure Storage, Azure Cosmos DB, etc.).
  
2. **Twilio Setup:**
- Coming soon

3. **Local Configuration:**
- Create a local.settings.json file in the project root.
- fill in with the below template.
   ```json
   {
    "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": [Connection String from Azure for the Azure Function],
    "FUNCTIONS_EXTENSION_VERSION": "~4",
    "TwilioAuth": [Auth Token from Your Twilio Account],
    "TwilioSID": [SID from Your Twilio Account],
    "MyNumber": [Number you want the Text messages to go to when you get a call],
    "MyNotificationNumber": [Twilio Number for sending notifications from],
    "FunctionURL": [The URL of the Function, Either get this from Azure or NGROK],
    "FUNCTIONS_WORKER_RUNTIME": "dotnet-isolated"

  }
   }
   ```

## Running Locally

To run the Azure Function locally, follow these steps:
   ```bash
   dotnet build
   func start
   ```

## Deployment
To deploy the Azure Function to Azure, you can use various methods including:

- Azure DevOps Pipelines
- GitHub Actions
- Visual Studio Publish
- Azure CLI
- Azure Portal
  
Choose the deployment method that best fits your workflow and follow the appropriate steps for deployment.

## Author

[Anthony Smith](https://www.linkedin.com/in/antland/)

