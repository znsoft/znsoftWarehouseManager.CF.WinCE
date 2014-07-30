using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using СкладскойУчет.Оборудование;
using System.Windows.Forms;
using System.Drawing;

namespace СкладскойУчет.РаботаСФормами.РасширенияЭлементов
{
   /// <summary>
    /// Extends the standard TreeView control to add an implementation
    /// of the NodeMouseClick event.
    /// </summary>
    public partial class TreeViewEx : TreeView
    {
        /// <summary>
        /// The original parent of this control.
        /// </summary>
        Control prevParent = null;

        /// <summary>
        /// Creates a new instance of the derived TreeView control
        /// </summary>
        public TreeViewEx():base()
        {
        }

        /// <summary>
        /// Called when the control's parent is changed. Here we hook into that
        /// parent's WndProc and spy on the WM_NOTIFY message. When the parent
        /// changes, we unhook the old parent's WndProc and hook into the new one.
        /// </summary>
        /// <param name="e">The arguments for this event</param>
        protected override void OnParentChanged(EventArgs e)
        {
            // unhook the old parent
            if (this.prevParent != null)
            {
                WndProcHooker.UnhookWndProc(prevParent, WinApi.WM_NOTIFY);
            }
            // update the previous parent
            prevParent = this.Parent;

            // hook up the new parent
            if (this.Parent != null)
            {
                WndProcHooker.HookWndProc(this.Parent,
                    new WndProcHooker.WndProcCallback(this.WM_Notify_Handler),
                    WinApi.WM_NOTIFY);
            }

            base.OnParentChanged(e);
        }

        /// <summary>
        /// Occurs when the user clicks a TreeNode with the mouse.
        /// </summary>
        public event TreeNodeMouseClickEventHandler NodeMouseClick;

        /// <summary>
        /// Occurs when the mouse pointer is over the control and a mouse button is clicked. 
        /// </summary>
        /// <param name="e">Provides data for the NodeMouseClick event.</param>
        protected void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            if (NodeMouseClick != null)
                NodeMouseClick(this, e);
        }

        /// <summary>
        /// The method that gets called when a WM_NOTIFY message is received by the
        /// TreeView's parent.
        /// </summary>
        /// <param name="hwnd">The handle of the window that received the message</param>
        /// <param name="msg">The message received</param>
        /// <param name="wParam">The wParam arguments for the message</param>
        /// <param name="lParam">The lParam arguments for the message</param>
        /// <param name="handled">Set to true to indicate that this message was handled</param>
        /// <returns>An appropriate returen code for the message handled (see MSDN)</returns>
        int WM_Notify_Handler(
            IntPtr hwnd, uint msg, uint wParam, int lParam,
            ref bool handled)
        {
            WinApi.NMHDR nmHdr = new WinApi.NMHDR();
            System.Runtime.InteropServices.Marshal.PtrToStructure((IntPtr)lParam, nmHdr);
            switch (nmHdr.code)
            {
                case WinApi.NM_RCLICK:
                case WinApi.NM_CLICK:
                    // get the cursor coordinates on the client
                    Point msgPos = WinApi.LParamToPoint((int)WinApi.GetMessagePos());
                    msgPos = this.PointToClient(msgPos);

                    // check to see if the click was on an item
                    WinApi.TVHITTESTINFO hti = new WinApi.TVHITTESTINFO();
                    hti.pt.x = msgPos.X;
                    hti.pt.y = msgPos.Y;
                    int hitem = WinApi.SendMessage(this.Handle, WinApi.TVM_HITTEST, 0, ref hti);
                    uint htMask = (
                        WinApi.TVHT_ONITEMICON |
                        WinApi.TVHT_ONITEMLABEL |
                        WinApi.TVHT_ONITEMINDENT |
                        WinApi.TVHT_ONITEMBUTTON |
                        WinApi.TVHT_ONITEMRIGHT |
                        WinApi.TVHT_ONITEMSTATEICON);
                    if ((hti.flags & htMask) != 0)
                    {
                        bool leftButton = (nmHdr.code == WinApi.NM_CLICK);
                        RaiseNodeMouseClickEvent(hti.hItem,
                            leftButton ? MouseButtons.Left : MouseButtons.Right,
                            msgPos);
                        return 0;
                    }
                    break;

                default:
                    break;
            }
            return 0;
        }

        /// <summary>
        /// Raises the TreeNodeMouseClick event for the TreeNode with the specified handle.
        /// </summary>
        /// <param name="hNode">The handle of the node for which the event is raised</param>
        /// <param name="button">The [mouse] buttons that were pressed to raise the event</param>
        /// <param name="coords">The [client] cursor coordinates at the time of the event</param>
        void RaiseNodeMouseClickEvent(IntPtr hNode, MouseButtons button, Point coords)
        {
            TreeNode tn = FindTreeNodeFromHandle(this.Nodes, hNode);

            TreeNodeMouseClickEventArgs e = new TreeNodeMouseClickEventArgs(
                tn,
                button,
                1, coords.X, coords.Y);

            OnNodeMouseClick(e);
        }

        /// <summary>
        /// Finds a TreeNode in the provided TreeNodeCollection that has the handle specified.
        /// Warning: recursion!
        /// </summary>
        /// <param name="tnc">The TreeNodeCollection to search</param>
        /// <param name="handle">The handle of the TreeNode to find in the collection</param>
        /// <returns>The TreeNode if found; null otherwise</returns>
        TreeNode FindTreeNodeFromHandle(TreeNodeCollection tnc, IntPtr handle)
        {
            foreach (TreeNode tn in tnc)
            {
                if (tn.Handle == handle) return tn;
                // we couldn't have clicked on a child of this node if this node
                // is not expanded!
                if (tn.IsExpanded)
                {
                    TreeNode tn2 = FindTreeNodeFromHandle(tn.Nodes, handle);
                    if (tn2 != null) return tn2;
                }
            }
            return null;
        }
    }
}
