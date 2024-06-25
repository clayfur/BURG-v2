using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.XR.Hands;

public class HandEventBridge : MonoBehaviour
{
    public XRHandTrackingEvents handTrackingEvents;  // Assign in Inspector
    public GameObject visualScriptTarget;  // Assign in Inspector

    private void OnEnable()
    {
        if (handTrackingEvents != null)
        {
            handTrackingEvents.poseUpdated.AddListener(OnPoseUpdated);
            handTrackingEvents.jointsUpdated.AddListener(OnJointsUpdated);
            handTrackingEvents.trackingAcquired.AddListener(OnTrackingAcquired);
            handTrackingEvents.trackingLost.AddListener(OnTrackingLost);
            handTrackingEvents.trackingChanged.AddListener(OnTrackingChanged);
        }
    }

    private void OnDisable()
    {
        if (handTrackingEvents != null)
        {
            handTrackingEvents.poseUpdated.RemoveListener(OnPoseUpdated);
            handTrackingEvents.jointsUpdated.RemoveListener(OnJointsUpdated);
            handTrackingEvents.trackingAcquired.RemoveListener(OnTrackingAcquired);
            handTrackingEvents.trackingLost.RemoveListener(OnTrackingLost);
            handTrackingEvents.trackingChanged.RemoveListener(OnTrackingChanged);
        }
    }

    private void OnPoseUpdated(Pose pose)
    {
        CustomEvent.Trigger(visualScriptTarget, "OnPoseDetected", pose);
    }

    private void OnJointsUpdated(XRHandJointsUpdatedEventArgs args)
    {
        CustomEvent.Trigger(visualScriptTarget, "OnJointsUpdated", args);
    }

    private void OnTrackingAcquired()
    {
        CustomEvent.Trigger(visualScriptTarget, "OnTrackingAcquired");
    }

    private void OnTrackingLost()
    {
        CustomEvent.Trigger(visualScriptTarget, "OnTrackingLost");
    }

    private void OnTrackingChanged(bool isTracked)
    {
        CustomEvent.Trigger(visualScriptTarget, "OnTrackingChanged", isTracked);
    }
}
