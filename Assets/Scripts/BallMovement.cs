using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour   {

    private Rigidbody2D rigidbody2D;
    [SerializeField][Range(0.5f, 2.0f)] float forcePower = 1.01f;

    public MovementState moveState = MovementState.NOT_MOVING;
    [SerializeField] private float minVelocity = 5.0f;

     private float ballVelocity; 
    void Start() 
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update() {
        ballVelocity = rigidbody2D.velocity.magnitude;
       
       if (moveState == MovementState.MOVING)
       {
           if (ballVelocity < minVelocity ) 
           {
               moveState = MovementState.NOT_MOVING;
               Debug.Log("not moving bruv");
               //now update score, refactor to be cleaner, make ScoreSystem a singleton 
               FindObjectOfType<ScoreSystem>().UpdateScore();
           }
       }
        
    }

    public void MoveBall(Vector3 newInputForce)
    {
        rigidbody2D.AddForce((newInputForce * forcePower), ForceMode2D.Impulse);
        moveState = MovementState.MOVING;
    }
}
public enum MovementState {
    NOT_MOVING,
    MOVING
}
