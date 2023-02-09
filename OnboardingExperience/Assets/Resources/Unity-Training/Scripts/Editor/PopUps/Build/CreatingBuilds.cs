using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreatingBuilds : PopUp
{
    void Update()
    {
        if (BuildPlayerWindow.HasOpenInstances<BuildPlayerWindow>())
        {
            NextWindow();
        }
    }
}
