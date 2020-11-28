using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] Projectile projectile;
    [SerializeField] GameObject shootPosition;

    AttackSpawner myLaneSpawner;
    Animator animator;
    GameObject projectileParent;

    const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start() {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent() {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent) {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void SetLaneSpawner() {
        AttackSpawner[] spawners = FindObjectsOfType<AttackSpawner>();
        foreach (AttackSpawner spawner in spawners) {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if(isCloseEnough) {
                myLaneSpawner = spawner;
                return;
            }
        }
    }

    private void Update() {
        if(IsAttackerInLane()) {
            animator.SetBool("isAttacking", true);
        }
        else {
            animator.SetBool("isAttacking", false);
        }
    }

    private bool IsAttackerInLane() {
        return myLaneSpawner.transform.childCount > 0;
    }

    public void Fire() {
        Projectile projectile = Instantiate(this.projectile, shootPosition.transform.position, transform.rotation) as Projectile;
        projectile.transform.parent = projectileParent.transform;
    }
}
