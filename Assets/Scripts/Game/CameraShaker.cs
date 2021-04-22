using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraShaker : MonoBehaviour
{
    //CONFIG PARAMS
    [SerializeField] float defaultCameraShake = 0.5f;
    [SerializeField] float ObstacleShakerMultiplier = 0.2f;
    [SerializeField] float damageShaker = 10f;
    [SerializeField] float damageShakeTime = 0.5f;

    //STATES
    float currentCameraShake;
    bool isDamageShaking = false;

    //CACHED EXTERNAL REFERENCES
    CinemachineBasicMultiChannelPerlin cameraNoise;

    private void Start()
    {
        cameraNoise = FindObjectOfType<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        currentCameraShake = defaultCameraShake;
        cameraNoise.m_AmplitudeGain = defaultCameraShake;
    }

    //OBSTACLE SHAKER
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Obstacle>() && !isDamageShaking)
        {
            //this gets a value that is multiplied by the obstacles size
            float intenseCameraShake = other.GetComponentInParent<Obstacle>().obstacleModel.transform.localScale.x * ObstacleShakerMultiplier;
            if (intenseCameraShake <= defaultCameraShake) { intenseCameraShake = defaultCameraShake; }

            SetCameraShake(intenseCameraShake);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<Obstacle>() && !isDamageShaking)
        {
            SetCameraShake(defaultCameraShake);
        }
    }

    private void SetCameraShake(float cameraShake)
    {
        currentCameraShake = cameraShake;
        cameraNoise.m_AmplitudeGain = currentCameraShake;
    }

    //DAMAGE SHAKER
    public IEnumerator DamageShake()
    {
        isDamageShaking = true;
        float previousShake = currentCameraShake;
        SetCameraShake(damageShaker);
        yield return new WaitForSeconds(damageShakeTime);
        isDamageShaking = false;
        SetCameraShake(previousShake);
    }
}