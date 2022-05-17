using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] private float damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Health>().TakeDamage(damage); // Reduce Health
            collision.GetComponent<Health>().ReduceHealthBar(); // Reduce HealthBar on UI
        }
    }
}
