using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour
{
    [SerializeField] BulletSpawner bulletSpawner;

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
        if (collision.name == "P1")
        {
            if (collision.GetComponent<Player1Controls>().GotKey)
            {
                bulletSpawner.Spawn();
            }
        }
    }
}
