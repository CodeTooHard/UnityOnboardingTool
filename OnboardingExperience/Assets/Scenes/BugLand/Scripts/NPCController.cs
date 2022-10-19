using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class NPCController : Interactables
{
    [SerializeField] private Quest quest;
    [SerializeField] private GameObject questAvailableIcon;
    [SerializeField] private GameObject questTurnInIcon;

    private bool hasQuest;

    [SerializeField] private GameObject questPanel;
    [SerializeField] private GameObject questTitle;
    [SerializeField] private GameObject questDetails;
    [SerializeField] private GameObject completeButton;

    public override void Start()
    {
        base.Start();
        //Check if the NPC was set up with a quest
        if (quest != null && PlayerController.GetQuest() != quest)
        {
            hasQuest = true;
            
        }

    }
    public override void Interact()
    {
        base.Interact();

        if (quest != null)
        {
            //If the player doesn't have a quest, update the quest UI panel and show it for the player to accept/decline the quest
            if (PlayerController.GetQuest() == null)
            {

                questTitle.GetComponent<TextMeshProUGUI>().text = quest.title;
                questDetails.GetComponent<TextMeshProUGUI>().text = quest.details;
                questPanel.SetActive(true);
                completeButton.SetActive(false);
            }
            else if (quest == PlayerController.GetQuest() && quest.isComplete)
            {
                questPanel.SetActive(true);
                completeButton.SetActive(true);

            }
            else
            {
                Debug.LogWarning("Interact failed, already have quest!");
            }
        }
    }

    public override void Update()
    {
        base.Update();
        DisplayIcon();
    }

    public Quest GetQuest()
    {
        return quest;
    }

    public void SetQuest(Quest quest)
    {
        this.quest = quest;
    }

    private void DisplayIcon()
    {
        if (quest != null)
        {
            //If the player does not have a quest, is too far to interact and this NPC has a quest to give, show the quest available icon.
            questAvailableIcon.SetActive(hasQuest && (isInRange == false) && PlayerController.GetQuest() != quest);

            //If the player is far but has a matching quest that is completed, show the question icon.
            questTurnInIcon.SetActive(quest == PlayerController.GetQuest() && isInRange == false && quest.isComplete);
        }
    }
}
