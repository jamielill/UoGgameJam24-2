using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    public float rotationSpeed = 90f;

    private bool isRotating = false; 
    private float targetYRotation = 0f;  //

    void Update()
    {
        // Trigger rotation to -90 degrees when "a" is pressed, if not already rotating
        if (Input.GetKeyDown(KeyCode.A) && !isRotating && Mathf.Abs(transform.eulerAngles.y - (-90)) > 0.01f)
        {
            StartCoroutine(RotateCamera(-90));
        }

        // Trigger rotation back to 0 degrees when "d" is pressed, if not already rotating
        if (Input.GetKeyDown(KeyCode.D) && !isRotating && Mathf.Abs(transform.eulerAngles.y - 0) > 0.01f)
        {
            StartCoroutine(RotateCamera(0));
        }
    }

    IEnumerator RotateCamera(float targetAngle)
    {
        isRotating = true; 
        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
        
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
        {
            //smooth rotation towards the target angle at a constant speed
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }

        transform.rotation = targetRotation; // Ensure the rotation exactly reaches the target
        isRotating = false;
    }
}

