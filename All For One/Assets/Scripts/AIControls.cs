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

    [SerializeField] Collider2D deathPlane;

    static int numGuards = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Walk());
        GetComponent<HealthController>().Health = HealthController.MONSTER_MAX_HEALTH;

        numGuards++;

        if (numGuards > 1)
        {
            // randomGuard = Random.Range(0, numGuards);
        }
        else
        {
            // randomGuard = 0;
        }
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
                if (deathPlane.enabled)
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
        Debug.Log("Destroying 1 guard from " + numGuards);
        numGuards--;

        if (numGuards == 0)
        {
            Debug.Log("Dropping key");
            Instantiate(key, transform.position, Quaternion.identity).name = "Key";
        }
    }

    private void OnApplicationQuit()
    {
        Destroy(GameObject.Find("Key"));
    }
}
