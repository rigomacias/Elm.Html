using Elm.Html;
//using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var div = HtmlNode.Div;

            var parentAttribute = Attribute.Class("parent");
            var childAttribute = Attribute.Class("child");

            var childDiv = HtmlNode.Div(new Attribute[1] { childAttribute }, new HtmlNode[0]);
            var parentDiv = HtmlNode.Div(new Attribute[1] { parentAttribute }, new HtmlNode[1] { childDiv });


            var result = parentDiv.Render();
        }
    }
}
