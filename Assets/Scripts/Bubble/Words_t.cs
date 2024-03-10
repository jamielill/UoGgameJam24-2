using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Words_t : MonoBehaviour
{
    public List<string> A; //name of the list  and the list.

    public TMP_Text textui;
    // Start is called before the first frame update
    void Start()
    {

        A = new List<string>(); //the list and its components, 'A.Add("here add the candy or product") 
        A.Add("A");
        A.Add("B");
        A.Add("C");


        texto_Random();
       
    }

    // Update is called once per frame
    void Update()
    {

    }


  

    public void texto_Random() // Randomness
    {

        int rand = Random.Range(0,A.Count);

        textui.text = "hello" + A[rand]; //here you can change the text that it shows in the Ui text. A[rand] select one componnent form the list

    } 
}
