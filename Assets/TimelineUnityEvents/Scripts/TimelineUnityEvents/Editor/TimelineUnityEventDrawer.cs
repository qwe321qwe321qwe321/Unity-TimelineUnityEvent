using UnityEditor;
using UnityEngine;

namespace TimelineUnityEvents {
    [CustomPropertyDrawer(typeof(TimelineUnityEventBehaviour))]
    public class TimelineUnityEventDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
			EditorGUILayout.HelpBox(new GUIContent("If you want to invoke events in edit mode, just set the property of UnityEvent to \"Editor and Runtime\"."));

			var clip = property.serializedObject.targetObject as TimelineUnityEventClip;
			if(clip.TrackTargetBindings != null) {
				var eventBindings = new SerializedObject(clip.TrackTargetBindings);
				eventBindings.Update();
				int eventIndex = clip.TrackTargetBindings.IndexOfEvents(clip);
				if(eventIndex != -1) {
					SerializedProperty unityEvent = eventBindings.FindProperty("eventValueTable").GetArrayElementAtIndex(eventIndex);
					EditorGUILayout.PropertyField(unityEvent, new GUIContent("Unity Event")); 
				}
				eventBindings.ApplyModifiedProperties();
			}
		}
    }
}
