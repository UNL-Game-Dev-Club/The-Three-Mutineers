using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.name == "Wall")
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0;
            return;
        }

        if (Input.GetButtonDown("P2 Attack"))
        {
            Vector2 direction = transform.position - collision.collider.transform.position;
            direction.Normalize();
            direction *= 500;

            GetComponent<Rigidbody2D>().AddForce(direction);
        }

        if (collision.collider.name == "P1" || collision.collider.name == "P3" || collision.collider.name == "Big Man")
            collision.collider.GetComponent<HealthController>().TakeHit();
    }
}
