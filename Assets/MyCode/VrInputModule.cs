using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

public class VrInputModule : BaseInputModule
{

    public Camera m_Camera;
    public  bool m_ClickAction;

    public  GameObject m_CurrentObject = null;
    public PointerEventData m_Data = null;
    protected override void Awake()
    {
        base.Awake();
        m_Data = new PointerEventData(eventSystem);

    }


    public override void Process()
    {
      


        m_Data.Reset();
        m_Data.position = new Vector2(m_Camera.pixelWidth / 2, m_Camera.pixelHeight / 2);
        eventSystem.RaycastAll(m_Data, m_RaycastResultCache);
        m_Data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
        m_CurrentObject = m_Data.pointerCurrentRaycast.gameObject;
        m_RaycastResultCache.Clear();
        HandlePointerExitAndEnter(m_Data, m_CurrentObject);

        if (m_ClickAction==true) ProcessPress(m_Data);
        if (m_ClickAction==false) ProcessRelease(m_Data);

    }


    public PointerEventData GetData() 
    {
        return m_Data;
    }
    private void ProcessPress(PointerEventData data) 
    {
        data.pointerPressRaycast = data.pointerCurrentRaycast;
        GameObject newPointPress = ExecuteEvents.ExecuteHierarchy(m_CurrentObject, data, ExecuteEvents.pointerDownHandler);
        if (newPointPress == null) newPointPress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(m_CurrentObject);
        data.pressPosition = data.position;
        data.pointerPress = newPointPress;
        data.rawPointerPress = m_CurrentObject;
    }
    private void ProcessRelease(PointerEventData data) 
    {

        ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerUpHandler);
        GameObject pointerUpHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(m_CurrentObject);
        if (data.pointerPress == pointerUpHandler) 
        {
            ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerClickHandler);
        }
        eventSystem.SetSelectedGameObject(null);
        data.pressPosition = Vector2.zero;
        data.pointerPress = null;
        data.rawPointerPress = null;

    }

}
