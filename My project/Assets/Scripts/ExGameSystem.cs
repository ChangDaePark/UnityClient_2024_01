using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item
{
    private int index;
    private string name;
    private Itemtype type;
    private Sprite image;


    public int Index
    {
        get { return index; }
        set { index = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Itemtype Type
    {
        get { return type; }
        set { type = value; }
    }

    public Sprite Image
    {
        get { return Image; }
        set { Image = value; }
    }

    public Item(int index, string name, Itemtype type)
    {
        this.index = index;
        this.name = name;
        this.type = type;
    }
}




public enum Itemtype
{
    Weapon,
    Armor,
    Potion,
    QuestItem
}

public class Inventory
{
    private Item[] items = new Item[16];

    public Item this[int index]
    {
        get { return items[index]; }
        set { items[index] = value; }
    }

    public int ItemCount
    {
        get
        {
            int count = 0;
            foreach (Item item in items)
            {
                if (item != null) count++;
            }
            return count;
        }
    }

    public bool Additem(Item item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = item;
                return true;
            }
        }
        return false;
    }

    public void RemoveItem(Item item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == item)
            {
                items[i] = null;
                break;
            }
        }
    }
}

public class ExGameSystem : MonoBehaviour
{
    private Inventory inventory = new Inventory();

    // Start is called before the first frame update
    void Start()
    {
        Item sword = new Item(0, "Sword", Itemtype.Weapon);
        Item sheild = new Item(100, "Sheild", Itemtype.Armor);

        inventory.Additem(sword);
        inventory.Additem(sheild);

        Debug.Log("Player Inventory : " + GetInventoryAsString());

    }

    private string GetInventoryAsString()
    {
        string result = "";
        for (int i = 0; i < inventory.ItemCount; i++)
        {
            if (inventory[i] != null)
            {
                result += inventory[i].Name + ",";
            }
        }
        return result.TrimEnd(',');
    }

    // Update is called once per frame
    void Update()
    {

    }
}