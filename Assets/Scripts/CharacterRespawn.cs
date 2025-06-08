using UnityEngine;
using UnityEngine.Rendering;

public class CharacterRespawnHandler : MonoBehaviour
{
    Vector3 respawnPosition;
    string respawnSceneName;
    CharacterDefeatHandler characterDefeat;
    [SerializeField] Animator animator;

    private void Awake()
    {
        characterDefeat = GetComponent<CharacterDefeatHandler>();
    }

    private void Start()
    {
        respawnPosition = transform.position;
    }

    public void Respawn()
    {
        gameObject.transform.position = respawnPosition;
        characterDefeat.Respawn();
        animator.Play("Idle");
        animator.SetBool("defeated", false);
    }
}
