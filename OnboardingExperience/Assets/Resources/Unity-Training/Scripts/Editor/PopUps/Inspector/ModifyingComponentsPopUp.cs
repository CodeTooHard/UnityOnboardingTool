using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyingComponentsPopUp : PopUp
{
    //This pop-up checks for a Y axis change.
    GameObject target;
    float startingY;
    
    private void OnInspectorUpdate()
    {
        CheckForYChange();
    }

    void CheckForYChange()
    {
        if (target == null)
        {
            CheckForCube();
        } else
        { 
            if (target.transform.position.y != startingY) //If the y of the object is ever different from the starting Y, that means the instruction is complete, next window.
            {
                NextWindow();
            }
        }

    }

    private void CheckForCube() //Attempt to find a cube reference, if cannot, prompt user to create cube.
    {
        target = GameObject.Find("Cube");
        if (target == null)
        {
            Debug.LogError("No cube was found, please create a cube gameobject in the hierarchy");
        } else
        {
            startingY = target.transform.position.y;
        }
    }
}
