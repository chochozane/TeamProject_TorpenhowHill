using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ItemSlot
{
    public ItemData item;
    public int Count;
}
public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public ItemSlot[] slots;

    public GameObject inventoryWindow;
    public Transform dropPosition;

    [Header("Selected Item")]
    private ItemSlot selectedItem;
    private int selectedItemIndex;

    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemDescription;
    public TextMeshProUGUI selectedItemStatNames;
    public TextMeshProUGUI selectedItemStatValues;

    public GameObject useButton;
    public GameObject eatButton;
    public GameObject dropButton;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Toggle()
    {
        //inventory Open?
        if (inventoryWindow.activeInHierarchy)
        {
            inventoryWindow.SetActive(false);
        }
        else
        {
            inventoryWindow.SetActive(true);
        }
    }


    public void AddItem(ItemData item)
    {
        Debug.Log("EatItem");
        //아이템 추가
    }



}
