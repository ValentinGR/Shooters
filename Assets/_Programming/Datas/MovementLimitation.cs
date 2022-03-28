using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Datas/Movement"), fileName = ("New Limited Movement"))]
public class MovementLimitation : ScriptableObject
{
    #region Arguments

    [Header("Is the object limited to screen space : ")]
    public bool isScreenLimited;

    [Header("If not, choose the limits :")]
    public float xMax;
    public float xMin;
    public float yMax;
    public float yMin;

    #endregion

    #region Methods

    public void LimitateMovement(Transform toCheck)
    {
        if (isScreenLimited)
            ScreenLimitation(toCheck);
        else
            ValueLimitation(toCheck);
    }

    void ScreenLimitation(Transform toCheck)
    {
        float camHorizontalSize = Camera.main.orthographicSize * Screen.width / Screen.height;
        Vector3 camPosition = Camera.main.transform.position;
        Vector3 objectHalfSize = toCheck.localScale / 2;

        toCheck.position = new Vector3(
        toCheck.position.x.GetFloatInRange(camPosition.x + objectHalfSize.x - camHorizontalSize, camPosition.x - objectHalfSize.x + camHorizontalSize),
        toCheck.position.y.GetFloatInRange(camPosition.y + objectHalfSize.y - Camera.main.orthographicSize, camPosition.y - objectHalfSize.y + Camera.main.orthographicSize),
        0);
    }

    void ValueLimitation(Transform toCheck)
    {
        toCheck.position = new Vector3(toCheck.position.x.GetFloatInRange(xMin, xMax), toCheck.position.y.GetFloatInRange(yMin, yMax), 0);
    }

    #endregion
}