using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class RotatingObjectsPopUp : PopUp
{
    GameObject rotatingObject;
    float x, y, z;
    // Start is called before the first frame update
    void Awake()
    {
        UpdateStartingPoint();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (rotatingObject)
    //    {
    //        if (rotatingObject.transform.rotation.x != x && rotatingObject.transform.rotation.y != y && rotatingObject.transform.rotation.z != z) //Check if each axis has been altered, if so we can go to next window.
    //        {
    //            NextWindow();
    //        }
    //    }
    //}

    private void OnInspectorUpdate()
    {
        if (rotatingObject)
        {
            if (rotatingObject.transform.rotation.x != x && rotatingObject.transform.rotation.y != y && rotatingObject.transform.rotation.z != z) //Check if each axis has been altered, if so we can go to next window.
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
        rotatingObject = Selection.activeGameObject;
        Debug.Log(rotatingObject.name);

        x = rotatingObject.transform.rotation.x;
        y = rotatingObject.transform.rotation.y;
        z = rotatingObject.transform.rotation.z;
    }
}
