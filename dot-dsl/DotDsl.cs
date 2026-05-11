using System.Collections;

public class Node
{
    public readonly string? Name;

    public Node(string? name)
    {
        Name = name;
    }

    public bool Equals(Node other)
    {
        return other.Name == Name;
    }

    public override bool Equals(object? obj)
        => Equals(obj as Node);
}

public class Edge
{
}

public class Attr
{
}

public class Graph : IEnumerable<Node>
{
    public List<Node> Nodes { get; } = [];
    public List<Edge>? Edges { get; } = [];
    public List<Attr>? Attrs { get; } = [];

    public void Add(Node node)
    {
        Nodes.Add(node);
    }

    public IEnumerator<Node> GetEnumerator() => throw new NotImplementedException();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
