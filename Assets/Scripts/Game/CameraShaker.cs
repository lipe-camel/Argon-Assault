using UnityEngine;
using Cinemachine;

public class CameraShaker : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] float defaultCameraShake = 0.5f;
    [SerializeField] float shakerMultiplier = 1f;

    //STATES
    float currentCameraShake;

    //CACHED EXTERNAL REFERENCES
    CinemachineBasicMultiChannelPerlin cameraNoise;

    private void Start()
    {
        cameraNoise = FindObjectOfType<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        currentCameraShake = defaultCameraShake;
        cameraNoise.m_AmplitudeGain = defaultCameraShake;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Obstacle>())
        {
            //this gets a value that is multiplied by the obstacles size
            float intenseCameraShake = other.GetComponentInParent<Obstacle>().obstacleModel.transform.localScale.x * shakerMultiplier;
            if (intenseCameraShake <= defaultCameraShake) { intenseCameraShake = defaultCameraShake; }

            SetCameraShake(other, intenseCameraShake);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<Obstacle>())
        {
            SetCameraShake(other, defaultCameraShake);
        }
    }

    private void SetCameraShake(Collider other, float cameraShake)
    {
        //Debug.Log(other.gameObject.transform.parent.parent.name);
        currentCameraShake = cameraShake;
        cameraNoise.m_AmplitudeGain = currentCameraShake;
    }
}