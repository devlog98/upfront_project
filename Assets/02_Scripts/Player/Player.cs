using System.Collections.Generic;
using UnityEngine;

/*
 * Player controller
 */

namespace devlog98.Player {
    public class Player : MonoBehaviour {
        public static string Tag = "Player";

        [Header("Health")]
        [SerializeField] private PlayerHealth playerHealth;
        [SerializeField] private PlayerCrush playerCrush;

        [Header("Actions")]
        [SerializeField] private PlayerMovement playerMovement; // movement logic
        [SerializeField] private PlayerJump playerJump; // jump logic
        [SerializeField] private PlayerShoot playerShoot; // shoot logic

        private void Update() {
            playerMovement.ExecuteUpdate();

            // cannot jump and shoot if crushed
            if (!(playerJump.IsGrounded && playerCrush.IsCrushed)) {
                // only shoot when jumping
                if (playerJump.VerticalVelocity == 0) {
                    playerShoot.ExecuteUpdate();
                }
                playerJump.ExecuteUpdate();
            }
        }

        private void FixedUpdate() {
            playerMovement.ExecuteFixedUpdate();
            playerJump.ExecuteFixedUpdate();
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            // hit by enemy
            if (collision.CompareTag(Enemy.Enemy.Tag)) {
                playerHealth.TakeDamage(1);
            }

            // crushed by block
            if (playerJump.IsGrounded && playerCrush.IsCrushed) {
                playerMovement.ChangeMoveSpeed(PlayerMovementState.Slow);
                playerHealth.TakeDamage(1);
            }
        }

        private void OnTriggerExit2D(Collider2D collision) {
            // escaped from under the block
            if (!playerCrush.IsCrushed) {
                playerMovement.ChangeMoveSpeed(PlayerMovementState.Default);
            }
        }
    }
}