using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ProfilerIntro : PopUp
{


    // Update is called once per frame
    void Update()
    {
        if (ProfilerWindow.HasOpenInstances<ProfilerWindow>())
        {
            NextWindow();
        }
    }
}
