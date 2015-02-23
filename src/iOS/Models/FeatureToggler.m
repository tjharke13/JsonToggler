#import "FeatureToggler.h"

@implementation FeatureToggler

-(NSDate *)getDateFromCommand:(NSString *)value {
    value = [value stringByTrimmingCharactersInSet:[NSCharacterSet whitespaceCharacterSet]];
	
	NSDateFormatter *dateFormat=[[NSDateFormatter alloc] init];
	[dateFormat setDateFormat:@"MM/dd/yyyy HH:mm:ss"];

    NSDate *result = [dateFormat dateFromString:value];
    
    if(result == nil)
	{
		[dateFormat setDateFormat:@"MM/dd/yyyy"];
        result = [dateFormat dateFromString:value];
	}
    
    if(result == nil)
	{
		[dateFormat setDateFormat:@"MM/dd/yyyy HH:mm"];
        result = [dateFormat dateFromString:value];
	}
    
    return result;
}

-(BOOL)isEnabled
{
    NSDate *now = [NSDate date];
    BOOL result = NO;
    
    if(self.isFeatureEnabled)
    {
        if(!self.commandType || self.commandType == 0 || !self.command || self.command.length == 0) {
            return YES;
        }
        
        switch (self.commandType) {
            case kDateOnOrAfter:{
                NSDate *commandDate = [self getDateFromCommand:self.command];
                if([commandDate compare:now] == NSOrderedAscending) {
                    result = YES;
                } else {
                    result = NO;
                }
                break;
            }
            case kDateOnOrBefore: {
                NSDate *commandDate = [self getDateFromCommand:self.command];
                if([commandDate compare:now] == NSOrderedDescending) {
                    result = YES;
                } else {
                    result = NO;
                }
                break;
            }
            case kDatesBetween: {
                NSArray *dateStrings = [self.command componentsSeparatedByString:@"|"];
                
                NSDate *startDate = [self getDateFromCommand:dateStrings[0]];
                NSDate *endDate = [self getDateFromCommand:dateStrings[1]];
                
                result = ([now compare:startDate] == NSOrderedDescending &&
                          [now compare:endDate] == NSOrderedAscending);
                
                break;
            }
            default:
                @throw([NSException exceptionWithName:@"FeaturToggler.IsEnabled" reason:@"The command is not supported." userInfo:nil]);
                break;
        }

    }
    
    return result;
}

@end