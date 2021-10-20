using UnityEngine;

public class ItemPickup : Interactable
{

    public Item item;

    public static ItemPickup instance;
    void Awake()
    {
        //if there is more than one instance of the class some is wrong
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public override void Interact()
    {
        base.Interact();

        Pickup();
    }

    public void Pickup()
    {
        Debug.Log("Picking up item " + item.name);

        GameObject go = GameObject.Find("GameManager");
        HotBarScript hotbar = go.GetComponent<HotBarScript>();

        if (hotbar.hotbaritems.Count <= 4)
        {
            HotBarScript.instance.AddHotbar(item);
            Destroy(gameObject);
        }
        else 
        {
            bool wasPickedUp = Inventory.instance.Add(item);
            if (wasPickedUp)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Pickup(Item item)
    {
        Debug.Log("Picking up item " + item.name);

        GameObject go = GameObject.Find("GameManager");
        HotBarScript hotbar = go.GetComponent<HotBarScript>();

        if (hotbar.hotbaritems.Count <= 4)
        {
            HotBarScript.instance.AddHotbar(item);
            Debug.Log("you should have gotten somethin");
        }
        else
        {
            bool wasPickedUp = Inventory.instance.Add(item);
            if (wasPickedUp)
            {
                Debug.Log("you should have gotten somethin");
            }
        }
    }

    public void TESTHotBar()
    {
        Debug.Log("Switching item to hotbar " + item.name);
        HotBarScript.instance.AddHotbar(item);
        //if (wasPickedUp)
        //{
        //    Destroy(gameObject);
        //}
    }
}
