@interface FeatureToggler (Mappings)

- (id)initWithServiceResult:(NSDictionary *)result;
- (id)initWithName:(NSString *)featureName;
- (id)initWithFeatureToggles:(NSArray *) featureToggles andName:(NSString *)featureName;

- (NSDictionary *)parameters;

@end
