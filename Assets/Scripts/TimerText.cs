using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour
{
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.active) return;
        int time = (int)(1 + GameController.gameTime - Time.time + GameController.startTime);
        text.text = time.ToString();
    }
}
