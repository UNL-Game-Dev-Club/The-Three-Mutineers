using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player1Controls.isDead = false;
        Player2Controls.isDead = false;
        Player3Controls.isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("title");
        }
    }
}
