using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameController gameController;
    public Vector2 movementDirection;
    public float movementSpeed;
    public float timeToAttack;
    public float attackCooldown;
    public Transform playerBulletParent;
    public PlayerBullet playerBullet;
    public float bulletSpeed;
    public Vector3 targetDirection;
    public float weaponRange;
    public float weaponDamage;
    public float rotationSpeed;
    public float maxHealth;
    public float health;
    public Slider healthbarSlider;

    private void Start()
    {
        HandleHealthbar();
    }

    void Update()
    {
        HandleMoving();
        HandleRotation();
        HandleCamera();
        HandleShooting();
    }

    void HandleHealthbar()
    {
        healthbarSlider.value = health / maxHealth;
    }

    void HandleMoving()
    {
        movementDirection = new Vector2((Input.GetKey("d") ? 1 : 0) - (Input.GetKey("a") ? 1 : 0), (Input.GetKey("w") ? 1 : 0) - (Input.GetKey("s") ? 1 : 0));
        movementDirection.Normalize();
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
    }

    void HandleRotation()
    {
        if (gameController.data.allowRotation)
        {
            if (Input.GetKey("q"))
            {
                transform.Rotate(new Vector3(0, 0, rotationSpeed));
            }
            if (Input.GetKey("e"))
            {
                transform.Rotate(new Vector3(0, 0, -rotationSpeed));
            }
            if (Input.GetKey("z"))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
        }
    }

    void HandleCamera()
    {
        if (Input.GetKey(KeyCode.Equals) && Camera.main.orthographicSize >= 250)
        {
            Camera.main.orthographicSize -= 10;
        }
        if (Input.GetKey(KeyCode.Minus) && Camera.main.orthographicSize <=5000)
        {
            Camera.main.orthographicSize += 10;
        }
    }

    void HandleShooting()
    {
        timeToAttack -= Time.deltaTime;
        if (timeToAttack <= 0 && Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 targetDirection = Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0);
        targetDirection.Normalize();
        targetDirection = Quaternion.AngleAxis(transform.rotation.eulerAngles.z, new Vector3(0, 0, 1)) * targetDirection;
        timeToAttack = attackCooldown;
        PlayerBullet bullet = Instantiate(playerBullet, transform.position, Quaternion.identity, playerBulletParent);
        bullet.speed = bulletSpeed;
        bullet.transform.up = targetDirection;
        bullet.range = weaponRange;
        bullet.damage = weaponDamage;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            if (other.TryGetComponent<EnemyBullet>(out var enemyBullet))
            {
                TakeDamage(enemyBullet.damage);
            }
            Destroy(enemyBullet.gameObject);
        }
    }

    void TakeDamage(float damage)
    {
        health -= damage;
        HandleHealthbar();
    }
}
