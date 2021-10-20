using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBarScript : MonoBehaviour
{
    public delegate void OnItemUse();
    public OnItemUse onItemUseCallBack;
    public static HotBarScript instance;

    public int space = 5;

    public List<Item> hotbaritems = new List<Item>();
    void Awake()
    {
        //if there is more than one instance of the class some is wrong
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }
    //method that adds items
    public void AddHotbar(Item item)
    {
        hotbaritems.Add(item);
        onItemUseCallBack.Invoke();
        
    }

    //method that removes items
    public void RemoveHotbar(Item item)
    {
        hotbaritems.Remove(item);
        onItemUseCallBack.Invoke();
    }


}
