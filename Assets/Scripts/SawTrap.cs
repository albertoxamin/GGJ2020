using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrap : Interactable
{
    private bool m_Broken = true;
    [SerializeField] private Animator spikeAnimator;
    [SerializeField] AudioClip spikeRepair, spikeTrigger;

    public override void Interact()
    {
        if (m_Broken)
        {
            spikeAnimator.SetBool("broken", false);
            m_Broken = false;
            InteractionText = "";
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(spikeRepair);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!m_Broken)
        {
            spikeAnimator.SetTrigger("active");
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(spikeTrigger);
        }
    }
}
