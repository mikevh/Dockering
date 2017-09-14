using System;
using System.Linq;
using Xunit;

namespace Dockering.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var x = Enumerable.Range(1, 3).ToList();
            
            Assert.Equal(3, x.Count);
        }
    }
}
