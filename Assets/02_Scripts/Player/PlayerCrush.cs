using UnityEngine;

/*
 * Responsible for checking objects falling at the Player
 */

namespace devlog98.Player {
    public class PlayerCrush : MonoBehaviour {
        [SerializeField] private string collisionTag;
        private bool isCrushed;
        public bool IsCrushed { get => isCrushed; }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.CompareTag(collisionTag)) {
                isCrushed = true;
            }
        }

        private void OnTriggerStayr2D(Collider2D collision) {
            if (collision.CompareTag(collisionTag)) {
                isCrushed = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision) {
            if (collision.CompareTag(collisionTag)) {
                isCrushed = false;
            }
        }
    }
}