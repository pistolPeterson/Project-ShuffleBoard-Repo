using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeImageOnHover : MonoBehaviour
{
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite hoverSprite;
    [SerializeField] private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image.sprite = defaultSprite;
    }

    public void OnHoverSprite() {
        image.sprite = hoverSprite;
    }
    public void OnHoverExitSprite() {
        image.sprite = defaultSprite;
    }
}
