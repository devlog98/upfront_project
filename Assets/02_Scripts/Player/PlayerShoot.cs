using devlog98.Weapons;
using System.Collections.Generic;
using UnityEngine;

/*
 * Responsible for Player shooting
 */
 
namespace devlog98.Player {
    public class PlayerShoot : MonoBehaviour {
        [SerializeField] private List<Weapon> weapons; // list with all possible weapons player has
        private Weapon currentWeapon; // current active weapon for player

        // initialize base weapon
        private void Start() {
            currentWeapon = weapons[0];
        }

        // get input
        public void ExecuteUpdate() {
            if (Input.GetButtonDown("Jump")) {
                currentWeapon.Shoot();
            }
        }

        // change weapon if it exists on weapons list
        public void SwapWeapon(WeaponType weaponType) {
            Weapon newWeapon = weapons.Find(x => x.Type == weaponType);
            if (newWeapon != null) {
                currentWeapon = newWeapon;
            }
        }
    }
}