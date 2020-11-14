using UnityEngine;

/*
 * Responsible for Player jump and gravity
 */

namespace devlog98.Player {
    public class PlayerJump : MonoBehaviour {
        [Header("Jump")]
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float jumpForce;
        [SerializeField] private float gravityForce;
        private float verticalVelocity;
        private bool canJump;

        [Header("Ground Detection")]
        [SerializeField] private Collider2D collider;
        [SerializeField] private LayerMask groundLayer;
        private bool isGrounded;
        private float raycastHorizontalOffset;
        private float raycastVerticalOffset;

        // initialize variables
        private void Start() {
            raycastHorizontalOffset = collider.bounds.size.x * 0.5f;
            raycastVerticalOffset = (collider.bounds.size.y * 0.5f) + 0.05f;
        }

        // get input
        public void ExecuteUpdate() {
            // ground check
            isGrounded = false;
            for (int i = -1; i <= 1; i++) {
                Vector2 rayOrigin = new Vector2(transform.position.x + (raycastHorizontalOffset * i), transform.position.y);

                Debug.DrawLine(rayOrigin, (Vector3)rayOrigin - transform.up * raycastVerticalOffset, Color.green);
                if (Physics2D.Raycast(rayOrigin, -transform.up, raycastVerticalOffset, groundLayer)) {
                    isGrounded = true;
                    canJump = true;
                    verticalVelocity = 0;
                    break;
                }
            }

            // jump
            if (canJump && Input.GetButtonDown("Jump")) {
                verticalVelocity = jumpForce;
                canJump = false;
            }

            // fall
            if (!isGrounded) {
                verticalVelocity -= gravityForce * Time.deltaTime;
            }
        }

        // apply movement force
        public void ExecuteFixedUpdate() {
            rb.AddForce(new Vector2(rb.velocity.x, verticalVelocity), ForceMode2D.Force);
        }
    }
}