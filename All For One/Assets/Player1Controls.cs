using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controls : MonoBehaviour
{
    string[] controllerNames;

    const float dead = 0.05f;
    const float speed = 0.5f;

    [SerializeField] float horizontal;
    [SerializeField] float vertical;

    Rigidbody2D thisRigidbody;
    Vector3 position;

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
    }

    // Update is called once per frame
    void Update()
    {
        position = thisRigidbody.position;

        horizontal = Input.GetAxisRaw("P1 Horizontal");
        vertical = Input.GetAxisRaw("P1 Vertical");

        if (Mathf.Abs(horizontal) > dead)
        {
            transform.Translate(Vector3.right * speed * horizontal);
        }
        if (Mathf.Abs(vertical) > dead)
        {
            transform.Translate(Vector3.up * speed * vertical);
        }
    }
}
