#import "FeatureToggler+Mappings.h"
#import "FeatureToggleManager.h"
#import "Enums.h"

@implementation FeatureToggler (Mappings)

- (id)initWithServiceResult:(NSDictionary *)result
{
    if((self = [super init]))
    {
        self.Name = [[result valueForKey:@"Name"] stringByReplacingOccurrencesOfString:@" " withString:@""];
        self.isFeatureEnabled = [[result valueForKey:@"IsEnabled"] boolValue];
        self.filterValues = [result mutableArrayValueForKey:@"FilterValues"];
        self.commandType = (FeatureToggleCommandTypeEnum)[[result valueForKey:@"CommandType"] integerValue];
        self.command = [result valueForKey:@"Command"];
    }
    
    return self;
}

- (id)initWithName:(NSString *)featureName
{
    self = [super init];
    
    FeatureToggler *featureToggle = [[FeatureToggleManager defaultService] getFeatureToggleWithName:featureName];
    
    if(featureToggle)
    {
        self = featureToggle;
    }
    
    return self;
}

- (id)initWithFeatureToggles:(NSArray *) featureToggles andName:(NSString *)featureName
{
    self = [super init];
    
    NSPredicate *predicate = [NSPredicate predicateWithBlock:^BOOL(id evaluatedObject, NSDictionary *bindings) {
        return [((FeatureToggler *)evaluatedObject).name isEqualToString:featureName];
    }];
    
    NSArray *ftArray = [featureToggles filteredArrayUsingPredicate:predicate];
    
    if(ftArray && ftArray.count > 0)
    {
        FeatureToggler *result = ftArray[0];
        self = result;
    }
    
    return self;
}

- (NSDictionary *)parameters
{
    NSMutableDictionary *result = [NSMutableDictionary new];
    
    self.key > 0 ? [result setValue:@(self.key) forKey:@"Key"] : [result setValue:[NSNull null] forKey:@"Key"];
    
    [result setValue:self.name forKey:@"Name"];
    [result setValue:@(self.isFeatureEnabled) forKey:@"IsEnabled"];
    self.commandType && self.commandType > 0 ? [result setValue:@(self.commandType) forKey:@"CommandType"] : [result setValue:[NSNull null] forKey:@"CommandType"];
    self.command ? [result setValue:self.command forKey:@"Command"] : [result setValue:[NSNull null] forKey:@"Command"];
    [result setValue:[self.filterValues componentsJoinedByString:@","] forKey:@"FilterValues"];
    [result setValue:[NSDate date] forKey:@"ChangeDate"];
    
    return result;
}
@end