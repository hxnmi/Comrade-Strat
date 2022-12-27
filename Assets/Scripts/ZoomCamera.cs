using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ZoomCamera : MonoBehaviour
{
    private CinemachineFreeLook freeloookCam;
    private CinemachineFreeLook.Orbit[] originalOrbits;

    [Range(1f, 5f)] public float minZoom = 5f;
    [Range(6f, 10f)] public float maxZoom = 10f;

    [AxisStateProperty] public AxisState zAxis = new AxisState(0, 1, false, true, 50f, 0.1f, 0.1f, "Mouse Scrollwheel", false);

    void Start()
    {
        freeloookCam = GetComponentInChildren<CinemachineFreeLook>();

        if(freeloookCam != null)
        {
            originalOrbits = new CinemachineFreeLook.Orbit[freeloookCam.m_Orbits.Length];

            for(int i = 0; i < originalOrbits.Length; i++)
            {
                originalOrbits[i].m_Height = freeloookCam.m_Orbits[i].m_Height;
                originalOrbits[i].m_Radius = freeloookCam.m_Orbits[i].m_Radius;
            }
        }
    }

    void Update()
    {
        if(originalOrbits != null)
        {
            zAxis.Update(Time.deltaTime);
            float zoomScale = Mathf.Lerp(minZoom, maxZoom, zAxis.Value);

            for(int i = 0; i < originalOrbits.Length; i++)
            {
                freeloookCam.m_Orbits[i].m_Height = originalOrbits[i].m_Height = zoomScale;
                freeloookCam.m_Orbits[i].m_Radius = originalOrbits[i].m_Radius = zoomScale;
            }
        }
    }
}
