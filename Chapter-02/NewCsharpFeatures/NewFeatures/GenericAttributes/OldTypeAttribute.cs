namespace NewFeatures.GenericAttributes;

public class OldTypeAttribute : Attribute
{
    public OldTypeAttribute(Type attributeType) => AttributeType = attributeType;

    public Type AttributeType { get; }
}