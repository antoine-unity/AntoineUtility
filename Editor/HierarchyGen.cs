using UnityEditor;
using UnityEngine;

namespace AntoineUtility
{
    internal sealed class HierarchyGen : ScriptableWizard
    {
        [SerializeField] GameObject m_ToClone;
        [SerializeField] int m_Depth = 3;
        [SerializeField] int m_RootCount = 5;
        [SerializeField] int m_ChildrenCount = 3;
        [SerializeField] float m_SpawnSphereRadius = 10;

        [MenuItem("Utilities/Antoine Utility/Open Hierarchy Generator")]
        static void CreateWizard()
        {
            DisplayWizard<HierarchyGen>("Hierarchy Generator", "Generate");
        }

        void OnWizardUpdate()
        {
            int count = 0;
            for (int i = 0; i <= m_Depth; ++i)
            {
                count += (int)Mathf.Pow(m_ChildrenCount, i);
            }

            count *= m_RootCount;

            helpString = $"Will Create {count} Objects";
            errorString = m_ToClone == null ? "To Clone Cannot be Null" : string.Empty;
        }

        void OnWizardCreate()
        {
            if (m_ToClone == null)
                return;

            for (int i = 0; i < m_RootCount; ++i)
            {
                Create_Recursive(m_ToClone, null, m_ChildrenCount, m_Depth);
            }
        }

        void Create_Recursive(GameObject prefab, Transform parent, int childCount, int depthRemaining)
        {
            if (depthRemaining <= 0)
                return;

            Vector3 pos = Random.insideUnitSphere * m_SpawnSphereRadius;
            var obj = Instantiate(prefab, parent);
            var transform = obj.transform;
            transform.position = pos;

            for (int i = 0; i < childCount; ++i)
            {
                Create_Recursive(prefab, transform, childCount, depthRemaining - 1);
            }
        }
    }
}