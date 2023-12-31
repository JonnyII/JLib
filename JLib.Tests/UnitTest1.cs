using JLib.Tests.ValueTypeDemo.DiscoveredTypes;
using JLib.Tests.ValueTypeDemo.TypeValueTypes;

namespace JLib.Tests;
public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var typeCache = new TypeCache(
            typeof(TypeValueTypes.ReadOnlyEntity),
            typeof(IOrderRoe),
            typeof(TypeValueTypes.QueryEntity),
            typeof(OrderQe),
            typeof(TypeValueTypes.CommandEntity),
            typeof(OrderCe)
            );
        var x = typeCache.All<TypeValueType>();
    }
    [Fact]
    public void Test2()
    {
        var typeCache = new TypeCache(
            typeof(UnitTest1).Assembly, typeof(TypeValueType).Assembly
        );
        var x = typeCache.All<TypeValueType>();
    }
}
