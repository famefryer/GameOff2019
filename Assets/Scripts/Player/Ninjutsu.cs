using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninjutsu
{

    private string jutsuName;

    public Ninjutsu(string name)
    {
        jutsuName = name;
    }

    public string getName()
    {
        return jutsuName;
    }

}
