using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPointsDisplay : MonoBehaviour {

    [SerializeField] float basePoints = 3f;

    float points;
    Text pointsText;

    void Start() {
        points = basePoints - PlayerPrefsController.GetDifficulty();
        pointsText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay() {
        pointsText.text = points.ToString();
    }

    public void AddPoints(float amount) {
        points += amount;
        UpdateDisplay();
    }

    public void DecreasePoints(float amount) {
        points -= amount;
        UpdateDisplay();
        if(IsOutOfPoints()) {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }

    public bool IsOutOfPoints() {
        return points <= 0;
    }
}
