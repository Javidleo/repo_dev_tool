using FluentAssertions;
using repo;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace repoTest
{
    public class UnitTest1
    {
        private readonly Repo _repo = new Repo();
        void Setup()
        {
            _repo.InitilizeForTest();
        }


        [Fact]
        public void GetCommandsTest()
        {
            string[] args = { "command","-m", "-h", "-s", "-u" };
            string[] expected = {"-m", "-h", "-s", "-u" };
        
            var result = _repo.GetSwitches(args);

            result.Should().BeEquivalentTo(expected);
        }
    }
}
