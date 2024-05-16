using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class CoinDrop : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;
    private float speed = 1f;

    private float startTime;
    private float journeyLength;
    private void OnEnable()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPos, endPos);
        startPos = transform.position;
        endPos = new Vector3(transform.position.x + 1.5f, transform.position.y + 1f, transform.position.z);
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;
        transform.position = Vector3.Slerp(startPos, endPos, fractionOfJourney);
    }
}
