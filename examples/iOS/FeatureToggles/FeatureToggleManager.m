#import <Foundation/Foundation.h>
#import "FeatureToggleManager.h"

@interface FeatureToggleManager ()

@end

static FeatureToggleManager *_defaultService;

@implementation FeatureToggleManager : NSObject


//Creae a singleton pattern for the FeatureToggleManager, so we only make one call to get feature toggles.
+ (FeatureToggleManager *)defaultService
{
    if(_defaultService == nil || !_defaultService.featureToggles || _defaultService.featureToggles.count == 0)
    {
        _defaultService = [[FeatureToggleManager alloc] init];
    }
    
    return _defaultService;
}

NSString *const USER_DEFAULT_FEATURETOGGLES = @"FeatureToggles";

-(id)init {
    self = [super init];
    
    //_featureToggles = Get all features from the database or API, Ideally I would say download the feature toggles
	//on app startup and store them in the database.
	
    NSMutableArray *myFeatureToggles = [[NSMutableArray alloc] initWithArray:_featureToggles];
    NSDictionary *userPrefFeatureToggles = [[NSUserDefaults standardUserDefaults] dictionaryForKey: USER_DEFAULT_FEATURETOGGLES];
    NSMutableDictionary *featureDictionary = [[NSMutableDictionary alloc] init];
    
    if(userPrefFeatureToggles)
    {
        for (id key in userPrefFeatureToggles)
        {
            NSPredicate *predicate = [NSPredicate predicateWithBlock:^BOOL(id evaluatedObject, NSDictionary *bindings) {
                return [((FeatureToggler *)evaluatedObject).name isEqualToString:key];
            }];
            
            NSArray *ftArray = [myFeatureToggles filteredArrayUsingPredicate:predicate];
            
            if(ftArray && ftArray.count > 0)
            {
                FeatureToggler *updatedVal = ftArray[0];
                updatedVal.isFeatureEnabled = [[userPrefFeatureToggles objectForKey:key] boolValue];
                
                //If the feature is overridden
                updatedVal.commandType = 0;
                updatedVal.command = nil;
                
                [myFeatureToggles removeObject:ftArray[0]];
                [myFeatureToggles addObject:updatedVal];
            }
        }
    }
    
    for(FeatureToggler *feature in myFeatureToggles)
    {
        [featureDictionary setValue:[NSNumber numberWithBool:feature.isEnabled] forKey:feature.name];
    }
    
    // save the list of feature toggles in user preferences
    [[NSUserDefaults standardUserDefaults] setValue:featureDictionary forKey:USER_DEFAULT_FEATURETOGGLES];
    
    //set the featureToggles property.
    _featureToggles = [NSArray arrayWithArray:myFeatureToggles];
    
    [self setFeatureToggles:_featureToggles];
    
    return self;
}

-(FeatureToggler*) getFeatureToggleWithName:(NSString *) name {
    
    NSPredicate *predicate = [NSPredicate predicateWithBlock:^BOOL(id evaluatedObject, NSDictionary *bindings) {
        return [((FeatureToggler *)evaluatedObject).name isEqualToString:name];
    }];
    
    NSArray *ftArray = [_featureToggles filteredArrayUsingPredicate:predicate];
    
    if(ftArray && ftArray.count > 0)
    {
        FeatureToggler *result = ftArray[0];
        return result;
    }
    
    return nil;
}

-(void) setFeatureToggles:(NSArray *)featureToggles
{
    self.myJsonTogglerFeature = [[MyJsonTogglerfeature alloc] initWithFeatureToggles:featureToggles];
}

@end
