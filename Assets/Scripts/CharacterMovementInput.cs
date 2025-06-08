using UnityEngine;

public class CharacterMovementInput : MonoBehaviour{
    [SerializeField] MouseInput mouseInput;
    CharacterMovement characterMovement;

    private void Awake(){
        characterMovement = GetComponent<CharacterMovement>();
    }

    // private void Update(){
    //     if(Input.GetMouseButtonDown(0)){
    //         characterMovement.SetDestination(mouseInput.mouseInputPosition);
    //     }
        
    // }

    public void MoveInput() {
        characterMovement.SetDestination(mouseInput.mouseInputPosition);
    }
}
