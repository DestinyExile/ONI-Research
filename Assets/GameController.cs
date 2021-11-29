using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    [Header("Food")]
    public GameObject BasicFarming;
    public GameObject MealPreparation;
    public GameObject Agriculture;
    public GameObject Ranching;
    public GameObject FoodRepurposing;
    public GameObject AnimalControl;
    public GameObject GourmetMealPreparation;

    bool BasicFarmingButtonSelected = false;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectButton(GameObject button)
    {
        
    }
}
