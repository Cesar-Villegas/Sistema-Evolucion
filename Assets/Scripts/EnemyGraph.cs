using System.Collections.Generic;
using UnityEngine;

public class EnemyGraph
{
    public Dictionary<string, List<string>> adjacencyList = new Dictionary<string, List<string>>();

    public void AddEdge(string from, string to)
    {
        if (!adjacencyList.ContainsKey(from))
            adjacencyList[from] = new List<string>();

        adjacencyList[from].Add(to);
    }

    public void PrintGraph()
    {
        foreach (var node in adjacencyList)
        {
            Debug.Log(node.Key + " → " + string.Join(", ", node.Value));
        }
    }
}