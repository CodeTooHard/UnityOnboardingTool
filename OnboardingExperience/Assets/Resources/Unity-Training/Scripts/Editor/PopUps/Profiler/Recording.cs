using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEditor.Profiling;
using UnityEditor;
using UnityEditorInternal;
using UnityEditorInternal.Profiling;
public class Recording : PopUp
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Profiler.enabled)
        {
            NextWindow();
        }
    }
}
