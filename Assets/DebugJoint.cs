using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class DebugJoint : MonoBehaviour
{
    public FixedJoint joint;
}

[CustomEditor(typeof(DebugJoint))]
public class DebugJointEditor : Editor
{
    DebugJoint script;
    public void OnEnable()
    {
        script = (DebugJoint)target;
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        DrawDefaultInspector();
        Vector3 anchor = script.joint.anchor;
        EditorGUILayout.HelpBox("Connected Anchor: " + anchor, MessageType.Warning);
        Vector3 connectedAnchor = script.joint.connectedAnchor;
        EditorGUILayout.HelpBox("Connected Anchor: " +connectedAnchor, MessageType.Warning);
    }
}
