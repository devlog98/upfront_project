using UnityEngine;

/*
 * Responsible for vertical movement
 */

namespace devlog98.Utility {
    public class VerticalMovement : MonoBehaviour {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float moveSpeed;
        private float moveDirection = -1; // always go down

        // apply movement force
        public void ExecuteFixedUpdate() {
            rb.velocity = new Vector2(rb.velocity.x, moveSpeed * moveDirection);
        }
    }
}