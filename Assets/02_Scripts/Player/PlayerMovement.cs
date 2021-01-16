using UnityEngine;

/*
 * Responsible for Player horizontal movement
 */

namespace devlog98.Player {
    // movement speed options
    public enum PlayerMovementState { Default, Slow }

    public class PlayerMovement : MonoBehaviour {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float defaultMoveSpeed;
        [SerializeField] private float slowMoveSpeed;
        private float moveSpeed;
        private float moveDirection; // left or right (-1 or 1)

        // set initial speed
        private void Start() {
            moveSpeed = defaultMoveSpeed;
        }

        // get input
        public void ExecuteUpdate() {
            moveDirection = Input.GetAxisRaw("Horizontal");
        }

        // apply movement force
        public void ExecuteFixedUpdate() {
            rb.AddForce(new Vector2(moveSpeed * moveDirection, rb.velocity.y), ForceMode2D.Force);
        }

        // change movement speed
        public void ChangeMoveSpeed(PlayerMovementState movementState) {
            switch (movementState) {
                case PlayerMovementState.Slow:
                    moveSpeed = slowMoveSpeed;
                    break;
                default:
                    moveSpeed = defaultMoveSpeed;
                    break;
            }
        }
    }
}