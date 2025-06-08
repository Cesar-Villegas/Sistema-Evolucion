using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCharacterInput : MonoBehaviour
{
    [SerializeField] MouseInput mouseInput;

    CharacterMovementInput characterMovementInput;
    AttackInput attackInput;
    InteractInput interactInput;

    private void Awake()
    {
        characterMovementInput = GetComponent<CharacterMovementInput>();
        attackInput = GetComponent<AttackInput>();
        interactInput = GetComponent<InteractInput>();
    }

    private void Update(){

        if (EventSystem.current.IsPointerOverGameObject()){
            return;
        }

        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E)){
            if(attackInput.AttackCheck() & Input.GetMouseButtonDown(0)){
                Debug.Log("Attacking");
                attackInput.Attack();
                return;
            }

            if(interactInput.InteractCheck() & Input.GetKeyDown(KeyCode.E)){
                Debug.Log("Interacting");
                interactInput.Interact();
                return;
            }

            
            if(Input.GetMouseButtonDown(0)){
                Debug.Log("Moving");
                interactInput.ResetState();
                characterMovementInput.MoveInput();
            }

            
        }
    }
}
