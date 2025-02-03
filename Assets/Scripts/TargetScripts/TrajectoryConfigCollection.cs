using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryConfigCollection : MonoBehaviour
{
    GameObject route;
    
    [SerializeField] public SO_TrajectoryConfig R_L_GaussCurve /*{ get; private set; }*/;
    public SO_TrajectoryConfig L_R_GaussCurve /*{ get; private set; }*/;
    [SerializeField] public SO_TrajectoryConfig R_L_LinearFalling;
    public SO_TrajectoryConfig L_R_LinearFalling /*{ get; private set; }*/;
    [SerializeField] public SO_TrajectoryConfig R_L_CurveToStraight_Raise;
    public SO_TrajectoryConfig L_R_CurveToStraight_Raise;



    public List<SO_TrajectoryConfig> configList /*{ get; private set; }*/;
    // Start is called before the first frame update
    void Start()
    {
        InitiateAllR_L_Configs();
        SetAllL_R_Configs();
        AddConfigsToConfigList();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitiateAllR_L_Configs()
    {
        R_L_GaussCurve.SetWaypoints();
        R_L_LinearFalling.SetWaypoints();
        R_L_CurveToStraight_Raise.SetWaypoints();

        Debug.Log("trajectoryConfigCollection. Base Trajectories Initiated");
    }
    void SetAllL_R_Configs()
    {
        L_R_GaussCurve = new SO_TrajectoryConfig();
        L_R_GaussCurve.trajectoryWaypointTransformList = SetL_R_Config(R_L_GaussCurve.trajectoryWaypointTransformList);
        L_R_LinearFalling = new SO_TrajectoryConfig();
        L_R_LinearFalling.trajectoryWaypointTransformList = SetL_R_Config(R_L_LinearFalling.trajectoryWaypointTransformList);
        L_R_CurveToStraight_Raise = new SO_TrajectoryConfig();
        L_R_CurveToStraight_Raise.trajectoryWaypointTransformList = SetL_R_Config(R_L_CurveToStraight_Raise.trajectoryWaypointTransformList);
    }

    void AddConfigsToConfigList()
    {
        configList.Add(R_L_GaussCurve);
        configList.Add(L_R_GaussCurve);
        configList.Add(R_L_LinearFalling);
        configList.Add(L_R_LinearFalling);
        configList.Add(R_L_CurveToStraight_Raise);
        configList.Add(L_R_CurveToStraight_Raise);
    }

    List<Transform> SetL_R_Config(List<Transform> R_L_Variant)
    {

        List<Transform> returnList = new List<Transform>();
        for (int i = R_L_Variant.Count - 1; i >= 0; i--)
        {
            returnList.Add(R_L_Variant[i]);
        }
        //Debug.Log("trajectoryConfigCollection.ReversedList Count = "+returnList.Count);
        return returnList;

    }
    /*
    List<Transform> ReverseList(List<Transform> R_L_Variant)
    {
        //List<Transform> returnList = new List<Transform>();
        
        List<Transform> returnList = R_L_Variant.Reverse();
        return returnList;
    }*/
    public int ReturnRandomConfig()
    {
        Debug.Log("trajectoryConfigCollection.configList.Count is:  " + configList.Count.ToString());
        int randomConfigIndex;
        randomConfigIndex = Random.Range(0, (configList.Count/*-1*/));//shouldnt work with count but here we are
        //Debug.Log("TrajectoryConfigCollection.randomConfigIndex = "+randomConfigIndex);
        Debug.Log("trajectoryConfigCollection returning config with index "+ randomConfigIndex);
        return randomConfigIndex;
    }
    void TestDebug()
    {//should be deleted
        Debug.Log("Number of configs = "+configList.Count);
        IList list1 = configList;
        for (int i = 0; i < list1.Count; i++)
        {
            List<Transform> list = (List<Transform>)list1[i];
            Debug.Log("List "+i+" Count = " + list.Count);
        }
    }
}
