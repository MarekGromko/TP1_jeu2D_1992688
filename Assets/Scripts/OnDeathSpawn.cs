using UnityEngine;

[RequireComponent(typeof(HealthState))]
public class OnDeathSpawn : MonoBehaviour
{
    public int nbItemSpawned = 1;
    public int chancesDenominator = 100;
    [System.Serializable]
    public class Spawnable
    {
        public GameObject prefab;
        public float chances = 0; 
        public bool isDependant = true;
    }
    public Spawnable[] spawnables;
    private HealthState hp;
    void Awake()
    {
        hp = GetComponent<HealthState>();
        hp.OnDeath += OnDeath;
    }
    private void OnDeath(Transform _)
    {
        // from https://docs.unity3d.com/6000.2/Documentation/Manual/instantiating-prefabs-intro.html
        float domain = 0;
        foreach (Spawnable spawnable in spawnables)
        {
            if (spawnable.isDependant)
            {
                domain += spawnable.chances / chancesDenominator;
            }
            else
            {
                if (spawnable.chances > Random.Range(0f, 1f))
                    Instantiate(spawnable.prefab, transform.position, Quaternion.identity);
            }
        }
        if (domain > 0)
        {
            for (int i = 0; i < nbItemSpawned; ++i)
            {
                float indexOffest = 0;
                float index = Random.Range(0, domain);
                foreach (Spawnable spawnable in spawnables)
                {
                    if (!spawnable.isDependant) continue;
                    float range = spawnable.chances / chancesDenominator;
                    if (range < index+indexOffest)
                    {
                        Instantiate(spawnable.prefab, transform.position, Quaternion.identity);
                        break;
                    }
                    indexOffest += range;
                }
            }
        }
        
        
    }
    // Update is called once per frame
    void on()
    {

    }
}
