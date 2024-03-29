using Moq.AutoMock;

namespace TDDMAUI.UnitTests;

public abstract class UnitTestBase<T> where T : class
{
    protected UnitTestBase()
    {
        Mocker = new AutoMocker();
        Sut = Mocker.CreateInstance<T>();
    }

    protected AutoMocker Mocker { get; }    // Mocker

    protected T Sut { get; }    // System under test
}