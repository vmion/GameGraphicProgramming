using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PhysicsHelper 
{
    public static Vector3? GetHeightPosition(Vector3 _origin)
    {
        //�Ű������� ���޵� ��ġ�κ��� ����� �������� ��ġ���� �Ʒ��� ���ϴ±� ����
        Vector3 rayStartpos = _origin;
        rayStartpos.y += 100f;
        RaycastHit hitInfo;
        int layerMask = 1 << LayerMask.NameToLayer("Monster");
        layerMask = ~layerMask;
        if(Physics.Raycast(rayStartpos, Vector3.down, out hitInfo, Mathf.Infinity, layerMask))
        {
            return hitInfo.point;
        }
        return null;
    }
    public static string GetResourcename(string _data)
    {
        int n = _data.IndexOf("_");
        return _data.Substring(0, n);
    }
}
