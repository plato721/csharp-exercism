using System.Collections;

using Xunit.Runner.Common;

public class Graph : Component
{
    public List<Node> Nodes { get; } = [];
    public List<Edge> Edges { get; } = [];
    public void Add(Node node) => Nodes.Add(node);
    public void Add(Edge edge) => Edges.Add(edge);
}

public class Component : IEnumerable
{
    public List<Attr>? Attrs { get; } = [];
    public void Add(string label, string value) => Attrs.Add(new Attr(label, value));
    public IEnumerator GetEnumerator() => Attrs.GetEnumerator();
}

public class Node : Component
{
    public readonly string? Name;
    public Dictionary<string, string> Values { get; } = [];
    public Node(string? name) => Name = name;
    public bool Equals(Node? other) => Name == other?.Name;
    public override bool Equals(object? obj) => Equals(obj as Node);
    public override int GetHashCode() => HashCode.Combine(Name);
}

public class Edge : Component
{
    public readonly string NodeName1;
    public readonly string NodeName2;

    public Edge(string nodeName1, string nodeName2)
    {
        NodeName1 = nodeName1;
        NodeName2 = nodeName2;
    }

    public override bool Equals(object? obj) => Equals(obj as Edge);

    public bool Equals(Edge? other)
    {
        return other.NodeName1 == NodeName1 && other.NodeName2 == NodeName2;
    }

    public override int GetHashCode() => HashCode.Combine(NodeName1, NodeName2);
}

public record Attr(string Key, string Value);
