using System.Collections;

using Xunit.Runner.Common;

public class Node : IEquatable<Node>, IEnumerable
{
    public readonly string? Name;
    public Dictionary<string, string> Values { get; } = [];
    public List<Attr>? Attrs { get; } = [];


    public Node(string? name)
    {
        Name = name;
    }

    public void Add(string label, string value)
    {
        Attrs.Add(new Attr(label, value));
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Values.GetEnumerator();
    }

    public bool Equals(Node? other)
    {
        return Name == other?.Name;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Node);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name);
    }
}

public class Edge : IEnumerable
{
    public readonly string NodeName1;
    public readonly string NodeName2;
    public List<Attr>? Attrs { get; } = [];

    public Edge(string nodeName1, string nodeName2)
    {
        NodeName1 = nodeName1;
        NodeName2 = nodeName2;
    }

    public void Add(string label, string value)
    {
        Attrs.Add(new Attr(label, value));
    }

    public IEnumerator GetEnumerator()
    {
        yield break;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Edge);
    }

    public bool Equals(Edge? other)
    {
        return other.NodeName1 == NodeName1 && other.NodeName2 == NodeName2;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(NodeName1, NodeName2);
    }
}

public record Attr(string Key, string Value);

public class Graph : IEnumerable
{
    public List<Node> Nodes { get; } = [];
    public List<Edge>? Edges { get; } = [];
    public List<Attr>? Attrs { get; } = [];

    public void Add(Node node)
    {
        Nodes.Add(node);
    }

    public void Add(Edge edge)
    {
        Edges.Add(edge);
    }

    public void Add(string label, string value)
    {
        Attrs.Add(new(label, value));
    }

    public IEnumerator GetEnumerator()
    {
        yield break;
    }
}
