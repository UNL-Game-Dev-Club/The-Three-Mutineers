using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Controls : MonoBehaviour
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
    [SerializeField] GameObject key;

    [SerializeField] public GameObject deadText;
    [SerializeField] GameObject playerCamera;

    public static bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        controllerNames = Input.GetJoystickNames();
        Debug.Log(controllerNames.Length + " controllers");
        foreach (string name in controllerNames)
        {
            Debug.Log(name);
        }

        thisRigidbody = GetComponent<Rigidbody2D>();

        if (name == "P1" || name == "P2" || name == "P3")
        {
            isPlayer = true;
        }
        else
        {
            isPlayer = false;
        }

        GetComponent<HealthController>().Health = HealthController.HUMAN_MAX_HEALTH;
    }

    // Update is called once per frame
    void Update()
    {
        position = thisRigidbody.position;

        horizontal = Input.GetAxisRaw("P1 Horizontal");
        vertical = Input.GetAxisRaw("P1 Vertical");
        sprint = Input.GetAxisRaw("P1 Sprint");

        if (Mathf.Abs(sprint) > dead)
        {
            speed = 0.2f;
            GetComponent<Animator>().SetFloat("IdleToWalkToRun", 1);
        }
        else
        {
            speed = 0.1f;
            GetComponent<Animator>().SetFloat("IdleToWalkToRun", 0);
        }

        if (Mathf.Abs(horizontal) > dead)
        {
            transform.Translate(Vector3.right * speed * horizontal);
            GetComponent<Animator>().SetFloat("Horizontal", horizontal);
        }
        else
        {
            GetComponent<Animator>().SetFloat("Horizontal", 0);
        }

        if (Mathf.Abs(vertical) > dead)
        {
            transform.Translate(Vector3.up * speed * vertical);
            GetComponent<Animator>().SetFloat("Vertical", vertical);
        }
        else
        {
            GetComponent<Animator>().SetFloat("Vertical", 0);
        }

        if (Mathf.Abs(horizontal) < dead && Mathf.Abs(vertical) < dead)
        {
            GetComponent<Animator>().SetFloat("IdleToWalkToRun", -1);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.name == "Wall")
            return;

        if (collision.collider.name == "Key")
        {
            Destroy(collision.collider.gameObject);
            gotKey = true;
        }

        Debug.Log(name + " " + collision.collider.name);

        attack = Input.GetButtonDown("P1 Attack");
        if (attack)
        {
            Debug.Log("P1 Attack");
            HealthController otherHealthP1 = collision.collider.GetComponent<HealthController>();
            if (otherHealthP1 != null)
            {
                otherHealthP1.TakeHit();
            }
        }

        if (collision.collider.name == "Exit")
        {
            if (attack && gotKey)
            {
                Destroy(collision.collider.gameObject);
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
        if (gotKey)
            Instantiate(key, transform.position, Quaternion.identity).name = "Key";

        deadText.SetActive(true);
        isDead = true;
        Destroy(gameObject);
    }
}
