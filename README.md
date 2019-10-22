# Course "Building Your Azure Skills Toolkit"
[https://www.edx.org/course/building-your-azure-skills-toolkit-3](https://www.edx.org/course/building-your-azure-skills-toolkit-3)
[https://github.com/msmithnova/DEV224x](https://github.com/msmithnova/DEV224x)

#  Module 0 | Welcome
- Welcome
- Pre-Course Survey
- About This Course
- Meet The Instructors
- Introduce Yourself

# Module 1 | Angular on Azure

Objectives
• Investigate the Azure account offers available from Microsoft, sign up for an Azure account, and explore your Azure portal.
• Create an ASP.NET Core application with a C# backend and an Angular Front End.
• Create an Azure App Service Web App (to host your application in the cloud) and deploy your Angular application to Azure.

- Resource Content

[https://www.edx.org/course/angularjs-framework-fundamentals](https://www.edx.org/course/angularjs-framework-fundamentals "AngularJS: Framework Fundamentals")
[https://www.edx.org/course/angularjs-advanced-framework-techniques](https://www.edx.org/course/angularjs-advanced-framework-techniques "AngularJS: Advanced Framework Techniques")
[https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/intro](https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/intro ".NET Tutorial - Hello World in 10 minutes")
[https://github.com/angular/angular.js](https://github.com/angular/angular.js)
[https://docs.microsoft.com/de-de/azure/architecture/guide/technology-choices/compute-decision-tree](https://docs.microsoft.com/de-de/azure/architecture/guide/technology-choices/compute-decision-tree)

- Labs Overview And Configuration

[https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download "Download .NET"), course requires .NET Core 1.1.2

[https://code.visualstudio.com/docs?dv=win&wt.mc_id=DXLEX_EDX_DEV224X](https://code.visualstudio.com/docs?dv=win&wt.mc_id=DXLEX_EDX_DEV224X "Visual Studio Code")

[https://nodejs.org/en/](https://nodejs.org/en/ "Node.js"), LTS (10.16.3)

- Tutorial Lab01: Getting Started With Azure
- Tutorial Lab02: Creating An Angular SPA

npm install -g yo

npm install -g generator-aspnetcore-spa

yo aspnetcore-spa -> ## Please use "dotnet new" templates instead ### This Yeoman generator is DEPRECATED

- dotnet new angular
- dotnet new react
- dotnet new redux

[https://angular.io/guide/architecture#!#components](https://angular.io/guide/architecture#!#components "Architecture overview")

[https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-3.0](https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-3.0 "Routing to controller actions in ASP.NET Core")

- Tutorial Lab03: Deploying To Azure

[https://git-scm.com/](https://git-scm.com/ "Git")

- Self-Assessment Lab: Angular On Azure

# Module 2 | Cognitive Services

Objectives
• Implement the Bing Image Search API to retrieve images based on a user supplied search term.
• Implement code that uses the Computer Vision Cognitive Service to and create a list of tags that describe the contents of the image.

- Resource Content
- Labs Overview And Configuration
- Tutorial Lab01: Implementing Bing Search Services
- Tutorial Lab02: Implementing The Computer Vision Service
- Self-Assessment Lab: Cognitive Services
 
Lab Requirements

Task: Extend the resultant dataset from the computer vision cognitive service to identify the number of people in the photo, their ages and their Gender.

User Story: As a user I want to know if a photo contains a person and if that person is male or female, and approximately how old they are.

Acceptance Criteria:
1.A photo with at least one person should display their age and gender.
2.There should be a count of the total number of people.

Hint You can see the full resultant response from the ComputerVision API call at: [https://azure.microsoft.com/en-us/services/cognitive-services/computer-vision/](https://azure.microsoft.com/en-us/services/cognitive-services/computer-vision/)

[https://azuretoolkit-oleier.azurewebsites.net/](https://azuretoolkit-oleier.azurewebsites.net/ "AzureToolkit")

# Module 3 | Securing Your App

Objectives
• Configure Azure Active Directory B2C to enforce user registration and authenticated sign-in to your application.
• Implement code that manages the user information that you collected at sign-in, implementing code on both the Angular side and the ASP.NET Core side of your application.

# Module 4 | Data Storage

Objectives
• Create an Azure Storage container (Azure Blob storage) and develop an ASP.NET Web API that can be used to store images.
• Create an Azure SQL Database and implement the code to store the metadata (tags, description, title) associated with images.

# Module 5 | Azure Search Service

Objectives
• Implement the code required to retrieve information from Azure Storage and your Azure SQL database.
• Create a gallery View in your application that can display all of the saved images for the user that is logged-in.
• Implement Azure Search within your application so that users can search their stored images for the ones that they want to view.
