using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultVolume = 0.8f;
    [SerializeField] float defaultDifficulty = 1f;

    void Start() {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    void Update() {
        // TODO is not the best with this var musicplayer on update
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if(musicPlayer) {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else {
            Debug.LogWarning("No music player found!!!");
        }
    }

    public void Save() {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
    }

    public void SetDefaults() {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
