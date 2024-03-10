using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bubble : MonoBehaviour
{
    public GameObject[] Icons;



    void Start()
    {
        randomchose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void randomchose() {
        foreach (GameObject icon in Icons)
        {
            icon.SetActive(false);
        }
        int n = Random.Range(0, Icons.Length);

        Icons[n].SetActive(true);

    }
        

}
