using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public Animator animator;
    public bool MoveRight;
    public bool MoveLeft;
    public bool Jump;
    public GameObject ColliderEdgePrefab;
    public List<GameObject> BottomSpheres = new List<GameObject>();

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

    // ground detection
    private void Awake()
    {
        BoxCollider box = GetComponent<BoxCollider>();

        float bottom = box.bounds.center.y - box.bounds.extents.y;
        float top = box.bounds.center.y + box.bounds.extents.y;
        float front = box.bounds.center.z + box.bounds.extents.z;
        float back = box.bounds.center.z - box.bounds.extents.z;

        GameObject bottomFront = CreateEdgeSphere(new Vector3(front, bottom, 0f));
        GameObject bottomBack = CreateEdgeSphere(new Vector3(back, bottom, 0f));

        bottomFront.transform.parent = this.transform;
        bottomBack.transform.parent = this.transform;

        BottomSpheres.Add(bottomFront);
        BottomSpheres.Add(bottomBack);

        float sec = (bottomFront.transform.position - bottomBack.transform.position).magnitude / 5f;
        for (int i = 0; i < 4; i++)
        {
            Vector3 pos = bottomBack.transform.position + (Vector3.right * sec * (i + 1));

            GameObject newObj = CreateEdgeSphere(pos);
            newObj.transform.parent = this.transform;
            BottomSpheres.Add(newObj);
        }
    }

    GameObject CreateEdgeSphere(Vector3 pos)
    {
        GameObject obj = Instantiate(ColliderEdgePrefab, pos, Quaternion.identity);
        return obj;
    }
}
 
