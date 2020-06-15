# Itch.io Collector

I made this tool to help me add all the games from the [Bundle for Racial Justice and Equality](https://itch.io/b/520/bundle-for-racial-justice-and-equality) to my Itch.io library. By default the games were available in your purchase history, but you had to click 'download' on each game to have them appear in your library.

I've only used this on Windows, but should work on Linux/Mac.

## Requirements
* Dotnet SDK 3.1
* Chromedriver (whichever matches your current version of Google Chrome)
* Google Crhome


## Instructions
1. Clone the repository
2. Download the [chromedriver](https://sites.google.com/a/chromium.org/chromedriver/) for your platform and extract it to .\ItchIoCollector\ItchIoCollector\chromedriver\ (see below if you don't know which version to get)
3. Edit .\ItchIoCollector\ItchIoCollector\Program.cs and change the 'USERNAME', 'PASSWORD' and 'UNIQUE_ID' values to your Itch.io username, password and the unique id is from the URL that was sent to you via Itch.io for your bundle purchase. You will only need the characters following https://itch.io/bundle/download/GET_THIS_PART . It'll be a string of random characters. If you url ends with ?page=## strip away that portion until your UNIQUE_ID in Program.cs looks like const string uniqueId = "jUMkdPGDBHeKHktSdtuujgjy2iPqHLiok3PsjuWj";
4. You can either run the application in Visual Studio by opening the .sln or .csproj file and pressing F5 or you can execute it from the command line by navigating to .\ItchIoCollector\ItchIoCollector\ and entering:

```
dotnet restore
dotnet run
```

It'll take awhile to complete.

## Help
* If the application failed partway through, you can modify the 'resumeFromPage' variable in Program.cs to the last page you were at. When you run the application again it'll start from that page.

* You need chromedriver to match you version of Chrome. If you're up to date and not running Chrome Beta/Dev then the latest stable release is likely what you'll need.


