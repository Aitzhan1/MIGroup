using System;
using Unity.VRTemplate;
using UnityEngine;

public class Burner : MonoBehaviour
{
    [SerializeField] private Collider Collider;
    [SerializeField] private XRKnob Knob;
    [SerializeField] private ParticleSystem Fire;
    [field: SerializeField] public InteractableKnobSettings InteractableKnob { get; private set; }
    private bool _isFireEntered;
    public Action<Burner> OnWrong;
    public bool GasActived { get; set; }
    public float KnobValue => Knob.value;
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
        if (Knob.value > 0 && _isFireEntered)
        {
            Debug.Log("Fire"+Knob.value);
            if (!Fire.isPlaying)
            {
                GasActived = true;
                Fire.Play();
            }
        }
        else if (Knob.value <= 0)
        {
            GasActived = false;
            Fire.Stop();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Match match))
        {
            if (match.IsFireEntered)
            {
                Debug.Log("Fire Entered");
                _isFireEntered = true;
                if (Knob.value > 0)
                {
                    GasActived = true;
                    Fire.Play();
                }
            }
        }

        if (other.TryGetComponent(out Analyzer analyzer))
        {
            if (Knob.value <= 0)
            {
                analyzer.SetText("Нормуль");
            }else if (!_isFireEntered)
            {
                OnWrong?.Invoke(this);
                analyzer.SetText("Выключи комфорку");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Match match))
        {
            _isFireEntered = false;
        }
    }

    public void ActivateCollider(bool isActive)
    {
        Debug.Log(isActive);
        Collider.enabled = isActive;
    }

    public void ActivateKnob(bool isActive)
    {
        
    }
}