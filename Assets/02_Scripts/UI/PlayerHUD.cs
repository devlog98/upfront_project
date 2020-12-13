using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Responsible for updating Player HUD
 */

namespace devlog98.UI.Player {
    public class PlayerHUD : MonoBehaviour {
        public static PlayerHUD instance; // singleton

        [Header("Health")]
        [SerializeField] private GameObject healthIconContainer; // game object with health icons as children
        private List<Image> healthIcons = new List<Image>();

        // initialize singleton
        private void Awake() {
            if (instance != null && instance != this) {
                Destroy(this.gameObject);
            }
            else {
                instance = this;
            }
        }

        private void Start() {
            // set health icon list
            healthIcons.AddRange(healthIconContainer.GetComponentsInChildren<Image>());
        }

        // update health icons based on player health
        public void UpdateHealth(int healthAmount) {
            int healthIndex = 0;
            foreach(Image healthIcon in healthIcons) {
                healthIcon.gameObject.SetActive(healthIndex < healthAmount);
                healthIndex++;
            }
        }
    }
}