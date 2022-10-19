using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class PopUpManager : Editor
{
    private static PopUpManagerData data;
    private static PopUpTemplate[] Hierarchy;
    private static PopUpTemplate[] Inspector;
    private static PopUpTemplate[] Scene;
    private static PopUpTemplate[] Game;
    private static PopUpTemplate[] Build;
    private static PopUpTemplate[] PackageManager;
    private static PopUpTemplate[] Profiler;
    private static PopUpTemplate[] Auditor;

    private static PopUpTemplate[] currentArray;
    private static PopUpTemplate[][] popUpSections;

    private static PopUp currentPopUp;

    private static int currentPopUpIndex;
    private static int currentSectionIndex;

    //Here I want to be able to create an editor window based on the imported information in awake and call this from any other class with PopUpManager.StartTutorial()
    public static void StartTutorial()
    {
        currentPopUpIndex = 0;
        currentSectionIndex = 0;
        currentArray = popUpSections[0];


        PopUp startingPopUp;
        if (currentArray[0].thisPopUpType != null)
        {
            startingPopUp = EditorWindow.CreateInstance(System.Type.GetType(popUpSections[currentSectionIndex][currentPopUpIndex].thisPopUpType)) as PopUp;
        } else
        {
            startingPopUp = EditorWindow.CreateInstance<GenericPopUp>();
        }

        //Creates the instance.
        startingPopUp.InitializePopup(currentArray[currentPopUpIndex]); //Populates the required fields to create the pop-up based on the template it's given in the parameter.
        currentPopUp = startingPopUp;
        startingPopUp.Show(); // When we have an instance and a completed pop-up initialized, we will show it to the user.
    }

    public static void StartTutorial(int index) //Start the tutorial at a specific section instead of the insteaded start.
    {
        currentPopUpIndex = 0;
        currentSectionIndex = index;
        if (index < popUpSections.Length) //If we get an out of range index passed in, proceed with normal start method instead.
        {
            currentArray = popUpSections[currentSectionIndex];
            
        } else
        {
            StartTutorial();
            return;
        }

        PopUp startingPopUp;
        if (currentArray[0].thisPopUpType != null)
        {
            startingPopUp = EditorWindow.CreateInstance(System.Type.GetType(popUpSections[currentSectionIndex][currentPopUpIndex].thisPopUpType)) as PopUp;
            
        }
        else
        {
            startingPopUp = EditorWindow.CreateInstance<GenericPopUp>();
            
        }
        Debug.Log(startingPopUp);
        //Creates the instance.
        startingPopUp.InitializePopup(currentArray[currentPopUpIndex]); //Populates the required fields to create the pop-up based on the template it's given in the parameter.
        currentPopUp = startingPopUp;
        startingPopUp.Show(); // When we have an instance and a completed pop-up initialized, we will show it to the user.
    }

    public static void InitializePopUpArrays()
    {
        data = Resources.Load("Unity-Training/Scripts/Editor/PopUpManager/TutorialManager") as PopUpManagerData;
        Hierarchy = data.Hierarchy;
        Inspector = data.Inspector;
        Scene = data.Scene;
        Game = data.Game;
        Build = data.Build;
        PackageManager = data.PackageManager;
        Profiler = data.Profiler;
        Auditor = data.Auditor;

        popUpSections = new PopUpTemplate[][] { Hierarchy, Inspector, Scene, Game, Build, PackageManager, Profiler, Auditor };
    }

    public static void NextPopUp()
    {
        //Below we are prepping the array indexes to get the correct section and pop-up to load next.
        currentPopUpIndex += 1;
        if (currentPopUpIndex > currentArray.Length - 1)
        {
            if (currentSectionIndex > popUpSections.Length - 1)
            {
                Debug.LogError("Reached the end of the tutorial module");
                return;
            } else
            {
                currentPopUpIndex = 0;
                currentSectionIndex++;
            }
            
        }
        //Instantiate the next pop-up with the corresponding type.
        PopUp nextPopUp;
        nextPopUp = EditorWindow.CreateInstance(System.Type.GetType(popUpSections[currentSectionIndex][currentPopUpIndex].thisPopUpType)) as PopUp;

        //Close the current pop-up since we no longer need it and make the pop-up we are going to, the new current.
        currentPopUp.Close();
        currentPopUp = nextPopUp;

        //Set up the data in the popup using the correct pop-up template and show the pop-up
        nextPopUp.InitializePopup(popUpSections[currentSectionIndex][currentPopUpIndex]);
        Debug.Log(nextPopUp.nextWindow);
        nextPopUp.Show();
    }

    
}
