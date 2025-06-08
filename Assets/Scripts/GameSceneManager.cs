using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] string currentScene;

    AsyncOperation load;
    AsyncOperation unload;

    private void Start()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i).name != "Essential")
            {
                currentScene = SceneManager.GetSceneAt(i).name;
                break;
            }
        }
    }

    public void StartTransition(string ToSceneName)
    {
        StartCoroutine(Transition(ToSceneName));
    }

    public IEnumerator Transition(string ToSceneName)
    {
        SwitchScenes(ToSceneName);

        while (load.isDone == false & unload.isDone == false)
        {
            yield return new WaitForSeconds(0.1f);
        }

        load = null;
        unload = null;
    }

    public void SwitchScenes(string ToSceneName)
    {
        load = SceneManager.LoadSceneAsync(ToSceneName, LoadSceneMode.Additive);
        unload = SceneManager.UnloadSceneAsync(currentScene);
        currentScene = ToSceneName;
    }
}
