using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private Transform _spawnContainer;
    [SerializeField] private int _repeatCount;
    [SerializeField] private int _distanceBetweenFullLine;
    [SerializeField] private int _distanceBetweenRandomLine;

    [Header("Block")]
    [SerializeField] private Block _blockTemplate;
    [SerializeField] private int _blockSpawnChance;

    [Header("Wall")]
    [SerializeField] private Wall _wallTemplate;
    [SerializeField] private int _wallSpawnChance;

    [Header("Bonus")] 
    [SerializeField] private Bonus _bonusTamplate;
    [SerializeField] private int _bonusSpawnChance;
    
    private BlockSpawnPoint[] _blockSpawnPoints;
    private WallSpawnPoint[] _wallSpawnPoints;
    private BonusSpawnPoint[] _bonusSpawnPoints;

    private void Start()
    {
        _blockSpawnPoints = GetComponentsInChildren<BlockSpawnPoint>();
        _wallSpawnPoints = GetComponentsInChildren<WallSpawnPoint>();
        _bonusSpawnPoints = GetComponentsInChildren<BonusSpawnPoint>();

        for (int i = 0; i < _repeatCount; i++)
        {
            MoveSpawner(_distanceBetweenFullLine);
            GenerateRandomLine(_wallSpawnPoints, _wallTemplate.gameObject, _wallSpawnChance);
            GenerateRandomLine(_bonusSpawnPoints, _bonusTamplate.gameObject, _bonusSpawnChance);
            GenerateFullLine(_blockSpawnPoints, _blockTemplate.gameObject);
            
            MoveSpawner(_distanceBetweenRandomLine);
            GenerateRandomLine(_wallSpawnPoints, _wallTemplate.gameObject, _wallSpawnChance);
            GenerateRandomLine(_bonusSpawnPoints, _bonusTamplate.gameObject, _bonusSpawnChance);
            GenerateRandomLine(_blockSpawnPoints, _blockTemplate.gameObject, _blockSpawnChance);
        }
    }

    private void GenerateFullLine(SpawnPoint[] spawnPoints, GameObject spawnObject)
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            GenerateElement(spawnPoints[i].transform.position, spawnObject);
        }
    }

    private void GenerateRandomLine(SpawnPoint[] spawnPoints, GameObject spawnObject, int spawnChance)
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (Random.Range(0, 100) < spawnChance)
            {
                GenerateElement(spawnPoints[i].transform.position, spawnObject);
            }   
        }
    }

    private GameObject GenerateElement(Vector3 spawnPoint, GameObject spawnObject)
    {
        return Instantiate(spawnObject, spawnPoint, Quaternion.identity, _spawnContainer);
    }

    private void MoveSpawner(int distanceY)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + distanceY, transform.position.z);
    }
}
