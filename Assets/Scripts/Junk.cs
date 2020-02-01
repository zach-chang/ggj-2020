using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Junk : MonoBehaviour, IPointerDownHandler
{
    public static float rotationSpeed = 300f;
    private Rigidbody2D rb2d;
    private TargetJoint2D tj2d;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        tj2d = GetComponent<TargetJoint2D>();
    }

    public void MoveTowards(Vector2 destination)
    {
        tj2d.enabled = true;
        tj2d.target = destination;
    }

    public void Deselect()
    {
        tj2d.enabled = false;
        rb2d.constraints = RigidbodyConstraints2D.None;
        rb2d.velocity = new Vector2();
    }

    public void Select()
    {
        tj2d.enabled = true;
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        PlayerController.SetJunk(this);
    }

    public void OnPointerDown(PointerEventData data)
    {
        Select();
    }

    public void Rotate(float rotate)
    {
        float deg = rb2d.rotation;
        Debug.Log("Rotation is currently " + deg);
        deg += (-1 * rotate * rotationSpeed * Time.deltaTime);
        Debug.Log("Attempting to set rotation to " + deg);
        rb2d.SetRotation(deg);
        Debug.Log("Rotation is now " + rb2d.rotation);
    }
}
