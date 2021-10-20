using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;
    public Image icon;
    public Button removeButton;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }
    private void Awake()
    {
        removeButton.interactable = false;
    }
    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButtton()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        {
            if (item != null)
            {
                GameObject go = GameObject.Find("GameManager");
                HotBarScript hotbar = go.GetComponent<HotBarScript>();

                if (hotbar.hotbaritems.Count < 5)
                {
                    HotBarScript.instance.AddHotbar(item);
                    Inventory.instance.Remove(item);
                    removeButton.interactable = true;
                }
                else
                    Debug.Log("Your hotbar is full genuis");
            }
            else
            {
                Debug.Log("No item to transfer..?");
            }

        }
    }
    //public void SwitchItem()
    //{
    //    GameObject go = GameObject.Find("GameManager");
    //    HotBarScript hotbar = go.GetComponent<HotBarScript>();

    //    if (hotbar.hotbaritems.Count < 5)
    //    {
    //        HotBarScript.instance.AddHotbar(item);
    //        Inventory.instance.Remove(item);
    //    }
    //    else 
    //        Debug.Log("Your hotbar is full genuis");
    //}
   
}
