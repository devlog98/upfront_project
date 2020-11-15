using UnityEngine;

/*
 * Enemy controller
 */

namespace devlog98.Enemy {
    public class Enemy : MonoBehaviour {
        [SerializeField] private EnemyMovement enemyMovement; // movement logic

        private void FixedUpdate() {
            enemyMovement.ExecuteFixedUpdate();
        }
    }
}