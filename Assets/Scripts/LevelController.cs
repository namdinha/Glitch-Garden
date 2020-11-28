using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    [SerializeField] float waitToLoad = 4f;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    private void Start() {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AttackerSpawned() {
        numberOfAttackers++;
    }

    public void AttackerDestroyed() {
        numberOfAttackers--;
        if(numberOfAttackers <= 0 && levelTimerFinished) {
            StartCoroutine(HandleWinCondition());
        }
    }

    private IEnumerator HandleWinCondition() {
        if (winLabel) {
            winLabel.SetActive(true);
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(waitToLoad);
            FindObjectOfType<SceneLoader>().LoadNextScene();
        }
    }

    public void HandleLoseCondition() {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevelTimerFinished() {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners() {
        AttackSpawner[] spawners = FindObjectsOfType<AttackSpawner>();
        foreach(AttackSpawner spawner in spawners) {
            spawner.StopSpawning();
        }
    }
}
