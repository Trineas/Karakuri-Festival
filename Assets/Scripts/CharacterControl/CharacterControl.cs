using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public Animator SkinnedMeshAnimator;
    public bool MoveRight;
    public bool MoveLeft;
    public bool Jump;
    public bool DoubleJump;
    public bool Attack;
    public GameObject ColliderEdgePrefab;
    public List<GameObject> BottomSpheres = new List<GameObject>();
    public List<GameObject> FrontSpheres = new List<GameObject>();
    public List<Collider> RagdollParts = new List<Collider>();
    //public List<Collider> CollidingParts = new List<Collider>();

    public float GravityMultiplier;
    public float PullMultiplier;

    private List<TriggerDetector> TriggerDetectors = new List<TriggerDetector>();

    private Rigidbody rigid;
    public Rigidbody RIGID_BODY
    {
        get
        {
            if (rigid == null)
            {
                rigid = GetComponent<Rigidbody>();
            }
            return rigid;
        }
    }
    
    private void Awake()
    {
        bool SwitchBack = false;

        if (!IsFacingForward())
        {
            SwitchBack = true;
        }

        FaceForward(true);

        //SetRagdollParts();
        SetColliderSpheres();

        if (SwitchBack)
        {
            FaceForward(false);
        }
    }

    public List<TriggerDetector> GetAllTriggers()
    {
        if (TriggerDetectors.Count == 0)
        {
            TriggerDetector[] arr = this.gameObject.GetComponentsInChildren<TriggerDetector>();

            foreach(TriggerDetector d in arr)
            {
                TriggerDetectors.Add(d);
            }
        }

        return TriggerDetectors;
    }

    public void SetRagdollParts()
    {
        RagdollParts.Clear();

        Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();

        foreach(Collider c in colliders)
        {
            if (c.gameObject != this.gameObject)
            {     
                c.isTrigger = true;
                RagdollParts.Add(c);

                if (c.GetComponent<TriggerDetector>() == null)
                {
                    c.gameObject.AddComponent<TriggerDetector>();
                }
            }
        }
    }

    // when used turns ragdolls on and everything else off
    public void TurnOnRagdoll()
    {
        RIGID_BODY.useGravity = false;
        RIGID_BODY.velocity = Vector3.zero;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        SkinnedMeshAnimator.enabled = false;
        SkinnedMeshAnimator.avatar = null;

        foreach(Collider c in RagdollParts)
        {
            c.isTrigger = false;
            c.attachedRigidbody.velocity = Vector3.zero;
        }
    }

    // ground detection and collision
    private void SetColliderSpheres()
    {
        BoxCollider box = GetComponent<BoxCollider>();

        float bottom = box.bounds.center.y - box.bounds.extents.y;
        float top = box.bounds.center.y + box.bounds.extents.y;
        float front = box.bounds.center.z + box.bounds.extents.z;
        float back = box.bounds.center.z - box.bounds.extents.z;

        GameObject bottomFront = CreateEdgeSphere(new Vector3(front, bottom, 0f));
        GameObject bottomBack = CreateEdgeSphere(new Vector3(back, bottom, 0f));
        GameObject topFront = CreateEdgeSphere(new Vector3(front, top, 0f));

        bottomFront.transform.parent = this.transform;
        bottomBack.transform.parent = this.transform;
        topFront.transform.parent = this.transform;

        BottomSpheres.Add(bottomFront);
        BottomSpheres.Add(bottomBack);

        FrontSpheres.Add(bottomFront);
        FrontSpheres.Add(topFront);

        float horSec = (bottomFront.transform.position - bottomBack.transform.position).magnitude / 5f;
        CreateMiddleSpheres(bottomFront, -this.transform.right, horSec, 4, BottomSpheres);

        float verSec = (bottomFront.transform.position - topFront.transform.position).magnitude / 10f;
        CreateMiddleSpheres(bottomFront, this.transform.up, verSec, 9, FrontSpheres);
    }

    private void FixedUpdate()
    {
        if (RIGID_BODY.velocity.y < 0f)
        {
            RIGID_BODY.velocity += (-Vector3.up * GravityMultiplier);
        }

        if (RIGID_BODY.velocity.y > 0f && !Jump)
        {
            RIGID_BODY.velocity += (-Vector3.up * PullMultiplier);
        }
    }

    public void CreateMiddleSpheres(GameObject start, Vector3 dir, float sec, int interations, List<GameObject> spheresList)
    {
        for (int i = 0; i < interations; i++)
        {
            Vector3 pos = start.transform.position + (dir * sec * (i + 1));

            GameObject newObj = CreateEdgeSphere(pos);
            newObj.transform.parent = this.transform;
            spheresList.Add(newObj);
        }
    }

    public GameObject CreateEdgeSphere(Vector3 pos)
    {
        GameObject obj = Instantiate(ColliderEdgePrefab, pos, Quaternion.identity);
        return obj;
    }

    // move forward
    public void MoveForward(float Speed, float SpeedGraph)
    {
        transform.Translate(Vector3.right * Speed * SpeedGraph * Time.deltaTime);
    }

    public void FaceForward(bool forward)
    {
        if (forward)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        else
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    public bool IsFacingForward()
    {
        if (transform.forward.z > 0f)
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
 
