using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpikes : Interactable
{
    public bool broken;
    public Vector3 translate;

    void Start()
    {
        broken = !broken;
        Interact();
        base.Start();
    }

    public override void Interact()
    {
        if (broken)
        {
            transform.Translate(-translate, Space.Self);
            broken = false;
            key = KeyCode.B;
            InteractionText = "Press B to Activate";
        }
        else
        {
            transform.Translate(translate, Space.Self);
            broken = true;
            key = KeyCode.E;
            InteractionText = "Press E to repair";
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (broken ? translate : -translate));
        Gizmos.DrawWireSphere(transform.position + (broken ? translate : -translate), 0.3f);
    }
}