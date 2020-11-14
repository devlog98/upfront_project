using UnityEngine;

/*
 * Responsible for Player horizontal movement
 */

namespace devlog98.Player {
    public class PlayerMovement : MonoBehaviour {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float moveSpeed;
        private float moveDirection; // left or right (-1 or 1)

        // get input
        public void ExecuteUpdate() {
            moveDirection = Input.GetAxisRaw("Horizontal");
        }

        // apply movement force
        public void ExecuteFixedUpdate() {
            rb.AddForce(new Vector2(moveSpeed * moveDirection, rb.velocity.y), ForceMode2D.Force);
        }
    }
}