using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3Controls : MonoBehaviour
{
    string[] controllerNames;

    const float dead = 0.05f;
    const float speed = 1f;

    [SerializeField] float horizontal;
    [SerializeField] float vertical;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("P3 Horizontal");
        vertical = Input.GetAxisRaw("P3 Vertical");

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
