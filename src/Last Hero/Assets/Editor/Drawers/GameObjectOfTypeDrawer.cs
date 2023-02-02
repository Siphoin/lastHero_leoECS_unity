
using NFTGamePrototype.Editor.Attributes;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace NFTGamePrototype.Drawers
{
    [CustomPropertyDrawer(typeof(GameObjectOfTypeAttribute))]
    public class GameObjectOfTypeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
           if (!IsFieldGameObject())
            {
                DrawError(position);

                return;
            }

           GameObjectOfTypeAttribute attributeRefrence = attribute as GameObjectOfTypeAttribute;

            var requiredType = attributeRefrence.Type;

            CheckAndDrops(position, requiredType);

            CheckValues(property, requiredType);

            DrawObjectField(property, position, label, attributeRefrence.AllowSceneObjects);
        }

        private void CheckValues(SerializedProperty property, Type requiredType)
        {
            if (property.objectReferenceValue != null)
            {
                if (!IsValidObject(property.objectReferenceValue, requiredType))
                {
                    property.objectReferenceValue = null;
                }
            }
        }

        private void DrawObjectField(SerializedProperty property, Rect position, GUIContent label, bool allowSceneObjects)
        {
            property.objectReferenceValue = EditorGUI.ObjectField(position, label, property.objectReferenceValue, typeof(GameObject), allowSceneObjects);
        }

        private void CheckAndDrops(Rect position, Type requiredType)
        {
            if (position.Contains(Event.current.mousePosition))
            {
                int draggedObjectsCount = DragAndDrop.objectReferences.Length;

                for (int i = 0; i < draggedObjectsCount; i++)
                {
                    bool isValid = IsValidObject(DragAndDrop.objectReferences[i], requiredType);

                    if (!isValid)
                    {
                        DragAndDrop.visualMode = DragAndDropVisualMode.Rejected;

                        return;
                    }
                }
            }
        }

        private bool IsValidObject(UnityEngine.Object objectUnity, Type requiredType)
        {
            bool result = false;

            var gameObject = objectUnity as GameObject;

            if (gameObject != null)
            {
                result = gameObject.GetComponent(requiredType) != null;
            }

            return result;
        }

        private void DrawError(Rect position)
        {
            EditorGUI.HelpBox(position, $"GameObject of type attribute works only GameObject field!", MessageType.Error);
        }

        public bool IsFieldGameObject ()
        {
            return fieldInfo.FieldType == typeof(GameObject) || typeof(IEnumerable<GameObject>).IsAssignableFrom(fieldInfo.FieldType);
        }
    }
}
