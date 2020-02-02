using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Axe : Interactable
{
    private bool broken = true;
    private bool trigger = false; 
    [SerializeField] private Animator axeAnimator;
    [SerializeField] AudioClip axeRepair, axeTrigger;

    private void Start()
    {
        GameManager.Instance.traps++;
        base.Start();
    }

    public override void Interact()
    {
        if (broken)
        {
            axeAnimator.SetBool("broken", false);
            axeAnimator.SetBool("trigger", false);
            trigger = false;
            broken = false;
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(axeRepair);
            InteractionText = "";
        }

        GameManager.Instance.notBrokenTraps += broken ? -1 : 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(broken+"-"+trigger);
        if (!broken && !trigger)
        {
            axeAnimator.SetBool("broken", false);
            axeAnimator.SetBool("trigger", true);
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(axeTrigger);
            trigger = true;
            broken = true;
            axeAnimator.SetBool("broken", true);
            axeAnimator.SetBool("trigger", true);
            InteractionText = "Press E to Repair";
        }
    }
}
