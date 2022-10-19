using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InspectorIntro : PopUp
{
    GameObject selectedObject;

    private void OnEnable()
    {
        Selection.activeGameObject = null;
    }

    
    void OnSelectionChange()
    {
        if (selectedObject != Selection.activeGameObject)
        {
            selectedObject = Selection.activeGameObject;
            Debug.Log(selectedObject.gameObject.name);
        }
        if (selectedObject != null)
        {
            CheckForCube();
        }
    }

    void CheckForCube()
    {
        if (selectedObject.name == "Cube")
        {
            NextWindow();
        }
    }
}
