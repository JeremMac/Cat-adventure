using System;
using System.Collections;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyHealth : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header ("iFrame")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int numberOffFlashes;
    private SpriteRenderer spriteRend;

    [Header ("Components")]
    [SerializeField] private Behaviour[] components;
    private GameObject PlayerH;
    private Health Phealth;
    private GameObject BossHealthBar;
    private GameObject NinjaBoss;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        PlayerH = GameObject.Find("player");
        Phealth = PlayerH.GetComponent<Health>();
        BossHealthBar = GameObject.Find("BossHealthBar");
        NinjaBoss = GameObject.Find("NinjaCatBoss");
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invulnerability());
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");

                // Player
                if (GetComponent<PlayerMovement>() != null)
                {
                    GetComponent<PlayerMovement>().enabled = false;
                }

                // Enemy
                if (GetComponentInParent<EnemyPatrol>() != null)
                {
                    GetComponentInParent<EnemyPatrol>().enabled = false;
                }

                if (GetComponent<MeleeEnemy>() != null)
                {
                    GetComponent<MeleeEnemy>().enabled = false;
                }

                // Deactivate all attached component classes
                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }

                dead = true;

                if (dead)
                {
                    GetComponent<LootBag>().InstantiateLoot(transform.position);
                }
            }
            
        }
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        for (int i = 0; i < numberOffFlashes ; i++)
        {
            spriteRend.color = new Color(1, 0 ,0, 0.5f);
            yield return new WaitForSeconds(iFrameDuration/ (numberOffFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration/ (numberOffFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
    public void Respawn()
    {
        dead = false;
        AddHealth(startingHealth);
        anim.ResetTrigger("die");
        anim.Play("Idle");
        StartCoroutine(Invulnerability());

        // Activate all attached component classes
        foreach (Behaviour component in components)
            {
                component.enabled = true;
            }
    }

    private void Update()
    {
        if (Phealth.currentHealth <= 0 && currentHealth > 0)
        {
            currentHealth = startingHealth;
            BossHealthBar.SetActive(false);
            NinjaBoss.SetActive(false);
        }
    }
}
