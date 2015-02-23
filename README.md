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

