using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public static Car instance;

    private bool driving = false;
    private Rigidbody2D rb2d;
    public static float drivingForce = 8f;
    public static float topSpeed = 6f;

    public GameObject explosion;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        driving = false;
        instance = this;
    }

    public void Drive()
    {
        driving = true;
    }

    public void Brakes()
    {
        driving = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!driving) return;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (!driving) return;
        //Debug.Log("Driving!");
        if (rb2d.velocity.magnitude <= topSpeed)
        {
            rb2d.AddRelativeForce(new Vector2(drivingForce, 0));
        } else
        {
            Debug.Log("Too fast!");
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        float angle = transform.rotation.eulerAngles.z % 360;
        if (angle > 90 && angle < 270)
        {
            //Debug.Log("Boom because angles! Angle was " + transform.rotation.eulerAngles.z);
            GoBoom(collision.GetContact(0).point);
            return;
        }


        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            //Debug.Log("Boom because ground!");
            GoBoom(collision.GetContact(0).point);
        }
    }

    public void GoBoom(Vector2 point)
    {
        //Instantiate(explosion, transform.position, Quaternion.identity);
        GameController.instance.GameOver();
        //Destroy(gameObject);
    }

    public void Win()
    {
        Destroy(gameObject);
    }
}
