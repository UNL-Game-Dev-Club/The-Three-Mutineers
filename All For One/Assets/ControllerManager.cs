using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    string[] controllerNames;


    // Start is called before the first frame update
    void Start()
    {
        controllerNames = Input.GetJoystickNames();
        foreach(string name in controllerNames)
        {
            Debug.Log(name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
