using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;


namespace System.Windows.Forms
{
    /// <summary>
    /// Represents the method that will handle the NodeMouseClick event of a TreeView
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A TreeNodeMouseClickEventArgs that contains the event data.</param>
    public delegate void TreeNodeMouseClickEventHandler(object sender, TreeNodeMouseClickEventArgs e);

    /// <summary>
    /// Provides data for the System.Windows.Forms.TreeView.NodeMouseClick event
    /// </summary>
    public class TreeNodeMouseClickEventArgs : MouseEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the TreeNodeMouseClickEventArgs class.
        /// </summary>
        /// <param name="node">The node that was clicked</param>
        /// <param name="button">One of the System.Windows.Forms.MouseButtons members</param>
        /// <param name="clicks">The number of clicks that occurred</param>
        /// <param name="x">The x-coordinate where the click occurred</param>
        /// <param name="y">The y-coordinate where the click occurred</param>
        public TreeNodeMouseClickEventArgs(TreeNode node, MouseButtons button, int clicks, int x, int y) :
            base(button, clicks, x, y, 0)
        {
            nodeValue = node;
        }

        /// <summary>
        /// Gets the node that was clicked.
        /// </summary>
        public TreeNode Node
        {
            get { return nodeValue; }
            set { nodeValue = value; }
        }
        TreeNode nodeValue;

        public override string ToString()
        {
            return string.Format(
                "TreeNodeMouseClickEventArgs\r\n\tNode: {0}\r\n\tButton: {1}\r\n\tX: {2}\r\n\tY: {3}",
                nodeValue.Text, Button.ToString(), X, Y);
        }
    }
}

