using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTiles : MonoBehaviour
{
    private Rigidbody2D tile;
    private void Awake()
    {
        tile = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            tile.gravityScale = 1;
            tile.mass = 10;
        }
    }
}
