using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public int StartSceneIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(true);
    }
    public void PlayAction()
    {
        SceneManager.LoadScene(StartSceneIndex);
    }
    public void QuitAction()
    {
        Application.Quit();
    }
}
