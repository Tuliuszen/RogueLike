﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject hitEffect;
    readonly float destroyEffectTime = 0.05f;
    public int projectileDamage;

    public float projectileSpeed = 10f;
    public float destroyTime = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, destroyEffectTime);
        
        collision.GetComponent<Health>().TakeDamage(projectileDamage);
        
        Destroy(gameObject);
    }

    public void InstantiateProjectile(GameObject projectilePrefab, int damage, Vector2 target, Transform shootingPoint)
    {
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        rb.velocity = target * projectileSpeed;
        projectile.transform.Rotate(0f, 0f, Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg);

        projectileDamage = damage;

        Destroy(projectile, destroyTime);
    }

}
