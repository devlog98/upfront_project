using devlog98.Player;
using devlog98.Utility;
using devlog98.Weapons;
using UnityEngine;

/*
 * Swaps Player weapon for specific type
 */

namespace devlog98.Powerup {
    public class WeaponPickup : Powerup {
        [Header("Weapon")]
        [SerializeField] private PlayerShoot playerShoot;
        [SerializeField] private WeaponType weaponType;

        [Header("Movement")]
        [SerializeField] private VerticalMovement pickupMovement;

        // pickup movement
        private void FixedUpdate() {
            pickupMovement.ExecuteFixedUpdate();
        }

        public override void Activate() {
            playerShoot.SwapWeapon(weaponType);
        }
    }
}