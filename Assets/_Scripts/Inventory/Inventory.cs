using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ItemSlot
{
    public ItemData item;
    public int count;
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
    //public TextMeshProUGUI selectedItemStatNames;
    //public TextMeshProUGUI selectedItemStatValues;

    public GameObject useButton;
    //public GameObject eatButton;
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

    private void InitInstanceUI()
    {
        //item icon
        //item count

        //selectedItemName
        //selectedItemDescription

        //useButton
        //dropButton
        //UI 코드로 연결 해보자~~
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
        if(item.canStack)
        {
            ItemSlot slotToStackTo = GetItem(item);
            if(slotToStackTo != null)
            {
                slotToStackTo.count++;
                return;
            }
        }
    }

    internal void SelectedItem(int index)
    {
        if (slots[index].item == null)
        {
            return;
        }

        selectedItem = slots[index];
        selectedItemIndex = index;

        selectedItemName.text = selectedItem.item.name;
        selectedItemDescription.text = selectedItem.item.description;
        //selectedItemStatNames.text = string.Empty;
        //selectedItemStatValues.text = string.Empty;
    }

    ItemSlot GetItem(ItemData item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == item && slots[i].count < item.maxStackAmount)
            {
                return slots[i];
            }
        }
        return null;
    }
}
