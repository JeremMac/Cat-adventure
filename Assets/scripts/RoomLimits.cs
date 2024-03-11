using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLimits : MonoBehaviour
{

    private GameObject BossHealthBar;
    private GameObject NinjaBoss;
    private EnemyHealth bossHealth;
    private void Awake()
    {
        BossHealthBar = GameObject.Find("BossHealthBar");
        BossHealthBar.SetActive(false);
        NinjaBoss = GameObject.Find("NinjaCatBoss");
        NinjaBoss.SetActive(true);
        bossHealth = NinjaBoss.GetComponent<EnemyHealth>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            BossHealthBar.SetActive(true);
            if (bossHealth.currentHealth <= 0)
            {
                BossHealthBar.SetActive(false);
                Destroy(NinjaBoss);
            }
            else
            {
                NinjaBoss.SetActive(true);
            }
        }
    }
}
