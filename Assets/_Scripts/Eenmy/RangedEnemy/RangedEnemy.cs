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
        // �÷��̾�� ���� ������ ������ �� ����ü�� �߻��ϴ� ������ �����մϴ�.
     //   float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

      //  if (distanceToPlayer < shootingRange && Time.time - lastAttackTime > attackDelay)
      //  {
   //         ShootProjectile();
      //      lastAttackTime = Time.time;
     //   }
   // }

 //   void ShootProjectile()
  //  {
     // ����ü�� �߻��ϴ� ������ �����մϴ�.
 //      GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
  //      projectile.GetComponent<Rigidbody2D>().velocity = (playerTransform.position - projectileSpawnPoint.position).normalized * projectileSpeed;
  //  }
}
