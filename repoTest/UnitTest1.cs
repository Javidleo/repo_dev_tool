using FluentAssertions;
using repo;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace repoTest
{
    public class UnitTest1
    {
        private readonly Repo _repo = new Repo();

        string s = "salam";
        [Fact]
        public void InitTest()
        {
            string b = "salam";

            b.Should().BeEquivalentTo(s);
        }
    }
}
