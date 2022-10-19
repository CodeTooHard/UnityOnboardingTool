using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class ScalingObjectsPopUp : PopUp
{
    GameObject scalingObject;
    float x, y, z;

    // Start is called before the first frame update
    void Awake()
    {
        UpdateStartingPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (scalingObject)
        {
            if (scalingObject.transform.localScale.x != x && scalingObject.transform.localScale.y != y && scalingObject.transform.localScale.z != z) //Check if each axis has been altered, if so we can go to next window.
            {
                NextWindow();
            }
        }
    }

    private void OnSelectionChange()
    {
        UpdateStartingPoint();
    }

    private void UpdateStartingPoint()
    {
        scalingObject = Selection.activeGameObject;

        x = scalingObject.transform.localScale.x;
        y = scalingObject.transform.localScale.y;
        z = scalingObject.transform.localScale.z;
    }
}
