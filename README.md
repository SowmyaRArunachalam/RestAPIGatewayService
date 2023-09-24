# RestAPIGatewayService
Sowmya Coding ApiGateway to HackerNews API

I have used .NET core 6.0
I have written a REST API to fetch results from Hacker News API and return top n best stories in descending order in the given json format (both key and value).
I have used .NET core 6, Swagger UI to test this. The number can be provided as integer as part of request to test my API gateway Service.  
Implemented dependency injection through Program.cs instead of Startup.cs, used async, await, HTTPClient factory, etc. Currently it takes 25 secs to retreive the results, json if given more time I would analyze and optimize using multiple threads or any other similar means of Tasks
