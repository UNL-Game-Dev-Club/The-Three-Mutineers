using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Controls : MonoBehaviour
{
    string[] controllerNames;

    const float dead = 0.05f;
    float speed = 0.1f;

    [SerializeField] float horizontal;
    [SerializeField] float vertical;
    [SerializeField] float sprint;

    Rigidbody2D thisRigidbody;
    Vector3 position;

    [SerializeField] bool attack;

    bool isPlayer;

    bool gotKey;

    [SerializeField] GameObject deadText;
    [SerializeField] GameObject playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody2D>();

        if (name == "P1" || name == "P2" || name == "P3")
        {
            isPlayer = true;
        }
        else
        {
            isPlayer = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        position = thisRigidbody.position;

        horizontal = Input.GetAxisRaw("P2 Horizontal");
        vertical = Input.GetAxisRaw("P2 Vertical");
        sprint = Input.GetAxisRaw("P2 Sprint");

        if (Mathf.Abs(sprint) > dead)
        {
            speed = 0.2f;
        }
        else
        {
            speed = 0.1f;
        }

        if (Mathf.Abs(horizontal) > dead)
        {
            transform.Translate(Vector3.right * speed * horizontal);
        }
        if (Mathf.Abs(vertical) > dead)
        {
            transform.Translate(Vector3.up * speed * vertical);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.name == "Wall" || collision.collider.name == "Walls")
            return;

        if (collision.collider.name == "Key")
        {
            Destroy(collision.collider.gameObject);
            gotKey = true;
            return;
        }

        Debug.Log(name + " " + collision.collider.name);

        attack = Input.GetButtonDown("P2 Attack");
        if (attack)
        {
            Debug.Log("P2 Attack");
            HealthController otherHealthP2 = collision.collider.GetComponent<HealthController>();
            if (otherHealthP2 != null)
            {
                otherHealthP2.TakeHit();
            }
        }
    }

    public bool GotKey
    {
        get
        {
            return gotKey;
        }
    }

    private void OnDestroy()
    {
        deadText.SetActive(true);
    }
}
