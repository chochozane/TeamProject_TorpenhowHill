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

    public ItemSlotUI[] uiSlots;
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

    public void OnInventoryButton()
    {
        Toggle();
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

    private void UpdateInventoryUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null)
            {
                uiSlots[1].Set(slots[i]);
            }
            else
            {
                uiSlots[i].Clear();
            }
        }
    }

    public void AddItem(ItemData item)
    {
        Debug.Log("EatItem");
        //아이템 추가
        if(item.canStack)
        {
            ItemSlot slotToStackTo = GetItemStack(item);
            if(slotToStackTo != null)
            {
                slotToStackTo.count++;
                UpdateInventoryUI();
                return;
            }
        }

        ItemSlot emptySlot = GetEmptySlot();

        if (emptySlot != null)
        {
            emptySlot.item = item;
            emptySlot.count = 1;
            UpdateInventoryUI();
            return;
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

        useButton.SetActive(selectedItem.item.type == ItemType.Consumable);
        dropButton.SetActive(true);
    }

    ItemSlot GetItemStack(ItemData item)
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
    ItemSlot GetEmptySlot()
    {
        for (int i = 0;i < slots.Length;i++)
        {
            if (slots[1].item == null)
            {
                return slots[i];
            }
        }
        return null;
    }



    private void ClearSeletecItem()
    {
        selectedItem = null;
        selectedItemName = null;
        selectedItemDescription = null;

        useButton.SetActive(false);
        dropButton.SetActive(false);
    }

    public void UseButton()
    {
        //Item의 효과에 따라 플레이어의 체력을 회복 시켜주자.
        if(selectedItem.item.type == ItemType.Consumable)
        {
            for(int i = 0; i < selectedItem.item.consumables.Length; i++)
            {
                switch (selectedItem.item.consumables[i].type)
                {
                    //플레이어와 연결...
                    case ConsumableType.Health:
                        //PlayerStatus.hp = Mathf.Min(PlayerStatus.hp + selectedItem.item.consumables[i].value, PlayerStatus.maxHp);
                        break;
                    case ConsumableType.Hunger:
                        break;
                    case ConsumableType.Thirsty:
                        break;
                }
            }
        }
    }

    public void DropButton()
    {
        //Item의 DropItem을 Vector3(player.transform.position + 1, 0, 0)을 해보자
    }
}
