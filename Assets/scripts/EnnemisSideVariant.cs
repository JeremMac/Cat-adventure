using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemisSideVariant : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    private bool movingHigh;
    private float lowEdge;
    private float highEdge;

    private void Awake()
    {
        lowEdge = transform.position.y - movementDistance;
        highEdge = transform.position.y + movementDistance;
    }

    private void Update()
    {
        if (movingHigh)
        {
            if (transform.position.y > lowEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
            }
            else
            {
                movingHigh = false;
            }
        }
        else
        {
            if (transform.position.y < highEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            }
            else
            {
                movingHigh = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
