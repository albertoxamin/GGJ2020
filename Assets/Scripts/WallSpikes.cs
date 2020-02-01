using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpikes : Interactable
{
    WallSpikes()
    {
        InteractionText = "Press E to cosare";
    }

    private bool rotto = true;
    public override void Interact()
    {
        if (rotto)
        {
            transform.Translate(0, 0, -2f, Space.Self);
            rotto = false;
        }
    }
}