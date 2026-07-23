using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;


[CustomEditor(typeof(EntityStats))]
public class Stats_Inspector : Editor
{
    public VisualTreeAsset m_InspectorXML;

    // public override VisualElement CreateInspectorGUI()
    // {
    //     VisualElement myInspector = new VisualElement();
    //     myInspector.Add(new Label("Custom Stat Inspector!"));

    //     m_InspectorXML.CloneTree(myInspector);

    //     return myInspector;
    // }
    
    public override VisualElement CreateInspectorGUI()
    {
        var root = new VisualElement();
        root.Add(new Label("Custom Stat Inspector"));
        var prop = serializedObject.GetIterator();

        if (prop.NextVisible(true))
        {
            do
            {
                if (prop.name == "m_Script") continue;

                if (prop.propertyType == SerializedPropertyType.Generic && !prop.isArray)
                {
                    var baseValueProp = prop.FindPropertyRelative("BaseValue");
                    if (baseValueProp == null) continue;

                    root.Add(new PropertyField(baseValueProp,
                        $"{ObjectNames.NicifyVariableName(prop.name)} Base"));
                }
                else
                {
                    root.Add(new PropertyField(prop));
                }

            } while (prop.NextVisible(false));
        }

        return root;
    }
}
