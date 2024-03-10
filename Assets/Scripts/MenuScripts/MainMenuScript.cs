using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject OptionsMenu;
    public GameObject MainMenu;
    //[SerializeField] SceneAsset sceneName;

    public void Quit()
    {
        Application.Quit();
        Debug.Log("quit button was pressed");
    }

    public void LoadGame(string scenename)
    {
        SceneManager.LoadScene(scenename);
        Debug.Log("the new game button was pressed");
    }
    
    public void Options()
    {
        OptionsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }
}