using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLimits : MonoBehaviour
{

    private GameObject BossHealthBar;
    private void Awake()
    {
        BossHealthBar = GameObject.Find("BossHealthBar");
        BossHealthBar.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            BossHealthBar.SetActive(true);
        }
    }
}
