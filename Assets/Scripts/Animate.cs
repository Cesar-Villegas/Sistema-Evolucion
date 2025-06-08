using System;
using UnityEngine;

public class Animate : MonoBehaviour{
    Animator animator;
    UnityEngine.AI.NavMeshAgent agent;
    Character character;

    private void Awake(){
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        character = GetComponent<Character>();
    }

    void Update(){
        float motion = agent.velocity.magnitude;
        animator.SetFloat("motion", motion);
        animator.SetBool("defeated", character.isDead);
    }
}
