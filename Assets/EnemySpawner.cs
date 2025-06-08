using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public int gameLevel = 1;  // Nivel del juego
    public Button generateButton;
    public GraphVisualizer graphVisualizer; // Asigna esto en el Inspector
    private EnemyEvolution currentEnemy;
    
    void Start()
    {
        generateButton.onClick.AddListener(GenerateEnemy);
    }

    public void GenerateEnemy()
    {
        currentEnemy = new EnemyEvolution(gameLevel);
        currentEnemy.PrintAbilities();

        EnemyGraph enemyGraph = currentEnemy.GetGraph();

        if (graphVisualizer != null && enemyGraph != null)
        {
            graphVisualizer.enemyGraph = enemyGraph;
            graphVisualizer.enemyGraph = currentEnemy.GetGraph();
            graphVisualizer.GenerateGraph();
        }
        else
        {
            Debug.LogWarning("GraphVisualizer o EnemyGraph no están inicializados.");
        }
    }
    public void TryEvolveEnemy()
{
    if (currentEnemy != null && currentEnemy.EvolveEnemy()) // Solo si evoluciona
    {
        if (graphVisualizer != null)
        {
            graphVisualizer.enemyGraph = currentEnemy.GetGraph(); // 🔹 Asegurar que obtiene el grafo actualizado
            Debug.Log("📌 Actualizando grafo en GraphVisualizer con nuevas habilidades.");
            graphVisualizer.GenerateGraph();
        }
    }
}



}



