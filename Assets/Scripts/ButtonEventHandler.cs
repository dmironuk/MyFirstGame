using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ButtonEventHandler : MonoBehaviour//, IVirtualButtonEventHandler
{

    void Start()
    {
        // Search for all Children from this ImageTarget with type VirtualButtonBehaviour
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; ++i)
        {
            // Register with the virtual buttons TrackableBehaviour
            //vbs[i].RegisterEventHandler(this);
        }
    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        switch (vb.VirtualButtonName)
        {
            case "Backward":
                // Do something
                break;
            case "Forward":
                // Do Something
                break;
            case "Left":
                // Do Something
                break;
            case "Right":
                // Do Something
                break;
        }
    }

}