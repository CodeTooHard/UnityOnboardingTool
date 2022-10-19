using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class RemoveComponentsPopUp : PopUp
{
    private void OnInspectorUpdate()
    {
        CheckForRigidBodyRemoved();
    }

    void CheckForRigidBodyRemoved()
    {
        if (!Selection.activeGameObject.TryGetComponent<Rigidbody>(out Rigidbody component))
        {
            NextWindow();
        }
    }
}

