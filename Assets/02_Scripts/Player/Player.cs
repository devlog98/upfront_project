using UnityEngine;

/*
 * Player controller
 */

namespace devlog98.Player {
    public class Player : MonoBehaviour {
        [SerializeField] private PlayerMovement playerMovement; // movement logic
        [SerializeField] private PlayerJump playerJump; // jump logic

        private void Update() {
            playerMovement.ExecuteUpdate();
            playerJump.ExecuteUpdate();
        }

        private void FixedUpdate() {
            playerMovement.ExecuteFixedUpdate();
            playerJump.ExecuteFixedUpdate();
        }
    }
}