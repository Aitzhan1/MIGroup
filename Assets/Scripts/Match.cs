using System;
using UnityEngine;

public class Match : MonoBehaviour
{
    [SerializeField] private ParticleSystem Fire;
    [SerializeField] private Rigidbody rb;
    public bool IsFireEntered { get; private set; }

    private void OnCollisionStay(Collision collision)
    {
       // Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("MatchBox"))
        {

            float speed = rb.linearVelocity.magnitude;
          //  Debug.Log(speed);
            if (speed < 0.5f) return;
            
            Vector3 contactNormal = collision.contacts[0].normal;
            float dot = Vector3.Dot(rb.linearVelocity.normalized, -contactNormal);
            Debug.Log(speed+" Dot: "+dot);

            if (dot > 0.2f)
            {
                Ignite();
            }
        }
    }

    private void Ignite()
    {
        if (!Fire.isPlaying)
        {
            IsFireEntered = true;
            Fire.Play();
            Debug.Log("Fire");
        }
    }
    
}