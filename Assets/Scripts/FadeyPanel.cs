using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeyPanel : MonoBehaviour
{
    public static float time = 1f;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        Color color = image.color;
        color.a = 0;
        image.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        Color color = image.color;
        float alpha = color.a;
        alpha += (Time.deltaTime / time);
        if (alpha >= 1)
        {
            alpha = 1;
            SceneManager.LoadScene("SampleScene");
        }
        color.a = alpha;
        image.color = color;
    }
}
