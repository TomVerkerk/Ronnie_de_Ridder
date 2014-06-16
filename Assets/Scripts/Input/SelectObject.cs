using UnityEngine;
using System.Collections;

public class SelectObject : MonoBehaviour
{

    public float minSwipePerc;
    private RaycastHit selected;
    private bool start = true;
    private bool touched = false;
    private bool unselect = false;
    private bool retap = false;
    private bool select = false;
    public float objectMoveSpeed;
    private Vector2 swipeBegin;
    private Vector2 swipeEnd;

    public Vector3 target;
    public bool arrived = true;
    public GameObject ARcamera;
    private Camera cam;


    void Start()
    {

        cam = ARcamera.gameObject.GetComponent<Camera>();
    }

    void Update()
    {
        if (arrived == false && start == false)
        {
            selected.transform.LookAt(target);
            selected.transform.Translate(Vector3.forward * objectMoveSpeed * Time.deltaTime);
            if (Vector3.Distance(selected.transform.position, target) < 2)
            {
                arrived = true;
            }
        }
        if (Input.touchCount == 1)
        {
            if (select == true && start == false)
            {
                Move();
            }
            else
            {
                RaycastObject();
            }
        }
        else
        {
            touched = false;
        }

    }

    void Move()
    {
        foreach (var T in Input.touches)
        {
            if (T.phase == TouchPhase.Began)
            {
                swipeBegin.x = ((100f / Screen.width) * T.position.x);
                swipeBegin.y = ((100f / Screen.height) * T.position.y);
            }
            else if (T.phase == TouchPhase.Ended)
            {
                swipeEnd.x = ((100f / Screen.width) * T.position.x);
                swipeEnd.y = ((100f / Screen.height) * T.position.y);
                if (swipeEnd.x - swipeBegin.x >= minSwipePerc || swipeEnd.x - swipeBegin.x <= -minSwipePerc || swipeEnd.y - swipeBegin.y >= minSwipePerc || swipeEnd.y - swipeBegin.y <= -minSwipePerc)
                {
                    Vector3 screenPoint = new Vector3(T.position.x, T.position.y, 0);
                    Ray swipeRay = cam.ScreenPointToRay(screenPoint);
                    float swipeDis = Vector3.Distance(cam.transform.position, selected.transform.position);
                    target = swipeRay.GetPoint(swipeDis);
                    if (selected.transform.gameObject.GetComponent<MoveInfo>().constrainAxis.x == 0)
                    {
                        target.x = selected.transform.position.x;
                    }
                    if (selected.transform.gameObject.GetComponent<MoveInfo>().constrainAxis.y == 0)
                    {
                        target.y = selected.transform.position.y;
                    }
                    if (selected.transform.gameObject.GetComponent<MoveInfo>().constrainAxis.z == 0)
                    {
                        target.z = selected.transform.position.z;
                    }
                    arrived = false;
                }
                else
                {
                    RaycastObject();
                }
            }
        }
    }

    void RaycastObject()
    {
        if (touched == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == TagConst.MOVEABLE)
                {
                    if (start == true)
                    {
                        hit.transform.gameObject.renderer.material.color = Color.yellow;
                        select = true;
                    }
                    else if (hit.transform.gameObject.name != selected.transform.gameObject.name)
                    {
                        hit.transform.gameObject.renderer.material.color = Color.yellow;
                        if (unselect == false && start == false)
                        {
                            selected.transform.gameObject.renderer.material.color = Color.white;
                        }
                        retap = false;
                        select = true;
                    }
                    else if (unselect == false && retap == false)
                    {
                        hit.transform.gameObject.renderer.material.color = Color.white;
                        select = false;
                        retap = true;
                    }
                    else
                    {
                        hit.transform.gameObject.renderer.material.color = Color.yellow;
                        retap = false;
                        select = true;
                    }
                    unselect = false;
                    selected = hit;
                    start = false;
                }
                else
                {
                    selected.transform.gameObject.renderer.material.color = Color.white;
                    unselect = true;
                    retap = false;
                    select = false;
                }
            }
            else
            {
                selected.transform.gameObject.renderer.material.color = Color.white;
                unselect = true;
                retap = false;
                select = false;
            }
            arrived = true;
            touched = true;
        }
    }
}