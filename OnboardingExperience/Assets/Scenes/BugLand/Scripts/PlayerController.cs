using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float mSpeed;
    private float x, z;
    private static Quest currentQuest;
    private int xp = 0;
    private int level = 1;
    [SerializeField] private Slider experienceBar;
    Vector3 moveDirection;

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerPosition();
    }

    private void SetMoveDirection()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        moveDirection = new Vector3(0, 0, z);
    }

    private void UpdatePlayerPosition()
    {
        SetMoveDirection();
        this.transform.Translate(moveDirection * mSpeed * Time.deltaTime);
        this.transform.Rotate(0, x , 0);
    }

    public static Quest GetQuest()
    {
        return currentQuest;
    }

    public static void SetQuest(Quest _quest)
    {
        currentQuest = _quest;
    }

    public void AddXP(int amount)
    {
       xp += amount;
        if (xp >= 100)
        {
            xp -= 100;
            level++;
            GameEvents.PlayerLeveledUp();
        }
        experienceBar.value = xp;
    }

    public int GetLevel()
    {
        return level;
    }
}
