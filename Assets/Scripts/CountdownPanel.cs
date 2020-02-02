using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownPanel : MonoBehaviour
{
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        text.text = "3";
        Invoke("SayTwo", 1);
    }

    void SayTwo()
    {
        text.text = "2";
        Invoke("SayOne", 1);
    }

    void SayOne()
    {
        text.text = "1";
        Invoke("SayGo", 1);
    }

    void SayGo()
    {
        text.text = "GO!";
        Invoke("Disappear", 1);
    }

    void Disappear()
    {
        Destroy(gameObject);
    }
}
