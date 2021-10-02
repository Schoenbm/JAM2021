using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
	public GameManager gm;
    public GameObject enemyObj;
    public int spawnsRemaining = 10;
    public float timeBetweenSpawns = 2.5f;
    private bool canSpawn = true;
    
	IEnumerator spawnEnemy() 
    {
        GameObject enemy;

        canSpawn = false;
        enemy = Instantiate(enemyObj, this.transform.position, new Quaternion()) as GameObject;
	    enemy.GetComponent<Enemy>().spawner = this;
	    enemy.GetComponent<Enemy>().setGm(gm);
        spawnsRemaining -= 1;
        yield return new WaitForSeconds(timeBetweenSpawns);
        canSpawn = true;
    }

	void Start(){
		gm = FindObjectOfType<GameManager>();
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
