using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinker : MonoBehaviour
{
    private Image image;
    public float blinkTime;

    private void Awake()
    {
        image = GetComponent<Image>();
        BlinkOn();
    }

    private void BlinkOn()
    {
        Color color = image.color;
        color.a = 1f;
        image.color = color;
        Invoke("BlinkOff", blinkTime);
    }

    private void BlinkOff()
    {
        Color color = image.color;
        color.a = 0f;
        image.color = color;
        Invoke("BlinkOn", blinkTime);
    }
}
