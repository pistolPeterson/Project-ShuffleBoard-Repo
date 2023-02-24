using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSelectUI : MonoBehaviour
{
    [SerializeField] Sprite[] ballSprites;
    [SerializeField] Image image;
    int index = 0;
    public void BackSelect() {
        if (index <= 0) {
            index = ballSprites.Length - 1;
        } else {
            index--;
        }
        image.sprite = ballSprites[index];
    }
    public void NextSelect() {
        if (index >= ballSprites.Length-1) {
            index = 0;
        }
        else {
            index++;
        }
        image.sprite = ballSprites[index];
    }
}
