using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button myButton;
    public GameObject text;
    public GameObject icons;
    public GameObject emojis;


    public 

    void Start()
    {
        
        if (myButton != null)
        {
            myButton.onClick.AddListener(OnClick);
        }
        else
        {
            Debug.LogError("El bot�n no est� asignado en el inspector.");
        }
    }

    
    void OnClick()
    {

        text.SetActive(false);
        icons.SetActive(false);
        emojis.SetActive(true);
    }
}