﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlitzImage : MonoBehaviour
{
    public SpriteRenderer AfterImage;
    public AudioSource blitz;

    AcceptInputs OpponentActions;

    // Start is called before the first frame update
    void Start()
    {
        OpponentActions = transform.root.GetChild(0).GetComponent<MovementHandler>().HitDetect.OpponentDetector.Actions;
    }

    // Update is called once per frame
    void Update()
    {
        if (OpponentActions.blitzed > .5f)
        {
            AfterImage.color = new Color(AfterImage.color.r, AfterImage.color.g, AfterImage.color.b, .7f);
        }
        else if (OpponentActions.blitzed > 0)
        {
            AfterImage.color = new Color(AfterImage.color.r, AfterImage.color.g, AfterImage.color.b, AfterImage.color.a - .02f);
        }
        else if (AfterImage.color.a > 0)
        {
            AfterImage.color = new Color(AfterImage.color.r, AfterImage.color.g, AfterImage.color.b, AfterImage.color.a - .05f);
        }
    }

    public void Play()
    {
        blitz.PlayOneShot(blitz.clip, 1);
    }
}
