using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    int health = 0;
    public const int HUMAN_MAX_HEALTH = 10;
    public const int MONSTER_MAX_HEALTH = 200;
    int startingHealth;

    [SerializeField] GameObject healthBar;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            if (health < 0)
            {
                health = 5;
            }
            else
            {
                startingHealth = value;
                health = value;
            }
        }
    }

    public void TakeHit()
    {
        health--;
        Vector3 scale = healthBar.transform.localScale;
        scale.x = (float) health / startingHealth;
        healthBar.transform.localScale = scale;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeHit(int hit)
    {
        health -= hit;
        Vector3 scale = healthBar.transform.localScale;
        scale.x = (float)health / startingHealth;
        healthBar.transform.localScale = scale;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
