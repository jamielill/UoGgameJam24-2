using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icon_s : MonoBehaviour
{
    public GameObject[] Emojis;



    void Start()
    {
        randomchose();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void randomchose()
    {
        foreach (GameObject icon in Emojis)
        {
            icon.SetActive(false);
        }
        int n = Random.Range(0, Emojis.Length);

        Emojis[n].SetActive(true);

    }

}
