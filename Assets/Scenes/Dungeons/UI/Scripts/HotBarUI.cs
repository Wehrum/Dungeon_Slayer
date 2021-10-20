using UnityEngine;

public class HotBarUI : MonoBehaviour
{
    public Transform HItems;
    HotBarScript hotbar;
    HotBarSlot[] hslots;
    Item item;
    public string itemname;
    public GameObject HotbarUI;
    public GameObject hslot1;
    public GameObject hslot2;
    public GameObject hslot3;
    public GameObject hslot4;
    public GameObject hslot5;

    public Item Item { get => item; set => item = value; }

    public HotBarUI()
    {
        item = Item;
    }

    void Start()
    {
        //create an instance so I don't have to instatitate
        hotbar = HotBarScript.instance;
        //subscribes to the event handler
        hotbar.onItemUseCallBack += UpdateHUI;
        //Grabs all items inside inventory
        hslots = HItems.GetComponentsInChildren<HotBarSlot>();

    }

    //Update is called once per frame
    void Update()
    {
        //Hotbar logic
        if (Input.GetKeyDown("1"))
        {
            if (hotbar.hotbaritems.Count > 0)
            {
                Item = hotbar.hotbaritems[0];
                itemname = Item.name;
                Debug.Log("Switched item to first slot");
                CheckActiveSlots(true, false, false, false, false);
            }
        }
        else if (Input.GetKeyDown("2"))
        {
            if (hotbar.hotbaritems.Count >= 2)
            {
                Item = hotbar.hotbaritems[1];
                itemname = Item.name;
                Debug.Log("Switched item to second slot");
                CheckActiveSlots(false, true, false, false, false);
            }
        }
        else if (Input.GetKeyDown("3"))
        {
            if (hotbar.hotbaritems.Count >= 3)
            {
                Item = hotbar.hotbaritems[2];
                itemname = Item.name;
                Debug.Log("Switch item to third slot");
                CheckActiveSlots(false, false, true, false, false);
            }
        }   
        else if (Input.GetKeyDown("4"))
        {
            if (hotbar.hotbaritems.Count >= 4)
            {
                Item = hotbar.hotbaritems[3];
                itemname = Item.name;
                Debug.Log("Switch item to fourth slot");
                CheckActiveSlots(false, false, false, true, false);
            }
        }
        else if (Input.GetKeyDown("5"))
        {
            if (hotbar.hotbaritems.Count > 4)
            {
                Item = hotbar.hotbaritems[4];
                itemname = Item.name;
                Debug.Log("Switch item to fith slot");
                CheckActiveSlots(false, false, false, false, true);
            }
        }
        else if (hotbar.hotbaritems.Count == 0)
        {
            Item = null;
            itemname = null;
            CheckActiveSlots(false, false, false, false, false);
        }
        if (Input.GetKeyDown("space"))
        {
            if (Item != null)
            {
                Item.Use();
            }
            else
                Debug.Log("No item in hotbar to use!");
        }
        #region Test Code
        //if (hotbar.hotbaritems.Count > 0)
        //{
        //    if (key1 == true)
        //    {
        //        item = hotbar.hotbaritems[0];
        //    }
        //    if (key2 == true && hotbar.hotbaritems.Count >= 2)
        //    {
        //        item = hotbar.hotbaritems[1];
        //    }
        //}


        //if (item != null && key6 == true)
        //{
        //    item.Use();
        //}
        //else if (item == null && Input.GetKey("space"))
        //{
        //    Debug.Log("No item in hotbar to use!");
        //}

        //if (Input.GetKeyDown("space"))
        //{
        //    GameObject go = GameObject.Find("GameManager");
        //    HotBarScript hotbar = go.GetComponent<HotBarScript>();
        //    if (hotbar.hotbaritems.Count > 0)
        //    {
        //        item = hotbar.hotbaritems[0];
        //    }
        //    else if (hotbar.hotbaritems.Count == 0)
        //    {
        //        item = null;
        //    }
        //    Debug.Log("button was pressed");
        //    if (item != null)
        //    {
        //        item.Use();
        //    }
        //    else
        //        Debug.Log("No item in hotbar to use!");
        //} 
        #endregion
    }

    //void Check()
    //{
    //    //Check method when UI updates to set the item
    //    switch (hotbar.hotbaritems.Count)
    //    {
    //        case 0:
    //            item = hotbar.hotbaritems[0];
    //            CheckActiveSlots(true, false, false, false, false);
    //            break;
    //        case 1:
    //            item = hotbar.hotbaritems[1];
    //            CheckActiveSlots(false, true, false, false, false);
    //            break;
    //        case 2:
    //            item = hotbar.hotbaritems[2];
    //            CheckActiveSlots(false, false, true, false, false);
    //            break;
    //        case 3:
    //            item = hotbar.hotbaritems[3];
    //            CheckActiveSlots(false, false, false, true, false);
    //            break;
    //        case 4:
    //            item = hotbar.hotbaritems[4];
    //            CheckActiveSlots(false, false, false, false, true);
    //            break;
    //        default:
    //            item = null;
    //            CheckActiveSlots(false, false, false, false, false);
    //            break;
    //    }
    //}

    void CheckActiveSlots(bool slot1, bool slot2, bool slot3, bool slot4, bool slot5)
    {
        hslot1.SetActive(slot1);
        hslot2.SetActive(slot2);
        hslot3.SetActive(slot3);
        hslot4.SetActive(slot4);
        hslot5.SetActive(slot5);
    }
        

    public void UpdateHUI()
    {
        for (int i = 0; i < hslots.Length; i++)
        {
            if (i < hotbar.hotbaritems.Count)
            {
                hslots[i].AddItem(hotbar.hotbaritems[i]);
            }
            else
            {
                hslots[i].ClearSlot();
                //going to sleep but idea to is to add logic to check if 
                //equal to 1, 2, 3 etc to do count == 1 hotbaritem[1] 
                //nvm wont work
                //maybe add bool or something to keep track of currently selected
                // item? 
                // idk 
                if (hotbar.hotbaritems.Count > 0)
                {
                    //when clearing slots from hotbar it'll set the selection to 0
                    //refreshes the selection, if not when changing it won't update 
                   Item = hotbar.hotbaritems[0];
                    itemname = Item.name;
                   hslot1.SetActive(true);
                   hslot2.SetActive(false);
                   hslot3.SetActive(false);
                   hslot4.SetActive(false);
                   hslot5.SetActive(false);
                }
            }
        }
    }
}
