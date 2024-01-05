using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesSpawn : MonoBehaviour
{
    public ItemData itemToGive;
    public Transform dropPosition;

    private void Awake()
    {
        dropPosition = GetComponent<Transform>();
    }
    public void ResourcesDrop()
    {
        Instantiate(itemToGive.dropPrefab, dropPosition.position + Vector3.down * 2, Quaternion.identity);
    }
}
