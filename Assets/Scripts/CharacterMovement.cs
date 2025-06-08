using System;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour{
    private NavMeshAgent agent;
    public float rotationSpeed = 10f;
    Character character;
    [SerializeField] float default_MoveSpeed = 3.5f;
    float current_MoveSpeed;
    StatsValue moveSpeed;

    private void Awake(){
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        character = GetComponent<Character>();
    }

    private void Start(){
        moveSpeed = character.TakeStats(Statistic.MoveSpeed);
        UpdateMoveSpeed();
    }

    private void UpdateMoveSpeed(){
        agent.speed = default_MoveSpeed * moveSpeed.float_value;
    }
    
    private void Update(){
        if (current_MoveSpeed != moveSpeed.float_value){
            current_MoveSpeed = moveSpeed.float_value;
            UpdateMoveSpeed();
        }
        if (agent.velocity != Vector3.zero){
            RotateTowardsMovementDirection();
        }
    }

    public void SetDestination(Vector3 destinationPosition){
        agent.isStopped = false;
        agent.SetDestination(destinationPosition);
    }
    private void RotateTowardsMovementDirection(){
        Vector3 movementDirection = agent.velocity.normalized;

        if (movementDirection != Vector3.zero){
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,
             rotationSpeed * Time.deltaTime);
        }
    }

    internal void Stop(){
        agent.isStopped = true;
    }
}
