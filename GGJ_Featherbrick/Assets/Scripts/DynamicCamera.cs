using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCamera : MonoBehaviour
{

    // DO public list of player transforms


    // -- Screen Shake Vars -- //
    public Vector3 translationShakeMax;
    public Vector3 rotationShakeMax;
    public float shakeIntensity = 1;
    public float shakeDecay = 1.0f; // Decay per second (1 means shakeValue goes from 1 to 0 in one second)

    float shakeValue;
    Vector3 shakePositionOffset;
    Vector3 shakeRotationOffset;

    // -- Smooth Camera Follow Vars -- //   
    public Vector2 cameraOffset;
    public float cameraMinY;
    public float cameraXResponsiveness = 1; // Closer to 0 = more lazyness, example value 1 = more responsiveness;
    public float cameraYResponsiveness = 1; // Closer to 0 = more lazyness, example value 1 = more responsiveness;


    // -- Camera Zoom In/Out Vars -- // 
    public float maxZoomFOV = 40;
    public float minZoomFOV = 10;
    public float cameraZoomResponsivenss = 1;



    // -- GLOBAL -- //
    Vector3 newPosition;
    Quaternion newRotation;
    Vector3 initPosition;
    float initFOV;
    public List<Transform> ListOfFollowing = new List<Transform>();

    void Start()
    {
        initPosition = Camera.main.transform.position;
        initFOV = Camera.main.fieldOfView;
    }

    // Update is called last
    void LateUpdate()
    {

        newPosition = transform.position - shakePositionOffset;
        newRotation = Quaternion.Euler(transform.eulerAngles - shakeRotationOffset);

        
        UpdateSmoothCamera();
        UpdateCameraZoom();
        UpdateCameraShake();

        transform.SetPositionAndRotation(newPosition + shakePositionOffset, Quaternion.Euler(newRotation.eulerAngles + shakeRotationOffset));
    }

    void ApplyShake( float shake_ammount)
    {
        shakeValue = Mathf.Min(1, shakeValue + shake_ammount);
    }

    void AddToListOfFollowing(Transform transform)
    {
        ListOfFollowing.Add(transform);
    }

    void RemoveFromListOfFollowing(Transform transform)
    {
        ListOfFollowing.Remove(transform);
    }









    private float RangedPerlinNoise(float x, float y)
    {
        return Mathf.Clamp((Mathf.PerlinNoise(x, y) - 0.5f) * 2.0f,-1,1);
    }
    private bool IsOnScreen(Vector3 position)
    {
        //   Camera.current.cameraToWorldMatrix();
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(position);
        return (screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1);
    }
    private void UpdateCameraZoom()
    {
        // Get greatest distance between players
        float zoom;

        if (ListOfFollowing.Count != 0)
        {
            var bounds = new Bounds(ListOfFollowing[0].position, Vector3.zero);

            foreach (Transform transform in ListOfFollowing)
            {
                bounds.Encapsulate(transform.position);
            }


            float distance = Mathf.Max(bounds.size.y / 2.0f, bounds.size.x / Camera.main.aspect / 2.0f);

            float maxdistance = Mathf.Atan(Mathf.Deg2Rad * (maxZoomFOV/ 2.0f)) * Mathf.Abs(Camera.main.transform.position.z);

            zoom = Mathf.Lerp(minZoomFOV, maxZoomFOV, distance / maxdistance);
        }
        else
        {
            zoom = initFOV;
        }
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView,zoom, cameraZoomResponsivenss * Time.deltaTime);
    }
   
    private void UpdateSmoothCamera()
    {
        Vector3 cameraGoToPos = Vector3.zero;

        if (ListOfFollowing.Count != 0)
        {
            foreach (Transform transform in ListOfFollowing)
            {
                cameraGoToPos += transform.position;
            };

            cameraGoToPos /= (float)(ListOfFollowing.Count);
        }
        else
        {
            cameraGoToPos = initPosition;
        }

        // camera y;
        float cam_middle_to_y_edge = Mathf.Atan(Mathf.Deg2Rad * (Camera.main.fieldOfView / 2.0f))* Mathf.Abs(Camera.main.transform.position.z);
        float gotopos_to_y_limit = Mathf.Abs(cameraGoToPos.y - cameraMinY);

        float y_floor_offset = 0.0f;

        if (gotopos_to_y_limit < cam_middle_to_y_edge)
        {
            y_floor_offset = cam_middle_to_y_edge - gotopos_to_y_limit;
        }
        newPosition.x = Mathf.Lerp(newPosition.x, cameraGoToPos.x  + cameraOffset.x, cameraXResponsiveness * Time.deltaTime);
        newPosition.y = Mathf.Lerp(newPosition.y, cameraGoToPos.y + cameraOffset.y + y_floor_offset, cameraYResponsiveness * Time.deltaTime);
    }

    private void UpdateCameraShake()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ApplyShake(0.3f);
        }

        shakeValue = Mathf.Max(0, shakeValue - (shakeDecay * Time.deltaTime));
        float quadraticShakeValue = Mathf.Pow(shakeValue, 2);

        shakeRotationOffset = new Vector3(
           quadraticShakeValue * rotationShakeMax.x * RangedPerlinNoise(Time.time * shakeIntensity, 0),
           quadraticShakeValue * rotationShakeMax.y * RangedPerlinNoise(Time.time * shakeIntensity, 1),
           quadraticShakeValue * rotationShakeMax.z * RangedPerlinNoise(Time.time * shakeIntensity, 2)
        );


        shakePositionOffset = new Vector3(
            quadraticShakeValue * translationShakeMax.x * RangedPerlinNoise(Time.time * shakeIntensity, 3),
            quadraticShakeValue * translationShakeMax.y * RangedPerlinNoise(Time.time * shakeIntensity, 4),
            quadraticShakeValue * translationShakeMax.z * RangedPerlinNoise(Time.time * shakeIntensity, 5)
        );

    }
}
