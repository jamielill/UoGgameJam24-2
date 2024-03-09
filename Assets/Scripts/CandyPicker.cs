using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CandyPicker : MonoBehaviour
{
    [SerializeField] float rayDist = 50f;

    private GameObject chosenItem;
    private bool isItemChosen;
    private bool isPouringSweets;


    [SerializeField] GameObject candyObject, candyVisual;
    [SerializeField] Transform itemPosOnShelf;
    Vector3 mousePos;

    //smooth item movement
    [SerializeField] float smoothTime = 10f;
    Vector3 vel = Vector3.zero;

    [SerializeField] ParticleSystem currentCandyParticles;

    void Start()
    {
        chosenItem = null;
        isItemChosen = false;

        candyObject.transform.position = itemPosOnShelf.position;

        currentCandyParticles.Pause();
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


    void CandyParticles()
    {

    }


}
