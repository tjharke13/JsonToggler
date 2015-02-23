#import <Foundation/Foundation.h>
#import "SharedConstants.h"

@interface FeatureToggler : NSObject

@property NSInteger key;

@property (strong, nonatomic) NSString *name;
@property BOOL isFeatureEnabled;
@property FeatureToggleCommandTypeEnum commandType;
@property (strong, nonatomic) NSString *command;
@property (strong, nonatomic) NSMutableArray *filterValues;

- (BOOL)isEnabled;

@end