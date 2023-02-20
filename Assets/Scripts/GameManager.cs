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
    [HideInInspector] public bool isGameStarted = false;
    [HideInInspector] public bool gameOver = false;
    public UnityEvent OnGameOver;
    public UnityEvent OnBallSpawn;
    [SerializeField] private GameObject spawnPos;
    [SerializeField] private List<GameObject> ballsShot = new List<GameObject>();
    
    //the ball in the prefabs folder 
    [SerializeField] private GameObject spawnBallPref;
    //the ball thats on the scenee 
    [SerializeField] private GameObject startingBall;
    private GameObject currentBall;
    [SerializeField] private Color32 defaultBallColor;
    [SerializeField] private Color32 ballStopColor;

    //the current level number that the player is on, statistics system uses it to write stats 
    public int CurrentLevelNumber = 1;

    // Start is called before the first frame update
    void Start()    {
        isGameStarted = false;
        currentBall = startingBall;
    }

    // Update is called once per frame
    void Update() {
        if (timer.GetTimerRunning() && !isGameStarted) {
            ballMovement.moveState = MovementState.MOVING; 
            // if in MOVING state, IT CANNOT BE MOVED AGAIN. IF STAtE IS NOT_MOVING MEANS IT CAN BE MOVED.
            // in DragLine ^
            isGameStarted = true;
        }
        if (gameOver) {
            StopBall();
        }
    }
    public void PostGameOverEvent() {
        OnGameOver?.Invoke();
        StopBall();
        FinalScore();
        isGameStarted = false;
        gameOver = true;
    }
    public void StopBall() {
        /*
         * find all ball
         * stop ball --> set velocity to zero 
         */
        BallMovement[] allBall = FindObjectsOfType<BallMovement>();
        foreach (BallMovement go in allBall) {
            go.gameObject.GetComponent<DragLine>().IsActive = false;
        }
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
            ballsShot.Add(currentBall);
            DeactivateBalls();
            SpawnBall();
        }
    }
    public void SpawnBall() {
        
        currentBall = Instantiate(spawnBallPref, spawnPos.transform.position, Quaternion.identity);
        currentBall.GetComponent<BallValue>().Init();
        
        SpriteRenderer sr = currentBall.GetComponent<SpriteRenderer>();
        sr.color = defaultBallColor;
        OnBallSpawn?.Invoke();
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
