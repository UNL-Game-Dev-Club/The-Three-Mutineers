using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlatformBehavior : MonoBehaviour
{
    [SerializeField] GameObject gate;
    [SerializeField] BulletSpawner bulletSpawner;

    [SerializeField] bool openGate;
    [SerializeField] bool isTrap;
    [SerializeField] bool isP1Platform;
    [SerializeField] bool isP2Platform;
    [SerializeField] bool isP3Platform;

    [SerializeField] bool firesBullet;

    [SerializeField] Tilemap tilemap;
    [SerializeField] TileBase tileUnactive;
    [SerializeField] TileBase tileActive;

    [SerializeField] Collider2D deathPlane;
    [SerializeField] GameObject deathPlaneObject;

    // Start is called before the first frame update
    void Start()
    {
        tilemap.SetTile(new Vector3Int(-1, -13, 0), tileUnactive);
        tilemap.SetTile(new Vector3Int(-2, -13, 0), tileUnactive);
        tilemap.SetTile(new Vector3Int(-1, -14, 0), tileUnactive);
        tilemap.SetTile(new Vector3Int(-2, -14, 0), tileUnactive);
        deathPlane.enabled = false;
        deathPlaneObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(isP1Platform && isP2Platform && isP3Platform))
        {
            if (isP1Platform && collision.name != "P1")
            {
                return;
            }
            else if (isP2Platform && collision.name != "P2")
            {
                return;
            }
            else if (isP3Platform && collision.name != "P3")
            {
                return;
            }
        }

        /* if (collision.name == "P1")
        {
            if (collision.GetComponent<Player1Controls>().GotKey)
            {
                bulletSpawner.Spawn();
            }
        } */

        if (firesBullet)
        {
            // if bullet is loaded

            bulletSpawner.Spawn();
        }

        if (openGate)
        {
            gate.SetActive(false);
        }

        if (isTrap)
        {
            tilemap.SetTile(new Vector3Int(-1, -13, 0), tileActive);
            tilemap.SetTile(new Vector3Int(-2, -13, 0), tileActive);
            tilemap.SetTile(new Vector3Int(-1, -14, 0), tileActive);
            tilemap.SetTile(new Vector3Int(-2, -14, 0), tileActive);

            deathPlane.enabled = true;
            deathPlaneObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!(isP1Platform && isP2Platform && isP3Platform))
        {
            if (isP1Platform && collision.name != "P1")
            {
                return;
            }
            else if (isP2Platform && collision.name != "P2")
            {
                return;
            }
            else if (isP3Platform && collision.name != "P3")
            {
                return;
            }
        }

        if (openGate)
        {
            gate.SetActive(true);
        }

        if (isTrap)
        {
            // Vector2 position = new Vector2(-1, -13);
            tilemap.SetTile(new Vector3Int(-1, -13, 0), tileUnactive);
            tilemap.SetTile(new Vector3Int(-2, -13, 0), tileUnactive);
            tilemap.SetTile(new Vector3Int(-1, -14, 0), tileUnactive);
            tilemap.SetTile(new Vector3Int(-2, -14, 0), tileUnactive);

            deathPlane.enabled = false;
            deathPlaneObject.SetActive(false);
        }
    }
}
