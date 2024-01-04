using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    public Button button;
    public Image icon;
    public TextMeshProUGUI countText;

    private ItemSlot curSlot;
    private Outline outLine;

    public int index;

    private void Awake()
    {
        InitInstanceUI();
    }

    private void InitInstanceUI()
    {
        button = GetComponent<Button>();

        outLine = GetComponent<Outline>();

        //¾È‰Î..
        //icon = GetComponentInChildren<Image>();
        //countText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Set(ItemSlot slot)
    {
        curSlot = slot;
        icon.gameObject.SetActive(true);
        icon.sprite = slot.item.icon;
        countText.text = slot.count > 1 ? slot.count.ToString() : string.Empty;

    }

    public void Clear()
    {
        Debug.Log("Clear");
        curSlot = null;
        icon.gameObject.SetActive(false);
        countText.text = string.Empty;
    }

    public void OnButtonClick()
    {
        Inventory.Instance.SelectedItem(index);
    }
}
