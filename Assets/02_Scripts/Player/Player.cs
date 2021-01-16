using devlog98.Weapons;
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

        [Header("General")]
        [SerializeField] private PlayerPause playerPause; // pause game

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

            // pause
            playerPause.ExecuteUpdate();
        }

        private void FixedUpdate() {
            playerMovement.ExecuteFixedUpdate();
            playerJump.ExecuteFixedUpdate();
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            // hit by enemy
            if (collision.CompareTag(Enemy.Enemy.Tag)) {
                playerShoot.SwapWeapon(WeaponType.SingleShot); // reset powerup if hit
                playerHealth.TakeDamage(1, PlayerDamageType.Enemy);
            }
        }

        private void OnTriggerStay2D(Collider2D collision) {
            // crushed by block
            if (playerJump.IsGrounded && playerCrush.IsCrushed) {
                playerMovement.ChangeMoveSpeed(PlayerMovementState.Slow);
                playerShoot.SwapWeapon(WeaponType.SingleShot); // reset powerup if hit
                playerHealth.TakeDamage(1, PlayerDamageType.Block);
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