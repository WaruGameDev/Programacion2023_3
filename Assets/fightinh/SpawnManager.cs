using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<Transform> direction; // 1 up 2 right 3 down 4 left
    public GameObject enemy;

    public void SpawnEnemy()
    {
        int dir = Random.RandomRange(0, direction.Count);
        Instantiate(enemy, direction[dir].position, direction[dir].localRotation);
    }
    private IEnumerator Start()
    {
        while(true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1);

        }
        
    }
}
