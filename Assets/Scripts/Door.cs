using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Collidable
{
    public GameObject OpenedDoor;
    public GameObject ClosedDoor;
    protected GameObject hotbar;
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            hotbar = GameObject.Find("Hotbar");
            HotBarUI item = hotbar.GetComponent<HotBarUI>();

            if (item.itemname == "Key")
            {
                OpenedDoor.SetActive(true);
                Destroy(ClosedDoor);
            }
            else
            {
                Debug.Log("Key not equipped?");
            }
        }

    }
}
