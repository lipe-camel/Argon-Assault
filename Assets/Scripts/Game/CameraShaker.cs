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

    //CACHED STRING REFERENCES
    const string PLAYER_LAYER = "Player";


    private void Start()
    {
        cameraNoise = FindObjectOfType<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        currentCameraShake = defaultCameraShake;
        cameraNoise.m_AmplitudeGain = defaultCameraShake;
    }

    private void OnTriggerEnter(Collider other)
    {
        float intenseCameraShake = other.GetComponentInParent<Obstacle>().obstacleModel.transform.localScale.x * shakerMultiplier;
        if (intenseCameraShake <= defaultCameraShake) { intenseCameraShake = defaultCameraShake; }

        SetCameraShake(other, intenseCameraShake);
    }

    private void OnTriggerExit(Collider other)
    {
        SetCameraShake(other, defaultCameraShake);
    }

    private void SetCameraShake(Collider other, float cameraShake)
    {
        if (other.gameObject.layer == LayerMask.GetMask(PLAYER_LAYER)) { return; }

        Debug.Log(other.gameObject.transform.parent.parent.name);
        currentCameraShake = cameraShake;
        cameraNoise.m_AmplitudeGain = currentCameraShake;
    }
}
