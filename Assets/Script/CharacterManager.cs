using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData
{
    public string name;
    public int level;
    public int fortitude;
    public int willpower;
    public int resistance;
    public int agility;
    public int[] growth;
    public int ability;
    public int typeassist;
    public Sprite characterSprite;
}

public class CharacterManager : MonoBehaviour
{
    [Header("Fortitude -> Amount of HP")]
    [Header("Willpower -> Amount of Stamina")]
    [Header("Resistance -> Amount of Defense")]
    [Header("Agility -> Amount of Speed")]
    [Header("THIS STAT IS FOR BASE STAT & ADDITIONAL MODIFIER")]


    [Header("Stats -> (Growth x Level) + additional modifier")]
    [Header("Assist Type -> ")]


    public List<CharacterData> character = new List<CharacterData>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
