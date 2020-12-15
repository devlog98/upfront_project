using devlog98.UI.Player;
using UnityEngine;

/*
 * Manages player score and highscore
 */

namespace devlog98.Data {
    public class PlayerScore : MonoBehaviour {
        public static PlayerScore instance; // singleton

        private int currentScore; // current score
        private int highScore; // max score achieved
        public int CurrentScore { get => currentScore; }
        public int HighScore { get => highScore; }

        // initialize singleton
        private void Awake() {
            if (instance != null && instance != this) {
                Destroy(this.gameObject);
            }
            else {
                instance = this;
            }
        }

        // get highscore
        private void Start() {
            highScore = PlayerPrefs.GetInt("player_highscore", 0);
        }

        // increase player score
        public void Score(int amount) {
            currentScore += amount;
            PlayerHUD.instance.UpdateScore(currentScore);
        }

        // checks for new highscore on player death
        public void FinishScore() {
            if (currentScore > highScore) {
                highScore = currentScore;
                PlayerPrefs.SetInt("player_highscore", highScore);
            }
        }
    }
}