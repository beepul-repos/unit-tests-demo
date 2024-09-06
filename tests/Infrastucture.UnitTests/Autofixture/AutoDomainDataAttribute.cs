using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace Infrastucture.UnitTests.Autofixture;

public class AutoDomainDataAttribute : AutoDataAttribute
{
    public AutoDomainDataAttribute()
        :base(() => new Fixture().Customize(new AutoMoqCustomization()))
    {
    }
}
