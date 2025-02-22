using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    [SerializeField] string nameScene;
    public void loadScene()
    {
        SceneManager.LoadScene(nameScene);
    }
    public void loadSceneAtNewWindow()
    {
        if (!SceneManager.GetSceneByName(nameScene).isLoaded == true)
        {
            SceneManager.LoadScene(nameScene, LoadSceneMode.Additive);
        }
    }
    public void sceneDeloader()
    {
        SceneManager.UnloadSceneAsync(nameScene);
    }
}
