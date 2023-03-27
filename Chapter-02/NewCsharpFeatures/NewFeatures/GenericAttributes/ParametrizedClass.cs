namespace NewFeatures.GenericAttributes;

public class ParametrizedClass
{
    [OldType(typeof(int))]
    public int DoOldStyleJob() => default;

    [NewType<int>]
    public int DoNewStyleJob() => default;

}