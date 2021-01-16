using System;
using TMPro;
using UnityEngine;

/*
 * Responsible for showing Enemy HUD onscreen
 */

namespace devlog98.UI.Enemy {
    public class EnemyHUD : MonoBehaviour {
        [Header("Score")]
        [SerializeField] private Animator anim;
        [SerializeField] private TextMeshProUGUI scoreText;        

        // update and show enemy score
        public void UpdateScore(Vector3 position, int scoreAmount) {
            transform.parent = null;
            transform.position = position;

            scoreText.text = "+" + Convert.ToString(scoreAmount);

            anim.SetTrigger("Score");
        }
    }
}