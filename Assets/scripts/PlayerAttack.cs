using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]private float attackCooldown;
    [SerializeField]private Transform shurikenPoint;
    [SerializeField]private GameObject[] shurikens;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.H) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        {
            Attack();
        }

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        shurikens[FindShuriken()].transform.position = shurikenPoint.position;
        shurikens[FindShuriken()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindShuriken()
    {
        for (int i = 0; i < shurikens.Length; i++)
        {
            if (!shurikens[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
