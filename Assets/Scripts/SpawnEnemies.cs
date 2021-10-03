using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
	public gameManager gm;
	public List<GameObject>enemylist;
    public int spawnsRemaining = 10;
	public int MaxTimeBetweenSpawns = 2;
	public float MinTimeBetweenSpawns = 1f;
	private bool canSpawn = true;
    
    IEnumerator spawnEnemy() 
    {
        GameObject enemy;

        canSpawn = false;
	    enemy = Instantiate(enemylist[Random.Range(0, enemylist.Count)], this.transform.position, new Quaternion()) as GameObject;
	    enemy.GetComponent<Enemy>().spawner = this;
	    enemy.GetComponent<Enemy>().setGm(gm);
        spawnsRemaining -= 1;
	    yield return new WaitForSeconds(Random.Range(MinTimeBetweenSpawns, MaxTimeBetweenSpawns)); // random wait time for spawn
        canSpawn = true;
    }

	void Start(){
		gm = FindObjectOfType<gameManager>();
	}
    // Update is called once per frame
    void Update()
    {
        if (spawnsRemaining > 0 && canSpawn) 
            StartCoroutine(spawnEnemy());
    }
    
	public void spawnedEnemyDied(){
		spawnsRemaining +=1;
	}
}
