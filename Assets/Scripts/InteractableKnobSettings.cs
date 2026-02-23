using System;
using Unity.VRTemplate;
using UnityEngine;

public class InteractableKnobSettings : MonoBehaviour
{
    [SerializeField] private XRKnob Knob;
    [SerializeField] private Collider KnobCollider;
    [SerializeField] private Outline KnobOutline;
    private Transform _startTransform;
    

    public void ActivateKnob()
    {
        KnobCollider.enabled = true;
        KnobOutline.enabled = true;
    }
    

    public void DeactivateKnob()
    {
        KnobCollider.enabled = false;
        KnobOutline.enabled = false;
    }

    public void ResetKnob()
    {
        transform.position = _startTransform.position;
        transform.rotation = _startTransform.rotation;
    }
    private void OnEnable()
    {
        CachedTransform();
    }

    private void CachedTransform()
    {
        _startTransform = transform;
    }
}