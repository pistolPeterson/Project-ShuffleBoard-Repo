using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionPolish : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
//Level 1 impact 0 - 1250
//level 2 impact 1250 - 2500
//level 3 impact 2500 or more
    private void Start()
    {
        particles.Stop();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.CompareTag("BoardBoundary"))
        {
            particles.Emit(50);
            var rb = GetComponent<Rigidbody2D>();
           
        }
    }
}
