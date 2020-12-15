using devlog98.Player;
using devlog98.Utility;
using UnityEngine;

/*
 * Increases Player health by specific amount
 */

namespace devlog98.Powerup {
    public class HealthPickup : Powerup {
        [Header("Health")]
        [SerializeField] private PlayerHealth playerHealth;
        [SerializeField] private int healthAmount;

        [Header("Movement")]
        [SerializeField] private VerticalMovement pickupMovement;

        // pickup movement
        private void FixedUpdate() {
            pickupMovement.ExecuteFixedUpdate();
        }

        public override void Activate() {
            playerHealth.ReceiveHeal(healthAmount);
        }
    }
}