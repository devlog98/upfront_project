using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*
 * Responsible for updating Player HUD
 */

namespace devlog98.UI.Player {
    public class PlayerHUD : MonoBehaviour {
        public static PlayerHUD instance; // singleton

        [Header("Health")]
        [SerializeField] private GameObject healthIconContainer; // game object with health icons as children
        private List<Image> healthIcons = new List<Image>();

        [Header("Score")]
        [SerializeField] private TextMeshProUGUI scoreText;

        [Header("Pause")]
        [SerializeField] private GameObject playerPause; // pause menu object

        [Header("Death")]
        [SerializeField] private GameObject playerDeath; // death screen object
        [SerializeField] private TextMeshProUGUI deathScoreText;
        [SerializeField] private TextMeshProUGUI highScoreText;

        // initialize singleton
        private void Awake() {
            if (instance != null && instance != this) {
                Destroy(this.gameObject);
            }
            else {
                instance = this;
            }
        }

        private void Start() {
            // set health icon list
            healthIcons.AddRange(healthIconContainer.GetComponentsInChildren<Image>());
        }

        // update health icons based on player health
        public void UpdateHealth(int healthAmount) {
            int healthIndex = 0;
            foreach(Image healthIcon in healthIcons) {
                healthIcon.gameObject.SetActive(healthIndex < healthAmount);
                healthIndex++;
            }
        }

        // update score text based on current score
        public void UpdateScore(int scoreAmount) {
            scoreText.text = Convert.ToString(scoreAmount);
        }

        // shows and hides pause menu
        public void UpdatePause(bool isPaused) {
            if (!isPaused) {
                playerPause.SetActive(false);
            }
            else {
                playerPause.SetActive(true);
            }
        }

        // shows when player dies
        public void DeathScreen(int scoreAmount, int highScoreAmount) {
            playerDeath.SetActive(true);
            deathScoreText.text = "Score: " + scoreAmount;
            highScoreText.text = "High Score: " + highScoreAmount;
        }
    }
}