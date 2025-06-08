using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GraphVisualizer : MonoBehaviour
{
    public EnemyGraph enemyGraph; // Grafo del enemigo
    public GameObject nodePrefab; // Prefab para representar nodos
    public Transform graphContainer; // Donde se instancian los nodos

    private Dictionary<string, GameObject> nodeObjects = new Dictionary<string, GameObject>();

    void Start()
    {
        if (enemyGraph != null)
        {
            GenerateGraph();
        }
    }

    public void GenerateGraph()
{
    ClearGraph(); // 🔹 Limpiar nodos anteriores

    if (enemyGraph == null || enemyGraph.adjacencyList.Count == 0)
    {
        Debug.LogWarning("GraphVisualizer: El grafo está vacío o no está inicializado.");
        return;
    }

    // Debug.Log("📌 Generando grafo con " + enemyGraph.adjacencyList.Count + " nodos.");

    Dictionary<string, Vector2> nodePositions = GenerateNodePositions();

    foreach (var node in enemyGraph.adjacencyList.Keys)
    {
        // Debug.Log("🔹 Dibujando nodo: " + node); // 🔹 Verificar que realmente intenta dibujar TODAS las habilidades

        GameObject nodeObj = Instantiate(nodePrefab, graphContainer);
        nodeObj.transform.localPosition = nodePositions[node];

        TMP_Text nodeText = nodeObj.GetComponentInChildren<TMP_Text>();
        if (nodeText != null)
        {
            nodeText.text = node;
        }
        else
        {
            Debug.LogWarning("El prefab del nodo no tiene un componente TMP_Text.");
        }

        nodeObjects[node] = nodeObj;
    }
}


    Dictionary<string, Vector2> GenerateNodePositions()
    {
        Dictionary<string, Vector2> positions = new Dictionary<string, Vector2>();
        int nodeCount = enemyGraph.adjacencyList.Count;

        if (nodeCount == 0) return positions;

        float radius = 300f; // 🔹 Ajusta el tamaño del círculo
        int index = 0;

        foreach (var node in enemyGraph.adjacencyList.Keys)
        {
            float angle = (index * Mathf.PI * 2f) / nodeCount;
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;

            positions[node] = new Vector2(x, y);
            index++;
        }

        return positions;
    }


    void ClearGraph()
    {
        foreach (Transform child in graphContainer)
        {
            Destroy(child.gameObject);
        }
        nodeObjects.Clear();
    }
}
