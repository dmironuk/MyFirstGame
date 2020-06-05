using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ButtonEventHandler : MonoBehaviour
{  
    public Transform Player;

    private bool moveForward = false;
    private bool moveBackward = false;
    private bool moveLeft = false;
    private bool moveRigth = false;

    float moveSpeed = 10f;

    float elapsed = 0.0f;
    float rotateSpeed = 1000f;

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
        moveBackward = false;
        moveLeft = false;
        moveForward = false;
        moveRigth = false;
    }

    public void Update()
    {
        elapsed += Time.deltaTime;
        Vector3 EulerRotation = new Vector3(0, elapsed * rotateSpeed, 0);

        if (moveForward != false)
            Player.transform.Translate(new Vector3(0, 0, Time.deltaTime * moveSpeed));
        else if (moveBackward != false)
            Player.transform.Translate(0, 0, Time.deltaTime * -moveSpeed);
        else if (moveRigth != false)
            Player.transform.rotation *= Quaternion.Euler(-EulerRotation);
        else if (moveLeft != false)    
            Player.transform.rotation *= Quaternion.Euler(EulerRotation);
    }

}

