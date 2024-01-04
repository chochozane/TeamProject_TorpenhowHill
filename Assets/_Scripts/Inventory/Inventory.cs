using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


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

    private void Start()
    {
        InitInstanceUI();
        inventoryWindow.SetActive(false);
        slots = new ItemSlot[uiSlots.Length];

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new ItemSlot();
            uiSlots[i].index = i;
            uiSlots[i].Clear();
        }
    }
    private void Update()
    {
        OnInventoryButton();
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            Toggle();
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

    private void UpdateInventoryUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
            {
                uiSlots[i].Set(slots[i]);
            }
            else
            {
                uiSlots[i].Clear();
            }
        }
    }

    public void AddItem(ItemData item)
    {
        if (item.canStack)
        {
            ItemSlot slotToStackTo = GetItemStack(item);
            if (slotToStackTo != null)
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

        ThrowItem(item);
    }

    private void ThrowItem(ItemData item)
    {
        Instantiate(item.dropPrefab, dropPosition.position, Quaternion.identity);
    }

    public void SelectedItem(int index)
    {
        if (slots[index].item == null)
            return;

        selectedItem = slots[index];
        selectedItemIndex = index;

        selectedItemName.text = selectedItem.item.displayName;
        selectedItemDescription.text = selectedItem.item.description;

        useButton.SetActive(selectedItem.item.type == ItemType.Consumable);
        dropButton.SetActive(true);

    }

    ItemSlot GetItemStack(ItemData item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == item && slots[i].count < item.maxStackAmount)
                return slots[i];
        }

        return null;
    }
    ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
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

    private void RemoveSelectedItem()
    {
        selectedItem.count--;

        if (selectedItem.count <= 0)
        {
            selectedItem = null;
            ClearSeletecItem();
        }

        UpdateInventoryUI();
    }    

    public void DropButton()
    {
        //Item의 DropItem을 Vector3(player.transform.position + 1, 0, 0)을 해보자
        ThrowItem(selectedItem.item);
        RemoveSelectedItem();
    }

    /////////////////////////////////////////////////
    
    public bool IsOpen()
    {
        return inventoryWindow.activeInHierarchy;
    }

    public void OnDropButton()
    {
        ThrowItem(selectedItem.item);
        RemoveSelectedItem();
    }


    public bool UHaveItem(ItemData item, int num)
    {
        bool have;
        ItemSlot slotToStackTo = GetItemStack(item);
        if (slotToStackTo != null)
        {
            if (slotToStackTo.count >= num)
            {
                have = true;
                return have;
            }
            else
            {
                Debug.Log("아이템이 모자랍니다");
                have = false;
            }
        }
        else
        {
            Debug.Log("아이템이 없습니다.");
            have = false;
        }
        return have;
    }
    public int CheckItemCount(ItemData item)
    {
        int Count = 0;
        ItemSlot slotToStackTo = GetItemStack(item);
        if (slotToStackTo != null)
        {
            Count = slotToStackTo.count;
        }
        return Count;
    }

    public void RemoveItem(ItemData item, int num)
    {
        ItemSlot slotToStackTo = GetItemStack(item);
        if (slotToStackTo != null)
        {
            if (slotToStackTo.count >= num)
            {
                slotToStackTo.count -= num;
                UpdateInventoryUI();
                return;
            }
            else
            {
                Debug.Log("아이템이 모자랍니다");
            }
        }
        else
        {
            Debug.Log("아이템이 없습니다.");
        }
    }

    public bool HasItems(ItemData item, int quantity)
    {
        return false;
    }
}
