using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestKey : Chest
{
    public Item item;
    protected override void OnCollect()
    {
        if (!collected)
        {
            base.OnCollect();
            ItemPickup.instance.Pickup(item);

        }

    }
}
