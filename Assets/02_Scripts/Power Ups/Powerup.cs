using devlog98.Spawn;
using UnityEngine;

/*
 * Base Powerup implementation from which all powerups must derive from
 */

namespace devlog98.Powerup {
    public abstract class Powerup : Spawnable {
        // base activation method to be overwritten
        public abstract void Activate();

        // default collision for powerups
        public void OnTriggerEnter2D(Collider2D collision) {
            if (collision.CompareTag(Player.Player.Tag)) {
                Activate();
                this.gameObject.SetActive(false);
            }
        }
    }
}