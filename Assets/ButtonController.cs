using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject NodeHighlight;
    GameObject button;
    bool selected = false;
    bool hovered = false;

    // Start is called before the first frame update
    void Start()
    {
        button = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            NodeHighlight.SetActive(true);
        }
        else if (hovered)
        {
            NodeHighlight.SetActive(true);
        }
        else
        {
            NodeHighlight.SetActive(false);
        }
    }

    public void ToggleSelection()
    {
        selected = !selected;
    }

    public void ToggleHover()
    {
        hovered = !hovered;
    }
}
