using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ObjectCreatedPopUp : PopUp
{
    // Start is called before the first frame update
    GameObject createdGameobject;
    void OnGUI()
    {
        createdGameobject = GameObject.Find("GameObject");
        SetUpLayout();
    }

    //void SetUpLayout()
    //{
    //    GUILayout.Label(newTitle, EditorStyles.boldLabel); //Display the title of the box
    //    GUILayout.Box(mainText); //Display text to welcome user
    //    if (GUILayout.Button("Continue"))
    //    {
    //      NextWindow();

    //    }
    //}

    //private void Update()
    //{
    //    if (createdGameobject.name != "GameObject")
    //    {
    //        NextWindow();   
    //    }
    //}

    private void OnHierarchyChange()
    {
        if (createdGameobject.name != "GameObject")
        {
            NextWindow();
        }
    }

    public override void NextWindow()
    {
        base.NextWindow();
        Debug.Log($"Object Renamed To {createdGameobject.name}, Opening Next Window....");
        this.Close();
    }
}
