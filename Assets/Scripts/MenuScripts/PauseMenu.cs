using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
    }

    public void resume()
    {
        GameplayUI.SetActive(true);
        PauseMenuUI.SetActive(false);
        paused= false;
    }

    public void options()
    {
        PauseMenuUI.SetActive(false);
        OptionsMenuUI.SetActive(true);
    }    
}