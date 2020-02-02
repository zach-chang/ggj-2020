using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static Junk selected;
    public static PlayerController instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogError("Two Player Controllers! Agh!");
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.active || Input.GetMouseButtonUp(0))
        {
            //Debug.Log("Mouse up!");
            if (selected) selected.Deselect();
            selected = null;
        }

        float rotate = Input.GetAxisRaw("Rotate");

        if (rotate != 0)
        {
            //Debug.Log("Rotate is currently " + rotate);
            if (selected)
            {
                selected.Rotate(rotate);
            }

        }

    }

    private void FixedUpdate()
    {
        if (selected)
        {
            // drag it towards the mouse position
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selected.MoveTowards(mousePos);

        }

    }

    public static void SetJunk(Junk junk)
    {
        selected = junk;
    }


}
