using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : Interactables
{
    [SerializeField] private GameObject SignUi;

    public override void Interact()
    {
        base.Interact();
        SignUi.SetActive(!SignUi.activeInHierarchy);
    }
}
