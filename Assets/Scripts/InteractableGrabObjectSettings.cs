using Unity.VRTemplate;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class InteractableGrabObjectSettings : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable Grab;
    [SerializeField] private Collider Collider;
    [SerializeField] private Outline Outline;
    private Transform _startTransform;
    

    public void ActivateGrab()
    {
        if(Grab)
            Grab.enabled = true;
        
        if (Outline)
            Outline.enabled = true;

        if (Collider)
            Collider.enabled = true;
    }
    
    public void DeactivateGrab()
    {
        gameObject.SetActive(false);
        // Grab.enabled = false;
        // if (Outline)
        // {
        //     Outline.enabled = false;
        // }
    }

    public void ResetGrab()
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