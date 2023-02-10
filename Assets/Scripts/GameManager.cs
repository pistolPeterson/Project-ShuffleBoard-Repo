using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Manages Game stuf.
/// 
/// TO-DO:
/// - After gameOver
/// - cannot move after overgame
/// - spawn stops after gameov
/// - best time for game time
/// - make static and moveable prefabs
/// </summary>
public class GameManager : MonoBehaviour {

    [SerializeField] private Timer timer;
    [SerializeField] private BallMovement ballMovement;
    public bool gameStart = false;
    public UnityEvent OnGameOver;

    [SerializeField] private GameObject spawnPos;
    [SerializeField] private List<GameObject> ballsShot = new List<GameObject>();
    [SerializeField] private GameObject spawnBallPref;
    private GameObject currentBall;
    [SerializeField] private Color32 defaultBallColor;
    [SerializeField] private Color32 ballStopColor;

    // Start is called before the first frame update
    void Start()    {
        gameStart = false;
        currentBall = spawnBallPref;
    }

    // Update is called once per frame
    void Update() {
        if (timer.GetTimerRunning() && !gameStart) {
            ballMovement.moveState = MovementState.MOVING; 
            // if in MOVING state, IT CANNOT BE MOVED AGAIN. IF STAtE IS NOT_MOVING MEAN IT CAN BE MOVED.
            // in DragLine ^
            gameStart = true;
        }
    }
    public void PostGameOverEvent() {
        OnGameOver?.Invoke();
        StopBall();
        FinalScore();
    }
    public void StopBall() {
        Debug.Log("Stop");
        /*
         * find all ball
         * stop ball --> set velocity to zero
         * 
         */
    }
    public void FinalScore() {
        Debug.Log("Final Score");
        /*
         * calls updateScore() to update the final score
         * show results
         */
    }
    public void BallState(GameObject go) {
        if (go == currentBall) {
            SpawnBall();
        }
    }
    public void SpawnBall() {
        ballsShot.Add(currentBall);
        DeactivateBalls();
        currentBall = Instantiate(spawnBallPref, spawnPos.transform.position, Quaternion.identity);

        SpriteRenderer sr = currentBall.GetComponent<SpriteRenderer>();
        sr.color = defaultBallColor;
    }
    public void DeactivateBalls() {
        foreach(GameObject go in ballsShot) {
            DragLine dL = go.GetComponent<DragLine>();
            dL.IsActive = false;
            SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
            sr.color = ballStopColor;
        }
    }

}
