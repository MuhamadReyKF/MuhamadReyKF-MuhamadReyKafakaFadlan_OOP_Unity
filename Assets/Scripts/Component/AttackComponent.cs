using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AttackComponent : MonoBehaviour
{
    public Bullet bulletPrefab;
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            HitboxComponent hitbox = collision.GetComponent<HitboxComponent>();
            if (hitbox != null)
            {
                hitbox.Damage(damage);
            }
        }
    }
}

