using System;
using Unity.VisualScripting;
using UnityEngine;

public class HandControl : MonoBehaviour
{
    public static HandControl instance;
    public MissonBehaviour missionBehaviour;
    public NPCBehaviour Npc;
    public bool isHandActive;
    public bool canTouch;
    
    private void Awake()
    {
        instance = this;
        isHandActive = false;
        canTouch = false;
    }

    public void GetMissionBehaviour(MissonBehaviour misson)
    {
        if(!canTouch)return;
        if(isHandActive)return;
        missionBehaviour = misson;
        isHandActive = true;
        misson.canTouch = false;
        misson.gameObject.transform.SetParent(Camera.main.transform);
        misson.gameObject.transform.position = transform.position;
        misson.gameObject.transform.rotation = transform.rotation;
        misson.gameObject.transform.localScale = new Vector3(0.11f, 0.11f, 0.11f);
    }
    
    public MissonBehaviour GetMissionBehaviour()
    {
        return isHandActive ? missionBehaviour : null;
    }

    public void CompleteMission()
    {
        missionBehaviour.gameObject.SetActive(false);
        missionBehaviour = null;
        isHandActive = false;
    }
    
    public void SetCanTouch(bool value)
    {
        canTouch = value;
    }
}
