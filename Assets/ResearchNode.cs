using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ResearchNode : ScriptableObject
{
    public new string name;
    public int reqNovicePoints;
    public int reqAdvancedPoints;
    public int reqInterstellarPoints;
    public ResearchNode preReq1 = null;
    public ResearchNode preReq2 = null;
    public int total;
    public bool researched = false;
}
