using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSelectUI : MonoBehaviour
{
    [SerializeField] private Sprite[] ballSprites;
    [SerializeField] private Image image;
    private int index = 0;
    public void BackSelect() {
        if (index <= 0) {
            index = ballSprites.Length - 1;
        } else {
            index--;
        }
        SetImageNIndex();
    }
    public void NextSelect() {
        if (index >= ballSprites.Length-1) {
            index = 0;
        }
        else {
            index++;
        }
        SetImageNIndex();
    }
    public void SetImageNIndex() {
        image.sprite = ballSprites[index];
        BallSelectData.Instance.SetBallPrefIndex(index);
    }
}
