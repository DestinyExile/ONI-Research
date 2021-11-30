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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && currentResearch != null)
        {
            currentResearch.reqNovicePoints--;
        }
        if (Input.GetKeyDown(KeyCode.W) && currentResearch != null)
        {
            currentResearch.reqAdvancedPoints--;
        }
        if (Input.GetKeyDown(KeyCode.E) && currentResearch != null)
        {
            currentResearch.reqInterstellarPoints--;
        }
    }

    private void StartResearch()
    {
        currentResearch = reqResearch[0];
    }

    private void CheckProgress()
    {
        ResearchNode[] temp = new ResearchNode[reqResearch.Length - 1];
        if (currentResearch.reqNovicePoints == 0 && currentResearch.reqAdvancedPoints == 0 && currentResearch.reqInterstellarPoints == 0)
        {
            if(reqResearch.Length != 0)
            {
                for(int r = 1; r < reqResearch.Length; r++)
                {
                    temp[r] = reqResearch[r];
                }
            }
        }
        reqResearch = temp;
    }
}
