using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactables : MonoBehaviour
{
    [SerializeField] private GameObject interactButton;
    public GameObject finderPanel;
    private float interactRange = 5.0f;
    GameObject player;
    protected bool isInRange = false;

    // Start is called before the first frame update
    public virtual void Start()
    {
        player = GameEvents.FindPlayer();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        isInRange = CheckDistanceToPlayer();
        //Debug.Log(Vector3.Distance(this.transform.position, player.transform.position));
        //If the player is within interact range, show the interact button to the user and check for input.
        if (isInRange)
        {
            interactButton.SetActive(true);
            if (Input.GetButtonDown("Submit"))
            {
                GameEvents.PlayerInteraction(this.gameObject);
                Interact();
            }
        } else
        {
            interactButton.SetActive(false);
        }
    }

    //return true is player is in interact range and false if they are too far away
    private bool CheckDistanceToPlayer()
    {
        if (player == null)
        {
            Debug.LogError("No gameobject with Player tag was found!");
            return false;
        }
        return (Vector3.Distance(this.transform.position, player.transform.position) < interactRange);
    }

    //Implement a custom interact for children to execute when the interact button is pressed.
    public virtual void Interact()
    {
        Quest quest = PlayerController.GetQuest();
        if (quest != null)
        {
            if (quest.type == Quest.QuestType.Interaction && quest.target.name == this.gameObject.name)
            {
                quest.isComplete = true;
            }
        }

    }
}
