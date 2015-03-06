# JsonToggler
A feature toggle library for .NET and am working on a port for Java using JSON files.

The premise of this library is to allow you to develop many features and have the ability to deploy to a production environment without affecting users.  

Take this scenario for example.  You are on an agile development team and your sprint cycle just completed.  Your deployment cycle is to always deploy after a sprint cycle.  During this sprint cycle FeatureA, FeatureB, FeatureC, and FeatureD were worked on by developers.  Come the end of the sprint FeatureA, C, and D were completed, but FeatureB had some issues and wasn't completed by development.  Then also when demoing the completed features the Product Owner decides there were issues in FeatureC and doesn't want this feature to be delivered to the customers.  What does this now mean from a deployment standpoint?  The happy path tag and branch release path is no longer valid as we have features scattered between checkins that may or may not have intermixed code.  The simple release process now turns into a much more involved complicated process.  We now have to cherry pick changesets and handle possible complicated merging.  On top of that now we have a different code base then what was tested and now everything has to be tested again!  Well that sucks and is a huge waste of time.  I wish there was some godsend tool that would allow me to avoid all of this.  Have no feature JsonToggler is here! :-)

Using JsonToggler the problems of releasing incomplete features and having to cherry pick changesets is no longer needed.  The ability to turn a feature on/off is as simple as updating a JSON file.  This allows you to do release from HEAD and what was tested in development environment is what will be deployed to production.

#How does it work?

So, how does this vodoo magic work?  All feature toggles are defined in indivdual JSON files.  It could be modified to handle a list of feature toggles in one file, but I decided to have multiple files for each feature toggle to make it easier to deploy and not have to worry about messing up other feature toggles.

If you look under the src/Examples directory you will see a JsonFiles folder that has example JSON files defining different types of feature toggles.

The FeatureToggle.API project is a .NET Web API, showing how you can serve up the feature toggles through an API and then consume them in any kind of application.

The FeatureToggleExample shows how you can consume the feature toggles using the JsonToggler library directly, through an API, or just consuming the API without the JsonToggler library.

#Steps to Setup

Add a config section for JsonToggler 

```XML
    <configSections>
        <section name="JsonToggler" type="JsonToggler.JsonTogglerSection, JsonToggler" />
    </configSections>
```

Create the configuration node for JsonToggler.

```XML
    <JsonToggler Environment="Local" JsonDirectory="C:\DirectoryToJsonFiles\FeatureToggles"  />
```

Create a JSON file for each individual feature.  e.g. MyFirstJsonTogglerFeature.json

```JSON
{
    "Application": "All",
    "Environment": "All",
    "Platform": "All", 
    "CommandType": null,
    "Command": null,
    "ConnectionString": null,
    "FilterValues":  null,
    "SubFeatureToggles": [
        {
            "Name": "Sub Feature 1",
            "Environment": "All",
            "Platform": "All",
            "CommandType": null,
            "Command": null,
            "ConnectionString": null,
            "FilterValues":  null
        }
    ],
    "SpecificEntities": [
    ]
}

```

Implement the feature in code to create a strongly typed class.  

-To implement a feature is really simple.  All you will have to do is create a new class and implement the JsonFeatureToggler<T> base class where T is the feature toggle implementation.

-This will be beneficial when removing features after they are no longer needed.

For example

```C#
using JsonToggler;

public class MyFirstJsonTogglerFeature : JsonFeatureToggler<MyFirstJsonTogglerFeature>
{
    
}

//Controller

public ActionResult Index()
{
	var vm = new MyPagesViewModel();
	var myFirstFeature = new MyFirstJsonTogglerFeature();
	
	var isEnabled = myFirstFeature.IsEnabled();
	
	if(isEnabled)
	{
		//Do something when the feature is enabled.
	}
	else
	{
		//Do something when the feature is disabled.
	}
	
	//Filtering
	
	var filterFeature = new FilterFeature();
	
	var testCollection = new List<SomeObject>();
	
	var filteredCollection = myFirstFeature.FilterCollection<SomeObject, Guid>(testCollection, "Id");
	
	...
	
	return View(vm)
}
```

If you want to avoid file IO by reading JSON files, or you are using an API to serve up your feature toggles you can do something like the following.  This enables you to get all features at one time and reuse the collection.

```C#
using JsonToggler;

public class FeatureToggleService
{
	public FeatureToggleService()
	{
		var featureService = new JsonTogglerService();
		_features = featureService.GetAllFeatureTogglesForPlatform(PlatformEnum.Web);
	}
	
	private List<FeatureToggle> _features { get; set; }
	
	public T GetFeatureToggle<T>() where T : FeatureToggle, new()
	{
	    string name = typeof(T).Name;
	
	    var feature = _features.Where(w => w.GetType() == typeof(T)).FirstOrDefault();
	
	    if (feature == null)
	        feature = new T() { Name = name.Replace("_", " ") };
	
	    return (T)feature;
	}
}

//Implementation

var jsonTogglerService = new FeatureToggleService();

var myFirstFeature = jsonTogglerService.GetFeatureToggle<MyFirstJsonTogglerFeature>();

```


#Config Values

Properties use a bitwise enum to handle multiple values without the need to have many configurations for each environment.  This way you make the change in one place and it is effective everywhere.  You can either use an integer value or string value of the enum.

These config values are used to determine if a feature toggle is enabled for the application and should be updated via config transforms when published to different environments.


Applications
---
This is a list of applications you would like to support for this application.  This is a comma seperated list.  If not provided it will default to "All".  If set to "All" it will use all feature toggles.  If you say AppXYZ, only feature toggles for this application will be enabled.


Environment
---
The environment this application is currently running in.  This will be used to determine if the feature is enabled for the application in it's current environment.

```C#
[System.Flags]
public enum EnvironmentEnum
{
    LOCAL=1,
    DEV=2,
    QAS=4,
    STAGE=8,
    PROD=16,
    NONPROD= LOCAL | DEV | QAS | STAGE,
    ALL= LOCAL | DEV | QAS | STAGE | PROD
}
```
Platform
---
The platform type this application is.  (Web is the default value)  This will make it available to make some feature toggles only available for certain platforms.  This is useful if you have a lot of feature toggles, or you are using mobile data and want to constrain the amount of data that is sent to be specific to a certain platform.

```C#
[System.Flags]
public enum PlatformEnum
{
    Web=1,
    Desktop=2,
    Android=4,
    iOS=8,
    WinPhone=16,
    Mobile= Android | iOS | WinPhone,
    All = Web | Desktop | Android | iOS | WinPhone
}
```

#JSON File Properties

Name (Optional)
---
The feature name.  If this isn't supplied the files name is used as the feature name.  

Application (Optional)
---
The application name this feature belongs to.  If you would like to make this feature specific for an application you can provide the application this feature belongs to.  It will only be enabled if the application consuming the feature toggle has "All", or the application name defined int he config.

Environment (Required)
---
The environment you would like this feature enabled for.  The values are detailed above in the EnvironmentEnum.  This is using bitwise operators, so you can enable this feature toggle in one place for multiple environments.

Platform (Required)
---
This will determine what 'platform' type this feature is enabled for.  Feature Toggles may be shared across multiple platforms.  (e.g. Android and iOS, but you may also want to just show a feature for only Android too).  This is using a bitwise operator.

FilterValues (Optional)
---
If you would like to filter a collection/dataset that is returned you can put the value of these (typically identity column) in a list here.  This is for when you have data in tables that should only show when a specific feature is enabled.  If the feature is disabled it will filter out these values from the results.

CommandType (Optional)
---
This will give you the ability to define a custom type of feature toggle.  Environment/Platform conditions will have to be satisfied first to enable/disable a feature based upon the command type/command combination.

Possible values...

**DateOnOrAfter (1)**

//Will enable you to put a date/datetime value in the 'Command' property and will either enable/disable the feature if it is AFTER or on that date.  Dates should be in UTC time.  e.g. ("CommandType": 1 "Command": "5/30/2000")

**DateOnOrBefore (2)**

//Will enable you to put a date/datetime value in the 'Command' property and will either enable/disable the feature if it is BEFORE or on that date.  Dates should be in UTC time.  e.g. ("CommandType": 2, "Command": "5/30/2000")

**DatesBetween (3)**

//Will enable you to put a date/datetime values in the 'Command' property and will either enable/disable the feature if it is BETWEEN the dates supplied.  Dates should be in UTC time and seperated by a pipe (|).  e.g. ("CommandType": 2, "Command": "5/30/2000 | 6/20/2000")

**SQL (4)**

//will enabled you to enable/disable a feature based upon a query to the database.  The query will have to return true/false to work correctly.  e.g. "CommandType": "SQL", "Command": "SELECT CAST(COUNT(1) AS BIT) as Result FROM [Company] WHERE Id = '00000000-0000-0000-0000-000000000000'"


ConnectionStringName (Optional)
---
This should be used in correlation with the 'SQL' CommandType.  This will determine what connection string in the config to use to do the SQL query against.

SubFeatureToggles (Optional)
---
This is a collection of sub features.  This will have the same properties as the base feature.  This could be useful if you have one big feature that has many smaller features and you want fine grain control on enabling/disabling specific parts. 

SpecificEntities (Optional)
---
This is a collection of values that will be used that you can extend in the FeatureToggle implementation.  If you want a feature only enabled for specific users or companies you can implement that by putting typically the identity column for the object you are trying to filter on.
