using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelectBase : MonoBehaviour
{
    //since main menu scene is index zero, the level numbers will correspond to the actual levels 
    [SerializeField] private int levelNumber = 1;

    private TextMeshProUGUI levelText;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnEnable()
    {
        levelText = GetComponentInChildren<TextMeshProUGUI>();
        levelText.text = levelNumber.ToString();    }

    public void OpenScene()
    {
        SceneManager.LoadScene(levelNumber);
    }
}
