using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] float speed = 1f;
    [SerializeField] int damage = 50;

    private void Update() {
        Move();
    }

    private void Move() {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        var health = other.GetComponent<Health>();
        var attacker = other.GetComponent<Attacker>();

        if (attacker && health) {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
