using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class Validator 
{
    //static GameObject objectToValidate;

    //public static void InitializeObject()
    //{
    //    if (Selection.activeGameObject)
    //    {
    //        objectToValidate = Selection.activeGameObject;
    //    } else
    //    {
    //        Debug.LogWarning("Tried to initialize an object to validate but no object was selected in the hierarchy");
    //    }
        
    //}


    #region Vector Validations
    public static bool Vector3ComponentChange(Vector3 originalVector, Vector3 newVector)
    {
        if (originalVector.x != newVector.x && originalVector.y != newVector.y && originalVector.z != newVector.z)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public static bool Vector3Change(Vector3 originalVector, Vector3 newVector)
    {
        if (originalVector != newVector)
        {
            return true;
        } else
        {
            return false;
        }
    }


    #endregion
}
