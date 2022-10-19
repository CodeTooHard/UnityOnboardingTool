using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest", fileName = "New Quest")]
public class Quest : ScriptableObject
{
    [HideInInspector] public enum QuestType {Interaction, Kill, Gather}
    public QuestType type;

    public string title;
    [TextArea(15,15)]
    public string details;
    [TextArea(15, 15)]
    public string helpTip;
    public string shortText; //Short version of the quest details to be shown on screen at all times.
    public string turnInText;

    public int goalCount;
    private int currentCount;
    public int xp;

    public GameObject target;
    public bool isComplete = false;

    //Resets the value to false on further plays
    private void Awake()
    {
        isComplete = false;
    }
    public void ProgressQuest()
    {
        currentCount++;
        if (currentCount >= goalCount)
        {
            isComplete = true;
        }
    }
}
