using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updatedParallax : MonoBehaviour
{
    private float length, startPos;
    public GameObject cam;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        //getting the x value of our starting position
        startPos = transform.position.x;
        //getting the length of the sprite
        length = GetComponent<SpriteRenderer>().bounds.size.x;        
    }

    // Update is called once per frame
    void Update()
    {
        //how far we have to moved from start point
        float dist = (cam.transform.position.x * parallaxEffect);
        //move sprite based on location of camera
        transform.position= new Vector3(startPos + dist, transform.position.y, transform.position.z);

        //move the background based on how far we have traveled. changing start position of the background to where we are now.
        float temp = (cam.transform.position.x * (parallaxEffect));

        if(temp > startPos + length){
            startPos += length;
        }else if(temp < startPos - length){
            startPos -= length;
        }

    }
}
