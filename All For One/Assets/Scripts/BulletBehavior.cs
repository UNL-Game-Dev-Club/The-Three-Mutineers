using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * 0.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HealthController healthController = collision.collider.GetComponent<HealthController>();
        if (healthController != null)
        {
            healthController.TakeHit(10);
        }
        Destroy(gameObject);
    }
}
