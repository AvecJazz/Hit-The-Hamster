using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardState
{
    HAMSTER_STATE,
    FLIP_STATE
}

public class Card : MonoBehaviour
{
 
    public CardState currentCardState = CardState.FLIP_STATE;
    private CardState prevCardState;
    private SpriteRenderer render;
    private Sprite shirtCard;
    private Sprite hamsterCard;
    

    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
        shirtCard = Resources.Load<Sprite>("Sprites/Shirt");
        hamsterCard = Resources.Load<Sprite>("Sprites/Hamster");
    }



    // Update is called once per frame
    void Update()
    {
        if (currentCardState != prevCardState)
        {
            if (currentCardState == CardState.FLIP_STATE)
            {
                render.sprite = shirtCard;
                prevCardState = currentCardState;
            }

            if (currentCardState == CardState.HAMSTER_STATE)
            {
                render.sprite = hamsterCard;
                prevCardState = currentCardState;
            }
        }
    }

    private void OnMouseDown()
    {
        HitCard();
    }


    private void HitCard()
    {
        if (CardManager.sharedInstance.hitCountdown > 1)
        {
            if (currentCardState == CardState.FLIP_STATE)
            {
                Debug.Log("Не Хомяк");
            }
            if (currentCardState == CardState.HAMSTER_STATE)
            {
                Timer.sharedInstance.timer += CardManager.sharedInstance.addTimeForHitHamster;
                Debug.Log("Хомяк!");
                CardManager.sharedInstance.hitCountdown = 0; 
            }
        }
    }
}
