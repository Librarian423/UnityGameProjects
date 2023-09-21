using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Wizard : Ability
{
    //Components
    private new Rigidbody rigidbody;
    private PlayerController controller;
    private Player player;

    [SerializeField] private int stoneCount = 10;

    [Header("Stone Pool")]
    public int maxPoolSize = 500;
    public int stackDefaultCapacity = 100;
    [SerializeField] private StoneWall stonePrefab;
    [SerializeField] private Transform firePos;

    private IObjectPool<StoneWall> stonePool;
    public IObjectPool<StoneWall> StonePool
    {
        get
        {
            if (stonePool == null)
                stonePool =
                    new ObjectPool<StoneWall>(
                        CreateStone,
                        OnTakeFromPool,
                        OnReturnedToPool,
                        OnDestroyPoolObject,
                        true,
                        stackDefaultCapacity,
                        maxPoolSize);
            return stonePool;
        }
    }

    private StoneWall CreateStone()
    {
        StoneWall stone = Instantiate(stonePrefab, firePos.position, transform.rotation);
        stone.stonePool = StonePool;
        stone.SetLayer(player.GetLayer());
        return stone;
    }

    private void OnTakeFromPool(StoneWall stone)
    {
        stone.gameObject.SetActive(true);

    }

    private void OnReturnedToPool(StoneWall stone)
    {
        stone.gameObject.SetActive(false);

    }

    private void OnDestroyPoolObject(StoneWall stone)
    {
        Destroy(stone.gameObject);
    }



    // Start is called before the first frame update
    protected override void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        controller = GetComponent<PlayerController>();
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        
    }

    public override void NormalAbility()
    {
        //player.NormalAttack();
        StartCoroutine(CoCreateWall());
    }

    private void ShootStone()
    {
        var stone = StonePool.Get();
        stone.transform.position = transform.position + new Vector3(10, 0, 0);
        stone.GetComponent<Rigidbody>().velocity = transform.forward * 10f;
    }

    IEnumerator CoCreateWall()
    {
        int count = 0;
        float distance = 1;
        Vector3 pos = firePos.position + firePos.forward.normalized * distance;
        Vector3 dir = firePos.forward.normalized;

        while (count < stoneCount)
        {           
            var stone = StonePool.Get();
            pos.y = 1.0f;
            stone.transform.position = pos;         
            count++;

            pos = stone.transform.position + dir.normalized * distance;
            yield return new WaitForSeconds(0.1f);
        }
        
    }
    
    public override void SpecialAbility()
    {
        Debug.Log("special");
    }
}
