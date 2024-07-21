using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardData
{
    public string name;
    public int attack;
    public int defense;
    public bool isHeal;
    public int healAmount;
    public int cardType;
    public Sprite cardSprite;
}

    public class CardInfoStorage : MonoBehaviour
{
    [Header("cardType -> 1 for Mech, 2 for Bio, 3 for Xeno")]

    public List<CardData> deck = new List<CardData>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
