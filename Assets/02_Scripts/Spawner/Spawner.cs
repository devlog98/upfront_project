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

        [SerializeField] private GameObject spawnableContainer; // object that has all spawnables as children (avoid instancing)
        private List<Spawnable> spawnables = new List<Spawnable>(); // list with all spawnables

        [Header("Timer")]
        [Range(0, 120)] [SerializeField] private float minimumSpawnTime; // spawn time (in seconds)
        [Range(0, 120)] [SerializeField] private float maximumSpawnTime;

        private bool isSpawning = true;

        // initialize spawn and enemy lists
        private void Start() {
            spawnPoints.AddRange(spawnPointContainer.GetComponentsInChildren<Transform>());
            spawnables.AddRange(spawnableContainer.GetComponentsInChildren<Spawnable>(true));

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
                Spawnable spawnable = spawnables.Find(x => !x.gameObject.activeSelf);
                if (spawnable != null) {
                    spawnable.transform.position = spawnPoints[index].position;
                    spawnable.gameObject.SetActive(true);
                }
            }
        }
    }
}