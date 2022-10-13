using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plantastic.Module_PoolingSystem;

public abstract class BasePeluru : MonoBehaviour, IPoolObject
{
    protected int hp;
    protected int speed;


    protected virtual void Move()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
    private void Update()
    {
        Move();
    }

    #region object pool
    public PoolingSystem poolingSystem { private set; get; }
    void IPoolObject.Initial(PoolingSystem poolSystem)
    {
        poolingSystem = poolSystem;
    }
    public abstract void OnCreate();
    public virtual void StoreToPool()
    {
        poolingSystem.Store(this);
        gameObject.SetActive(false);
    }
    #endregion
}
