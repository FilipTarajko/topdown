using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;
    public float range;
    public Vector2 startPosition;
    public float damage;

    private void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if(Vector2.Distance(startPosition, transform.position) > range)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Target"))
        {
            if (other.TryGetComponent<BasicTarget>(out var BasicTarget))
            {
                BasicTarget.DealDamage(damage);
            }
            Destroy(this.gameObject);
        }
    }
}
