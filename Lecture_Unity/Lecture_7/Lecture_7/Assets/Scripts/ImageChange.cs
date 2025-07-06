using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    public Sprite newSprite;

    private Image img;


    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Меняем спрайт.
    public void ChangeSprite()
    {
        img.sprite = newSprite;
        img.SetNativeSize();
    }


    // Меняем на спрайте цвет.
    public void ChahgeColor()
    {
        //img.color = Color.magenta;
        img.color = new Color(0.1f, 0.2f, 0.3f);
    }
}
