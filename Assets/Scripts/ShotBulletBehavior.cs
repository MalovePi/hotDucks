using UnityEngine;

public class ShotBulletBehavior : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed = 100f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bullet, this.transform.position, this.transform.rotation) as GameObject;
            Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();
            bulletRb.velocity = this.transform.forward * bulletSpeed;
        }
    }
}
