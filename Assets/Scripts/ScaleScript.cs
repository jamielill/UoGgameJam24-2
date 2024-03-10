using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleScript : MonoBehaviour
{
    [SerializeField] ParticleSystem ps;
    [SerializeField]   List<ParticleCollisionEvent> colEvents;

    [SerializeField] float scaleReturnSpeed = 2f;
    [SerializeField] float itemMass = .1f;
    float weight;

    [SerializeField] Transform scaleTop, scaleBottom;

    Vector3 vel = Vector3.zero;

    private void Start()
    {

        colEvents = new List<ParticleCollisionEvent>();

        transform.position = scaleTop.position;
        weight = itemMass / 1000;
    }

    private void Update()
    {
        MoveScaleUp();


        if (Input.GetKeyDown(KeyCode.O))
        {
            ResetScales();
        }

    }

    private void OnParticleCollision(GameObject particleSystem)
    {
        ps = particleSystem.GetComponent<ParticleSystem>();
        int colEventCount = ps.GetCollisionEvents(this.gameObject, colEvents);

        
        if (colEventCount > 1)
        {
            if (transform.position.y > scaleBottom.position.y)
            {
                transform.position -= Vector3.up * colEventCount * weight;
            }

        }
    }


    void MoveScaleUp()
    {
        if(colEvents.Count <= 1)
        {
            if (transform.position.y <= scaleTop.position.y - .05f)
            {
                transform.position = Vector3.Lerp(transform.position, scaleTop.position, Time.deltaTime * scaleReturnSpeed);

            }
            else
            {
                transform.position = scaleTop.position;

            }
        }
    }

    public void ResetScales()
    {
        colEvents.Clear();
        //transform.position = scaleTop.position;
    }


    public int GetCollision()
    {
        return colEvents.Count;
    }

    public List<ParticleCollisionEvent> GetList(){

        return colEvents;
    }

    public void SetItemMass(float inMass)
    {
        weight = inMass / 1000;
    }
}
