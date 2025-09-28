using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUIManager : MonoBehaviour
{
    public HealthState heathState;
    void Awake()
    {
        heathState.OnDeath += OnDeath;
    }
    void OnDeath(Transform _)
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    void Start()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ShowDeathUI()
    {
        gameObject.SetActive(true);
    }

    public void RestartAction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitAction()
    {
        Application.Quit();
    }
}
