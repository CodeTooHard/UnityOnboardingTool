using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RemovingPackages : PopUp
{

    // Update is called once per frame
    void Update()
    {
        if (AssetDatabase.FindAssets("Auditor", new string[] { "Packages" }).Length <= 0)
        {
            NextWindow();
        }
        else
        {
            Debug.LogWarning("Project Auditor has not been removed yet");
        }
    }
}

