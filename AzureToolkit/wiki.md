
# Microsoft.DEV224x.2T2017

This is the wiki for Microsoft's Building Your Azure Skills Toolkit.

Be sure that the Integrated Terminal is using the proper version of NodeJS/NPM. Type "node -v" and "npm -v" for the version numbers (these commands can take a bit to run). If they come back with the incorrect version then type (on Windows) 'C:\Windows\System32\cmd.exe /k "C:\Program Files\nodejs\nodevars.bat"' without single quotes. This should put the proper NodeJS/NPM versions in the environment.

Yeoman is no longer required with the latest .NET Core v2.0. Assuming you installed the .NET Core 2.0 SDK then you can ommit installing and running "yo" and simply run "dotnet new angular"

Assuming .NET Core 2.0 you neet to run "npm install" in the console before you can issue a "dotnet run" for the first time.

Also Assuming .NET Core was used and you create the project with "dotnet new angular" in your AzureToolkit directory then their is no need to modify the application name from Web Application Basic as it already has the correct name in navmenu_components.html

## Module 1 - Lab 3 - Git Deployment When you push your app to Azure, the build process fails!

*Unsupported platform error In your app service, click Deployment Options. This will give you access to your deployment log. When you review the error, you will see an unsupported platform error for fsevents.

Fix 1: To fix this problem, I edited the package.json file and added an optionalDependencies section

"optionalDependencies": { "fsevents":"*" }

Then ran npm install --no-optional from the terminal.

Commited the changes and then pushed to Azure.

This fixed the issue for me. Here is an article explaining this a little more: http://www.hanselman.com/blog/VisualStudio2015FixingDependenciesNpmNotInstalledFromFseventsWithNodeOnWindows.aspx

*Error MSB3073: The command "npm install" exited with code 1 When attempting to deploy/push to the master branch, you will see the following.
remote: npm ERR! node -v v0.10.40 remote: npm ERR! npm -v 1.4.28 remote: npm ERR! code E405

Azure uses an outdated version of NPM and NodeJs and I updated it by going to App Service > Application Settings and under Application settings you can add: APP SETTING NAME VALUE
WEBSITE_NODE_DEFAULT_VERSION 8.11.1 (or your preferred version) WEBSITE_NPM_DEFAULT_VERSION 5.6.0 (or your preferred version)

And if you redeploy, it should work. :)

## Module 2 | Cognitive Services | Tutorial Lab01: Implementing Bing Search Services | To Integrate Bing Search

Activity 11: the code referenced to: return this.http.get('https://api.cognitive.microsoft.com/bing/v5.0/images/search?q=${searchTerm}', this.bingSearchAPIKey) is incorrect. The string must be surrounded with backticks (`) like return this.http.get(`https://api.cognitive.microsoft.com/bing/v5.0/images/search?q=${searchTerm}`, this.bingSearchAPIKey) to indicate that it is an ES2015 template literal ( https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Template_literals)

## Module 3, Lab 1 | To Configure Authentication In Your Azure Web App

Instead of these instructions that are outdated, follow

https://docs.microsoft.com/en-us/azure/app-service/configure-authentication-provider-aad

## Module 3, Lab 2

You'll need to modify the user.service.ts in order for it to properly call Azure AD B2C. The latest version of Angular uses BASE_URL instead of ORIGIN_URL. Replace ORIGIN_URL in the constructor with BASE_URL. Then modify the get call to use the following: return this.http.get(this.originUrl + '.auth/me')

## Module 4, Lab 1

Replace ORIGIN_URL in the constructor with BASE_URL in the azureToolkitservice.ts and then modify Line 16 to the following: return this.http.post(this.originUrl + '/api/images', imagePostRequest)

You may also have to remove the piped null from currentItem: ImageResult in the search.component.ts file. It should look like this: currentItem: ImageResult;

search.component.ts needs to import: import { AzureToolkitService } from '../../common/services/azureToolkit.service'

## Module 5, Lab 2

1) when you instantiate SearchIndexClient you also need to provide the index name from under the Search service, so the correct code should be as follows:

string searchServiceName ="";

string queryApiKey = "";

string searchServiceIndexName = ""; // the name of the index you created on the SavedImages table

SearchIndexClient indexClient = new SearchIndexClient(searchServiceName, searchServiceIndexName, ..

2) as the Controller's Action method on the back-end side expects a GET request, searchImage should call this.http.get instead of this.http.post: return this.http.get('${this.originUrl}/api/images/search/${userId}/${searchTerm}')...
