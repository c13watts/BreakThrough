﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtboxDHA : MonoBehaviour
{
    public BoxCollider2D head;
    public BoxCollider2D body;
    public BoxCollider2D legs1;
    public BoxCollider2D legs2;
    public BoxCollider2D misc1;
    public BoxCollider2D misc2;

    Vector2 headStandSize;
    Vector2 headStandOffset;
    Vector2 bodyStandSize;
    Vector2 bodyStandOffset;
    Vector2 legsStandSize;
    Vector2 legsStandOffset;

    Vector2 headCrouchSize;
    Vector2 headCrouchOffset;
    Vector2 bodyCrouchSize;
    Vector2 bodyCrouchOffset;
    Vector2 legsCrouchSize;
    Vector2 legsCrouchOffset;

    CharacterProperties CharProp;

    void Start()
    {
        head.enabled = false;
        body.enabled = false;
        legs1.enabled = false;
        legs2.enabled = false;
        misc1.enabled = false;
        misc2.enabled = false;

        headStandSize = new Vector2(.37f, .35f);
        headStandOffset = new Vector2(.07f, .68f);
        bodyStandSize = new Vector2(.512f, .55f);
        bodyStandOffset = new Vector2(.041f, .24f);
        legsStandSize = new Vector2(.55f, .87f);
        legsStandOffset = new Vector2(-.03f, -.465f);

        headCrouchOffset = new Vector2(.09f, .2f);
        bodyCrouchSize = new Vector2(.68f, .38f);
        bodyCrouchOffset = new Vector2(.1f, -.16f);
        legsCrouchSize = new Vector2(.7f, .6f);
        legsCrouchOffset = new Vector2(-.03f, -.62f);

        CharProp = transform.GetComponentInParent<CharacterProperties>();
    }

    void Update()
    {
        if (CharProp.HitDetect.currentState.IsName("FUKnockdown") || CharProp.HitDetect.currentState.IsName("FDKnockdown"))
        {
            if (CharProp.HitDetect.hitStun > 0)
                Knockdown();
            else
                ClearHurtBox();
        }
    }

    public void Standing()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;
        head.offset = headStandOffset;
        head.size = headStandSize;
        body.offset = bodyStandOffset;
        body.size = bodyStandSize;
        legs1.offset = legsStandOffset;
        legs1.size = legsStandSize;
    }

    public void Crouching()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;
        head.offset = headCrouchOffset;
        head.size = headStandSize;
        body.offset = bodyCrouchOffset;
        body.size = bodyCrouchSize;
        legs1.offset = legsCrouchOffset;
        legs1.size = legsCrouchSize;
    }

    public void Knockdown()
    {
        ClearHurtBox();
        misc1.enabled = true;

        misc1.offset = new Vector2(0f, -.7f);
        misc1.size = new Vector2(1.7f, .3f);
    }

    public void Invincible()
    {
        CharProp.HitDetect.Actions.InvincibleHigh();
        CharProp.HitDetect.Actions.InvincibleLow();
    }

    public void ClearHurtBox()
    {
        head.enabled = false;
        body.enabled = false;
        legs1.enabled = false;
        legs2.enabled = false;
        misc1.enabled = false;
        misc2.enabled = false;
    }

    public void Walk()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;

        head.offset = new Vector2(.04f, .65f);
        head.size = headStandSize;
        body.offset = new Vector2(.01f, .22f);
        body.size = new Vector2(.5f, .5f);
        legs1.offset = new Vector2(0, -.45f);
        legs1.size = new Vector2(.65f, .9f);
    }

    public void BackDash()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;

        head.offset = new Vector2(-.47f, -.05f);
        head.size = headStandSize;
        body.offset = new Vector2(-.23f, -.2f);
        body.size = new Vector2(.69f, .33f);
        legs1.offset = new Vector2(.15f, -.57f);
        legs1.size = new Vector2(.97f, .54f);
    }

    public void JumpStart()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;

        head.offset = new Vector2(.07f, .7f);
        head.size = new Vector2(.35f, .32f);
        body.offset = new Vector2(.05f, .3f);
        body.size = new Vector2(.37f, .47f);
        legs1.offset = new Vector2(0.05f, -.4f);
        legs1.size = new Vector2(.4f, .9f);
    }

    public void FallForward()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;

        head.offset = new Vector2(.49f, .14f);
        head.size = new Vector2(.35f, .32f);
        body.offset = new Vector2(.22f, 0f);
        body.size = new Vector2(.64f, .4f);
        legs1.offset = new Vector2(-0.36f, .16f);
        legs1.size = new Vector2(.6f, .35f);
    }

    public void Jump()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;

        head.offset = new Vector2(.05f, .5f);
        head.size = new Vector2(.35f, .32f);
        body.offset = new Vector2(-.06f, .21f);
        body.size = new Vector2(.69f, .5f);
        legs1.offset = new Vector2(-.12f, -.11f);
        legs1.size = new Vector2(.6f, .5f);
    }

    public void HitAir()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;

        head.offset = new Vector2(-.045f, .28f);
        head.size = new Vector2(.37f, .34f);
        body.offset = new Vector2(-.1f, .013f);
        body.size = new Vector2(.79f, .53f);
        legs1.offset = new Vector2(.16f, -.52f);
        legs1.size = new Vector2(.6f, .75f);
    }

    public void LaunchFall()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;

        head.offset = new Vector2(-.07f, .6f);
        head.size = new Vector2(.35f, .32f);
        body.offset = new Vector2(.058f, -.18f);
        body.size = new Vector2(.51f, .52f);
        legs1.offset = new Vector2(.18f, .35f);
        legs1.size = new Vector2(.39f, .57f);
    }

    public void Deflected()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;
        legs2.enabled = true;

        head.offset = new Vector2(-.5f, .48f);
        head.size = new Vector2(.69f, .32f);
        body.offset = new Vector2(-.47f, .15f);
        body.size = new Vector2(.4f, .36f);
        legs1.offset = new Vector2(-.35f, -.21f);
        legs1.size = new Vector2(.49f, .41f);
        legs2.offset = new Vector2(-.325f, -.66f);
        legs2.size = new Vector2(.78f, .49f);
    }


    public void Run()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;

        head.offset = new Vector2(.1f, .6f);
        head.size = new Vector2(.35f, .32f);
        body.offset = new Vector2(-.03f, .14f);
        body.size = new Vector2(.6f, .6f);
    }

    public void StandLight()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;
        misc1.enabled = true;

        head.offset = headStandOffset;
        head.size = headStandSize;
        body.offset = bodyStandOffset;
        body.size = bodyStandSize;
        legs1.offset = legsStandOffset;
        legs1.size = legsStandSize;
        misc1.offset = new Vector2(.21f, .3f);
        misc1.size = new Vector2(1.1f, .47f);
    }

    public void CrouchingLight()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;
        misc1.enabled = true;

        head.offset = headCrouchOffset;
        head.size = headStandSize;
        body.offset = bodyCrouchOffset;
        body.size = bodyCrouchSize;
        legs1.offset = legsCrouchOffset;
        legs1.size = legsCrouchSize;
        misc1.offset = new Vector2(.61f, -0.2f);
        misc1.size = new Vector2(.34f, .2f);
    }

    public void JumpLight()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;
        misc1.enabled = true;

        head.offset = new Vector2(.05f, .5f);
        head.size = new Vector2(.35f, .32f);
        body.offset = new Vector2(-.06f, .21f);
        body.size = new Vector2(.69f, .5f);
        legs1.offset = new Vector2(-.12f, -.11f);
        legs1.size = new Vector2(.6f, .5f);
        misc1.offset = new Vector2(.48f, 0.3f);
        misc1.size = new Vector2(.7f, .15f);
    }

    public void StandMedStartup()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;

        head.offset = new Vector2(-.22f, .51f);
        head.size = new Vector2(.3f, .3f);
        body.offset = new Vector2(-.04f, .18f);
        body.size = new Vector2(.5f, .47f);
        legs1.offset = new Vector2(-.03f, -.47f);
        legs1.size = new Vector2(.5f, .9f);
    }

    public void StandMedActive()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;
        legs2.enabled = true;

        head.offset = new Vector2(.17f, .56f);
        head.size = new Vector2(.3f, .3f);
        body.offset = new Vector2(.12f, .18f);
        body.size = new Vector2(.8f, .47f);
        legs1.offset = new Vector2(-.03f, -.47f);
        legs1.size = new Vector2(.5f, .9f);
        legs2.offset = new Vector2(.55f, -.32f);
        legs2.size = new Vector2(.7f, .45f);
    }

    public void CrouchMed()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;
        legs2.enabled = true;

        head.offset = new Vector2(-.2f, .17f);
        head.size = new Vector2(.37f, .3f);
        body.offset = new Vector2(-.02f, -.16f);
        body.size = new Vector2(.43f, .38f);
        legs1.offset = new Vector2(.06f, -.62f);
        legs1.size = new Vector2(.88f, .6f);
        legs2.offset = new Vector2(.74f, -.68f);
        legs2.size = new Vector2(.485f, .44f);
    }

    public void JumpMedFirst()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;
        legs2.enabled = true;
        misc1.enabled = true;

        head.offset = new Vector2(-.03f, .59f);
        head.size = new Vector2(.37f, .48f);
        body.offset = new Vector2(.085f, .2f);
        body.size = new Vector2(.43f, .38f);
        legs1.offset = new Vector2(-.05f, -.28f);
        legs1.size = new Vector2(.56f, .58f);
        legs2.offset = new Vector2(.77f, 0f);
        legs2.size = new Vector2(1.08f, .25f);
        misc1.offset = new Vector2(.41f, .425f);
        misc1.size = new Vector2(.57f, .21f);
    }

    public void JumpMedActive()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;
        legs2.enabled = true;
        misc1.enabled = true;

        head.offset = new Vector2(-.03f, .54f);
        head.size = new Vector2(.37f, .38f);
        body.offset = new Vector2(.085f, .2f);
        body.size = new Vector2(.43f, .38f);
        legs1.offset = new Vector2(-.02f, -.22f);
        legs1.size = new Vector2(.62f, .7f);
        legs2.offset = new Vector2(-.525f, 0f);
        legs2.size = new Vector2(.42f, .19f);
        misc1.offset = new Vector2(.4f, .35f);
        misc1.size = new Vector2(.55f, .15f);
    }

    public void StandHeavyFirstActive()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;

        head.offset = new Vector2(.17f, .42f);
        head.size = new Vector2(.5f, .3f);
        body.offset = new Vector2(.4f, .02f);
        body.size = new Vector2(.92f, .5f);
        legs1.offset = new Vector2(-.09f, -.57f);
        legs1.size = new Vector2(1.4f, .7f);
    }
    public void StandHeavyBetween()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;

        head.offset = new Vector2(.07f, .42f);
        head.size = new Vector2(.5f, .3f);
        body.offset = new Vector2(.12f, .02f);
        body.size = new Vector2(.5f, .47f);
        legs1.offset = new Vector2(-.09f, -.57f);
        legs1.size = new Vector2(1.4f, .7f);
    }

    public void StandHeavySecondActive()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;

        head.offset = new Vector2(.2f, .47f);
        head.size = new Vector2(.38f, .29f);
        body.offset = new Vector2(.4f, .05f);
        body.size = new Vector2(1f, .6f);
        legs1.offset = new Vector2(-.09f, -.57f);
        legs1.size = new Vector2(1.4f, .7f);
    }

    public void StandHeavyRecovery()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;

        head.offset = new Vector2(.17f, .5f);
        head.size = new Vector2(.45f, .3f);
        body.offset = new Vector2(.4f, .21f);
        body.size = new Vector2(.9f, .8f);
        legs1.offset = new Vector2(-.09f, -.55f);
        legs1.size = new Vector2(1.4f, .75f);
    }

    public void CrouchHeavyActive()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;
        legs2.enabled = true;

        head.offset = new Vector2(.56f, .49f);
        head.size = new Vector2(.42f, .78f);
        body.offset = new Vector2(.45f, .12f);
        body.size = new Vector2(.8f, .41f);
        legs1.offset = new Vector2(.41f, -.26f);
        legs1.size = new Vector2(.79f, .39f);
        legs2.offset = new Vector2(.37f, -.68f);
        legs2.size = new Vector2(1.24f, .45f);
    }

    public void FHeavyFirstStartup()
    {
        ClearHurtBox();
        legs1.enabled = true;
        legs2.enabled = true;
        
        legs1.offset = new Vector2(-.146f, -.48f);
        legs1.size = new Vector2(.775f, .826f);
        legs2.offset = new Vector2(.278f, -.62f);
        legs2.size = new Vector2(.15f, .53f);
    }

    public void FHeavyActive()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;
        legs2.enabled = true;
        misc1.enabled = true;

        head.offset = new Vector2(.04f, .565f);
        head.size = new Vector2(.46f, .31f);
        body.offset = new Vector2(.085f, .16f);
        body.size = new Vector2(.62f, .57f);
        legs1.offset = new Vector2(-.146f, -.48f);
        legs1.size = new Vector2(.775f, .826f);
        legs2.offset = new Vector2(.278f, -.62f);
        legs2.size = new Vector2(.15f, .53f);
        misc1.offset = new Vector2(.63f, .4f);
        misc1.size = new Vector2(.57f, .25f);
    }

    public void JumpHeavyFirstActive()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;
        legs2.enabled = true;
        misc1.enabled = true;

        head.offset = new Vector2(.28f, .4f);
        head.size = new Vector2(.3f, .295f);
        body.offset = new Vector2(-.02f, .25f);
        body.size = new Vector2(.58f, .48f);
        legs1.offset = new Vector2(.01f, -.13f);
        legs1.size = new Vector2(.67f, .39f);
        legs2.offset = new Vector2(-.46f, -.36f);
        legs2.size = new Vector2(.29f, .24f);
        misc1.offset = new Vector2(-.67f, -.53f);
        misc1.size = new Vector2(.15f, .25f);
    }

    public void JumpHeavySecondActive()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;

        head.offset = new Vector2(.016f, .545f);
        head.size = new Vector2(.57f, .24f);
        body.offset = new Vector2(.14f, .22f);
        body.size = new Vector2(.3f, .42f);
        legs1.offset = new Vector2(-.08f, -.028f);
        legs1.size = new Vector2(.49f, .69f);
    }

    public void JumpHeavyThirdActive()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;
        legs2.enabled = true;
        misc1.enabled = true;
        misc2.enabled = true;

        head.offset = new Vector2(0f, .58f);
        head.size = new Vector2(.3f, .31f);
        body.offset = new Vector2(-.031f, .332f);
        body.size = new Vector2(.4f, .41f);
        legs1.offset = new Vector2(.075f, -.037f);
        legs1.size = new Vector2(.64f, .333f);
        legs2.offset = new Vector2(.012f, -.31f);
        legs2.size = new Vector2(.45f, .23f);
        misc1.offset = new Vector2(.31f, -.5f);
        misc1.size = new Vector2(.2f, .23f);
        misc2.offset = new Vector2(-.35f, .39f);
        misc2.size = new Vector2(.41f, .288f);
    }

    public void JumpHeavyFourthActive()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;
        legs2.enabled = true;
        misc1.enabled = true;
        misc2.enabled = true;

        head.offset = new Vector2(.2f, .69f);
        head.size = new Vector2(.36f, .53f);
        body.offset = new Vector2(-.03f, .3f);
        body.size = new Vector2(.575f, .36f);
        legs1.offset = new Vector2(-.16f, -.14f);
        legs1.size = new Vector2(.59f, .545f);
        legs2.offset = new Vector2(-.646f, -.32f);
        legs2.size = new Vector2(.39f, .395f);
    }

    public void StandBreakCharge()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;

        head.offset = new Vector2(-.05f, .5f);
        head.size = new Vector2(.5f, .3f);
        body.offset = new Vector2(-.05f, .1f);
        body.size = new Vector2(.7f, .62f);
        legs1.offset = new Vector2(-.15f, -.55f);
        legs1.size = new Vector2(.6f, .75f);
    }

    public void StandBreakActive()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;

        head.offset = new Vector2(-.12f, .41f);
        head.size = new Vector2(.5f, .3f);
        body.offset = new Vector2(.1f, .1f);
        body.size = new Vector2(.8f, .62f);
        legs1.offset = new Vector2(-.09f, -.55f);
        legs1.size = new Vector2(1.2f, .75f);
    }

    public void CrouchBreakCharge()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;
        legs2.enabled = true;

        head.offset = new Vector2(-.09f, -.094f);
        head.size = new Vector2(.4f, .35f);
        body.offset = new Vector2(0f, -.34f);
        body.size = new Vector2(.47f, .47f);
        legs1.offset = new Vector2(-.1f, -.54f);
        legs1.size = new Vector2(.74f, .12f);
        legs2.offset = new Vector2(-.13f, -.75f);
        legs2.size = new Vector2(1.18f, .3f);
    }

    public void CrouchBreakActive()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;
        legs2.enabled = true;

        head.offset = new Vector2(.47f, -.05f);
        head.size = new Vector2(.47f, .31f);
        body.offset = new Vector2(0.092f, -.21f);
        body.size = new Vector2(.59f, .36f);
        legs1.offset = new Vector2(.19f, -.47f);
        legs1.size = new Vector2(.93f, .17f);
        legs2.offset = new Vector2(.01f, -.72f);
        legs2.size = new Vector2(1.29f, .35f);
    }

    public void FBreak()
    {
        ClearHurtBox();
        body.enabled = true;
        legs1.enabled = true;

        body.offset = bodyStandOffset;
        body.size = bodyStandSize;
        legs1.offset = legsStandOffset;
        legs1.size = legsStandSize;
    }

    public void JumpBreakStartup()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;
        legs2.enabled = true;
        misc1.enabled = true;

        head.offset = new Vector2(.3f, .62f);
        head.size = new Vector2(.83f, .26f);
        body.offset = new Vector2(-0.07f, .32f);
        body.size = new Vector2(.515f, .33f);
        legs1.offset = new Vector2(-.165f, -.09f);
        legs1.size = new Vector2(.59f, .52f);
        legs2.offset = new Vector2(-.1f, -.5f);
        legs2.size = new Vector2(.16f, .32f);
        misc1.offset = new Vector2(-.22f, -.77f);
        misc1.size = new Vector2(.18f, .275f);
    }

    public void JumpBreakActive()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;
        legs2.enabled = true;
        misc1.enabled = true;

        head.offset = new Vector2(-.03f, .6f);
        head.size = new Vector2(.81f, .35f);
        body.offset = new Vector2(-.19f, .26f);
        body.size = new Vector2(.63f, .35f);
        legs1.offset = new Vector2(-.13f, -.11f);
        legs1.size = new Vector2(.52f, .49f);
        legs2.offset = new Vector2(-.48f, -.29f);
        legs2.size = new Vector2(.18f, .315f);
        misc1.offset = new Vector2(-.657f, -.53f);
        misc1.size = new Vector2(.18f, .29f);
    }

    public void JumpBreakRecovery()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;
        legs2.enabled = true;

        head.offset = new Vector2(-.09f, .65f);
        head.size = new Vector2(.45f, .25f);
        body.offset = new Vector2(0.07f, .41f);
        body.size = new Vector2(.65f, .32f);
        legs1.offset = new Vector2(-.13f, 0f);
        legs1.size = new Vector2(.65f, .53f);
        legs2.offset = new Vector2(-.655f, .073f);
        legs2.size = new Vector2(.41f, .22f);
    }

    public void BBStartup()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;

        head.offset = new Vector2(.6f, .34f);
        head.size = new Vector2(.3f, .41f);
        body.offset = new Vector2(0.2f, .33f);
        body.size = new Vector2(.52f, .57f);
        legs1.offset = new Vector2(-.135f, -.25f);
        legs1.size = new Vector2(.5f, 1f);
    }

    public void BBCycleHurtBox()
    {
        ClearHurtBox();
        head.enabled = true;

        head.offset = new Vector2(0, .24f);
        head.size = new Vector2(1.2f, 1.2f);
    }

    public void BBRecovery()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;

        head.offset = new Vector2(.134f, -.1f);
        head.size = new Vector2(.56f, .32f);
        body.offset = new Vector2(0.27f, -.44f);
        body.size = new Vector2(.66f, .5f);
        legs1.offset = new Vector2(.08f, -.8f);
        legs1.size = new Vector2(2f, .22f);
    }

    public void HRCycle()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;

        head.offset = new Vector2(.66f, -.42f);
        head.size = new Vector2(.27f, .32f);
        body.offset = new Vector2(0.32f, -.6f);
        body.size = new Vector2(.75f, .64f);
        legs1.offset = new Vector2(-.21f, -.76f);
        legs1.size = new Vector2(1.1f, .3f);
    }

    public void HRUpper()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;
        legs2.enabled = true;

        head.offset = new Vector2(.1f, .54f);
        head.size = new Vector2(.3f, .24f);
        body.offset = new Vector2(-0.03f, .175f);
        body.size = new Vector2(.68f, .55f);
        legs1.offset = new Vector2(-.07f, -.24f);
        legs1.size = new Vector2(.5f, .3f);
        legs2.offset = new Vector2(-.3f, -.5f);
        legs2.size = new Vector2(.35f, .38f);
    }

    public void BCCharge()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;
        legs2.enabled = true;

        head.offset = new Vector2(-.37f, .4f);
        head.size = new Vector2(.25f, .25f);
        body.offset = new Vector2(-0.12f, .1f);
        body.size = new Vector2(.8f, .4f);
        legs1.offset = new Vector2(-.1f, -.27f);
        legs1.size = new Vector2(.58f, .375f);
        legs2.offset = new Vector2(-.02f, -.68f);
        legs2.size = new Vector2(.9f, .45f);
    }

    public void BCActive()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;
        legs2.enabled = true;

        head.offset = new Vector2(-.33f, .495f);
        head.size = new Vector2(.33f, .44f);
        body.offset = new Vector2(-0.3f, .1f);
        body.size = new Vector2(.38f, .4f);
        legs1.offset = new Vector2(-.1f, -.27f);
        legs1.size = new Vector2(.58f, .375f);
        legs2.offset = new Vector2(-.02f, -.68f);
        legs2.size = new Vector2(.9f, .45f);
    }

    public void JSActive()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;
        legs2.enabled = true;

        head.offset = new Vector2(.12f, .675f);
        head.size = new Vector2(.33f, .83f);
        body.offset = new Vector2(0.17f, .22f);
        body.size = new Vector2(.45f, .87f);
        legs1.offset = new Vector2(.1f, -.3f);
        legs1.size = new Vector2(.72f, .28f);
        legs2.offset = new Vector2(-.07f, -.66f);
        legs2.size = new Vector2(1f, .45f);
    }

    public void JSRecovery()
    {
        ClearHurtBox();
        head.enabled = true;
        body.enabled = true;
        legs1.enabled = true;
        legs2.enabled = true;

        head.offset = new Vector2(-.025f, .21f);
        head.size = new Vector2(.85f, .32f);
        body.offset = new Vector2(-0.03f, -.07f);
        body.size = new Vector2(.64f, .275f);
        legs1.offset = new Vector2(.047f, -.3f);
        legs1.size = new Vector2(.61f, .28f);
        legs2.offset = new Vector2(.135f, -.66f);
        legs2.size = new Vector2(1f, .48f);
    }
}
