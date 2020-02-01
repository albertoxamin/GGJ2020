using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpikes : Interactable
{
    public bool broken = true;
    public override void Interact()
    {
        if (broken)
        {
            transform.Translate(0, 0, -3f, Space.Self);
            broken = false;
            key = KeyCode.B;
            InteractionText = "Press B to Activate";
        }
        else
        {
            transform.Translate(0, 0, 3f, Space.Self);
            broken = true;
            key = KeyCode.E;
            InteractionText = "Press E to repair";
        }
    }
}