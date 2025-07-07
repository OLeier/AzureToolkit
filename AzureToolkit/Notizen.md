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

- Tutorial Lab03: Deploying To Azure (* Web App *)

[https://git-scm.com/](https://git-scm.com/ "Git")

- Self-Assessment Lab: Angular On Azure

# Module 2 | Cognitive Services

Objectives
• Implement the Bing Image Search API to retrieve images based on a user supplied search term.
• Implement code that uses the Computer Vision Cognitive Service to and create a list of tags that describe the contents of the image.

- Resource Content
- Labs Overview And Configuration
- Tutorial Lab01: Implementing Bing Search Services (* Bing Search *)
- Tutorial Lab02: Implementing The Computer Vision Service (* Computer Vision *)
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

[https://docs.microsoft.com/de-de/azure/active-directory/develop/v1-protocols-oauth-code](https://docs.microsoft.com/de-de/azure/active-directory/develop/v1-protocols-oauth-code)

Lab Requirements

(* Azure Active Directory B2C *)

Task: Show the Job Title of the user in addition to their name on the Home screen.

User Story: As a user I want to be able to see my Job Title next to my name whenever I log in.

Acceptance Criteria:

        The job title of the currently logged in user will be displayed using the following format: "Hello John Smith, Manager"

# Module 4 | Data Storage

Objectives
• Create an Azure Storage container (Azure Blob storage) and develop an ASP.NET Web API that can be used to store images.
• Create an Azure SQL Database and implement the code to store the metadata (tags, description, title) associated with images.

- Resource Content
- Azure Storage Overview
- Azure Blob Storage, https://docs.microsoft.com/en-us/azure/storage/storage-blob-storage-tiers
- Azure SQL Database
- Video: SQL Firewalls
- Video: Entity Framework Core
- Entity Framework Core Contexts
- Video: Entity Framework Core Contexts In Depth
- Entity Framework Core Migrations
- Video: Entity Framework Core Migrations
- Creating .NET Core Web APIs
- Tutorial Labs

        Implementing Blob Storage

        In this lab, you will create an Azure Storage container and then add photos to the container using an ASP.NET Web API.
        Implementing an Azure SQL Database

        In this lab, you will store the metadata (tags, description, title) for a user's images in an Azure SQL Database so that when they retrieve their images, they get all the metadata information as well.

- To Create An Azure Storage Account (* Storage account *)
- To Create A Blob Storage Container
- To Create A Web API for Storing Images
  dotnet add package WindowsAzure.Storage
  dotnet restore

- To Call Your Web API from Angular

- To Create a SQL Database (* SQL Database *)
- To Create an Entity Framework Context
  dotnet add package Microsoft.EntityFrameworkCore.SqlServer -> v2.1.11 für .NETCoreApp,Version=v2.1
  dotnet add package Microsoft.EntityFrameworkCore.Design -v 2.1.11

  dotnet ef migrations add InitialCreate
  dotnet ef database update

- To Implement Your DB Context
- Lab Overview

In this module, you learned how to store data in both Azure Storage and an Azure SQL Database.

In this self-assessment lab, you will extend the data that is being stored to include the "people data" that you added during the Module 1 self-assessment lab.

If successful, the number of people in a photo, their ages and their genders will be stored in the Azure SQL database.

Lab Requirements

Task: Retain the number of people in a image, their genders and their ages.

User Story: As a user I want to know how many people are in an image, their ages and their genders, so I can search on these additional data tags.

Acceptance Criteria:

        The total number of people in an image is persisted.
        For each person their age is persisted.
        For each person their gender is persisted.


# Module 5 | Azure Search Service

Objectives
• Implement the code required to retrieve information from Azure Storage and your Azure SQL database.
• Create a gallery View in your application that can display all of the saved images for the user that is logged-in.
• Implement Azure Search within your application so that users can search their stored images for the ones that they want to view.

- Azure Search Service
- Video: Azure Search Servicee
- Video: Azure Search Indexes
- Video: Azure Search Data Providers
- Video: Azure Search APIs
- Full Text Search in Azure Search
- Simple Query Syntax in Azure Search
  https://docs.microsoft.com/de-de/azure/search/query-simple-syntax
- Lucene Query Syntax in Azure Search
- How to Page Search Results in Azure Search
  GET /indexes/onlineCatalog/docs?search=*$top=15&$skip=30&$count=true

Tutorial Lab01: Reading From Storage
- To Retrieve Images from A SQL Database
- To Create A Gallery View for User Images
- To Display User Images

Tutorial Lab02: Implementing Azure Search
- To Create An Azure Search Service (* Azure Cognitive Search *)
- To Connect Azure Search to Your Azure SQL Database
- To Configure a Search Index
- To Implement Azure Search in Your App
  dotnet add package Microsoft.Azure.Search

Lab Overview

In this module, you learned how to implement Azure Search.

In this self-assessment lab, you will extend your search criteria to include only those photos with people.

If successful, a user should be able to search their gallery for images with people in them.

Lab Requirements

Task: Enable searching by "people"

User Story: As a user I want to be able to search for images containing people

Acceptance Criteria:

    There is a new option available in the UI that enables the user to search for images that contain people.
    When searching for images with people, the images that are returned are photos that contained "Faces"

# @angular/cli @ "18.2.20"

The output location of the browser build has been updated from "dist" to "dist/browser". You might need to adjust your deployment pipeline or, as an alternative, set outputPath.browser to "" in order to maintain the previous functionality.

# @angular/cli @ "19.2.15"

ng build
- X [ERROR] NG8001: 'app-nav-menu' is not a known element:
- X [ERROR] TS-991010: Value at position 0 in the NgModule.imports of AppModule is not a reference
  Value could not be determined statically.

- https://javascript.plainenglish.io/migrating-my-newly-built-portfolio-to-angular-19-b95cb95c2aa6
- Replace BrowserModule.withServerTransition()

- NG8002: Can't bind to 'ngClass' since it isn't a known property of 'div'
- https://github.com/medic/cht-core/issues/9759
- https://www.edureka.co/community/301299/can-t-bind-to-ngclass-since-it-isn-t-a-known-property-of-input
- aapp.moduls.ts

- Error: NG0402: A required Injectable was not found in the dependency injection tree. If you are bootstrapping an NgModule, make sure that the `BrowserModule` is imported.
- BrowserModule notwendig
