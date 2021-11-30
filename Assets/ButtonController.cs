using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject NodeHighlight;
    [SerializeField] GameObject NodeSelect;
    [SerializeField] GameObject NodeConnection1 = null;
    [SerializeField] GameObject NodeConnection2 = null;
    [SerializeField] GameObject NextNode = null;
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
            NodeSelect.SetActive(true);
        }
        else
        {
            NodeSelect.SetActive(false);
        }
        if (hovered)
        {
            NodeHighlight.SetActive(true);
            if (NodeConnection1 != null)
                NodeConnection1.SetActive(true);
            if (NodeConnection2 != null)
                NodeConnection2.SetActive(true);
        }
        else if (NextNode != null && NextNode.activeInHierarchy)
        {
            NodeHighlight.SetActive(true);
        }
        else
        {
            NodeHighlight.SetActive(false);
            if (NodeConnection1 != null)
                NodeConnection1.SetActive(false);
            if (NodeConnection2 != null)
                NodeConnection2.SetActive(false);
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
