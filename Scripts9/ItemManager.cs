using System.Collections;
using System.Collections.Generic;
public class ItemManager {

    private static ItemManager _instance;
    public static ItemManager Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = new ItemManager();
            }
            return _instance;
        }
    }



    private List<Item> items=new List<Item>();

    public List<Item> GetItems()
    {
        return items;
    }

    public void AddItem(int id)
    {
        AddItem(id, 1);
    }
    public void AddItem(int id, int count)
    {
        foreach (var v in items)
        {
            if (v.Id == id&&v.Count < Data._instance.MaxCount(id))
            {
                int beforeCt = Data._instance.MaxCount(id) - v.Count;
                if (beforeCt >= count)
                {
                    v.Count += count;
                }
                else
                {
                    v.Count += beforeCt;                    
                }
                count -= beforeCt;
                break;
            }
        }

        while (count > 0)
        {
            Item item = null;
            if (count >= Data._instance.MaxCount(id))
            {
                item = new Item(id, Data._instance.MaxCount(id));
            }
            else
            {
                item = new Item(id, count);
            }
            count -= Data._instance.MaxCount(id);
            items.Add(item);
        }
    }

}
