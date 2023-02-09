using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Profiling;

public abstract class PopUp : EditorWindow
{
    protected PopUpTemplate template;
    protected string templatePath;
    protected string newTitle;
    protected string mainText;
    public string nextWindow;
    protected bool isSkippable = true;
    protected Rect location;
    Texture helpImage;
    Vector2 scrollPosition;

    public virtual void InitializePopup() //Sets the data from the template scriptable object or returns an error if no template was provided
    {
        
        if (templatePath != null)
        {
            template = Resources.Load<PopUpTemplate>(templatePath) as PopUpTemplate;

            newTitle = template.title;
            mainText = template.mainText;
            helpImage = template.helpImage;
            //nextWindow = template.NextPopUpType;
            position = template.location;
            isSkippable = template.isSkippable;
            location = template.location;
        }
        else
        {
            Debug.LogError("No template path was provided for PopUp > InitializePopup");
        }

    }

    public virtual void InitializePopup(PopUpTemplate template) //Override used for creating windows with a specific template
    {
        newTitle = template.title;
        mainText = template.mainText;
        helpImage = template.helpImage;
        //nextWindow = template.NextPopUpType;
        position = template.location;
        isSkippable = template.isSkippable;
        location = template.location;
        GUI.color = Color.white;
        GUI.contentColor = Color.white;
        //templatePath = template.nextPopUpDataPath;
    }

    private void OnInspectorUpdate()
    {
        
        this.position = location;
        //ValidationCheck();
    }

    private void OnSelectionChange()
    {
        //Validator.InitializeObject();
    }
    private void OnGUI()
    {
        EditorGUI.hyperLinkClicked += EditorGUI_hyperLinkClicked;
        SetUpLayout();
        GUILayout.Box($"Position \n X: {this.position.x} \n Y: {this.position.y} \n Scale \n W: {this.position.width} \n H: {this.position.height}");
    }

    protected virtual void SetUpLayout()
    {

        GUILayout.Label(newTitle, EditorStyles.boldLabel); //Display the title of the box
        GUILayout.Box(mainText, GUILayout.MaxWidth(this.position.width)); //Display text to welcome user
        if (helpImage)
        {
            GUILayout.Box(helpImage, GUILayout.MaxHeight(this.position.height), GUILayout.MaxWidth(this.position.width));
            this.maxSize = new Vector2(this.maxSize.x, this.maxSize.y + helpImage.height);
        }
        GUILayout.BeginHorizontal(); //Create a horizontal row to store continue and skip button
        if (isSkippable)
        {
            if (GUILayout.Button("Continue"))
            {
                NextWindow();
            }


            if (GUILayout.Button("Close"))
            {
                this.Close();
            }
            GUILayout.EndHorizontal();
        }
        //if (GUILayout.Button("Video Instruction"))
        //{
        //    Application.OpenURL("www.unity.com");
        //}
    }

        public void SetPath(string path)
    {
        templatePath = path;
    }

    public string GetPath()
    {
        return templatePath;
    }

    public virtual void NextWindow()
    {

        PopUpManager.CheckForReference();
    }

    public void ValidationCheck()
    {
        switch (template.validationType)
        {
            case PopUpTemplate.ValidationTypes.Vector3Change:
                Validator.Vector3Change(new Vector3(), new Vector3());
                break;
            default:
                break;
        }
    }

    private static void EditorGUI_hyperLinkClicked(EditorWindow window, HyperLinkClickedEventArgs args)
    {
        //if (window.titleContent.text == "EditorGUIHyperLinkClicked")
        //{
        //    var hyperLinkData = args.hyperLinkData;
        //    var data = hyperLinkData["data"];
        //    var otherData = hyperLinkData["otherData"];

        //    Debug.Log($"data: {data}, otherData: {otherData}");
        //}
    }
}
