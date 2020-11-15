using devlog98.Ammunition;
using UnityEngine;

/*
 * Enemy controller
 */

namespace devlog98.Enemy {
    public class Enemy : MonoBehaviour {
        [SerializeField] private EnemyHealth enemyHealth;
        [SerializeField] private EnemyMovement enemyMovement; // movement logic

        private void FixedUpdate() {
            enemyMovement.ExecuteFixedUpdate();
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            // hit by bullet
            Debug.Log(collision.tag);
            if (collision.CompareTag(Bullet.Tag)) {
                enemyHealth.TakeDamage(1);
            }
        }
    }
}