#import <Foundation/Foundation.h>
#import "FeatureToggler+Mappings.h"
#import "MyJsonTogglerFeature.h"

@implementation MyJsonTogglerFeature: FeatureToggler

-(id)init
{
    if(self)
    {
        NSString *className = NSStringFromClass([self class]);
        
        self = [super initWithName:className];
    }
    
    return self;
}

-(id)initWithFeatureToggles:(NSArray *)featureToggles
{
    if(self)
    {
        NSString *className = NSStringFromClass([self class]);
        self = [super initWithFeatureToggles:featureToggles andName:className];
    }
    
    return self;
}

@end