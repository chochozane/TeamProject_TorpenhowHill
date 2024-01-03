using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public float projectileSpeed;
    public float shootingRange = 5f;
    public float attackDelay = 1.5f;

    private float lastAttackTime;

   // void Update()
   // {
        // 플레이어와 일정 범위에 들어왔을 때 투사체를 발사하는 로직을 구현합니다.
     //   float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

      //  if (distanceToPlayer < shootingRange && Time.time - lastAttackTime > attackDelay)
      //  {
   //         ShootProjectile();
      //      lastAttackTime = Time.time;
     //   }
   // }

 //   void ShootProjectile()
  //  {
     // 투사체를 발사하는 로직을 구현합니다.
 //      GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
  //      projectile.GetComponent<Rigidbody2D>().velocity = (playerTransform.position - projectileSpawnPoint.position).normalized * projectileSpeed;
  //  }
}
