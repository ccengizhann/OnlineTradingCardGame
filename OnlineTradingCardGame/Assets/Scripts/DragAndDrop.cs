using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DragAndDrop : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Transform originalParent;
    private Vector3 startPosition;

    public Card dragCard;
    private Image image = null;

    public TextMeshProUGUI cardName;
    public TextMeshProUGUI attack;
    public TextMeshProUGUI health;

    private void Awake()
    {
        image = GetComponent<Image>();

        cardName = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        attack = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        health = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }


    private void Start()
    {
        originalParent = transform.parent;
        startPosition = transform.position;
    }

    private void Update()
    {
        if (dragCard != null)
        {
            image.sprite = dragCard.backSide;
            cardName.text = dragCard.monsterName;
            attack.text = dragCard.attack.ToString();
            health.text = dragCard.health.ToString();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!CardGameManager.Instance.playerTurn) return;
        
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!CardGameManager.Instance.playerTurn) return;
        
        GraphicRaycaster raycaster = GetComponentInParent<GraphicRaycaster>();

        if (raycaster != null)
        {
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
            pointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            raycaster.Raycast(pointerEventData, results);

            bool droppedOnSlot = false;

            if (results.Count > 0)
            {
                foreach (RaycastResult result in results)
                {
                    Transform attachTransform = result.gameObject.transform;

                    if (attachTransform.CompareTag("Slot"))
                    {
                        CardSlotUI cardSlotUI = attachTransform.GetComponent<CardSlotUI>();

                        if (cardSlotUI != null)
                        {
                            cardSlotUI.AssignCard(dragCard);
                            
                            GameManager.Instance.SwitchTurn();
                            CardGameManager.Instance.CheckMonsters();
                            OwnCardRemoved();
                            break;
                        }
                    }
                }
            }

            
            transform.position = startPosition;
            transform.SetParent(originalParent);
        }
        else
        {
            transform.position = startPosition;
            transform.SetParent(originalParent);
        }
    }

    private void OwnCardRemoved()
    {
        dragCard = null;
        transform.gameObject.SetActive(false);
    }
}
