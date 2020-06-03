using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour
{
    public GameObject Menu;
    public bool gameIsPaused = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            gameIsPaused = !gameIsPaused;

        if (gameIsPaused)
        {
            Pause();

        }
        else
            Resume();
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Resume()
    {
        if (gameIsPaused == true)
        {
            Menu.SetActive(false);
            Time.timeScale = 1f;
            gameIsPaused = false;
        }
    }

    public void Pause() 
    {
        Menu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
