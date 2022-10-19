using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingShapesPopUp : PopUp
{
    //private void Update()
    //{
    //    if (GameObject.Find("Cube"))
    //    {
    //        NextWindow();
    //    }
    //}

    private void OnHierarchyChange()
    {
        if (GameObject.Find("Cube"))
        {
            NextWindow();
        }
    }
}

 