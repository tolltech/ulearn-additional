using HttpTask;

namespace HttpSolves
{
    [TestFixture]
    public class SolvedKeyValueStorageClientTests : KeyValueStorageClientTests
    {
        protected override void Setup()
        {
            client = new SolvedKeyValueStorage();
        }
    }
}