using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollider : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D otherCollider) {
        FindObjectOfType<PlayerPointsDisplay>().DecreasePoints(1f);
        Destroy(otherCollider.gameObject);
    }
}
