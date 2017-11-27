using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elm.Html
{




    public interface Renderable
    {
        string Render();
    }


    public interface INode
    {
        string Name { get; }
        IEnumerable<Attribute> Attributes { get; }
        IEnumerable<HtmlNode> Children { get; }

        string Render();
    }


    public sealed class HtmlNode : INode
    {
        public string Name { get; }
        public IEnumerable<Attribute> Attributes { get; }
        public IEnumerable<HtmlNode> Children { get; }


        private HtmlNode(string name, IEnumerable<Attribute> attributes, IEnumerable<HtmlNode> children)
        {
            Name = name;
            Attributes = attributes;
            Children = children;
        }



        public static Func<IEnumerable<Attribute>, IEnumerable<HtmlNode>, HtmlNode> Span = (attributes, children) => { return new HtmlNode("div", attributes, children); };
        public static Func<Attribute[], HtmlNode[], HtmlNode> Div = (attributes, children) => { return new HtmlNode("div", attributes, children); };

        public string Render()
        {
            var nodeAttributes = String.Join("", Attributes.Select(x => $"{x.Name}={x.Value}"));
            var childrenNodes = String.Join(Environment.NewLine, Children.Select(x => x.Render()));



            return $"<{Name} {nodeAttributes}>{childrenNodes}</{Name}>";
            
        }



        //public static INode Div = new HtmlNode("div", null, null);

    }






    public abstract class Node
    {
        public Node(string name, IEnumerable<Attribute> attributes, IEnumerable<Html> children)
        {

        }

    }

    public class Html : Node
    {
        public Html(string name, IEnumerable<Attribute> attributes, IEnumerable<Html> children) : base(name, attributes, children)
        {
        }
    }





    //public class Div : Node
    //{

    //}


    public sealed class Attribute
    {
        public string Name { get; }
        public string Value { get; }

        public Attribute(string name, string value)
        {
            Name = name;
            Value = value;
        }


        public static Func<string, Attribute> Class = (value) => new Attribute("class", value);
        public static Func<string, Attribute> Id = (value) => new Attribute("id", value);


    }








    public class Property
    {

    }

}
