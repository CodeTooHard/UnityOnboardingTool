using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CPUProfiling : PopUp
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AssetDatabase.FindAssets("sample").Length > 0)
        {
            foreach (var item in AssetDatabase.FindAssets("sample"))
            {
                Debug.Log(AssetDatabase.GUIDToAssetPath(item));
            }
            NextWindow();
        } else
        {
            Debug.Log("None");
        }
    }
}
