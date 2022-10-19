using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Pop-Up Manager", fileName = "New Manager")]
public class PopUpManagerData : ScriptableObject
{
    public PopUpTemplate[] Hierarchy;
    public PopUpTemplate[] Inspector;
    public PopUpTemplate[] Scene;
    public PopUpTemplate[] Game;
    public PopUpTemplate[] Build;
    public PopUpTemplate[] PackageManager;
    public PopUpTemplate[] Profiler;
    public PopUpTemplate[] Auditor;
}
