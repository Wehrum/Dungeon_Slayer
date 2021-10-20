using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform Items;
    Inventory inventory;
    InventorySlot[] slots;
    public GameObject inventoryUI;
    void Start()
    {
        //create an instance so I don't have to instatitate
        inventory = Inventory.instance;
        //subscribes to the event handler
        inventory.onItemChangedCallBack += UpdateUI;
        //Grabs all items inside inventory
        slots = Items.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            Debug.Log("Inventory button was pressed");
            //toggle between setting inventoryUI active or not
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

}

