using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Spawns enemies in specific moments and positions
 */

namespace devlog98.Spawn {
    public class Spawner : MonoBehaviour {
        [Header("Containers")]
        [SerializeField] private GameObject spawnPointContainer; // object that has all spawn points as children
        private List<Transform> spawnPoints = new List<Transform>(); // list with all spawn points

        [SerializeField] private GameObject enemyContainer; // object that has all enemies as children (avoid instancing)
        private List<Enemy.Enemy> enemies = new List<Enemy.Enemy>(); // list with all spawnable enemies

        [Header("Timer")]
        [Range(0, 10)] [SerializeField] private float minimumSpawnTime; // enemies spawn time
        [Range(0, 10)] [SerializeField] private float maximumSpawnTime;

        private bool isSpawning = true;

        // initialize spawn and enemy lists
        private void Start() {
            spawnPoints.AddRange(spawnPointContainer.GetComponentsInChildren<Transform>());
            enemies.AddRange(enemyContainer.GetComponentsInChildren<Enemy.Enemy>(true));

            StartCoroutine(SpawnTimerCoroutine());
        }

        // spawner timer
        private IEnumerator SpawnTimerCoroutine() {
            while(isSpawning) {
                // wait for period for next spawn
                float waitTime = Random.Range(minimumSpawnTime, maximumSpawnTime);
                yield return new WaitForSeconds(waitTime);

                // spawn inactive enemy at random spawn point
                int index = Random.Range(0, spawnPoints.Count);
                Enemy.Enemy enemy = enemies.Find(x => !x.gameObject.activeSelf);
                if (enemy != null) {
                    enemy.transform.position = spawnPoints[index].position;
                    enemy.gameObject.SetActive(true);
                }
            }
        }
    }
}