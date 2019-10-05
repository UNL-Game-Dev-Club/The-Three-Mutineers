using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controls : MonoBehaviour
{
    string[] controllerNames;

    const float dead = 0.05f;
    const float speed = 1f;

    [SerializeField] float horizontal;
    [SerializeField] float vertical;

    // Start is called before the first frame update
    void Start()
    {
        controllerNames = Input.GetJoystickNames();
        Debug.Log(controllerNames.Length + " controllers");
        foreach (string name in controllerNames)
        {
            Debug.Log(name);
        }
    }

    // Update is called once per frame
    void Update()
    {
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
