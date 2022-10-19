using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foutain : Interactables
{
    bool foutainIsRunning = false;
    Vector3 offset = new Vector3(0,2,0);
    List<GameObject> foutainSpawns = new List<GameObject>();

    
    //public override void Start()
    //{
    //    base.Start();
       
    //}

    //// Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (foutainIsRunning)
        {
            for (int i = 0; i < 125; i++)
            {
                var o = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                o.transform.position = this.transform.position + offset;
                o.AddComponent<Rigidbody>();
                o.GetComponent<Rigidbody>().AddForce(Vector3.up, ForceMode.Impulse);
                Physics.IgnoreCollision(o.GetComponent<Collider>(), GameEvents.FindPlayer().GetComponent<Collider>());
                foutainSpawns.Add(o);
            }
        }
    }

    public override void Interact()
    {
        base.Interact();
        //On interact toggle the foutain is running bool to the opposite of it's current state.
        foutainIsRunning = !foutainIsRunning; 

        //If the foutain is turned off, then destroy the balls after a couple seconds.
       if (!foutainIsRunning)
        {
            ClearSpawns();
        }
    }

    private void ClearSpawns()
    {
        float destroyDelay = 3f;
        foreach (GameObject spawnedObject in foutainSpawns)
        {
            Destroy(spawnedObject,destroyDelay);
        }
    }
}
