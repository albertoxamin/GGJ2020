using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonTrap : Interactable
{
    private bool m_Broken = true;
    [SerializeField] private Animator devilAnimator;
    public Transform demon;
    [SerializeField] AudioClip demonTriggerOne, demonTriggerTwo,demonTriggerThunder;
    private void Start()
    {
        GameManager.Instance.traps++;
        base.Start();
    }
    IEnumerator waitAndPlay()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Stop();
        audio.PlayOneShot(demonTriggerOne);
        yield return new WaitForSeconds(0.3f);
        audio.PlayOneShot(demonTriggerTwo);
        yield return new WaitForSeconds(0.4f);
        audio.PlayOneShot(demonTriggerThunder);
        
    }
    public override void Interact()
    {
        if (m_Broken)
        {
            devilAnimator.SetTrigger("evoke");
            m_Broken = false;
            InteractionText = "";
            demon.transform.localPosition = Vector3.up * 0.3f;
            GameManager.Instance.notBrokenTraps += 1;
            StartCoroutine(waitAndPlay());
            
            
            
        }
        }
        
    }

