using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Deactivates any Spawnable that comes nearby
 */

namespace devlog98.Spawn {
    public class SpawnableConfiner : MonoBehaviour {
        // only spawnables can reach this trigger
        private void OnTriggerEnter2D(Collider2D collision) {
            collision.gameObject.SetActive(false);
        }
    }
}