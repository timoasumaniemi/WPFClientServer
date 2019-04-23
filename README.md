# WPFClientServer

Simple application to demonstrate client-server implementation using C#.
Client will be done with WPF and server with C# .NET ASP Web API 2

WPFClientServer solution was done with Visual Studio 2019. .NET Framework 4.7.2 version was used.

Solution contains 4 projects:
- Client: WPF Client, a simple GUI with one button - "Receive Message". By clicking it, a string message is received from API server, then encrypted using BCRYPT method and this encrypted message is then sent back to server. Currently server will response by returning this encyrpted message undomdified with OK statusresponse. 
- ClientTests: Unit tests related to the WPF Client

- Server: ASP Web API 2 C# server with two endpoints, GET ("api/message") which returns currently hardcoded string back to user and POST ("sendmessage") which takes given string and returns it back with OK statusresponse.
- Server.Tests: Unit tests related to the Server. This project also includes a index.html file which can be used to test server endpoints using basic ajax calls. 

To run on Windows (Only tested with Windows 10 Home version):
-First, enable IIS services in Windows.
-Publish the Server project to location where default user has access rights, for example "c:\publish"
-Add this location as new website in IIS Manager so it can be run on background (instead of running it only in Visual Studio)
-In this project host name "localhost" was used for identifying this site.
-Modify c:\Windows\System32\drivers\etc\hosts file to allow access by adding entry "127.0.0.1 localhost" at the end of the file.
-Run "Client" project.

-To test server endpoints with the index.html file, select "Server" as Startup project and start debugging. Browser page should appear. See the index.html file for ajax call examples.

TODO:
- Implement message encryption check in server
- Implement message randomizer in server
