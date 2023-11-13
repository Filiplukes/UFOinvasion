using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlaneScript : MonoBehaviour
{
    private Button pauseButton; // Reference na tlaèítko "pauseButton"
    public float speed;

    void Start()
    {
        pauseButton = GameObject.FindGameObjectWithTag("pause").GetComponent<Button>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!IsMouseOverButton())
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                pos.x = pos.x + 1;
                transform.position = Vector2.MoveTowards(transform.position, pos, speed * Time.deltaTime);
            }
        }
    }

    bool IsMouseOverButton()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;

        // Získá vrstvu (layer) UI pro kontrolu, zda je kurzor myši nad UI prvkem
        eventData.pointerId = -1;

        // Vytvoøí seznam výsledkù pøekryvu
        System.Collections.Generic.List<RaycastResult> results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject == pauseButton.gameObject)
            {
                return true; // Kurzor myši je nad tlaèítkem
            }
        }

        return false; // Kurzor myši není nad tlaèítkem
    }

}
