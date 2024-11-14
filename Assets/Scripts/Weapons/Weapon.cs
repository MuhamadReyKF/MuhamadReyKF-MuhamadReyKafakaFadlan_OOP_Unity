using UnityEngine;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] private float shootIntervalInSeconds = 3f;

    [Header("Bullets")]
    public Bullet bullet;
    [SerializeField] private Transform bulletSpawnPoint;

    [Header("Bullet Pool")]
    private IObjectPool<Bullet> objectPool;

    private float timer;
    public Transform parentTransform;

    private void Awake()
    {
        objectPool = new ObjectPool<Bullet>(CreateBullet, OnTakeBullet, OnReleaseBullet);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= shootIntervalInSeconds)
        {
            timer = 0f;
            Shoot();
        }
    }

    private void Shoot()
    {
        Bullet newBullet = objectPool.Get();
        newBullet.transform.position = bulletSpawnPoint.position;
        newBullet.transform.rotation = bulletSpawnPoint.rotation;
    }

    private Bullet CreateBullet()
    {
        Bullet newBullet = Instantiate(bullet);
        newBullet.gameObject.SetActive(false);
        return newBullet;
    }

    private void OnTakeBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    private void OnReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }
}
