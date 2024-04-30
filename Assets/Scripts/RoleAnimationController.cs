using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class RoleAnimationController : MonoBehaviour
{
    SkeletonAnimation _roleSkeleton;
    bool isInteracting = false;
    void Start()
    {
        _roleSkeleton = GetComponent<SkeletonAnimation>();
        _roleSkeleton.skeleton.SetToSetupPose();
        _roleSkeleton.AnimationState.SetAnimation(0, "19reset", false);
        StartCoroutine(IDLEAnimation());
    }
    public void PickedUp()
    {
        isInteracting = true;
        _roleSkeleton.skeleton.SetToSetupPose();
        _roleSkeleton.AnimationState.SetAnimation(0, "2huxi", true);
    }
    public void Dropped()
    {
        isInteracting = false;
        _roleSkeleton.skeleton.SetToSetupPose();
        _roleSkeleton.AnimationState.SetAnimation(0, "19reset", false);
    }
    public void SetOnSofa()
    {
        isInteracting = true;
        _roleSkeleton.skeleton.SetToSetupPose();
        _roleSkeleton.AnimationState.SetAnimation(0, "14sit", false);
    }
    IEnumerator IDLEAnimation()
    {
        while (true)
        {
            yield return new WaitUntil(() => !isInteracting);
            _roleSkeleton.AnimationState.SetAnimation(0, "1dazhaohu", false);
            yield return new WaitForSeconds(10f);
        }

    }

}
