using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ParentingPopUp : PopUp
{
    // Update is called once per frame
    //void Update()
    //{
    //    CheckChildCount();
    //}

    private void OnHierarchyChange()
    {
        CheckChildCount();
    }

    void CheckChildCount()
    {
        if (GameObject.Find("Main Camera").transform.childCount >= 3)
        {
            NextWindow();

        }
    }
}
