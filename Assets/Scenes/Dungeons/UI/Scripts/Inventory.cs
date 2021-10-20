using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour
{
    //create a variable of the class
    public static Inventory instance;

    //on start sets instance to this class
    //allows the ability to always call the class easily'
    //it's called a singleton, I don't understand fully but ye
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
    //This is a delegate, don't even ask for explaination IDEK
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    //max space of inventory
    public int space = 12;
    //creates a new list
    public List<Item> items = new List<Item>();

    //method that adds items
    public bool Add (Item item)
    {
        //if item is not a default item, add it to the inventory
        if (!item.isDefaultItem && item != null)
        {
            if (items.Count >= space)
            {
                //returns false to PickUp() method, this makes it so game object is not destroyed.
                Debug.Log("Not enough room!");
                return false;
            }
            items.Add(item);
            if (onItemChangedCallBack != null)
            {
                onItemChangedCallBack.Invoke();
            }
           
        }
        return true;
    }

    //method that removes items
    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
        }
    }



}
