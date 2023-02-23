using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BallMovement : MonoBehaviour   {

    private Rigidbody2D rb2d;
    [SerializeField][Range(0.5f, 3.0f)] float forcePower = 1.01f;

    public MovementState moveState;
    [SerializeField] private float minVelocity = 5.0f;
    [SerializeField] private int obstacleLayerIndex;
    [SerializeField] private int ballLayerIndex;


    private float ballVelocity;

    [SerializeField] private BallAudio ballAudio;
    void Start() 
    {
        moveState = MovementState.MOVING;
        rb2d = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(obstacleLayerIndex, ballLayerIndex);
    }

    void Update() {
       
        ballVelocity = rb2d.velocity.magnitude;
       
       if (moveState == MovementState.MOVING || moveState == MovementState.CHANGING)
       {
           if (ballVelocity < minVelocity) 
           {
                var gameStarted = FindObjectOfType<GameManager>().isGameStarted;
                if (!gameStarted) return;
                if (moveState == MovementState.CHANGING) {
                    FindObjectOfType<GameManager>().BallState(gameObject);
                    GetComponent<BallValue>().DetermineScore();
                    GetComponent<BallValue>().CallUpdateScore();
                    PostGameplayAudio();
                }
                moveState = MovementState.NOT_MOVING;

                //now update score, refactor to be cleaner, make ScoreSystem a singleton
            }
        } 
    }

   
    public void MoveBall(Vector3 newInputForce)
    {
        rb2d.AddForce((newInputForce * forcePower), ForceMode2D.Impulse);
        moveState = MovementState.MOVING;
        ballAudio.PlayBallHitSfx(newInputForce.magnitude);
        
    }
    
  
    
    private void PostGameplayAudio()
    {

        GameplayUIAudio gameplayUIAudio = FindObjectOfType<GameplayUIAudio>();
        if(gameplayUIAudio == null) return;

        var score = GetComponent<BallValue>().GetBallValue();
        gameplayUIAudio.PlayAudioBasedOnScore(score);
        
    }
    
}
//state machine
// moving state: if ballvel is less than the min than go to changing
//changing: do one frame of logic then go to not moving 
//not moving: if velocity changes go to moving 


public enum MovementState {
    NOT_MOVING,
    MOVING,
    CHANGING // State to make new ball
}
