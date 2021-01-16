using devlog98.Data;
using devlog98.UI.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Responsible for controlling Player health and damage feedback
 */

namespace devlog98.Player {
    public enum PlayerDamageType { Enemy, Block } // types of damage Player can receive

    public class PlayerHealth : MonoBehaviour {
        [Header("Health")]
        [SerializeField] private int health; // health pool
        [SerializeField] private int maxHealth; // max health pool
        [SerializeField] private float defaultInvincibilityTime; // default amount
        [SerializeField] private float longInvincibilityTime; // amount for crushing or longer damages
        private float invincibilityTime; // seconds of invincibility
        private bool isInvincible; // period that Player cannot receive damage

        [Header("Damage Flash")]
        [SerializeField] private List<SpriteRenderer> spriteRenderers; // all sprites that must flash when damage is received
        [SerializeField] private Material defaultMaterial; // the sprite's basic material
        [SerializeField] private Material flashMaterial; // the material of the flash
        private const float flashValue = 0.07f; // duration of each single flash
        private float timer; // generic timer

        // makes player restore health
        public void ReceiveHeal(int heal) {
            // heal
            health += heal;
            if (health > maxHealth) {
                health = maxHealth;
            }

            PlayerHUD.instance.UpdateHealth(health);
        }

        // makes player lose health
        public void TakeDamage(int damage, PlayerDamageType damageType) {
            if (!isInvincible) {
                // damage
                health -= damage;
                PlayerHUD.instance.UpdateHealth(health);

                // set correct invincibility
                switch (damageType) {
                    case PlayerDamageType.Block:
                        invincibilityTime = longInvincibilityTime;
                        break;
                    default:
                        invincibilityTime = defaultInvincibilityTime;
                        break;
                }

                // damage flash
                StopCoroutine("DamageFlash");
                StartCoroutine("DamageFlash");

                // kill enemy if health reaches 0
                if (health <= 0) {
                    Die();
                }
            }
        }

        // makes player flash when receiving damage
        private IEnumerator DamageFlash() {
            isInvincible = true;
            timer = Time.time + invincibilityTime;

            while (Time.time < timer) {
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

        // saves score and kills player
        private void Die() {
            PlayerScore.instance.FinishScore();
            PlayerHUD.instance.DeathScreen(PlayerScore.instance.CurrentScore, PlayerScore.instance.HighScore);
            Destroy(this.gameObject);
        }
    }
}