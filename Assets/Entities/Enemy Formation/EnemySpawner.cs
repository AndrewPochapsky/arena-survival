using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {
    public float speed = 5f;
    float xmin;
    float xmax;
    public float padding = 10f; 
    public float spawnDelay = 0f;

    List<GameObject> enemyList = new List<GameObject>();
    public GameObject chaserEnemy;
    public GameObject shootingEnemy;
    


    // Use this for initialization
    void Start () {

       

        SpawnUntilFull();

        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftMost.x + padding;
        xmax = rightMost.x - padding;


    }

    public void OnDrawGizmos()
    {
        //Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }
	
	// Update is called once per frame
	void Update () {

        //assigning string value to lastTouch
        //if (transform.position.x >= xmax)
        //{
        //    lastTouchWasRight = true;
        //}
        //else if (transform.position.x <= xmin)
        //{
        //    lastTouchWasRight = false;
        //}
        ////using the value of lastTouch to move 
        //if (lastTouchWasRight ==true)
        //{
        //    MoveLeft();
        //}
        //else if (lastTouchWasRight == false)
        //{
        //    MoveRight();
            
        //}

        if (AllMembersDead())
        {
            SpawnUntilFull();
        }
    }

    bool AllMembersDead()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }

    Transform NextFreePosition()
    {

        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount == 0)
            {
                return childPositionGameObject;
            }
        }
        return null;
    }

    void MoveLeft()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
      
    }
    void MoveRight()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        print("enemy hit");
    }

    void SpawnUntilFull()
    {
        enemyList.Add(chaserEnemy);
        //enemyList.Add(enemyPrefab2);

        int prefabIndex = Random.Range(0, 1);
        Transform freePosition = NextFreePosition();
        if (freePosition)
        {
            GameObject enemy = Instantiate(enemyList[prefabIndex], freePosition.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;
        }
        if (NextFreePosition())
        {
            Invoke("SpawnUntilFull", spawnDelay);
        }
        

    }

   
}
