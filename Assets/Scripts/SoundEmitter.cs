using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEmitter : MonoBehaviour
{

    public float maxRadius;
    public bool debugView;
    public AudioSource Source;
    GameObject emission;
    public GameObject baseEmission;
    public float increase;

    void Start()
    {
        Source = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        updateEmission();
        if (Source.isPlaying & emission == null)
        {
            emit();
        }
    }

    void updateEmission()
    {

        if(emission != null)
        {
            emission.GetComponent<MeshRenderer>().enabled = debugView;

            if (emission.transform.localScale.x <= maxRadius)
            {
                emission.transform.localScale += new Vector3(increase, increase, increase);
            }
            else
            {
                Destroy(emission);
            }
        }
        
        
    }

    void emit()
    {
        emission = Instantiate(baseEmission, gameObject.transform);
    }

}
