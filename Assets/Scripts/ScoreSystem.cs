using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    private int randomScore = 0;
    private int currentScore = 0;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private int pointsLowerLimit = -5;
    [SerializeField] private int pointsUpperLimit = 10;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            randomScore = Random.Range(pointsLowerLimit, pointsUpperLimit);
            Debug.Log("RS:" + randomScore);

            currentScore += randomScore;
            scoreText.text = "Score: " + currentScore;
        }     
    }
}
