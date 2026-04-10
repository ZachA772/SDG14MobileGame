using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [Header("Slow Enemy Variables")]
    [SerializeField] private GameObject slowEnemyPrefab;//Prefab for slow enemy
    [SerializeField] private float slowEnemySpawnInterval = 5f;//Time between spawns
    [SerializeField] private float slowEnemySpeed = 5f;//Movement speed of slow enemy
    [SerializeField] private Transform slowEnemySpawnPoint;//Spawn point transform

    [Header("Circle Enemy Variables")]
    [SerializeField] private GameObject circleEnemyPrefab;//Prefab for circle enemy
    [SerializeField] private float circleEnemySpawnInterval = 5f;//Spawn interval
    [SerializeField] private Transform circleEnemySpawnPoint;//Spawn point

    [Header("Net Enemy Variable")]
    [SerializeField] private GameObject netEnemyPrefab;//Prefab for net enemy
    [SerializeField] private float netEnemySpawnInterval = 3f;//Time between spawns
    [SerializeField] private float netEnemySpeed = 4f;//Movement speed of net enemy
    [SerializeField] private Transform netEnemySpawnPoint;//Spawn point transform

    [Header("Strafe Enemy Variables")]
    [SerializeField] private GameObject strafeEnemyPrefab;//Prefab for strafe enemy
    [SerializeField] private float strafeEnemySpawnInterval = 5f;//Spawn interval
    [SerializeField] private Transform strafeEnemySpawnPoint;//Spawn point

    [Header("Shield Enemy Variables")]
    [SerializeField] private GameObject shieldEnemyPrefab;//Prefab for shield enemy
    [SerializeField] private float shieldEnemySpawnInterval = 5f;//Spawn interval
    [SerializeField] private Transform shieldEnemySpawnPoint;//Spawn point
       
    [Header("Split Enemy Variables")]
    [SerializeField] private GameObject splitEnemyPrefab;//Prefab for split enemy
    [SerializeField] private float splitEnemySpawnInterval = 5f;//Spawn interval
    [SerializeField] private Transform splitEnemySpawnPoint;//Spawn point

    //Max and Min Y spawns
    [SerializeField] private Transform MinYSpawn;//Min Y
    [SerializeField] private Transform MaxYSpawn;//Max Y
    [SerializeField] private Transform MaxYLeftSpawn;//Max Y Top Left



    private void Start()
    {
        ResumeSpawning();//Start spawning enemies when scene starts
    }

    public void ResumeSpawning()
    {
        enabled = true;//Enable this spawner

        string currentScene = SceneManager.GetActiveScene().name;//Get current scene

        //Spawn different enemies based on current level
        if (currentScene == "Level1")
        { 
            InvokeRepeating(nameof(SpawnSlowEnemy), 0f, slowEnemySpawnInterval);//Spawn slow enemies
            InvokeRepeating(nameof(SpawnCircleEnemy), 1f, circleEnemySpawnInterval);//Spawn circle enemies
        }
        else if (currentScene == "Level2")
        {
            InvokeRepeating(nameof(SpawnNetEnemy), 1f, netEnemySpawnInterval);//Spawn net enemies
            InvokeRepeating(nameof(SpawnStrafeEnemy), 0f, strafeEnemySpawnInterval);//Spawn strafe enemies
        }
        else if (currentScene == "Level3")
        {
            InvokeRepeating(nameof(SpawnShieldEnemy), 1f, shieldEnemySpawnInterval);//Spawn shield enemies
            InvokeRepeating(nameof(SpawnSplitEnemy), 0f, splitEnemySpawnInterval);//Spawn split enemies
        }
    }

    private void SpawnSlowEnemy()
    {
        if (slowEnemyPrefab == null) return;//Return if prefab missing

        Vector3 spawnPos = slowEnemySpawnPoint != null ? slowEnemySpawnPoint.position : transform.position;//Get spawn position
        spawnPos.y = Random.Range(MinYSpawn.position.y, MaxYSpawn.position.y);//Randomize Y

        GameObject slowEnemy = Instantiate(slowEnemyPrefab, spawnPos, Quaternion.identity);//Spawn slow enemy

        Rigidbody2D rb = slowEnemy.GetComponent<Rigidbody2D>();
        if (rb == null)
            rb = slowEnemy.AddComponent<Rigidbody2D>();//Add Rigidbody if missing

        rb.gravityScale = 0;//No gravity
        rb.velocity = Vector2.left * slowEnemySpeed;//Move left
    }

    private void SpawnNetEnemy()
    {
        if (netEnemyPrefab == null) return;//Return if prefab missing

        float randomX = Random.Range(MaxYLeftSpawn.position.x, MaxYSpawn.position.x);//Random X
        Vector3 spawnPos = new Vector3(randomX, netEnemySpawnPoint.position.y, 0f);//Spawn above screen

        GameObject netEnemy = Instantiate(netEnemyPrefab, spawnPos, Quaternion.identity);

        Rigidbody2D rb = netEnemy.GetComponent<Rigidbody2D>();
        if (rb == null)
            rb = netEnemy.AddComponent<Rigidbody2D>();

        rb.gravityScale = 0;

        Vector2 downLeft = new Vector2(-1f, -1f).normalized;//Direction diagonally down-left
        rb.velocity = downLeft * netEnemySpeed;
    }

    private void SpawnShieldEnemy()
    {
        if (shieldEnemyPrefab == null) return;

        Vector3 spawnPos = shieldEnemySpawnPoint != null ? shieldEnemySpawnPoint.position : transform.position;
        spawnPos.y = Random.Range(MinYSpawn.position.y, MaxYSpawn.position.y);

        GameObject shieldEnemy = Instantiate(shieldEnemyPrefab, spawnPos, Quaternion.identity);

        Rigidbody2D rb = shieldEnemy.GetComponent<Rigidbody2D>();
        if (rb == null)
            rb = shieldEnemy.AddComponent<Rigidbody2D>();

        rb.gravityScale = 0;
    }

    private void SpawnCircleEnemy()
    {
        if (circleEnemyPrefab == null) return;

        Vector3 spawnPos = circleEnemySpawnPoint != null ? circleEnemySpawnPoint.position : transform.position;
        spawnPos.y = Random.Range(MinYSpawn.position.y, MaxYSpawn.position.y);

        GameObject circleEnemy = Instantiate(circleEnemyPrefab, spawnPos, Quaternion.identity);

        Rigidbody2D rb = circleEnemy.GetComponent<Rigidbody2D>();
        if (rb == null)
            rb = circleEnemy.AddComponent<Rigidbody2D>();

        rb.gravityScale = 0;
    }

    private void SpawnStrafeEnemy()
    {
        if (strafeEnemyPrefab == null) return;

        Vector3 spawnPos = strafeEnemySpawnPoint != null ? strafeEnemySpawnPoint.position : transform.position;
        spawnPos.y = Random.Range(MinYSpawn.position.y, MaxYSpawn.position.y);

        GameObject strafeEnemy = Instantiate(strafeEnemyPrefab, spawnPos, Quaternion.identity);

        Rigidbody2D rb = strafeEnemy.GetComponent<Rigidbody2D>();
        if (rb == null)
            rb = strafeEnemy.AddComponent<Rigidbody2D>();

        rb.gravityScale = 0;
    }

    private void SpawnSplitEnemy()
    {
        if (splitEnemyPrefab == null) return;

        Vector3 spawnPos = splitEnemySpawnPoint != null ? splitEnemySpawnPoint.position : transform.position;
        spawnPos.y = Random.Range(MinYSpawn.position.y, MaxYSpawn.position.y);

        GameObject splitEnemy = Instantiate(splitEnemyPrefab, spawnPos, Quaternion.identity);

        Rigidbody2D rb = splitEnemy.GetComponent<Rigidbody2D>();
        if (rb == null)
            rb = splitEnemy.AddComponent<Rigidbody2D>();

        rb.gravityScale = 0;
    }

    public void StopSpawning()
    {
        CancelInvoke();//Stop all repeated invokes
        StopAllCoroutines();//Stop any coroutines
        enabled = false;//Disable this spawner
    }
}
