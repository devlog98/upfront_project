using devlog98.Ammunition;
using System.Collections.Generic;
using UnityEngine;

/*
 * Responsible for Player shooting
 */
 
namespace devlog98.Player {
    public class PlayerShoot : MonoBehaviour {
        [SerializeField] private List<Bullet> bullets;
        [SerializeField] private GameObject firePoint;

        // get input
        public void ExecuteUpdate() {
            if (Input.GetButtonDown("Jump")) {
                Bullet bullet = bullets.Find(x => !x.gameObject.activeSelf);

                if (bullet != null) {
                    bullet.Shoot(firePoint.transform.position, transform.up);
                }
            }
        }
    }
}