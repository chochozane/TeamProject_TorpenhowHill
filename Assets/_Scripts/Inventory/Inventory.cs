using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor.SceneManagement;
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

    [SerializeField] private ItemSlotUI[] uiSlots;
    [SerializeField] private ItemSlot[] slots;

    [SerializeField] private GameObject inventoryWindow;
    [SerializeField] private Transform dropPosition;

    private PlayerStatus playerStatus;

    [Header("Selected Item")]
    private ItemSlot selectedItem;
    private int selectedItemIndex;

    [SerializeField] private TextMeshProUGUI selectedItemName;
    [SerializeField] private TextMeshProUGUI selectedItemDescription;

    [SerializeField] private GameObject useButton;
    [SerializeField] private GameObject dropButton;

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

        playerStatus = GetComponent<PlayerStatus>();
    }

    private void Start()
    {
        inventoryWindow.SetActive(false);
        slots = new ItemSlot[uiSlots.Length];

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new ItemSlot();
            uiSlots[i].index = i;
            uiSlots[i].Clear();
        }
        ClearSeletecItem();
    }
    private void Update()
    {
        OnInventoryButton();
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
        if (inventoryWindow.activeInHierarchy)
        {
            inventoryWindow.SetActive(false);
            UIManager.instance.ResumeTime();
        }
        else
        {
            inventoryWindow.SetActive(true);
            UIManager.instance.PauseTime();
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
        Instantiate(item.dropPrefab, dropPosition.position + Vector3.down * 2, Quaternion.identity);
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
        selectedItemName.text = string.Empty;
        selectedItemDescription.text = string.Empty;


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
                    case ConsumableType.Health:
                        Debug.Log($"playerStatus.Hp : {playerStatus.Hp}");
                        Debug.Log($"selectedItem.item.consumables[i].value : {selectedItem.item.consumables[i].value}");
                        playerStatus.ModifyHp(selectedItem.item.consumables[i].value);
                        Debug.Log($"playerStatus. + selectedItem.item.consumables[i].value : {playerStatus.Hp}");
                        break;
                    case ConsumableType.Hunger:
                        break;
                    case ConsumableType.Thirsty:
                        break;
                }
            }
        }
        RemoveSelectedItem();
    }

    private void RemoveSelectedItem()
    {
        selectedItem.count--;

        if (selectedItem.count <= 0)
        {
            selectedItem.item = null;
            ClearSeletecItem();
        }

        UpdateInventoryUI();
    }    

    public void DropButton()
    {
        ThrowItem(selectedItem.item);
        RemoveSelectedItem();
        UpdateInventoryUI();
    }

    


    public bool IsOpen()
    {
        return inventoryWindow.activeInHierarchy;
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
