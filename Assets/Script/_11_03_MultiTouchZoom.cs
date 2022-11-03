using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _11_03_MultiTouchZoom : MonoBehaviour
{
    public float perspectivespeed = 0.5f;
    float elapsed;
    void Start()
    {        
    }
    //실시간 랜더링모드 변경
    public void SetRenderMode()
    {
        Material mat = GetComponent<MeshRenderer>().material;
        mat.SetFloat("_Mode", 2);
        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mat.SetInt("_ZWrite", 0);
        mat.DisableKeyword("_ALPHATEST_ON");
        mat.EnableKeyword("_ALPHABLEND_ON");
        mat.DisableKeyword("_ALPHAMULTIPLY_ON");
        mat.renderQueue = 3000;
    }
    void Update()
    {
        if(Input.touchCount == 2)
        {
            //어느정도 움직였느냐에 대한 코드
            
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);
            Vector2 touchZeroPrePos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrePos = touchOne.position - touchOne.deltaPosition;
            float pretouchDeltaMag = (touchZeroPrePos - touchOnePrePos).magnitude;
            float touchDeltaMag = (touchZeroPrePos - touchOnePrePos).magnitude;
            float deltaMagnitudediff = pretouchDeltaMag - touchDeltaMag;
            //Camera.main.fieldOfView += deltaMagnitudediff - touchDeltaMag;
            //Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 1, 179f);

            float a = Camera.main.fieldOfView;
            float b = Camera.main.fieldOfView + deltaMagnitudediff - touchDeltaMag;
            elapsed += Time.deltaTime;
            elapsed = Mathf.Clamp(elapsed, 0f, 1f);
            Mathf.Lerp(a, b, elapsed);
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 1, 179f);
        }
    }
}
