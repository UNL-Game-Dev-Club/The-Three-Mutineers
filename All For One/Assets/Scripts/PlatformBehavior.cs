using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour
{
    [SerializeField] GameObject gate;
    [SerializeField] BulletSpawner bulletSpawner;

    [SerializeField] bool openGate;
    [SerializeField] bool isP1Platform;
    [SerializeField] bool isP2Platform;
    [SerializeField] bool isP3Platform;

    [SerializeField] bool firesBullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isP1Platform && collision.name != "P1")
        {
            return;
        }
        else if (isP2Platform && collision.name != "P2")
        {
            return;
        }
        else if (isP3Platform && collision.name != "P3")
        {
            return;
        }

        /* if (collision.name == "P1")
        {
            if (collision.GetComponent<Player1Controls>().GotKey)
            {
                bulletSpawner.Spawn();
            }
        } */

        if (firesBullet)
        {
            // if bullet is loaded

            bulletSpawner.Spawn();
        }

        if (openGate)
        {
            gate.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isP1Platform && collision.name != "P1")
        {
            return;
        }
        else if (isP2Platform && collision.name != "P2")
        {
            return;
        }
        else if (isP3Platform && collision.name != "P3")
        {
            return;
        }

        if (openGate)
        {
            gate.SetActive(true);
        }
    }
}
