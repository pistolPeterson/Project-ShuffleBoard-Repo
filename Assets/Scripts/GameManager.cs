using System;
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
    [HideInInspector] public bool isGameStarted = false;
    [HideInInspector] public bool gameOver = false;
    public UnityEvent OnGameOver;
    public UnityEvent OnBallSpawn;
    [SerializeField] private GameObject spawnPos;
    [SerializeField] private List<GameObject> ballsShot = new List<GameObject>();
    
    //the ball in the prefabs folder 
    [SerializeField] private GameObject spawnBallPref;
    //the ball thats on the scenee 
 private GameObject startingBall;
    private GameObject currentBall;
    private Color32 defaultBallColor = new Color32(255, 255, 255, 255);
    [SerializeField] private Color32 ballStopColor;
    [SerializeField] private GameObject levelSelectPanel;

    private bool isPaused = false;
    //the current level number that the player is on, statistics system uses it to write stats 
    public int CurrentLevelNumber = 1;

    // Start is called before the first frame update
    void Start()    {
        levelSelectPanel.gameObject.SetActive(false);

        InitBall();
        isGameStarted = false;
    }

    // Update is called once per frame
    void Update() {
        if (timer.GetTimerRunning() && !isGameStarted)
        {
            BallMovement ballMovement = currentBall.gameObject.GetComponent<BallMovement>();
            ballMovement.moveState = MovementState.MOVING; 
            // if in MOVING state, IT CANNOT BE MOVED AGAIN. IF STAtE IS NOT_MOVING MEANS IT CAN BE MOVED.
            // in DragLine ^
            isGameStarted = true;
        }
        if (gameOver) {
            StopBall();
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gameOver) return;
            isPaused = !isPaused;

            if (isPaused)
            {
                Paused();
                levelSelectPanel.gameObject.SetActive(true);
            }
            else
            {
                Resume();
                levelSelectPanel.gameObject.SetActive(false);
            }
        }
    }
    public void InitBall() {
        int tempIndx = BallSelectData.Instance.GetSelectBallIndex();
        startingBall = BallSelectData.Instance.GetBallPrefab(tempIndx);
        GameObject tempBall = Instantiate(startingBall, spawnPos.transform);   
        currentBall = tempBall;
        spawnBallPref = startingBall;
    }
    public void PostGameOverEvent() {
        OnGameOver?.Invoke();
        StopBall();
        FinalScore();
        isGameStarted = false;
        gameOver = true;
        levelSelectPanel.gameObject.SetActive(true);
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

  

    public void Paused()
    {
        Debug.Log("we pauseing");
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;

    }
}
