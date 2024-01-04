using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerManager instance;

    [SerializeField] private GameObject inventory;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
