using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "New Popup", fileName = "New Pop-up")]
public class HierarchyPopUp : PopUp
{
    // Start is called before the first frame update
    float fadeDuration = 5.5f;
    bool skipCreatedGameObject = false;
    string skipGameObjectWarning = "WARNING: You have not yet created a gameobject, if you still wish to proceed and skip this step, press 'Skip Object Creation'";
    GameObject createdGameobject;

    public override void InitializePopup()
    {
        base.InitializePopup();
        
    }

    //void Update()
    //{
    //    if (GameObject.Find("GameObject"))
    //    {
    //        createdGameobject = GameObject.Find("GameObject");
    //        NextWindow();
    //    }
    //}


    private void OnHierarchyChange()
    {
        if (GameObject.Find("GameObject"))
        {
            createdGameobject = GameObject.Find("GameObject");
            NextWindow();
        }
    }
    //protected override void SetUpLayout()
    //{
    //    GUILayout.Label(newTitle, EditorStyles.boldLabel); //Display the title of the box
    //    GUILayout.Box(mainText); //Display text to welcome user
    //    if (GUILayout.Button("Continue"))
    //    {
    //        if (!skipCreatedGameObject)
    //        {
    //            this.ShowNotification(new GUIContent(skipGameObjectWarning), fadeDuration);

    //            return;

    //        } else
    //        {
    //            NextWindow();
    //        }

    //    }
    //    if (GUILayout.Button("Skip Object Creation"))
    //    {
    //        skipCreatedGameObject = true;
    //        this.Close();
    //    }
    //}
}
