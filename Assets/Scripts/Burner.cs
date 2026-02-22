using System;
using Unity.VRTemplate;
using UnityEngine;

public class Burner : MonoBehaviour
{
    [SerializeField] private Collider Collider;
    [SerializeField] private XRKnob Knob;
    [SerializeField] private ParticleSystem Fire;
    public bool IsFireEntered { get; set; }
    private void OnEnable()
    {
        Knob.onValueChange.AddListener(KnobRotate);
    }

    private void OnDisable()
    {
        Knob.onValueChange.RemoveListener(KnobRotate);
    }

    private void KnobRotate(float arg0)
    {
        if (Knob.value > 0 && IsFireEntered)
        {
            Fire.Play();
        }
        else
        {
            Fire.Stop();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Match match))
        {
            if (match.IsFireEntered)
            {
                IsFireEntered = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Match match))
        {
            IsFireEntered = false;
        }
    }

    public void ActivateCollider(bool isActive)
    {
        Collider.enabled = isActive;
    }
}