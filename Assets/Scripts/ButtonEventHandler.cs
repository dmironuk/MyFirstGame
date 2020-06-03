using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ButtonEventHandler : MonoBehaviour
{
    public Transform Player;

    bool moveForward = false;
    bool moveBackward = false;
    bool moveLeft = false;
    bool moveRigth = false;

    float moveSpeed = 10f;
    float rotationSpeed = 10f;

    void Start()
    {
        // Search for all Children from this ImageTarget with type VirtualButtonBehaviour
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; ++i)
        {
            // Register with the virtual buttons TrackableBehaviour
            vbs[i].RegisterOnButtonPressed(OnButtonPressed);
            vbs[i].RegisterOnButtonReleased(OnButtonReleased);
        }
    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        moveForward = false;
        switch (vb.VirtualButtonName)
        {
            case "Forward":
                // Do something
                
                Debug.Log("Forward");
                moveForward = true;
                
                break;
            case "Backward":
                // Do Something
                
                Debug.Log("Backward");
                moveBackward = true;
                
                break;
            case "Left":
                // Do Something
               
                Debug.Log("Left");
                moveLeft = true;
                
                break;
            case "Right":
                // Do Something
                
                Debug.Log("Right");
                moveRigth = true;
                
                break;
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        moveRigth = false;
        moveLeft = false;
        moveForward = false;
        moveRigth = false;
    }

    public void Update()
    {
        if (moveForward != false)
            Player.transform.Translate(new Vector3(0, 0, Time.deltaTime * moveSpeed));
        else if (moveBackward != false)
            Player.transform.Translate(0, 0, Time.deltaTime * -moveSpeed);
        else if (moveRigth != false)
            Player.transform.Rotate(Vector3.up * moveSpeed);
        else if (moveLeft != false)
            Player.transform.Rotate(-Vector3.up * moveSpeed);

    }

}