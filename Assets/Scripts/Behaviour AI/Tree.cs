using UnityEngine;

namespace BehaviorTree
{
    public abstract class Tree : MonoBehaviour
    {
        Node _root = null;

        protected void Start()
        {
            _root = SetUpTree();
        }

        void Update()
        {
            if (_root != null)
                _root.Evaluate();
        }

        protected abstract Node SetUpTree();
    }

}
