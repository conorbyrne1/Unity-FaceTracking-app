using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePNGwithSound : MonoBehaviour
{
    public AudioSource source;
    //public Material current;
    public Material closedMouth;
    public Material openMouth;
    public AudioLoudnessDetection detector;

    public GameObject plane;

    public float loudnessSensibility = 100;
    public float threshold = 1f;

    float time;
    float timeDelay;

    // Start is called before the first frame update
    void Start()
    {
        //current = closedMouth;
        plane.GetComponent<MeshRenderer>().material = closedMouth;
        time = 0f;
        timeDelay = 1.5f;

    }




    // Update is called once per frame
    void Update()
    {
        time = time + 1f* Time.deltaTime;

        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;

        if (loudness < threshold)
        {
            loudness = 0;
        }

        //lerp value from minscale to maxscale
       // transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);

        if (loudness >= 6)
        {
            Talking();
        }else if (loudness < 6) 
        {
            if(time >= timeDelay)
            {
                time = 0f;
                StopTalking();
            }
            //Invoke("StopTalking", 1f);
        }
    }

    void Talking()
    {
        plane.GetComponent<MeshRenderer>().material = openMouth;
    }
    void StopTalking()
    {
        plane.GetComponent<MeshRenderer>().material = closedMouth;
    }
}
