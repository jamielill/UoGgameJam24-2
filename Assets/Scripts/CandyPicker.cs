using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CandyPicker : MonoBehaviour
{
    [Header("Script/Object References")]
    [SerializeField] ScaleScript scaleScript;


    [Header("Raycast")]
    [SerializeField] float rayDist = 50f;

    private GameObject chosenItem;
    private bool isItemChosen;
    private bool isPouringSweets;


    [Header("Candy Shelf")]
    [SerializeField] GameObject candyObject;
    [SerializeField] GameObject candyVisual;
    [SerializeField] Transform itemPosOnShelf;
    Vector3 mousePos;
    [SerializeField] GameObject hoverItem;

    //smooth item movement
    [SerializeField] float smoothTime = 10f;
    Vector3 vel = Vector3.zero;


    [Header("Particle Visuals")]
    [SerializeField] ParticleSystem currentCandyParticles;
    [SerializeField] Material[] candyMats;


    [Header("Candy Image Visuals")]
    [SerializeField] Image chosenItemImage;
    [SerializeField] Sprite[] candyImages;

    void Start()
    {
        chosenItem = null;
        isItemChosen = false;

        candyObject.transform.position = itemPosOnShelf.position;

        currentCandyParticles.Pause();

        hoverItem = null;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))    //testing purpose to reset the chosen item to nothing
        {
            chosenItem = null;
            Debug.Log(chosenItem);
        }


        if (isItemChosen)
        {
            PourCandy();

            MoveCandyOnScreen();

            if (isPouringSweets)
            {
                //something here when the candy is being poured
                currentCandyParticles.Play();
                CandyParticles();
                Debug.Log("particles");

            }
            else
            {
                currentCandyParticles.Pause();
                currentCandyParticles.Clear();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(1))
            {
                StartCoroutine(PickItem());

            }
            if(Input.GetMouseButtonUp(1))
            {
                StopCoroutine(PickItem());
            }
        }

        //hovering over shelf items will make them bigger when mouse is over them 
        HoverOverItem();
    }


    //sends ray to where mouse is and puts that item as the chosen item
    IEnumerator PickItem() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDist))
        {
            chosenItem = hit.collider.gameObject;
            Debug.Log(chosenItem);

            yield return new WaitForSeconds(0.5f);
            isItemChosen = true;

        }
        else
        {
            chosenItem = null;
            isItemChosen = false;
        }
    }


    //when you let go of mouse button, the pouring stops AND you have to pick another candy from the shelf
    void PourCandy()
    {

        if (Input.GetMouseButton(1))
        {
            Debug.Log("Pouring " + chosenItem);

            isPouringSweets = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            Debug.Log("End pour");

            isPouringSweets = false;
            isItemChosen = false;


            //candy.transform.position = Vector3.Lerp(candy.transform.position, itemPosOnShelf.position, Time.deltaTime* smoothTime);
            candyObject.transform.position = itemPosOnShelf.position;
        }

    }


    void MoveCandyOnScreen()
    {
        Camera cam = GetComponent<Camera>();

        //move object to follow mouse cursor
        mousePos =  cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, (Input.mousePosition.z + 4.67f)));
        candyObject.transform.position = Vector3.SmoothDamp(candyObject.transform.position, mousePos, ref vel, Time.deltaTime * smoothTime);


        //rotate to always face the camera
        Vector3 pos = candyVisual.transform.position - cam.transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        candyVisual.transform.rotation = rotation;
       
    }


    //setup the particles system for each candy type
    void CandyParticles()
    {
        ParticleSystem.MainModule psMain = currentCandyParticles.main;
        ParticleSystem.ShapeModule psShape = currentCandyParticles.shape;



        switch (chosenItem.name)
        {
            case "Item1":
                //
                psMain.startSize = 0.4f;
                psMain.startSpeed = 2;
                //psMain.startColor = Color.white;

                currentCandyParticles.GetComponent<ParticleSystemRenderer>().material = candyMats[0];

                chosenItemImage.sprite = candyImages[0];

                scaleScript.SetItemMass(1);

                break;
            case "Item2":
                //
                psMain.startSize = 1f;
                psMain.startSpeed = 1;
                //psMain.startColor = Color.red;

                currentCandyParticles.GetComponent<ParticleSystemRenderer>().material = candyMats[1];

                chosenItemImage.sprite = candyImages[1];

                scaleScript.SetItemMass(1.1f);

                break;
            case "Item3":
                //
                psMain.startSize = 0.7f;
                psMain.startSpeed = 3;
                //psMain.startColor = Color.blue;

                currentCandyParticles.GetComponent<ParticleSystemRenderer>().material = candyMats[2];

                chosenItemImage.sprite = candyImages[2];

                scaleScript.SetItemMass(0.8f);

                break;
            case "Item4":
                //
                psMain.startSize = 0.5f;
                psMain.startSpeed = 2;
                //psMain.startColor = Color.yellow;

                currentCandyParticles.GetComponent<ParticleSystemRenderer>().material = candyMats[3];

                chosenItemImage.sprite = candyImages[3];

                scaleScript.SetItemMass(0.3f);

                break;
            case "Item5":
                //
                psMain.startSize = .6f;
                psMain.startSpeed = 4;
                //psMain.startColor = Color.magenta;

                currentCandyParticles.GetComponent<ParticleSystemRenderer>().material = candyMats[4];

                chosenItemImage.sprite = candyImages[4];

                scaleScript.SetItemMass(0.4f);

                break;
            case "Item6":
                //
                psMain.startSize = .4f;
                psMain.startSpeed = 1;
                //psMain.startColor = Color.cyan;

                currentCandyParticles.GetComponent<ParticleSystemRenderer>().material = candyMats[5];

                chosenItemImage.sprite = candyImages[5];

                scaleScript.SetItemMass(0.25f);

                break;
            case "Item7":
                //
                psMain.startSize = .3f;
                psMain.startSpeed = 2;
                //psMain.startColor = Color.magenta;

                currentCandyParticles.GetComponent<ParticleSystemRenderer>().material = candyMats[6];

                chosenItemImage.sprite = candyImages[6];

                scaleScript.SetItemMass(0.1f);

                break;
            case "Item8":
                //
                psMain.startSize = .5f;
                psMain.startSpeed = 1;
                //psMain.startColor = Color.cyan;

                currentCandyParticles.GetComponent<ParticleSystemRenderer>().material = candyMats[7];

                chosenItemImage.sprite = candyImages[7];

                scaleScript.SetItemMass(0.4f);

                break;

        }
    }

    void HoverOverItem()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDist))
        {
            /*chosenItem = hit.collider.gameObject;
            Debug.Log(chosenItem);


            isItemChosen = true;*/
            

            hoverItem = hit.collider.gameObject;
            hoverItem.transform.localScale = new Vector3(hoverItem.transform.localScale.x, 1.0005f, 1.0005f);

        }
        else
        {
            
            //hoverItem.transform.localScale = new Vector3(hoverItem.transform.localScale.x, hoverItem.transform.localScale.y, hoverItem.transform.localScale.z);
            hoverItem = null;
        }
    }


}
