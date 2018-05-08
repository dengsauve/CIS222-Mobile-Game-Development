using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public List<GameObject> enemies;
    //public float rockDelay = 0.5f;
    public float minTime, maxTime;

    private BoxCollider2D spawnCollider;
    private float minX, maxX;

    void Awake(){
        spawnCollider = GetComponent<BoxCollider2D>();
        minX = transform.position.x - (spawnCollider.bounds.size.x / 2);
        maxX = transform.position.x + (spawnCollider.bounds.size.x / 2);
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnRock(Random.Range(minTime, maxTime)));
    }

    // Update is called once per frame
    void Update () {
    	
    }

    IEnumerator SpawnRock(float time){
        // Wait for time seconds outside main thread
        yield return new WaitForSeconds(time);
        // Create new instance of object from list 
        Instantiate(enemies[ Random.Range(0, enemies.Count) ], 
                    new Vector3(Random.Range(minX, maxX), 6),
                    Quaternion.identity);
        // Run Coroutine again after complete (recursion kind of)
        StartCoroutine(SpawnRock(Random.Range(minTime, maxTime)));
    }
}
