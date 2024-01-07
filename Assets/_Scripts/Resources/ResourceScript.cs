using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ResourceScript : MonoBehaviour
{
    public GameObject itemprefab;

    public float ResourceHP = 3.0f;

    private void Update()
    {
        //Debug.Log(ResourceHP);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((Input.GetKeyDown(KeyCode.A)))
        {
            if (collision.gameObject.CompareTag("PlayerWeapon"))
            {

                Debug.Log("¶§·È´Ù.");
                if (ResourceHP > 0)
                {
                    ResourceHP--;
                }
                else
                {
                    Die();
                }
            }
        }
    }

    private void Die()
    {
        if (ResourceHP < 0)
        {
            Destroy(gameObject);
            DropItem();
        }
    }
    private void DropItem()
    {
        Instantiate(itemprefab, transform.position, Quaternion.identity);
    }
}
