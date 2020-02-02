using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firethrower : Interactable
{
    private bool broken = true;
    private bool trigger = false;
    public GameObject prticles;

    [SerializeField] private AudioClip Fire;
    // Start is called before the first frame update
    private void Start()
    {
        GameManager.Instance.traps++;
        prticles.GetComponent<ParticleSystem>().Stop();
        base.Start();
    }

    public override void Interact()
    {
        if (broken)
        {
            trigger = false;
            broken = false;
            InteractionText = "";
            GameManager.Instance.notBrokenTraps ++;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(broken+"-"+trigger);
        if (!broken && !trigger)
        {
            trigger = true;
            prticles.GetComponent<ParticleSystem>().Play();
            AudioSource audio = GetComponent<AudioSource>();
            audio.Stop();
            audio.PlayOneShot(Fire);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (!broken && trigger)
        {
            trigger = false;
            prticles.GetComponent<ParticleSystem>().Stop();
            AudioSource audio = GetComponent<AudioSource>();
            audio.Stop();
        }
    }
}
