using System.Collections.Generic;
using UnityEngine;

/*
 * Basic bullet movement and damage
 */
 
namespace devlog98.Ammunition {
    public class Bullet : MonoBehaviour {
        public static string Tag = "PlayerBullet"; // default bullet tag

        [Header("Movement")]
        [SerializeField] protected Rigidbody2D rb;
        [SerializeField] protected float moveSpeed; // bullet speed
        [SerializeField] protected float duration; // bullet alive period (in seconds)

        [Header("Damage")]
        [SerializeField] protected int damage; // bullet damage
        private readonly List<string> collisionTags = new List<string> { "Player", "PlayerCrush", "CameraConfiner" }; // tags to ignore on collision check

        // shoots bullet based on direction
        public void Shoot(Vector2 startPosition, Vector2 moveDirection) {
            transform.parent = null;

            transform.position = startPosition;
            this.gameObject.SetActive(true);
            rb.velocity = moveDirection * moveSpeed;

            CancelInvoke("Disable");
            Invoke("Disable", duration);
        }

        // collision checks
        private void OnTriggerEnter2D(Collider2D other) {
            if (collisionTags.Contains(other.gameObject.tag)) {
                return;
            }

            Disable();
        }

        // disables bullet after period (in order to avoid instantiating)
        private void Disable() {
            this.gameObject.SetActive(false);
        }
    }
}