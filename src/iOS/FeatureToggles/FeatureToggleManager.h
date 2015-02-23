#import <Foundation/Foundation.h>
#import "MyJsonTogglerFeature.h"

@interface FeatureToggleManager : NSObject

@property (nonatomic, retain) NSArray *featureToggles;

@property MyJsonTogglerFeature *myJsonTogglerFeature;

@property BOOL featureTogglesLoaded;

-(FeatureToggler*) getFeatureToggleWithName:(NSString *) name;

+ (FeatureToggleManager *)defaultService;


@end

