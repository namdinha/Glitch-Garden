﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [Range(0f, 5f)] float currentSpeed = 1f;
    GameObject currentTarget;

    void Awake() {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy() {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController) {
            levelController.AttackerDestroyed();
        }
    }

    void Update() {
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
        UpdateAnimationState();
    }

    private void UpdateAnimationState() {
        if(!currentTarget) {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed) {
        currentSpeed = speed;
    }

    public void Attack(GameObject target) {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(int damage) {
        if(!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        health.DealDamage(damage);
    }
}
