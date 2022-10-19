using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MovingObjectsPopUp : PopUp
{
    float x, y, z;
    GameObject movingObject; //Target object to check for movement.

    private void Awake()
    {
        UpdateStartingPoint();
    }

    void Update()
    {
        if (movingObject)
        {
            if (Validator.Vector3ComponentChange(new Vector3(x, y, z), movingObject.transform.position))
            {
                NextWindow();
            };
            //if (movingObject.transform.position.x != x && movingObject.transform.position.y != y && movingObject.transform.position.z != z) //Check if each axis has been altered, if so we can go to next window.
            //{
            //    NextWindow();
            //}
        }
    }

    private void OnSelectionChange() //Make the target object for the move whichever object the user is hovering.
    {
        UpdateStartingPoint();
    }

    private void UpdateStartingPoint()
    {
        movingObject = Selection.activeGameObject;
        Debug.Log(movingObject.name);
        x = movingObject.transform.position.x;
        y = movingObject.transform.position.y;
        z = movingObject.transform.position.z;
    }
}
