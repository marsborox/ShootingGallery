using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryConfigCollection : MonoBehaviour
{
    GameObject route;

    [SerializeField] public SO_TrajectoryConfig R_L_GaussCurve /*{ get; private set; }*/;
    public SO_TrajectoryConfig L_R_GaussCurve { get; private set; }




    public List<SO_TrajectoryConfig> configList /*{ get; private set; }*/;
    // Start is called before the first frame update
    void Start()
    {
        SetAllL_R_Configs();
        AddConfigsToConfigList();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetAllL_R_Configs()
    {
        L_R_GaussCurve = new SO_TrajectoryConfig();
        L_R_GaussCurve.trajectoryWaypointTransformList = SetL_R_Config(R_L_GaussCurve.trajectoryWaypointTransformList);

    }

    void AddConfigsToConfigList()
    {
        configList.Add(R_L_GaussCurve);
        configList.Add(L_R_GaussCurve);
    }

    List<Transform> SetL_R_Config(List<Transform> R_L_Variant)
    {
        List<Transform> returnList = new List<Transform>();
        for (int i = R_L_Variant.Count - 1; i >= 0; i--)
        {
            returnList.Add(R_L_Variant[i]);
        }
        return returnList;

    }
    public int ReturnRandomConfig()
    {
        int randomConfigIndex;
        randomConfigIndex = Random.Range(0, (configList.Count-1));
        Debug.Log("TrajectoryConfigCollection.randomConfigIndex = "+randomConfigIndex);
        
        return randomConfigIndex;
    }
}
