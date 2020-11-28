using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    [SerializeField] SceneAsset startScreen;
    [SerializeField] SceneAsset loadingScreen;
    [SerializeField] SceneAsset optionsScreen;
    [SerializeField] SceneAsset gameOverScreen;
    public void LoadStartScene() {
        Time.timeScale = 1;
        SceneManager.LoadScene(startScreen.name);
    }

    public void LoadLoadingScene() {
        SceneManager.LoadScene(loadingScreen.name);
    }

    public void LoadGameOverScene() {
        SceneManager.LoadScene(gameOverScreen.name);
    }

    public IEnumerator LoadSceneAfterDelay(SceneAsset scene, float delayInSeconds) {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(scene.name);
    }

    public void LoadNextScene() {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }

    public void ReloadScene() {
        Time.timeScale = 1;
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void LoadOptionsScene() {
        SceneManager.LoadScene(optionsScreen.name);
    }
}
