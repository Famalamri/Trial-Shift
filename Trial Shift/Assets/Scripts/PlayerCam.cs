using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCam : MonoBehaviour
{
    //CREDIT TO MKs Unity https://youtu.be/pSEYdnAHIKg

    public Camera mainCamera;
    public float zoomSpeed = 1;

    private bool buttonReleased;


    //CREDIT TO 'DAVE / GAMEDEVELOPMENT' (https://www.youtube.com/watch?v=f473C43s8nE)

    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
        buttonReleased = true;
        //mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //zoom
        if (Input.GetMouseButtonDown(1))
        {
            buttonReleased = false;
            if(mainCamera.fieldOfView >= 45)
            {
                mainCamera.fieldOfView -= 15;
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            buttonReleased = true;
        }

        if (buttonReleased)
        {
            if(mainCamera.fieldOfView <= 60)
            {
                mainCamera.fieldOfView = 60;
                //mainCamera.fieldOfView += 1;
            }
        }

        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        //handles rotation
        yRotation += mouseX;

        xRotation -= mouseY;

        //limit looking up/down to 90 degrees
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate cam
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        //rotate player along y axis
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
