using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float timeLimit = 30f;
    public float elapsedTime = 0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (elapsedTime > 0)
        {
            elapsedTime -= Time.deltaTime;
            if (elapsedTime <= 0)
            {
                SwitchToEndingScene();
            }
        }
    }

    public void ResetTimer()
    {
        elapsedTime = timeLimit;
    }

    private void SwitchToEndingScene()
    {
        SceneManager.LoadScene("ending");
    }
}
