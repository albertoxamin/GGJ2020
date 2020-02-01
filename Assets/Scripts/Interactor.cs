using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class Interactor : MonoBehaviour
{
    private Camera playerCamera;
    [SerializeField]private Animator Animator;

    private void Awake()
    {
        playerCamera = GetComponent<Camera>();
    }
    
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(playerCamera.ViewportPointToRay(Vector3.one / 2f), out hit, 2f);
        if (hit.collider && hit.collider.CompareTag("Interaction"))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            Hud.Instance.SetInteractionText(interactable.InteractionText);
            if (Input.GetKeyDown(interactable.key))
            {
                Animator.SetTrigger("Interact");
                interactable.Interact();
            }
        }
        else
        {
            Hud.Instance.SetInteractionText("");
        }
        Animator.SetFloat("MovementSpeed", transform.parent.GetComponent<Rigidbody>().velocity.magnitude);
    }
    
}
