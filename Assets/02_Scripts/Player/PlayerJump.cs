using UnityEngine;

/*
 * Responsible for Player jump and gravity
 */

namespace devlog98.Player {
    public class PlayerJump : MonoBehaviour {
        [Header("Jump")]
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float jumpForce; // force applied on Player jump
        [SerializeField] private float gravityForce; // default force applied down
        [SerializeField] private float shortJumpForce; // bigger force applied down to ease jump height control

        private float verticalVelocity;
        public float VerticalVelocity { get => verticalVelocity; }
        private bool canJump; // if Player can jump currently

        [Header("Ground Detection")]
        [SerializeField] private Collider2D collider;
        [SerializeField] private LayerMask groundLayer;
        private bool isGrounded;
        private float raycastHorizontalOffset;
        private float raycastVerticalOffset;

        // initialize variables
        private void Start() {
            raycastHorizontalOffset = collider.bounds.extents.x - 0.03f;
            raycastVerticalOffset = collider.bounds.extents.y + 0.03f;
        }

        // jump logic
        public void ExecuteUpdate() {
            isGrounded = GroundCheck();
            if (isGrounded) {
                // reset vertical velocity on ground
                if (verticalVelocity <= 0) {
                    canJump = true;
                    verticalVelocity = 0;
                }
            }
            else {
                // fall
                canJump = false;
                if (Input.GetButton("Jump")) {
                    verticalVelocity -= gravityForce * Time.deltaTime;
                }
                else {
                    verticalVelocity -= shortJumpForce * Time.deltaTime;
                }
            }

            // jump
            if (canJump && Input.GetButtonDown("Jump")) {
                verticalVelocity = jumpForce;
            }
        }

        // apply movement force
        public void ExecuteFixedUpdate() {
            rb.AddForce(new Vector2(rb.velocity.x, verticalVelocity), ForceMode2D.Force);
        }

        // cast ray to ground
        private bool GroundCheck() {
            for (int i = -1; i <= 1; i++) {
                Vector3 rayOrigin = new Vector2(transform.position.x + (raycastHorizontalOffset * i), transform.position.y);
                Debug.DrawLine(rayOrigin, new Vector3(rayOrigin.x + (raycastHorizontalOffset * i), rayOrigin.y, rayOrigin.z) + Vector3.down * raycastVerticalOffset, Color.green);
                if (Physics2D.Raycast(rayOrigin, Vector3.down, raycastVerticalOffset, groundLayer)) {
                    return true;
                }
            }

            return false;
        }
    }
}