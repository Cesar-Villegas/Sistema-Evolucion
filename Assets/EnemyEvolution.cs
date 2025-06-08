using System.Collections.Generic;
using UnityEngine;

public class EnemyEvolution
{
    private EnemyGraph enemyGraph;
    private string enemyName;
    private int gameLevel;
    
    public EnemyEvolution(int level)
    {
        enemyName = "Enemigo";
        gameLevel = level;
        enemyGraph = new EnemyGraph();

        // Agregar "Forma base" como nodo inicial
        enemyGraph.adjacencyList["Forma base"] = new List<string>();

        // Agregar habilidades iniciales
        enemyGraph.AddEdge("Forma base", "Ataque 1");
        enemyGraph.AddEdge("Ataque 1", "Ataque 2");

        Debug.Log(enemyName + " aparece con habilidades base. ");
        Debug.Log("Nivel del juego: " + gameLevel);

        if (gameLevel > 1)
        {
            EvolveEnemy();
        }
    }

    public bool EvolveEnemy()
{
    List<string> possibleAbilities = new List<string>
    {
        "Ataque de fuego", "Ataque de hielo", "Ataque de veneno", "Ataque de rayo",
        "Ataque de agua", "Ataque de viento", "Ataque de tierra", "Ataque de luz",
        "Ataque de oscuridad"
    };

    float evolutionChance = Mathf.Clamp01(gameLevel * 0.1f); // Probabilidad de evolución
    int newAbilitiesCount = Mathf.Clamp(gameLevel / 2, 1, 3); // Número de habilidades a agregar

    bool evolved = false;

    if (Random.value < evolutionChance)
    {
        for (int i = 0; i < newAbilitiesCount; i++)
        {
            string newAbility = possibleAbilities[Random.Range(0, possibleAbilities.Count)];

            if (!enemyGraph.adjacencyList.ContainsKey(newAbility))
            {
                enemyGraph.AddEdge("Forma base", newAbility);
                Debug.Log("Nueva habilidad adquirida: " + newAbility);
                evolved = true;
            }
        }
    }

    // 🔹 Verificar que las habilidades están realmente dentro del grafo
    Debug.Log("Habilidades en el grafo después de evolucionar:");
    foreach (var node in enemyGraph.adjacencyList)
    {
        Debug.Log($"{node.Key} -> [{string.Join(", ", node.Value)}]");
    }

    return evolved; // Devuelve "true" si el enemigo evolucionó
}



    public void PrintAbilities()
    {
        enemyGraph.PrintGraph();
    }

    public EnemyGraph GetGraph()
    {
        return enemyGraph ?? new EnemyGraph(); // Si es null, crea uno nuevo
    }
}