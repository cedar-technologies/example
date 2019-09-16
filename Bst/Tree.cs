using System;

namespace example.Bst
{
    public class Tree
    {

        private Node _root;

        public Node Root
        {
            get { return _root; }
        }

        public void Insert(int key)
        {
            _root = Insert(_root, key);
        }

        private Node Insert(Node root, int key)
        {

            if(root == null)
                return new Node(key);

            if (key < root.Value)
                root.Left = Insert(root.Left, key);

            if (key > root.Value)
                root.Right = Insert(root.Right, key);

            return root;
        }

        

        public bool remove(int key)
        {
            if (_root == null)
            {
                return false;
            }
            else
            {
                if (_root.Value == key)
                {
                    Node auxNode = new Node(0);
                    auxNode.Left = _root;
                    bool result = _root.Delete(key, auxNode);
                    _root = auxNode.Left;
                    return result;
                }
                else
                {
                    return _root.Delete(key, null);
                }
            }
        }

        
    }
}