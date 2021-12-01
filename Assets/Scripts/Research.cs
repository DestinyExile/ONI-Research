using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    Image NoviceBar = null;
    Image AdvancedBar = null;
    Image InterstellarBar = null;
    Text NoviceText = null;
    Text AdvancedText = null;
    Text InterstellarText = null;

    ResearchNode[] reqResearch;
    ResearchNode currentResearch = null;
    float novicePoints, advancedPoints, interstellarPoints = 0;

    private void Start()
    {
        if(currentResearch != null && NoviceText != null)
            NoviceText.text = "0 / " + currentResearch.reqNovicePoints.ToString();
        if (currentResearch != null && AdvancedText != null)
            AdvancedText.text = "0 / " + currentResearch.reqAdvancedPoints.ToString();
        if (currentResearch != null && InterstellarText != null)
            InterstellarText.text = "0 / " + currentResearch.reqInterstellarPoints.ToString();
    }

    private void Update()
    {
        if(currentResearch != null && currentResearch.researched)
        {
            UpdateResearchList();
        }
        if (Input.GetKeyDown(KeyCode.Q) && currentResearch != null && NoviceText != null && NoviceBar != null)
        {
            novicePoints+=5;
            novicePoints = Mathf.Clamp(novicePoints, novicePoints, currentResearch.reqNovicePoints);
            NoviceBar.fillAmount = novicePoints / currentResearch.reqNovicePoints;
            NoviceText.text = novicePoints.ToString() + " / " + currentResearch.reqNovicePoints.ToString();
        }
        if (Input.GetKeyDown(KeyCode.W) && currentResearch != null && AdvancedText != null && AdvancedBar != null)
        {
            advancedPoints+=5;
            advancedPoints = Mathf.Clamp(advancedPoints, 0, currentResearch.reqAdvancedPoints);
            AdvancedBar.fillAmount = advancedPoints / currentResearch.reqAdvancedPoints;
            AdvancedText.text = advancedPoints.ToString() + " / " + currentResearch.reqAdvancedPoints.ToString();
        }
        if (Input.GetKeyDown(KeyCode.E) && currentResearch != null && AdvancedText != null && InterstellarBar != null)
        {
            interstellarPoints+=5;
            interstellarPoints = Mathf.Clamp(interstellarPoints, 0, currentResearch.reqInterstellarPoints);
            InterstellarBar.fillAmount = interstellarPoints / currentResearch.reqInterstellarPoints;
            InterstellarText.text = interstellarPoints.ToString() + " / " + currentResearch.reqInterstellarPoints.ToString();
        }
        if (currentResearch != null && currentResearch.reqNovicePoints == novicePoints && currentResearch.reqAdvancedPoints == advancedPoints && currentResearch.reqInterstellarPoints == interstellarPoints)
        {
            currentResearch.researched = true;
            UpdateResearchList();
        }
    }

    private void StartResearch()
    {
        currentResearch = reqResearch[0];
        novicePoints = 0;
        advancedPoints = 0;
        interstellarPoints = 0;

        GameObject node = GameObject.Find(currentResearch.name);
        Debug.Log(node);
        if(currentResearch.reqNovicePoints != 0)
            NoviceBar = node.transform.Find("NoviceProgressBar").transform.Find("ProgressBar").GetComponent<Image>();
        if(currentResearch.reqAdvancedPoints != 0)
            AdvancedBar = node.transform.Find("AdvancedProgressBar").transform.Find("ProgressBar").GetComponent<Image>();
       if(currentResearch.reqInterstellarPoints != 0)
            InterstellarBar = node.transform.Find("InterstellarProgressBar").transform.Find("ProgressBar").GetComponent<Image>();
        if (currentResearch.reqNovicePoints != 0)
            NoviceText = node.transform.Find("NoviceProgressBar").transform.Find("Text").GetComponent<Text>();
        if (currentResearch.reqAdvancedPoints != 0)
            AdvancedText = node.transform.Find("AdvancedProgressBar").transform.Find("Text").GetComponent<Text>();
        if (currentResearch.reqInterstellarPoints != 0)
            InterstellarText = node.transform.Find("InterstellarProgressBar").transform.Find("Text").GetComponent<Text>();
        Debug.Log(currentResearch);
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
        else
        {
            currentResearch = null;
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
    public void LoadPowerRegulation()
    {
        reqResearch = new ResearchNode[] { PowerRegulation };
        StartResearch();
    }
    public void LoadInternalCombustion()
    {
        reqResearch = new ResearchNode[] { PowerRegulation, InternalCombustion };
        StartResearch();
    }
    public void LoadFossilFuels()
    {
        reqResearch = new ResearchNode[] { PowerRegulation, InternalCombustion, FossilFuels };
        StartResearch();
    }
    public void LoadSoundAmplifiers()
    {
        reqResearch = new ResearchNode[] { PowerRegulation, InternalCombustion, SoundAmplifires };
        StartResearch();
    }
    public void LoadAdvancedPowerRegulation()
    {
        reqResearch = new ResearchNode[] { PowerRegulation, InternalCombustion, AdvancedPowerRegulation };
        StartResearch();
    }
    public void LoadPlasticManufacturing()
    {
        reqResearch = new ResearchNode[] { PowerRegulation, InternalCombustion, FossilFuels, PlasticManufacturing };
        StartResearch();
    }
    public void LoadLowResistanceConductors()
    {
        reqResearch = new ResearchNode[] { PowerRegulation, InternalCombustion, AdvancedPowerRegulation, LowResistanceConductors };
        StartResearch();
    }
    public void LoadValveMiniturization()
    {
        reqResearch = new ResearchNode[] { PowerRegulation, InternalCombustion, FossilFuels, PlasticManufacturing, ValveMiniturization };
        StartResearch();
    }
    public void LoadRenewableEnergy()
    {
        reqResearch = new ResearchNode[] { PowerRegulation, InternalCombustion, AdvancedPowerRegulation, LowResistanceConductors, RenewableEnergy };
        StartResearch();
    }
    public void LoadEmployment()
    {
        reqResearch = new ResearchNode[] { Employment };
        StartResearch();
    }
    public void LoadBruteForceRefinement()
    {
        reqResearch = new ResearchNode[] { Employment, BruteForceRefinement };
        StartResearch();
    }
    public void LoadSmartStorage()
    {
        reqResearch = new ResearchNode[] { Employment, BruteForceRefinement, SmartStorage };
        StartResearch();
    }
    public void LoadRefinedRenovations()
    {
        reqResearch = new ResearchNode[] { Employment, BruteForceRefinement, RefinedRenovations };
        StartResearch();
    }
    public void LoadSolidTransport()
    {
        reqResearch = new ResearchNode[] { Employment, PowerRegulation, BruteForceRefinement, InternalCombustion, SmartStorage, AdvancedPowerRegulation, SolidTransport };
        StartResearch();
    }
    public void LoadSmelting()
    {
        reqResearch = new ResearchNode[] { Employment, BruteForceRefinement, RefinedRenovations, Smelting };
        StartResearch();
    }
    public void LoadSolidControl()
    {
        reqResearch = new ResearchNode[] { Employment, PowerRegulation, BruteForceRefinement, InternalCombustion, SmartStorage, AdvancedPowerRegulation, SolidControl };
        StartResearch();
    }
    public void LoadSuperheatedForging()
    {
        reqResearch = new ResearchNode[] { Employment, BruteForceRefinement, RefinedRenovations, Smelting, SuperheatedForging };
        StartResearch();
    }
    public void LoadSolidManagement()
    {
        reqResearch = new ResearchNode[] { Employment, PowerRegulation, BruteForceRefinement, InternalCombustion, SmartStorage, AdvancedPowerRegulation, SolidControl, SolidManagement };
        StartResearch();
    }
    public void LoadAdvancedResearch()
    {
        reqResearch = new ResearchNode[] { Employment, AdvancedResearch };
        StartResearch();
    }
    public void LoadArtificialFriends()
    {
        reqResearch = new ResearchNode[] { Employment, AdvancedResearch, ArtificialFriends };
        StartResearch();
    }
    public void LoadNotificationSystems()
    {
        reqResearch = new ResearchNode[] { Employment, AdvancedResearch, NotificationSystems };
        StartResearch();
    }
    public void LoadRoboticTools()
    {
        reqResearch = new ResearchNode[] { Employment, AdvancedResearch, ArtificialFriends, RoboticTools };
        StartResearch();
    }
    public void LoadPharmacology()
    {
        reqResearch = new ResearchNode[] { Pharmacology };
        StartResearch();
    }
    public void LoadMedicalEquipment()
    {
        reqResearch = new ResearchNode[] { Pharmacology, MedicalEquipment };
        StartResearch();
    }
    public void LoadPathogenDiagnostics()
    {
        reqResearch = new ResearchNode[] { Pharmacology, MedicalEquipment, PathogenDiagnostics };
        StartResearch();
    }
    public void LoadMicroTargetedMedicine()
    {
        reqResearch = new ResearchNode[] { Pharmacology, MedicalEquipment, PathogenDiagnostics, MicroTargetedMedicine };
        StartResearch();
    }
    public void LoadPlumbing()
    {
        reqResearch = new ResearchNode[] { Plumbing };
        StartResearch();
    }
    public void LoadAirSystems()
    {
        reqResearch = new ResearchNode[] { Plumbing, AirSystems };
        StartResearch();
    }
    public void LoadSanitation()
    {
        reqResearch = new ResearchNode[] { Plumbing, Saniation };
        StartResearch();
    }
    public void LoadFiltration()
    {
        reqResearch = new ResearchNode[] { Plumbing, Filtration };
        StartResearch();
    }
    public void LoadLiquidBasedRefinement()
    {
        reqResearch = new ResearchNode[] { Plumbing, AirSystems, LiquidBasedRefinement };
        StartResearch();
    }
    public void LoadFlowRedirection()
    {
        reqResearch = new ResearchNode[] { Plumbing, Saniation, FlowRedirection };
        StartResearch();
    }
    public void LoadDistillation()
    {
        reqResearch = new ResearchNode[] { Plumbing, Filtration, Distillation };
        StartResearch();
    }
    public void LoadImprovedPlumbing()
    {
        reqResearch = new ResearchNode[] { Plumbing, Filtration, ImprovedPlumbing };
        StartResearch();
    }
    public void LoadLiquidTuning()
    {
        reqResearch = new ResearchNode[] { Plumbing, Filtration, ImprovedPlumbing, LiquidTuning };
        StartResearch();
    }
    public void LoadAdvancedCaffeination()
    {
        reqResearch = new ResearchNode[] { Plumbing, Filtration, ImprovedPlumbing, LiquidTuning, AdvancedCaffeination };
        StartResearch();
    }
    public void LoadVentilation()
    {
        reqResearch = new ResearchNode[] { Ventilation };
        StartResearch();
    }
    public void LoadPressureManagement()
    {
        reqResearch = new ResearchNode[] { Ventilation, PressureManagement };
        StartResearch();
    }
    public void LoadPortableGases()
    {
        reqResearch = new ResearchNode[] { Ventilation, PortableGases };
        StartResearch();
    }
    public void LoadTemperatureModulation()
    {
        reqResearch = new ResearchNode[] { Ventilation, PressureManagement, TemperatureModulation };
        StartResearch();
    }
    public void LoadDecontamination()
    {
        reqResearch = new ResearchNode[] { Ventilation, PressureManagement, Decontamination };
        StartResearch();
    }
    public void LoadImprovedVentilation()
    {
        reqResearch = new ResearchNode[] { Ventilation, PressureManagement, ImprovedVentilation };
        StartResearch();
    }
    public void LoadHVAC()
    {
        reqResearch = new ResearchNode[] { Ventilation, PressureManagement, TemperatureModulation, HVAC };
        StartResearch();
    }
    public void LoadCatalytics()
    {
        reqResearch = new ResearchNode[] { Ventilation, PressureManagement, TemperatureModulation, HVAC, Catalytics };
        StartResearch();
    }
    public void LoadHazardProtection()
    {
        reqResearch = new ResearchNode[] { InteriorDecor, Ventilation, ArtisticExpression, PressureManagement, TextileProduction, ImprovedVentilation, HazardProtection };
        StartResearch();
    }
    public void LoadTransitTubes()
    {
        reqResearch = new ResearchNode[] { InteriorDecor, Ventilation, ArtisticExpression, PressureManagement, TextileProduction, ImprovedVentilation, HazardProtection, TransitTubes };
        StartResearch();
    }
    public void LoadJetpacks()
    {
        reqResearch = new ResearchNode[] { InteriorDecor, Ventilation, ArtisticExpression, PressureManagement, TextileProduction, ImprovedVentilation, HazardProtection, TransitTubes, Jetpacks };
        StartResearch();
    }
    public void LoadInteriorDecor()
    {
        reqResearch = new ResearchNode[] { InteriorDecor };
        StartResearch();
    }
    public void LoadArtisticExpression()
    {
        reqResearch = new ResearchNode[] { InteriorDecor, ArtisticExpression };
        StartResearch();
    }
    public void LoadTextileProduction()
    {
        reqResearch = new ResearchNode[] { InteriorDecor, ArtisticExpression, TextileProduction };
        StartResearch();
    }
    public void LoadFineArt()
    {
        reqResearch = new ResearchNode[] { InteriorDecor, ArtisticExpression, FineArt };
        StartResearch();
    }
    public void LoadHomeLuxuries()
    {
        reqResearch = new ResearchNode[] { InteriorDecor, ArtisticExpression, TextileProduction, HomeLuxuries };
        StartResearch();
    }
    public void LoadHighCulture()
    {
        reqResearch = new ResearchNode[] { InteriorDecor, ArtisticExpression, FineArt, HighCulture };
        StartResearch();
    }
    public void LoadGlassBlowing()
    {
        reqResearch = new ResearchNode[] { InteriorDecor, ArtisticExpression, TextileProduction, HomeLuxuries, GlassBlowing };
        StartResearch();
    }
    public void LoadRenaissanceArt()
    {
        reqResearch = new ResearchNode[] { InteriorDecor, ArtisticExpression, FineArt, HighCulture, RenaissanceArt };
        StartResearch();
    }
    public void LoadEnvironmentalAppreciation()
    {
        reqResearch = new ResearchNode[] { InteriorDecor, ArtisticExpression, TextileProduction, HomeLuxuries, GlassBlowing, EnvironmentalAppreciation };
        StartResearch();
    }
    public void LoadNewMedia()
    {
        reqResearch = new ResearchNode[] { InteriorDecor, ArtisticExpression, TextileProduction, FineArt, HomeLuxuries, HighCulture, GlassBlowing, RenaissanceArt, NewMedia };
        StartResearch();
    }
    public void LoadMonuments()
    {
        reqResearch = new ResearchNode[] { InteriorDecor, ArtisticExpression, TextileProduction, FineArt, HomeLuxuries, HighCulture, GlassBlowing, RenaissanceArt, EnvironmentalAppreciation, NewMedia, Monuments };
        StartResearch();
    }
    public void LoadSmartHome()
    {
        reqResearch = new ResearchNode[] { InteriorDecor, SmartHome };
        StartResearch();
    }
    public void LoadGenericSensors()
    {
        reqResearch = new ResearchNode[] { InteriorDecor, SmartHome, GenericSensors };
        StartResearch();
    }
    public void LoadParallelAutomation()
    {
        reqResearch = new ResearchNode[] { InteriorDecor, SmartHome, GenericSensors, ParallelAutomation };
        StartResearch();
    }

    public void LoadAdvancedAutomation()
    {
        reqResearch = new ResearchNode[] { InteriorDecor, SmartHome, GenericSensors, AdvancedAutomation };
        StartResearch();
    }
    public void LoadComputing()
    {
        reqResearch = new ResearchNode[] { InteriorDecor, SmartHome, GenericSensors, AdvancedAutomation, Computing };
        StartResearch();
    }
    public void LoadMulltiplexing()
    {
        reqResearch = new ResearchNode[] { InteriorDecor, SmartHome, GenericSensors, AdvancedAutomation, Computing, Multiplexing };
        StartResearch();
    }
    public void LoadCelestialDetection()
    {
        reqResearch = new ResearchNode[] { InteriorDecor, SmartHome, GenericSensors, AdvancedAutomation, Computing, CelestialDetection};
        StartResearch();
    }
    public void LoadIntroductoryRocketry()
    {
        reqResearch = new ResearchNode[] { InteriorDecor, SmartHome, GenericSensors, AdvancedAutomation, Computing, CelestialDetection, IntroductoryRocketry };
        StartResearch();
    }
    public void LoadSolidFuelCombustion()
    {
        reqResearch = new ResearchNode[] { Plumbing, Ventilation, InteriorDecor, Filtration, PressureManagement, ArtisticExpression, SmartHome, ImprovedPlumbing, ImprovedVentilation, TextileProduction, GenericSensors, LiquidTuning, HazardProtection, AdvancedAutomation, AdvancedCaffeination, TransitTubes, Computing, Jetpacks, CelestialDetection, IntroductoryRocketry, SolidFuelCombustion };
        StartResearch();
    }
    public void LoadSolidCargo()
    {
        reqResearch = new ResearchNode[] { InteriorDecor, SmartHome, GenericSensors, AdvancedAutomation, Computing, CelestialDetection, IntroductoryRocketry, SolidCargo };
        StartResearch();
    }
    public void LoadHydrocarbonCombustion()
    {
        reqResearch = new ResearchNode[] { Plumbing, Ventilation, InteriorDecor, Filtration, PressureManagement, ArtisticExpression, SmartHome, ImprovedPlumbing, ImprovedVentilation, TextileProduction, GenericSensors, LiquidTuning, HazardProtection, AdvancedAutomation, AdvancedCaffeination, TransitTubes, Computing, Jetpacks, CelestialDetection, IntroductoryRocketry, SolidFuelCombustion, HydrocarbonCombustion };
        StartResearch();
    }
    public void LoadLiquidandGasCargo()
    {
        reqResearch = new ResearchNode[] { InteriorDecor, SmartHome, GenericSensors, AdvancedAutomation, Computing, CelestialDetection, IntroductoryRocketry, SolidCargo, LiquidandGasCargo };
        StartResearch();
    }
    public void LoadCryoFuelCombustion()
    {
        reqResearch = new ResearchNode[] { Plumbing, Ventilation, InteriorDecor, Filtration, PressureManagement, ArtisticExpression, SmartHome, ImprovedPlumbing, ImprovedVentilation, TextileProduction, GenericSensors, LiquidTuning, HazardProtection, AdvancedAutomation, AdvancedCaffeination, TransitTubes, Computing, Jetpacks, CelestialDetection, IntroductoryRocketry, SolidFuelCombustion, HydrocarbonCombustion, CryofuelCombustion };
        StartResearch();
    }
    public void LoadUniqueCargo()
    {
        reqResearch = new ResearchNode[] { InteriorDecor, SmartHome, GenericSensors, AdvancedAutomation, Computing, CelestialDetection, IntroductoryRocketry, SolidCargo, LiquidandGasCargo, UniqueCargo };
        StartResearch();
    }
}

