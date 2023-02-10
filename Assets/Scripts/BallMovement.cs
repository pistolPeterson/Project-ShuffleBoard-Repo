using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour   {

    private Rigidbody2D rb2d;
    [SerializeField][Range(0.5f, 2.0f)] float forcePower = 1.01f;

    public MovementState moveState = MovementState.NOT_MOVING;
    [SerializeField] private float minVelocity = 5.0f;

     private float ballVelocity; 
    void Start() 
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update() {
       
        ballVelocity = rb2d.velocity.magnitude;
       
       if (moveState == MovementState.MOVING)
       {
           if (ballVelocity < minVelocity ) 
           {
               moveState = MovementState.NOT_MOVING;
               //now update score, refactor to be cleaner, make ScoreSystem a singleton
           }
       } 
        
    }

    public void MoveBall(Vector3 newInputForce)
    {
        rb2d.AddForce((newInputForce * forcePower), ForceMode2D.Impulse);
        moveState = MovementState.MOVING;
    }
    
    
    
}
public enum MovementState {
    NOT_MOVING,
    MOVING
}
