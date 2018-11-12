# Unity-TimelineUnityEvent
Using UnityEvent to execute arbitrary code from Unity timelines.

Inspiration reference: https://github.com/georgejecook/UnityTimelineEvents
I replace the former methods with UnityEvent.
Bind UnityEvent and TimelineClip on custom script to store UnityEvent. 
Just like PlayeableDirector binding object.
So it can even work on same scene, same timeline but different director.

# Usage
Create TimelineUnityEventTrack in Timeline

![create track](screenshot3.png)

Add TimelineUnityEventClip. Then it will create a binding script on your director object.

![create track](screenshot4.png)

Select clip and set UnityEvent.

![create track](screenshot1.png)

The binding script is bind on director object.

![create track](screenshot2.png)