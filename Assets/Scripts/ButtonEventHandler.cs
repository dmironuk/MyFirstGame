using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ButtonEventHandler : MonoBehaviour
{
    public Transform Player;

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
        switch (vb.VirtualButtonName)
        {
            case "Forward":
                // Do something
                Debug.Log("Forward");
                Player.transform.Translate(Vector3.forward * 100.0f * Time.deltaTime, Space.World);
                break;
            case "Backward":
                // Do Something
                Debug.Log("Backward");
                Player.transform.Translate(-Vector3.forward * 100.0f * Time.deltaTime, Space.World);
                break;
            case "Left":
                // Do Something
                Debug.Log("Left");
                Player.transform.position += Vector3.left * 100.0f * Time.deltaTime;
                break;
            case "Right":
                // Do Something
                Debug.Log("Right");
                Player.transform.position += Vector3.right * 100.0f * Time.deltaTime;
                break;
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb) { }

}