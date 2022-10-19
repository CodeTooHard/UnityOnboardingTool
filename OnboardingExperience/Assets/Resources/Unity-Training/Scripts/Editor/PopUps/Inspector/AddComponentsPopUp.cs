using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AddComponentsPopUp : PopUp
{

    private void OnInspectorUpdate()
    {
        Debug.Log(Selection.activeGameObject.name);
        CheckForRigidBody();
    }

    void CheckForRigidBody()
    {
        if (Selection.activeGameObject.GetComponent<Rigidbody>())
        {
            NextWindow();
        }
    }

}
