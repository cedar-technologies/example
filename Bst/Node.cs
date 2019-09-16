using System;

namespace example.Bst
{
    public class Node
    {

        private int _value;
        private Node _left;
        private Node _right;

        public int Value
        {
            get => _value;
            set => _value = value;
        }

        public Node Left
        {
            get => _left;
            set => _left = value;
        }

        public Node Right
        {
            get => _right;
            set => _right = value;
        }

        public Node(int value)
        {
            _value = value;
        }


        public bool Delete(int value, Node parent)
        {

            if (value < this._value)
            {
                if(_left != null)
                    return this._left.Delete(value, this);

                return false;
            }

            if (value > this._value)
            {
                if (_right != null)
                    return this._right.Delete(value, this);

                return false;
            }


            if (_left != null && _right != null)
            {
                this._value = _right.minValue();
                _right.Delete(_value, this);
            }
            else if (parent.Left?.Value == value)
            {
                parent.Left = _left ?? _right;
            }
            else if (parent.Right?.Value == value)
            {
                parent.Right = _left ?? _right;
            }

            return true;
        }

        private int minValue()
        {
            if (_left == null)
                return this._value;
            return _left.minValue();
        }

    }

    public static class NodeExtensions
    {

        public static void Traverse(this Node root, Action<int> action)
        {
            if(root == null) return;
            
            action.Invoke(root.Value);

            root.Left?.Traverse(action);

            root.Right?.Traverse(action);
        }


    }
}