using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : Interactable
{
    private bool broken = true;
    private bool trigger = false;
    [SerializeField] private Animator spikeAnimator;
    [SerializeField] AudioClip spikeRepair, spikeTrigger;

    private void Start()
    {
        GameManager.Instance.traps++;
        base.Start();
    }
    public override void Interact()
    {
        
        if (broken)
        {
            spikeAnimator.SetBool("broken", false);
            spikeAnimator.SetBool("trigger", false);
            trigger = false;
            broken = false;
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(spikeRepair);
            InteractionText = "";
            GameManager.Instance.notBrokenTraps +=  1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(broken+"-"+trigger);
        if (!broken && !trigger)
        {
            spikeAnimator.SetBool("broken", false);
            spikeAnimator.SetBool("trigger", true);
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(spikeTrigger);
            trigger = true;
            broken = true;
            spikeAnimator.SetBool("broken", true);
            spikeAnimator.SetBool("trigger", true);
            InteractionText = "Press E to Repair";
            GameManager.Instance.notBrokenTraps --;
        }
    }
}