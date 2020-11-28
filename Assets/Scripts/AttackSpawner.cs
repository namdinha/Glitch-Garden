using System.Collections;
using UnityEngine;

public class AttackSpawner : MonoBehaviour {

    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefabs;
    bool spawn = true;

    IEnumerator Start() {
        while(spawn) {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning() {
        spawn = false;
    }

    private void SpawnAttacker() {
        int attackerIndex = Random.Range(0, attackerPrefabs.Length);
        Spawn(attackerPrefabs[attackerIndex]);
    }

    private void Spawn(Attacker attackerPrefab) {
        Attacker newAttacker = Instantiate(attackerPrefab, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
}
