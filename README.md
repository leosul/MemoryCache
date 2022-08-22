# CachingApp

![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)

The idea of ​​this package is to facilitate the use of memory cache, it is just an abstraction that helps the developer to add or remove data in memory, just by making use of an interface.

## Dependencies

- .NET6 or >
- Microsoft.Extensions.Caching.Memory
- Microsoft.Extensions.Configuration.Abstractions
- Microsoft.Extensions.DependencyInjection.Abstractions

## Installation

[nuget CachingApp](https://www.nuget.org/packages/CachingApp)

```sh
Install-Package CachingApp -Version 1.0.0
```

## How to use

Create a .json file in the root of your project with the name ${appsettings.json} and create
a configuration:

````
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "Caching" : {
    "Customer" : "01:00:00"
  }
}
````
where the "Caching" node must contain the name and the time that the data will be in memory.
To use the feature, just add it to the program.cs file

![Capture](https://user-images.githubusercontent.com/22174344/185879520-d4e33791-abda-4944-abe5-3ed05e40897c.JPG)

### Example

![Capture](https://user-images.githubusercontent.com/22174344/185881434-19aeb8c5-9d5f-4a24-bc75-b69f70e78109.JPG)

inject ICacheStore in the controller's constructor, on line 23 instantiate the CacheKeyStore class passing the object you intend to put in memory, informing the cache key and the name previously registered in the appsettings.json file. On line 24 try to get the data in memory passing the key, on line 32 if there is no data in memory, it must be added. This way the data is already available in memory from the next request.


## License

MIT
