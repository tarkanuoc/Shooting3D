using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollSwitcher : MonoBehaviour
{
    public Animator anim;
    public Rigidbody[] rigids;
    [ContextMenu("Retrieve Rigibodies")]
    private void RetrieveRigibodies()
    {
        rigids = GetComponentsInChildren<Rigidbody>();
    }

    [ContextMenu("Clear Ragdoll")]
    private void ClearRagdoll()
    {
        CharacterJoint[] joints = GetComponentsInChildren<CharacterJoint>();
        for (int i = 0; i < joints.Length; i++)
        {
            DestroyImmediate(joints[i]);
        }

        Rigidbody[] rigiList = GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < rigiList.Length; i++)
        {
            DestroyImmediate(rigiList[i]);
        }

        Collider[] colls = GetComponentsInChildren<Collider>();
        for (int i = 0; i < colls.Length; i++)
        {
            DestroyImmediate(colls[i]);
        }
    }

    [ContextMenu("Enable Ragdoll")]
    public void EnableRagdoll()
    {
        SetRagdoll(true);
    }

    [ContextMenu("Disable Ragdoll")]
    public void DisableRagdoll()
    {
        SetRagdoll(false);
    }
    private void SetRagdoll(bool ragdollEnable)
    {
        anim.enabled = !ragdollEnable;
        for (int i = 0; i < rigids.Length; i++)
        {
            rigids[i].isKinematic = !ragdollEnable;
        }
    }
    [ContextMenu("Add HitSurface")]
    private void AddHitSurface()
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.GetComponent<HitSurface>() == null)
            {
                var hitSurface = colliders[i].gameObject.AddComponent<HitSurface>();
                hitSurface.surfaceType = HitSurfaceType.Blood;
            }
        }
    }
}
