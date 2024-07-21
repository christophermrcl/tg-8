using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleCardManager : MonoBehaviour
{
    public int[] Deck;
    public int[] Hand;
    public int[] ComboNumber;

    private int[] DeckCopy;

    public GameObject[] CardSlots;
    public TextMeshProUGUI[] ComboNumberText;

    private int currentCombo = 0;

    private int maxHandSize = 3;
    // Start is called before the first frame update
    private CardInfoStorage cardInfoStorage;
    void Start()
    {
        cardInfoStorage = GameObject.FindGameObjectWithTag("CardStorage").gameObject.GetComponent<CardInfoStorage>();

        DeckCopy = (int[])Deck.Clone();
        RandomizeArray(DeckCopy);
        UpdateHandSize();
        UpdateSeenableCard();
        InitialDraw();
        UpdateCardSprite();
        UpdateComboNumber();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySlot1()
    {
        PlayAndDrawToHand(0);
        UpdateCardSprite();
    }

    public void PlaySlot2()
    {
        PlayAndDrawToHand(1);
        UpdateCardSprite();
    }

    public void PlaySlot3()
    {
        PlayAndDrawToHand(2);
        UpdateCardSprite();
    }

    public void PlaySlot4()
    {
        PlayAndDrawToHand(3);
        UpdateCardSprite();
    }

    public void PlaySlot5()
    {
        PlayAndDrawToHand(4);
        UpdateCardSprite();
    }

    public void PlaySlot6()
    {
        PlayAndDrawToHand(5);
        UpdateCardSprite();
    }

    public void PlaySlot7()
    {
        PlayAndDrawToHand(6);
        UpdateCardSprite();
    }

    void PlayAndDrawToHand(int slotNum)
    {
        currentCombo = ComboNumber[slotNum];
        int randomNum = Random.Range(0, DeckCopy.Length - maxHandSize - 1);
        int tempID = DeckCopy[randomNum];
        DeckCopy[randomNum] = Hand[slotNum];
        Hand[slotNum] = tempID;
        ComboNumber[slotNum] = Random.Range(1, 9);
        UpdateComboNumber();
    }


    void UnallowThisCard(int slotNum)
    {
        CardSlots[slotNum].transform.Find("Canvas").transform.Find("Button").GetComponent<Button>().interactable = false;
        CardSlots[slotNum].GetComponent<SpriteRenderer>().color = new Color32(100,100,100, 255);
    }

    void AllowThisCard(int slotNum)
    {
        CardSlots[slotNum].transform.Find("Canvas").transform.Find("Button").GetComponent<Button>().interactable = true;
        CardSlots[slotNum].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
    }

    void UpdateComboNumber()
    {
        for (int i = 0; i < maxHandSize; i++)
        {
            
            if (ComboNumber[i] != 0)
            {
                ComboNumberText[i].text = ComboNumber[i].ToString();

                if (ComboNumber[i] == currentCombo|| ComboNumber[i] == currentCombo - 1 || ComboNumber[i] == currentCombo + 1 || currentCombo == 0)
                {
                    AllowThisCard(i);
                }
                else
                {
                    UnallowThisCard(i);
                }

                
            }
        }
    }

    void InitialDraw()
    {
        for (int i = 0; i < maxHandSize; i++)
        {
            Hand[i] = DeckCopy[Deck.Length - i - 1];
        }

        for (int i = 0; i < maxHandSize; i++)
        {
            ComboNumber[i] = Random.Range(1, 9);
        }
    }

    void UpdateHandSize()
    {
        if(Deck.Length > 9)
        {
            maxHandSize = 3;
        }else if(Deck.Length > 14)
        {
            maxHandSize = 4;
        }
        else if (Deck.Length > 24)
        {
            maxHandSize = 5;
        }
        else if (Deck.Length > 39)
        {
            maxHandSize = 6;
        }
        else if (Deck.Length > 59)
        {
            maxHandSize = 7;
        }
    }

    void UpdateSeenableCard()
    {
        for (int i = 0; i < CardSlots.Length; i++)
        {
            CardSlots[i].SetActive(true);
        }
        for(int i = 6; i >= maxHandSize; i--)
        {
            CardSlots[i].SetActive(false);
        }
    }

    public void RandomizeArray(int[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            int temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }

    void UpdateCardSprite()
    {
        for(int i = 0; i< 7; i++)
        {
            SpriteRenderer sprite;
            if (Hand[i] != 0)
            {
                sprite = CardSlots[i].GetComponent<SpriteRenderer>();
                sprite.sprite = cardInfoStorage.deck[Hand[i]-1].cardSprite;
            }
        }
    }
}
