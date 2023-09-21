using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class StoneWall : MonoBehaviour
{
    private Rigidbody rigidbody;
    [SerializeField] private Collider collider;
    [SerializeField]int layerNum;

    [SerializeField] private float damage = 10f;
    public IObjectPool<StoneWall> stonePool { get; set; }

    private void OnEnable()
    {
        collider.enabled = true;
        StartCoroutine(CoRelease());
        StartCoroutine(CoDisableCollider());
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        //StartCoroutine(CoRelease());
    }

    IEnumerator CoRelease()
    {
        yield return new WaitForSeconds(3f);
        stonePool.Release(this);
        
    }

    IEnumerator CoDisableCollider()
    {
        yield return new WaitForSeconds(0.01f);
        Debug.Log("Disable");
        collider.enabled = false;
    }

    public void SetLayer(LayerMask layer)
    {
        layerNum = layer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != layerNum &&
           other.CompareTag("HitBox"))
        {
            Debug.Log("Hit");
            other.gameObject.GetComponentInParent<Player>().GetDamage(damage);
            collider.enabled = false;
            StopCoroutine(CoDisableCollider());
        }
    }
}
