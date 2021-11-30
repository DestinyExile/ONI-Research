using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Research : MonoBehaviour
{
    [Header("Food")]
    [SerializeField] ResearchNode BasicFarming;
    [SerializeField] ResearchNode MealPreparation;
    [SerializeField] ResearchNode Agriculture;
    [SerializeField] ResearchNode Ranching;
    [SerializeField] ResearchNode FoodRepurposing;
    [SerializeField] ResearchNode AnimalControl;
    [SerializeField] ResearchNode GourmetMealPreparation;
    [Header("Power")]
    [SerializeField] ResearchNode PowerRegulation;
    [SerializeField] ResearchNode InternalCombustion;
    [SerializeField] ResearchNode FossilFuels;
    [SerializeField] ResearchNode SoundAmplifires;
    [SerializeField] ResearchNode AdvancedPowerRegulation;
    [SerializeField] ResearchNode PlasticManufacturing;
    [SerializeField] ResearchNode LowResistanceConductors;
    [SerializeField] ResearchNode ValveMiniturization;
    [SerializeField] ResearchNode RenewableEnergy;
    [Header("Solid Material")]
    [SerializeField] ResearchNode BruteForceRefinement;
    [SerializeField] ResearchNode SmartStorage;
    [SerializeField] ResearchNode RefinedRenovations;
    [SerializeField] ResearchNode SolidTransport;
    [SerializeField] ResearchNode Smelting;
    [SerializeField] ResearchNode SolidControl;
    [SerializeField] ResearchNode SuperheatedForging;
    [SerializeField] ResearchNode SolidManagement;
    [Header("Colony Development")]
    [SerializeField] ResearchNode Employment;
    [SerializeField] ResearchNode AdvancedResearch;
    [SerializeField] ResearchNode ArtificialFriends;
    [SerializeField] ResearchNode NotificationSystems;
    [SerializeField] ResearchNode RoboticTools;
    [Header("Medicine")]
    [SerializeField] ResearchNode Pharmacology;
    [SerializeField] ResearchNode MedicalEquipment;
    [SerializeField] ResearchNode PathogenDiagnostics;
    [SerializeField] ResearchNode MicroTargetedMedicine;
    [Header("Liquids")]
    [SerializeField] ResearchNode Plumbing;
    [SerializeField] ResearchNode AirSystems;
    [SerializeField] ResearchNode Saniation;
    [SerializeField] ResearchNode Filtration;
    [SerializeField] ResearchNode LiquidBasedRefinement;
    [SerializeField] ResearchNode FlowRedirection;
    [SerializeField] ResearchNode Distillation;
    [SerializeField] ResearchNode ImprovedPlumbing;
    [SerializeField] ResearchNode LiquidTuning;
    [SerializeField] ResearchNode AdvancedCaffeination;
    [Header("Gases")]
    [SerializeField] ResearchNode Ventilation;
    [SerializeField] ResearchNode PressureManagement;
    [SerializeField] ResearchNode PortableGases;
    [SerializeField] ResearchNode TemperatureModulation;
    [SerializeField] ResearchNode Decontamination;
    [SerializeField] ResearchNode ImprovedVentilation;
    [SerializeField] ResearchNode HVAC;
    [SerializeField] ResearchNode Catalytics;
    [Header("Exosuits")]
    [SerializeField] ResearchNode HazardProtection;
    [SerializeField] ResearchNode TransitTubes;
    [SerializeField] ResearchNode Jetpacks;
    [Header("Decor")]
    [SerializeField] ResearchNode InteriorDecor;
    [SerializeField] ResearchNode ArtisticExpression;
    [SerializeField] ResearchNode TextileProduction;
    [SerializeField] ResearchNode FineArt;
    [SerializeField] ResearchNode HomeLuxuries;
    [SerializeField] ResearchNode HighCulture;
    [SerializeField] ResearchNode GlassBlowing;
    [SerializeField] ResearchNode RenaissanceArt;
    [SerializeField] ResearchNode EnvironmentalAppreciation;
    [SerializeField] ResearchNode NewMedia;
    [SerializeField] ResearchNode Monuments;
    [Header("Computers")]
    [SerializeField] ResearchNode SmartHome;
    [SerializeField] ResearchNode GenericSensors;
    [SerializeField] ResearchNode ParallelAutomation;
    [SerializeField] ResearchNode AdvancedAutomation;
    [SerializeField] ResearchNode Computing;
    [SerializeField] ResearchNode Multiplexing;
    [Header("Rocketry")]
    [SerializeField] ResearchNode CelestialDetection;
    [SerializeField] ResearchNode IntroductoryRocketry;
    [SerializeField] ResearchNode SolidFuelCombustion;
    [SerializeField] ResearchNode SolidCargo;
    [SerializeField] ResearchNode HydrocarbonCombustion;
    [SerializeField] ResearchNode LiquidandGasCargo;
    [SerializeField] ResearchNode CryofuelCombustion;
    [SerializeField] ResearchNode UniqueCargo;


    ResearchNode[] reqResearch;
    ResearchNode currentResearch = null;
    float novicePoints, advancedpoints, interstellarPoints = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && currentResearch != null)
        {
            novicePoints++;
            novicePoints = Mathf.Clamp(novicePoints, novicePoints, currentResearch.reqNovicePoints);
            Debug.Log(novicePoints);
        }
        if (Input.GetKeyDown(KeyCode.W) && currentResearch != null)
        {
            advancedpoints++;
            advancedpoints = Mathf.Clamp(advancedpoints, 0, currentResearch.reqAdvancedPoints);
        }
        if (Input.GetKeyDown(KeyCode.E) && currentResearch != null)
        {
            interstellarPoints++;
            interstellarPoints = Mathf.Clamp(interstellarPoints, 0, currentResearch.reqInterstellarPoints);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(currentResearch);
        }
        if (currentResearch != null && currentResearch.reqNovicePoints == novicePoints && currentResearch.reqAdvancedPoints == advancedpoints && currentResearch.reqInterstellarPoints == interstellarPoints)
        {
            UpdateResearchList();
        }
    }

    private void StartResearch()
    {
        currentResearch = reqResearch[0];
        novicePoints = 0;
        advancedpoints = 0;
        interstellarPoints = 0;
        Debug.Log(currentResearch);
        Debug.Log(reqResearch.Length);
    }

    private void UpdateResearchList()
    {
        if(reqResearch.Length > 1)
        {
            ResearchNode[] temp = new ResearchNode[reqResearch.Length - 1];
            for(int r = 1; r < reqResearch.Length; r++)
            {
                temp[r - 1] = reqResearch[r];
            }
            reqResearch = new ResearchNode[temp.Length];
            reqResearch = temp;
            StartResearch();
        }
    }

    public void LoadBasicFarming()
    {
        reqResearch = new ResearchNode[] { BasicFarming };
        StartResearch();
    }
    public void LoadMealPreparation()
    {
        reqResearch = new ResearchNode[] { BasicFarming, MealPreparation };
        StartResearch();
    }
    public void LoadAgriculture()
    {
        reqResearch = new ResearchNode[] { BasicFarming, MealPreparation, Agriculture };
        StartResearch();
    }
    public void LoadRanching()
    {
        reqResearch = new ResearchNode[] { BasicFarming, MealPreparation, Ranching };
        StartResearch();
    }
    public void LoadFoodRepurposing()
    {
        reqResearch = new ResearchNode[] { BasicFarming, MealPreparation, Agriculture, FoodRepurposing };
        StartResearch();
    }
    public void LoadAnimalControl()
    {
        reqResearch = new ResearchNode[] { BasicFarming, MealPreparation, Ranching, Agriculture, AnimalControl };
        StartResearch();
    }
    public void LoadGourmetMealPreparation()
    {
        reqResearch = new ResearchNode[] { BasicFarming, MealPreparation, Ranching, Agriculture, AnimalControl, GourmetMealPreparation };
        StartResearch();
    }

}
