using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject p1;
    [SerializeField] GameObject p2;
    [SerializeField] GameObject p3;

    [SerializeField] GameObject p1DeadText;
    [SerializeField] GameObject p2DeadText;
    [SerializeField] GameObject p3DeadText;

    // Start is called before the first frame update
    void Start()
    {
        if (!Player1Controls.isDead)
        {
            GameObject g = Instantiate(p1, new Vector2(-16, 0), Quaternion.identity);
            g.name = "P1";
            g.GetComponent<Player1Controls>().deadText = p1DeadText;
        }
        else
        {
            p1DeadText.SetActive(true);
        }

        if (!Player2Controls.isDead)
        {
            GameObject g = Instantiate(p2, new Vector2(-16, 2), Quaternion.identity);
            g.name = "P2";
            g.GetComponent<Player2Controls>().deadText = p2DeadText;
        }
        else
        {
            p2DeadText.SetActive(true);
        }

        if (!Player3Controls.isDead)
        {
            GameObject g = Instantiate(p3, new Vector2(-16, -2), Quaternion.identity);
            g.name = "P3";
            g.GetComponent<Player3Controls>().deadText = p3DeadText;
        }
        else
        {
            p3DeadText.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1Controls.isDead && Player2Controls.isDead && Player3Controls.isDead)
        {
            SceneManager.LoadScene("dead");
        }
    }
}
