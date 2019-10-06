using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControls : MonoBehaviour
{
    [SerializeField] GameObject start;
    [SerializeField] GameObject end;
    [SerializeField] GameObject spikeBeacon;

    [SerializeField] float time;
    [SerializeField] GameObject key;

    [SerializeField] GameObject deathPlane;

    static int numGuards = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Walk());
        GetComponent<HealthController>().Health = HealthController.MONSTER_MAX_HEALTH;

        numGuards++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Walk()
    {
        Vector3 destination = end.transform.position;

        time = 0;
        while (true)
        {
            if (deathPlane != null)
            {
                if (deathPlane.activeSelf)
                {
                    destination = spikeBeacon.transform.position;
                }
                else
                {
                    destination = end.transform.position;
                }
            }

            time = 0;
            while (transform.position != destination)
            {
                transform.position = Vector3.Lerp(transform.position, destination, time / 10.0f);
                time += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            destination = start.transform.position;
            time = 0;
            while (time < 20.0f)
            {
                time += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            time = 0;
            while (transform.position != destination)
            {
                transform.position = Vector3.Lerp(transform.position, destination, time / 10.0f);
                time += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            time = 0;
            while (time < 20.0f)
            {
                time += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
    }

    private void OnDestroy()
    {
        numGuards--;
        if (numGuards > 0)
        {
            return;
        }

        Instantiate(key, transform.position, Quaternion.identity).name = "Key";
    }
}
