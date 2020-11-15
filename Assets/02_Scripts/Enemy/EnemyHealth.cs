using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Responsible for controlling enemy health and damage feedback
 */

namespace devlog98.Enemy {
    public class EnemyHealth : MonoBehaviour {
        [Header("Health")]
        [SerializeField] private int health; // health pool

        [Header("Damage Flash")]
        [SerializeField] private List<SpriteRenderer> spriteRenderers; // all sprites that must flash when damage is received
        [SerializeField] private Material defaultMaterial; // the sprite's basic material
        [SerializeField] private Material flashMaterial; // the material of the flash
        private const float flashValue = 0.07f; // duration of each single flash

        // makes enemy lose health
        public void TakeDamage(int damage) {
            // damage
            health -= damage;

            // damage flash
            StopCoroutine("DamageFlash");
            StartCoroutine("DamageFlash");

            // kill enemy if health reaches 0
            if (health <= 0) {
                Die();
            }
        }

        // makes enemy flash when receiving damage
        private IEnumerator DamageFlash() {
            // flash on
            foreach (SpriteRenderer spriteRenderer in spriteRenderers) {
                spriteRenderer.material = flashMaterial;
            }
            yield return new WaitForSeconds(flashValue);

            // flash off
            foreach (SpriteRenderer spriteRenderer in spriteRenderers) {
                spriteRenderer.material = defaultMaterial;
            }
            yield return new WaitForSeconds(flashValue);
        }

        // kills enemy
        private void Die() {
            Destroy(this.gameObject);
        }
    }
}