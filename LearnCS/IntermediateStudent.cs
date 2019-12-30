using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LearnCS
{
    public class HttpCookie
    {
        private readonly Dictionary<String, String> _cookDict;
        public HttpCookie()
        {
            _cookDict = new Dictionary<string, string>();
        }
        public String this[String key]
        {
            get { return _cookDict[key]; }
            set { _cookDict[key] = value; }
        }
    }

    public class IntermediateStudent
    {
        [Fact]
        [Trait("category", "smoke")]
        [Trait("priority", "p0")]
        public void NewClassTest()
        {
            var cookie = new HttpCookie();
            cookie["name"] = "Test Value";
            Xunit.Assert.NotEmpty(cookie["name"]);
        }
    }

}
