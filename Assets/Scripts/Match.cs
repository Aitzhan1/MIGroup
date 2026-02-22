using System;
using UnityEngine;

public class Match : MonoBehaviour
{
    [SerializeField] private ParticleSystem Fire;
    public bool IsFireEntered { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MatchBox"))
        {
            
        }
    }
}