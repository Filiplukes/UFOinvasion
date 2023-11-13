using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlaneScript : MonoBehaviour
{
    private Button pauseButton; // Reference na tla��tko "pauseButton"
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

        // Z�sk� vrstvu (layer) UI pro kontrolu, zda je kurzor my�i nad UI prvkem
        eventData.pointerId = -1;

        // Vytvo�� seznam v�sledk� p�ekryvu
        System.Collections.Generic.List<RaycastResult> results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject == pauseButton.gameObject)
            {
                return true; // Kurzor my�i je nad tla��tkem
            }
        }

        return false; // Kurzor my�i nen� nad tla��tkem
    }

}
