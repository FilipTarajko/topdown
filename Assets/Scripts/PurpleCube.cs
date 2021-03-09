using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleCube : BasicTarget
{
    public float timeToAttack;
    public float attackCooldown;
    public float bulletSpeed;
    public float weaponRange;
    public float weaponDamage;
    public EnemyBullet bulletPrefab;

    private void Start()
    {
        enemyBulletParent = gameController.enemyBulletParent;
    }

    public override void Frame()
    {
        HandleShooting();
    }

    void HandleShooting()
    {
        timeToAttack -= Time.deltaTime;
        if (timeToAttack <= 0 && Vector2.Distance(transform.position, gameController.player.transform.position) < visionRange)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 targetDirection = gameController.player.transform.position - transform.position;
        targetDirection.Normalize();
        targetDirection = Quaternion.AngleAxis(transform.rotation.eulerAngles.z, new Vector3(0, 0, 1)) * targetDirection;
        targetDirection = Quaternion.Inverse(transform.rotation) * targetDirection;
        timeToAttack = attackCooldown;
        EnemyBullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity, enemyBulletParent);
        bullet.speed = bulletSpeed;
        bullet.transform.up = targetDirection;
        bullet.range = weaponRange;
        bullet.damage = weaponDamage;
        bullet.spriteRenderer.color = spriteRenderer.color;
    }
}
