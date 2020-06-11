using System.Collections;
using System.Collections.Generic;
public class Item {

    public int Id { get; set; }

    public int Count { get; set; }

    public Item()
    {

    }
    public Item(int id)
    {
        Id = id;
    }
    public Item(int id,int count)
    {
        Id = id;
        Count = count;
    }
}
