using System;
using UnityEngine;

public class InteractInput : MonoBehaviour{
    [SerializeField] TMPro.TextMeshProUGUI textOnScreen;
    GameObject currentHoveOverObject;
    [SerializeField] UIPoolBar hpBar;
    [HideInInspector]
    public InteractableObject hoveringOverObject;
    [HideInInspector]
    public Character hoveringOverCharacter;
    InteractHandler interactHandler;

    private void Awake(){
        interactHandler = GetComponent<InteractHandler>();
    }

    void Update(){
        CheckInteractableObject();
    }

    void CheckInteractableObject(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit)){
            if(currentHoveOverObject != hit.transform.gameObject){
                currentHoveOverObject = hit.transform.gameObject;
                UpdateIneractableObject(hit);
            }
        }
    }
    private void UpdateIneractableObject(RaycastHit hit)
    {
        InteractableObject interactableObject = hit.transform.GetComponent<InteractableObject>();
        if (interactableObject != null){
            hoveringOverObject = interactableObject;
            hoveringOverCharacter = interactableObject.GetComponent<Character>();
            textOnScreen.text = hoveringOverObject.objectName;
        }
        else{
            hoveringOverCharacter = null;
            hoveringOverObject = null;
            textOnScreen.text = "";
        }
        
        UpdateHPBAR();
    }

    private void UpdateHPBAR(){
        if(hoveringOverCharacter != null){
            hpBar.Show(hoveringOverCharacter.lifePool);
        }else{
            hpBar.Clear();
        }
    }

    internal void Interact()
    {
        interactHandler.interactedObject = hoveringOverObject;
        // hoveringOverObject.Interact();
    }

    internal bool InteractCheck()
    {
        return hoveringOverObject != null;
    }

    internal void ResetState()
    {
        interactHandler.ResetState();
    }
}
