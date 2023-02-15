using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour {
   
    [SerializeField] private float getReadyInterval = 1;
    [SerializeField] private float timeInSeconds = 70f;
    [SerializeField] private TMP_Text timerText;
    private bool timerRunning = false;
    private bool gameOver = false;

    // UI stuf : COLORS INITIALIZED ARE DEFAULT. Can be changed in inspector
    [SerializeField] private Color32 getReadyColor = new Color32(125, 205, 209, 255);
    [SerializeField] private Color32 timerColor = new Color32(122, 62, 161, 255);
    [SerializeField] private Color32 timeWarningColor = new Color32(202, 98, 98, 255);
    
    void Start() {
        StartCoroutine(RdySetGO(getReadyInterval));
        timeInSeconds += 1f;
        gameOver = false;
    }
    void Update()
    {
        if (timerRunning && timeInSeconds > 1) {  // Keep at n > 1 so that the timer stops exactly at 00:00
            if (timeInSeconds < 11f)
            {
                TimerColor(timeWarningColor);
            }
            else
            {
                TimerColor(timerColor);
            }

            UpdateTimerText();
        }

        if (timeInSeconds < 0.9999999f && !gameOver) {
            timerText.text = "GAME OVER";
            gameOver = true;
        }              
    }
   private IEnumerator RdySetGO(float time) {
        TimerColor(getReadyColor);
        timerText.text = "Ready";
        yield return new WaitForSeconds(time);
        timerText.text = "Set";
        yield return new WaitForSeconds(time);
        timerText.text = "Go!";
        yield return new WaitForSeconds(time);
        timerRunning = true;
    }
    private void TimerColor(Color32 color) {
        timerText.color = color;
    }

    private void UpdateTimerText()
    {
        timeInSeconds -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60f);

        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00"); // Changes timer text to display time
    }
    public bool GetTimerRunning() {
        return timerRunning;
    }
    public void GameOverAlert() {
        FindObjectOfType<GameManager>().PostGameOverEvent();        
    }
}
