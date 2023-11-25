using System.Collections;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [Header("Depedências")]
    [SerializeField] private GameObject infectedBC;
    [SerializeField] private GameObject normalBC;

    [Header("Spawner Config")]
    [SerializeField] private float minY, maxY;

    private float spawnIdnterval;
    private float sortedYPos;

    private int sortedEnemy;

    private void Start()
    {
        spawnIdnterval = 2f;

        StartCoroutine(EnemiesGen());
    }

    private void Update()
    {
        if (UIScript.score >= 100)
        {
            spawnIdnterval = 1.5f;
        }
        else if (UIScript.score >= 500)
        {
            spawnIdnterval = 1;
        }
        else if (UIScript.score > 1000)
        {
            spawnIdnterval = 0.5f;
        }
        else
        {
            spawnIdnterval = 2f;
        }

    }

    IEnumerator EnemiesGen()
    {
        SortEnemy();
        yield return new WaitForSeconds(spawnIdnterval);
        StartCoroutine(EnemiesGen());
    }

    public void SortEnemy()
    {
        sortedYPos = Random.Range(minY, maxY);
        sortedEnemy = Random.Range(0, 2);

        switch (sortedEnemy)
        {
            case 0:
                Instantiate(normalBC, new Vector2(transform.position.x, sortedYPos), transform.rotation);
                break;
            case 1:
                Instantiate(infectedBC, new Vector2(transform.position.x, sortedYPos), transform.rotation);
                break;
            default:
                break;
        }
    }
}
