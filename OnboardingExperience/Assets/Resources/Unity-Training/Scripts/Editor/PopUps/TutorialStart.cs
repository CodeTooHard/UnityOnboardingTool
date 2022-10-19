using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class TutorialStart : PopUp
{
    [SerializeField] string test;
    [MenuItem("Window/Start Tutorial")]
    static void Init()
    {
        PopUpManager.InitializePopUpArrays();
        PopUpManager.StartTutorial();
    }

    public override void InitializePopup()
    {
        templatePath = "Scripts/Editor/PopUps/ScriptableObjects/TutorialData";
         
        base.InitializePopup();
    }
    private void OnGUI()
    {
        SetUpText();
        SetUpLayout();  
    }

    void SetUpText()
    {
        this.titleContent.text = "Tutorial";
    }

   
}
