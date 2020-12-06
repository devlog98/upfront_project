using UnityEngine;
using UnityEngine.SceneManagement;

namespace devlog98.Utility.Demo {
    public class DemoManager : MonoBehaviour {
        private void Update() {
            // quit game
            if (Input.GetButtonDown("Cancel")) {
                Application.Quit();
            }

            // reset level
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}