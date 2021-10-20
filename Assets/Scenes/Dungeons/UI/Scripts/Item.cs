using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    //Default Item class, assigns properties and allows you to change them from within unity
    //right click on project view => Create => Inventory => New Item
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use()
    {
        // use the item
        //something might happen

        Debug.Log("Using " + name);
    }
}
