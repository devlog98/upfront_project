using UnityEngine;

/*
 * Player controller
 */

namespace devlog98.Player {
    public class Player : MonoBehaviour {
        [SerializeField] private PlayerMovement playerMovement; // movement logic
        [SerializeField] private PlayerJump playerJump; // jump logic
        [SerializeField] private PlayerShoot playerShoot; // shoot logic

        private void Update() {
            playerMovement.ExecuteUpdate();
            // only shoot when jumping
            if (playerJump.VerticalVelocity == 0) {
                playerShoot.ExecuteUpdate();
            }
            playerJump.ExecuteUpdate();
        }

        private void FixedUpdate() {
            playerMovement.ExecuteFixedUpdate();
            playerJump.ExecuteFixedUpdate();
        }
    }
}