using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEvents : MonoBehaviour
{
    private static GameObject player;
    private static GameObject currentTarget;
    private static Quest quest;
    private static GameObject tipPanel;


    private static GameObject[] NPCS;
    private static GameObject interactionTarget;
    private static TextMeshProUGUI questTrackerText;
    [SerializeField] private static TextMeshProUGUI levelText;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        NPCS = GameObject.FindGameObjectsWithTag("NPC");
        tipPanel = GameObject.Find("Tip Panel");
        questTrackerText = GameObject.Find("Quest ShortText").GetComponent<TextMeshProUGUI>();
        levelText = GameObject.Find("Level Text").GetComponent<TextMeshProUGUI>();
        tipPanel.SetActive(false);

        if (player != null)
        {
            Debug.Log($"Player has been found: {player.gameObject.name}");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static GameObject FindPlayer()
    {
        return player;
    }

    //If the player makes an interaction while holding an interaction quest, check if the target matches the quest target and if so, progress the quest.
    public static void PlayerInteraction(GameObject _target)
    {
        
        currentTarget = _target;
        
        Debug.Log($"Player interacted with an object: {_target.name}");

        if (quest != null)
        {
            if (PlayerController.GetQuest().type == Quest.QuestType.Interaction && PlayerController.GetQuest().target.name == _target.name)
            {
                interactionTarget.GetComponent<Interactables>().finderPanel.SetActive(false);
                tipPanel.SetActive(true);
                GameObject.Find("Tip Details").GetComponent<TextMeshProUGUI>().text = quest.helpTip;
                quest.ProgressQuest();
                if (quest.isComplete)
                {
                    questTrackerText.text = quest.turnInText;
                }
            }
        }
        
    }

    public static void PlayerPickedUpQuest()
    {
        if (currentTarget.GetComponent<NPCController>())
        {
            quest = currentTarget.GetComponent<NPCController>().GetQuest(); 
            {
                interactionTarget = GameObject.Find(quest.target.name);
                interactionTarget.GetComponent<Interactables>().finderPanel.SetActive(true);
            }
             questTrackerText.text = quest.shortText;
        }
        
        PlayerController.SetQuest(quest);
        Debug.Log($"Player picked up a quest: {PlayerController.GetQuest().title}");
    }

    //Award xp on a completed quest and remove the quest from both the NPC and the Player
    public static void PlayerCompletedQuest()
    {
        Debug.Log($"Player completed a quest: {quest.title}");
        //Award XP on this Line

        //Search through the NPCs for the one who has the appropriate quest
        foreach (GameObject npc in NPCS)
        {
            if (npc.GetComponent<NPCController>().GetQuest() == PlayerController.GetQuest())
            {
                npc.GetComponent<NPCController>().SetQuest(null);
            }
        }
        PlayerController.GetQuest().isComplete = false; //Reset the value for future plays
        PlayerController.SetQuest(null); //Remove quest from player so they can pick up other quests

        if (interactionTarget != null)
        {
            interactionTarget = null;
        }

        questTrackerText.text = null;
        player.GetComponent<PlayerController>().AddXP(quest.xp);
        quest = null;
    }

    public static void PlayerLeveledUp()
    {
        Debug.Log($"Player leveled up to: {player.GetComponent<PlayerController>().GetLevel()}" );
        levelText.text = player.GetComponent<PlayerController>().GetLevel().ToString();
        
    }
}
