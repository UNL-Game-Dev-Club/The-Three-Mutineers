using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

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
