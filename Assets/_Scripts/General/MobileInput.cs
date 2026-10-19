using General.Interface;
using UnityEngine;

namespace General
{
    public class MobileInput : MonoBehaviour
    {
        private float _recordInputTime;

        // Update is called once per frame
        void Update()
        {
            // if (Input.GetMouseButtonDown(0))
            // {
            //     _recordInputTime += Time.deltaTime;
            //     
            //     Debug.Log("Click");
            //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //     RaycastHit hit;
            //     if (Physics.Raycast(ray, out hit, 10))
            //     {
            //         IClickable clickable = hit.transform.GetComponent<IClickable>();
            //         if (clickable != null)
            //         {
            //             clickable.OnClick();
            //         }
            //     }
            // }

            // if (Input.GetMouseButton(0))
            // {
            //     _recordInputTime += Time.deltaTime;
            //     if (_recordInputTime >= 3)
            //     {
            //         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //         RaycastHit hit;
            //         Debug.Log("OnClickWithLongTap");
            //         if (Physics.Raycast(ray, out hit, 10))
            //         {
            //             IClickable clickable = hit.transform.GetComponent<IClickable>();
            //             if (clickable != null)
            //             {
            //                 clickable.OnClickWithLongTap();
            //             }
            //         }
            //     }
            // }
            // else
            // {
            //     _recordInputTime = 0;
            // }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit[] hits;
                    hits = Physics.RaycastAll(ray, 50);
                    if (hits.Length>0)
                    {
                        IClickable clickable;
                        foreach (var hit in hits)
                        {
                            if (!hit.transform.TryGetComponent<IClickable>(out clickable))
                                continue;
                            else
                            {
                                clickable.OnClick();
                                break; 
                            }                              
                            

                        }                         
                       
                       
                    }

                    Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 1);
                }
            }
        }
    }
}
