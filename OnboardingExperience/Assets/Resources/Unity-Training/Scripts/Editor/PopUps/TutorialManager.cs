using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class TutorialManager : EditorWindow
{
    Rect size;
    [SerializeField] private Dictionary<ScriptableObject, PopUp> Windows = new Dictionary<ScriptableObject, PopUp>();
    [MenuItem("Window/Tutorial Manager")]
    static void Init()
    {
        PopUpManager.InitializePopUpArrays();
        EditorWindow window = EditorWindow.CreateInstance<TutorialManager>();
        window.Show();
        
    }

    private void Update()
    {
        Debug.Log("Why tho");
    }

    private void OnGUI()
    {
        //size = new Rect(500, 250, 250, 100);
        //GetWindow<TutorialManager>().maxSize = new Vector2(250,100);    

        //PopUp nextWindow = EditorWindow.CreateInstance<GenericPopUp>();
        //GUILayout.Label("Select a section to start");
        
        if (GUILayout.Button("Hierarchy"))
        {
            PopUpManager.StartTutorial(0);
        }
        else if (GUILayout.Button("Inspector"))
        {
            PopUpManager.StartTutorial(1);

        }
        else if (GUILayout.Button("Scene View"))
        {
            PopUpManager.StartTutorial(2);
        }
        else if (GUILayout.Button("Game View"))
        {
            PopUpManager.StartTutorial(3);
        }
        else if (GUILayout.Button("Build"))
        {
            PopUpManager.StartTutorial(4);
        }
        else if (GUILayout.Button("Package Manager"))
        {
            PopUpManager.StartTutorial(5);
        }
        else if (GUILayout.Button("Profiler"))
        {
            PopUpManager.StartTutorial(6);
        }
        else if (GUILayout.Button("Auditor"))
        {
            PopUpManager.StartTutorial(7);
        }

        //if (nextWindow.GetPath() != null)
        //{
        //    nextWindow.InitializePopup();
        //    nextWindow.Repaint();
        //    nextWindow.Show();
        //}
    }
}
