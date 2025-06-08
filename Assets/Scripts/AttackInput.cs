using UnityEngine;

public class AttackInput : MonoBehaviour{
    InteractInput interactInput;
    AttackHandler attackHandler;

    private void Awake(){
        interactInput = GetComponent<InteractInput>();
        attackHandler = GetComponent<AttackHandler>();
    }

    // void Update(){
    //     if(Input.GetMouseButtonDown(0)){
    //         if(interactInput.hoveringOverObject != null){
    //             attackHandler.Attack(interactInput.hoveringOverCharacter);
    //         }
    //     }
    // }

    public void Attack(){
        attackHandler.Attack(interactInput.hoveringOverCharacter);
    }

    public bool AttackCheck(){
        return interactInput.hoveringOverObject != null;
    }
}
