namespace WebServer.ViewEngine.Parser.Nodes
{
    using System.Collections.Generic;

    /// <summary>
    /// A node that contains a sequence of other nodes
    /// </summary>
    public class BlockNode : SyntaxTreeNode
    {
        private readonly List<SyntaxTreeNode> _nodes = new List<SyntaxTreeNode>();

        /// <summary>
        /// Get all the nodes currently in the block
        /// </summary>
        public IEnumerable<SyntaxTreeNode> Nodes
        {
            get { return _nodes; }
        }

        /// <summary>
        /// Adds a new node to the block
        /// </summary>
        /// <param name="node"></param>
        public void Add(SyntaxTreeNode node)
        {
            _nodes.Add(node);
        }

        /// <summary>
        /// Adds a set of nodes to the block
        /// </summary>
        public void AddRange(IEnumerable<SyntaxTreeNode> nodes)
        {
            _nodes.AddRange(nodes);
        }

        /// <summary>
        /// Determines if there are any nodes in the block already
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _nodes.Count == 0;
        }

        /// <summary>
        /// Returns the last node in the block
        /// </summary>
        /// <returns></returns>
        public SyntaxTreeNode LastNode()
        {
            return _nodes[_nodes.Count - 1];
        }
    }
}