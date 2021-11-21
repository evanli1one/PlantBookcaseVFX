using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraManager : MonoBehaviour
{
    [SerializeField] GameObject auraSegmentPrefab;
    [SerializeField] int segmentCount;
    [SerializeField] float auraRadius;

    private Transform auraTransform;

    private Vector3 vectorRadius;
    private float rotationIncrement;
    private List<GameObject> auraSegmentList = new List<GameObject>();



    private void Awake()
    {
        Construct();
    }

    private void Construct()
    {
        if (auraSegmentPrefab == null)
        {
            Debug.LogError("AuraSegmentPrefab cannot be null");
        }

        auraTransform = gameObject.transform;

        rotationIncrement = 360f / (float) segmentCount;

        vectorRadius = gameObject.transform.right * auraRadius;

        for (int i = 0; i < segmentCount; i++)
        {
            float thisRotation = rotationIncrement * i;

            GameObject newSegment = Instantiate(auraSegmentPrefab, auraTransform.position
                , Quaternion.Euler(90, thisRotation + 90, 0), auraTransform);
            
            Vector3 newPosition = newSegment.transform.position +
                (Quaternion.Euler(0, thisRotation, 0) * vectorRadius);

            newSegment.transform.position = newPosition;

            auraSegmentList.Add(newSegment);
        }
    }
}
