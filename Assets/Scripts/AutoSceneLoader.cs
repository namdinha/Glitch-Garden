using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AutoSceneLoader : SceneLoader {

    [SerializeField] SceneAsset sceneToLoad;
    [SerializeField] float delay;

    void Start() {
        StartCoroutine(LoadSceneAfterDelay(sceneToLoad, 3f));
    }

}
