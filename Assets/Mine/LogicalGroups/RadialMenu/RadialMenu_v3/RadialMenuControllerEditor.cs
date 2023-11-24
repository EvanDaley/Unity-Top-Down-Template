using UnityEngine;
using UnityEditor;
using Rito.RadialMenu_v3.Test; // Import your namespace

[CustomEditor(typeof(RadialMenuController))]
public class RadialMenuControllerEditor : Editor
{
    SerializedProperty topLevelMenuSprites;
    SerializedProperty constructionMenuSprites;
    SerializedProperty weaponMenuSprites;

    private void OnEnable()
    {
        // Link the SerializedProperties to the actual arrays in RadialMenuController
        topLevelMenuSprites = serializedObject.FindProperty("topLevelMenuSprites");
        constructionMenuSprites = serializedObject.FindProperty("constructionMenuSprites");
        weaponMenuSprites = serializedObject.FindProperty("weaponMenuSprites");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // Show the existing Inspector properties
        // DrawDefaultInspector();
        DrawPropertiesExcluding(
            serializedObject, 
            "topLevelMenuSprites", 
            "constructionMenuSprites", 
            "weaponMenuSprites"
        );

        EditorGUILayout.LabelField("PREVIEW", EditorStyles.boldLabel);

        DisplaySpriteList(topLevelMenuSprites, "Top Level Menu Sprites");

        DisplaySpriteList(constructionMenuSprites, "Construction Menu Sprites");

        DisplaySpriteList(weaponMenuSprites, "Weapon Menu Sprites");

        serializedObject.ApplyModifiedProperties();
    }

    private void DisplaySpriteList(SerializedProperty spriteList, string label)
    {
        EditorGUILayout.LabelField(label, EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(spriteList);

        for (int i = 0; i < spriteList.arraySize; i++)
        {
            SerializedProperty spriteProperty = spriteList.GetArrayElementAtIndex(i);
            Sprite sprite = (Sprite)spriteProperty.objectReferenceValue;

            if (sprite != null)
            {
                // Get the thumbnail for the sprite
                Texture2D thumbnail = AssetPreview.GetAssetPreview(sprite);
                if (thumbnail != null)
                {
                    // Display the thumbnail with the sprite object field
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.ObjectField(sprite, typeof(Sprite), false);
                    GUILayout.Label(new GUIContent(thumbnail), GUILayout.Height(50), GUILayout.Width(50));
                    EditorGUILayout.EndHorizontal();
                }
            }
        }
    }
}
