using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bumble : MonoBehaviour
{
   public GameObject[] Icons;

    public Transform pos;

    void Start()
    {
        int n = Random.Range(0, Icons.Length);
        Instantiate(Icons[n], pos.position, Icons[n].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
