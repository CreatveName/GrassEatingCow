using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
public enum NodeState
    {
        RUNNING,
        SUCCESS,
        FAILURE
    }

    public class Node
    {
        protected NodeState state;
    } public Node parent;
    protected <List> children = new List <Node>();

        private Dictionary<string, object> _dataContext = new Dictionary<string, object>();
    public Node()
    {
        parent = null;
    }
    public Node(List<Node> children)
    {
        foreach (Node child in children)
            _Attach(child);
    }
}