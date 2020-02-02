using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonTrap : Interactable
{
    private bool m_Broken = true;
    [SerializeField] private Animator devilAnimator;
    public Transform demon;
    private void Start()
    {
        GameManager.Instance.traps++;
        base.Start();
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
        }
        
    }
}
