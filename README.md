# Sistema de Evolución Dinámica de Enemigos mediante Reescritura de Grafos

Este sistema permite representar y evolucionar dinámicamente las habilidades de los enemigos en un videojuego, utilizando **grafos reescribibles** como estructura de datos principal.

## 1. Concepto General

Cada enemigo es representado como un **grafo**, donde:

- **Nodos** → representan **habilidades** (activas o pasivas).  
- **Enlaces** → representan **conexiones entre habilidades** o **progresión evolutiva** entre ellas.

El grafo puede ser modificado a lo largo del juego mediante un conjunto de **reglas de reescritura**.

## 2. Reglas de Evolución

El sistema de evolución dinámica ajusta el grafo de habilidades de cada enemigo en función de:

- El **nivel actual** del enemigo.
- El **rendimiento del jugador** (por ejemplo, tiempo de supervivencia, efectividad en combate, etc.).
- Factores probabilísticos o decisiones basadas en IA.

### Probabilidad de Adquisición de Nuevas Habilidades

| Nivel de Enemigo | Probabilidad de adquirir habilidades | Cantidad de habilidades a adquirir |
|------------------|-------------------------------------|-----------------------------------|
| Niveles 2–4      | 10% – 30%                           | 1 habilidad                       |
| Niveles 5–7      | 40% – 60%                           | 2 habilidades                     |
| Niveles 8–10     | 70% – 90%                           | 3 habilidades                     |

### Acumulación de Efectos

- Las habilidades pueden acumular efectos.
- Cada habilidad tiene límites claramente definidos para evitar combinaciones desbalanceadas.

## 3. Proceso de Reescritura de Grafos

1. **Inicialización**  
   Cada enemigo se inicializa con un **grafo base** de habilidades por defecto.

2. **Evaluación de evolución**  
   En momentos clave (por ejemplo, tras derrotas, cambios de zona, o aumento de nivel), el sistema evalúa si el enemigo debe evolucionar.

3. **Aplicación de reglas**  
   Si se decide una evolución, se seleccionan nuevas habilidades de acuerdo a las probabilidades establecidas y se insertan nuevos nodos y enlaces en el grafo.

4. **Validación**  
   Se valida que la acumulación de efectos no exceda los límites permitidos.
