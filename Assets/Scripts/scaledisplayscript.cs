using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scaledisplayscript : MonoBehaviour
{
    public Slider WeightSlider;
    ScaleScript scalesscript;

    public Slider WeightSlider1 { get => WeightSlider; set => WeightSlider = value; }

    // Start is called before the first frame update
    void Start()
    {
        scalesscript = FindObjectOfType<ScaleScript>().GetComponent<ScaleScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //WeightSlider.value = scalesscript.GetList().Count;
        //Debug.Log(scalesscript.GetList().Count);
    }
}