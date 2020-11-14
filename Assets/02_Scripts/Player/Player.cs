using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Player controller
 */

namespace devlog98.Player {
    public class Player : MonoBehaviour {
        [SerializeField] private PlayerMovement playerMovement; // movement logic

        private void Update() {
            playerMovement.ExecuteUpdate();
        }

        private void FixedUpdate() {
            playerMovement.ExecuteFixedUpdate();
        }
    }
}