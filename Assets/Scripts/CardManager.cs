using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager sharedInstance;

    [SerializeField] GameObject card;
    public float addTimeForHitHamster;
    public float hitCountdown;

    private GameObject[,] cards;
    private Sprite shirtCard;
    private Sprite hamsterCard;


    private int hamsterCount = 3;
    private float spawnTime;
    private float currentTime;

    private Vector2 offset;

    private void Awake()
    {
        shirtCard = Resources.Load<Sprite>("Sprites/Shirt");
        hamsterCard = Resources.Load<Sprite>("Sprites/Hamster");
        offset = card.GetComponent<SpriteRenderer>().bounds.size;
        sharedInstance = this;
        CreateBoard(offset.x, offset.y);
    }
    void Start()
    { 
        SetRandomTime();
        currentTime = 0;
    }

    // Update is called once per frame

    private void Update()
    {
        SpawnHamster();
        hitCountdown += Time.deltaTime;
    }

    private void SpawnHamster()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= spawnTime)
        {
            UpdateBoard();
            SetRandomTime();
            currentTime = 0;
        }
    }

    private void CreateBoard(float xOffset, float yOffset) 
    {
        cards = new GameObject[4, 4];
        float startX = transform.position.x;
        float startY = transform.position.y;

        for (int x = 0; x < 4; x++) 
        {
            for (int y = 0; y < 4; y++) 
            {
                GameObject newCard = Instantiate(card, new Vector3(startX + (xOffset * x * 1.1f), startY + (yOffset * y * 1.1f), 0), card.transform.rotation);
                cards[x, y] = newCard;
                newCard.transform.parent = transform;
            }
        }
    }

    private void UpdateBoard() 
    {
        int randomIndex = Random.Range(0, 16);
        int currentIndex = 0;
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                currentIndex += 1;
                if (hamsterCount > 0 && currentIndex == randomIndex) 
                {
                    GameObject newCard = cards[x, y];
                    if (newCard.GetComponent<SpriteRenderer>().sprite != hamsterCard) 
                    {
                        StartCoroutine(FlipTheCard(newCard));               
                    }
                    
                }
                
            }
        }
    }

    private IEnumerator FlipTheCard(GameObject card) 
    {
        card.GetComponent<Card>().currentCardState = CardState.HAMSTER_STATE;
        hamsterCount -= 1;
        yield return new WaitForSeconds(0.65f);
        card.GetComponent<Card>().currentCardState = CardState.FLIP_STATE;
        hamsterCount += 1;
    }


    void SetRandomTime() 
    {
        spawnTime = Random.Range(0, 3);
    }
}
