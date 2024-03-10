using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject GameplayUI;
    [SerializeField]
    private GameObject PauseMenuUI;
    [SerializeField]
    private GameObject OptionsMenuUI;

    private bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            GameplayUI.SetActive(false);
            PauseMenuUI.SetActive(true);
            paused = true;
            Time.timeScale = 0.0f;
        }
    }

    public void resume()
    {
        GameplayUI.SetActive(true);
        PauseMenuUI.SetActive(false);
        paused= false;
        Time.timeScale = 1.0f;
    }

    public void options()
    {
        PauseMenuUI.SetActive(false);
        OptionsMenuUI.SetActive(true);
    }

    public void ReturnToMenu(string scenename)
    {
        SceneManager.LoadScene(scenename);
        Debug.Log("the main menu button was pressed");
    }
}
