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

        [Fact]
        public void testAbstractClass()
        {
            ActualImpl actl = new ActualImpl();
            Xunit.Assert.False(actl.evaluate());
            actl.num = 100;
            Xunit.Assert.False(actl.evaluate());
            actl.str = "Test String";
            Xunit.Assert.True(actl.evaluate());
        }
        [Fact]
        public void testInterfaces()
        {
            ILearnClient rcl = new RESTClient();
            rcl.prepareClient("Json");
            rcl.executeClient("Post");
            Xunit.Assert.Equal("DefaultJsonPost", rcl.getClient().requestUri);
        }
    }

}
