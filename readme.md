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
   ```
2. **Navigate to the project directory:**
   ```bash
   cd CloudAnswerPhone
   ```
3. **Restore dependencies:**
   ```bash
   dotnet restore
   ```
4. **Set up Azure Function CLI (Azure Functions Core Tools):**
   ```bash
   npm i -g azure-functions-core-tools --unsafe-perm true
   ```
   
   
## Configuration

1. **Azure Resources Setup:**
- Create an Azure Function App in the Azure portal.
- Obtain the connection string and URL for your Azure Function
  
2. **Twilio Setup:**
- Sign up for Twilio if you haven't already - ([Create Twilio account](https://login.twilio.com/u/signup))
- Also setup the numbers you will use with the service to use it to its full you will need at least 2 numbers one to send the notifications and one to call to.
- Go to the Account Info on the main page and note down the Account SID and the Auth Token as they will both be used for the Function.

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

1. Run the Azure function locally. Note down the port number being used for the function AnswerPhone. 
   ```bash
   dotnet build
   func start
   ```
2. Run NGROK with the port number used, Default is 7071. 
   ```bash
   ngrok.exe http 7071
   ```
3. Go to Twilio and navigate to thw phone number you wish to use and set the webhook URL to NGROKURL/api/AnswerPhone     
   

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

