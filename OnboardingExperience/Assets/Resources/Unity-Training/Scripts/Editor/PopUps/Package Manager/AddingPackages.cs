using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AddingPackages : PopUp
{

    // If there is a project auditor installed, go to next window
    void Update()
    {
        if (AssetDatabase.FindAssets("Auditor", new string[] { "Packages" }).Length > 0)
        {
            NextWindow();
        } else
        {
            Debug.LogWarning("No auditor found");
        }
    }

}
