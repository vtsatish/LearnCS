using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Learnoops
{
    public class oopstests
    {
        [Fact]
        public void testInheritance()
        {
            ChildClass cls = new ChildClass("New person");
            Xunit.Assert.True(cls.gotName);
            cls.setName(null);
            Xunit.Assert.False(cls.gotName);
        }
        [Fact]
        public void testComposition()
        {
            ComposeClass ccls = new ComposeClass(-300);
            Xunit.Assert.True(ccls.outNumber > 0);
        }
    }

}
