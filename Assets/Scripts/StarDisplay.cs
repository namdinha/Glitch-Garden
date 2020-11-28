using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour {

    [SerializeField] int stars = 100;
    Text starsText;

    void Start() {
        starsText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay() {
        starsText.text = stars.ToString();
    }

    public void AddStars(int amount) {
        stars += amount;
        UpdateDisplay();
    }

    public bool SpendStars(int amount) {
        if(amount <= stars) {
            stars -= amount;
            UpdateDisplay();
            return true;
        }
        return false;
    }

    public bool HaveEnoughStars(int amount) {
        return amount <= stars;
    }
}
