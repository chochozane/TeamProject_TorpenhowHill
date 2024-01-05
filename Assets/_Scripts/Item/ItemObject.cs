using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public ItemData item;

    private Rigidbody2D rigid;
    private CircleCollider2D collider;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //Inventory.Instance.AddItem(item);
            collision.gameObject.GetComponent<Inventory>().AddItem(item);
            Destroy(gameObject);
        }
    }
}
