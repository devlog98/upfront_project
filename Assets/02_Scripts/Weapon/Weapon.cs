using devlog98.Weapons.Bullets;
using System.Collections.Generic;
using UnityEngine;

/*
 * Base weapon class
 */

namespace devlog98.Weapons {
    // all weapon types available
    public enum WeaponType { SingleShot, TripleShot }

    public class Weapon : MonoBehaviour {
        [Header("Weapon Attributes")]
        [SerializeField] private WeaponType type;
        [SerializeField] private List<Bullet> bullets;
        [SerializeField] private List<Transform> firePoints;
        
        // shoot bullets
        public void Shoot() {
            foreach(Transform firePoint in firePoints) {
                Bullet bullet = bullets.Find(x => !x.gameObject.activeSelf);

                if (bullet != null) {
                    bullet.Shoot(firePoint.position, firePoint.up);
                }
            }
        }
    }
}