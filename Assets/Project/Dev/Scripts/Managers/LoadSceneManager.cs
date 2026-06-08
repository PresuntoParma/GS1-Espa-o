using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{

    private void Start()
    {
        AudioManager.Instance.PlayMenuMusic();
    }
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
