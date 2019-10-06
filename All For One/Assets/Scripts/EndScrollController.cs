using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScrollController : MonoBehaviour
{
    [SerializeField] Text congrats;
    [SerializeField] Text title;

    int numPlayersAlive = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (!Player1Controls.isDead)
        {
            numPlayersAlive++;
        }
        if (!Player2Controls.isDead)
        {
            numPlayersAlive++;
        }
        if (!Player3Controls.isDead)
        {
            numPlayersAlive++;
        }

        string[] titles = {"Vassel", "Vassel", "Dukes", "Generals" };
        string[] iNameThee = { "I name thee", "I name thee", "I name thee both", "I name thee all" };

        congrats.text += " " + iNameThee[numPlayersAlive];
        title.text = titles[numPlayersAlive];
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
