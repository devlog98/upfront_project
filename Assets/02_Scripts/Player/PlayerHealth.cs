using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace devlog98.Player {
    public class PlayerHealth : MonoBehaviour {
        [Header("Health")]
        [SerializeField] private int health; // health pool
        private bool isInvincible; // period that Player cannot receive damage

        [Header("Damage Flash")]
        [SerializeField] private List<SpriteRenderer> spriteRenderers; // all sprites that must flash when damage is received
        [SerializeField] private Material defaultMaterial; // the sprite's basic material
        [SerializeField] private Material flashMaterial; // the material of the flash
        [SerializeField] private int repeatFlashes; // how many times sprites will flash
        private const float flashValue = 0.07f; // duration of each single flash

        // makes enemy lose health
        public void TakeDamage(int damage) {
            if (!isInvincible) {
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
        }

        // makes enemy flash when receiving damage
        private IEnumerator DamageFlash() {
            isInvincible = true;

            for (int i = 0; i <= repeatFlashes; i++) {
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

            isInvincible = false;
        }

        // kills enemy
        private void Die() {
            Destroy(this.gameObject);
        }
    }
}