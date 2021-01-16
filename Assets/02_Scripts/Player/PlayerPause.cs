using devlog98.UI.Player;
using devlog98.Utility.Demo;
using UnityEngine;

/*
 * Used to pause and unpause game
 */

namespace devlog98.Player {
    public class PlayerPause : MonoBehaviour {
        [SerializeField] private DemoManager demoManager;

        // pause controls
        public void ExecuteUpdate() {
            if (Input.GetButtonDown("Cancel")) {
                demoManager.PauseLevel();
            }
        }
    }
}