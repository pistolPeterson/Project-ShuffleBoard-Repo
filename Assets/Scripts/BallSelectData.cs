using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSelectData : MonoBehaviour
{
    [SerializeField] private GameObject[] ballPrefabs;
    public static BallSelectData Instance;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start() {
        PlayerPrefs.SetInt("SelectedBallIndex", 0);        
    }
    public int GetSelectBallIndex() {
        return PlayerPrefs.GetInt("SelectedBallIndex");
    }
    public GameObject GetBallPrefab(int index) {
        return ballPrefabs[index];
    }
    public void SetBallPrefIndex(int newIndex) {
        PlayerPrefs.SetInt("SelectedBallIndex", newIndex);
    }
}
