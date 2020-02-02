using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Interactor : MonoBehaviour
{
    private Camera playerCamera;
    [SerializeField] private Animator Animator;
    public Transform HoldPosition;
    private Transform heldObject;

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
        else if (hit.collider && hit.rigidbody && !heldObject)
        {
            Hud.Instance.SetInteractionText("Press E to grab");
            if (Input.GetKeyDown(KeyCode.E))
            {
                heldObject = hit.transform;
                hit.rigidbody.isKinematic = true;
                heldObject.SetParent(HoldPosition);
                heldObject.localPosition = Vector3.zero;
                heldObject.localRotation = Quaternion.identity;
            }
        }
        else
        {
            Hud.Instance.SetInteractionText("");
        }

        if (heldObject)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                heldObject.GetComponent<Rigidbody>().isKinematic = false;
                heldObject.GetComponent<Rigidbody>().AddForce((transform.forward+transform.up/2f)*500f);
                heldObject.SetParent(null);
                heldObject = null;
            }
        }

        Animator.SetFloat("MovementSpeed", transform.parent.GetComponent<Rigidbody>().velocity.magnitude);
    }
}