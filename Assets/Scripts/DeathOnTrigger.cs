using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnTrigger : MonoBehaviour
{
    public bool canKill;
    private void OnTriggerEnter(Collider other)
    {
        if (canKill && other.CompareTag("Player"))
            GameManager.Instance.Death();
    }
}