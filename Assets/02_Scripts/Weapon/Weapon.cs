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
        public WeaponType Type { get => type; }

        [SerializeField] private GameObject bulletContainer;
        private List<Bullet> bullets = new List<Bullet>();

        [SerializeField] private GameObject firePointContainer;
        private List<Transform> firePoints = new List<Transform>();

        // initialize bullet and firePoints list
        private void Start() {
            bullets.AddRange(bulletContainer.GetComponentsInChildren<Bullet>(true));
            firePoints.AddRange(firePointContainer.GetComponentsInChildren<Transform>());
            firePoints.RemoveAt(0);
        }

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