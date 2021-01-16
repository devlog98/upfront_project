using devlog98.UI.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * General level management methods
 */

namespace devlog98.Utility.Demo {
    public class DemoManager : MonoBehaviour {
        private bool isPaused;

        public void PauseLevel() {
            if (!isPaused) {
                PauseGame();
                isPaused = true;
                PlayerHUD.instance.UpdatePause(isPaused);
            }
            else {
                UnpauseGame();
                isPaused = false;
                PlayerHUD.instance.UpdatePause(isPaused);
            }
        }

        public void RestartLevel() {
            UnpauseGame();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void QuitGame() {
            UnpauseGame();
            Application.Quit();
        }

        // pause game
        private void PauseGame() {
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        // resume game
        private void UnpauseGame() {
            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}