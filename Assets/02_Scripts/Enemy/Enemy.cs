using devlog98.Ammunition;
using devlog98.Spawn;
using System.Collections.Generic;
using UnityEngine;

/*
 * Enemy controller
 */

namespace devlog98.Enemy {
    public class Enemy : Spawnable {
        public static string Tag = "Enemy";

        [SerializeField] private EnemyHealth enemyHealth;
        [SerializeField] private EnemyMovement enemyMovement; // movement logic
        [SerializeField] private int enemyScore; // how much score the enemy gives when killed
        private readonly List<string> collisionTags = new List<string> { "Enemy", "Block" }; // tags to ignore on collision check

        private void FixedUpdate() {
            enemyMovement.ExecuteFixedUpdate();
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.tag.Contains(Bullet.Tag)) {
                enemyHealth.TakeDamage(1, enemyScore, true);
            }
            else if (collision.tag.Contains(Player.Player.Tag)) {
                enemyHealth.TakeDamage(1, 0, false);
            }
            else if (collision.tag.Contains(Tag)) {
                enemyHealth.TakeDamage(1, 0, false);
            }
        }
    }
}