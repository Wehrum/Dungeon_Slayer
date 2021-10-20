using UnityEngine;
using UnityEngine.UI;

public class HotBarSlot : MonoBehaviour
{
    Item item;
    public Image icon;
    public Button button;
    public GameObject inventoryUI;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    //public void OnRemoveButtton()
    //{
    //    Inventory.instance.Remove(item);
    //}

    public void Update()
    {
        if (inventoryUI.activeInHierarchy)
        {
            button.enabled = true;
        }
        else
        {
            button.enabled = false;
        }
    }

    public void UseItem()
    {
        {
            if (item != null)
            {
                Inventory.instance.Add(item);
                HotBarScript.instance.RemoveHotbar(item);
            }
            else
            {
                Debug.Log("No item to transfer..?");
            }
        }
    }
}
